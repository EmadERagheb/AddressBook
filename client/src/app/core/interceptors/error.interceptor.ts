import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
import {
  BehaviorSubject,
  Observable,
  catchError,
  filter,
  switchMap,
  take,
  throwError,
} from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../../account/account.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  private isRefreshing = false;
  private refreshTokenSubject: BehaviorSubject<any> = new BehaviorSubject<any>(
    null
  );

  constructor(
    private accountService: AccountService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        if (
          error &&
          error.status === 401 &&
          !request.url.includes('login') &&
          !this.isRefreshing
        ) {
          return this.handle401Error(request, next);
        } else if (error.status === 401) {
          this.toastr.error(error.error.message, error.status.toString());
        } else if (error.status === 400) {
          if (error.error.errors) {
            throw error.error;
          }
          this.toastr.error(error.error.message, error.status.toString());
        } else if (error.status === 404) {
          this.router.navigateByUrl('/not-found');
        } else if (error.status === 500) {
          let navigationExtras: NavigationExtras = {
            state: { error: error.error },
          };
          this.router.navigateByUrl('/server-error', navigationExtras);
        }
        return throwError(() => new Error(error.message));
      })
    );
  }

  private handle401Error(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (!this.isRefreshing) {
      this.isRefreshing = true;
      this.refreshTokenSubject.next(null);

      return this.accountService.isValidRefreshToken().pipe(
        switchMap((user) => {
          this.isRefreshing = false;
          const newToken = user?.token;
          console.log('New token obtained:', newToken);
          if (newToken) {
            localStorage.setItem('token', newToken); // Ensure the token is stored
          }
          this.refreshTokenSubject.next(newToken);

          return next.handle(this.addToken(request, newToken || '')); // Pass the new token explicitly
        }),
        catchError((error) => {
          this.isRefreshing = false;
          this.toastr.error(
            'Session expired. Please log in again.',
            'Unauthorized'
          );
          this.accountService.logout();
          return throwError(() => new Error(error.message));
        })
      );
    } else {
      return this.refreshTokenSubject.pipe(
        filter((token) => token != null),
        take(1),
        switchMap((token) => next.handle(this.addToken(request, token))) // Pass the new token explicitly
      );
    }
  }

  private addToken(request: HttpRequest<any>, token: string): HttpRequest<any> {
    console.log('Token used for cloning request:', token);

    if (token) {
      const headers = request.headers.set('Authorization', `Bearer ${token}`);
      return request.clone({ headers });
    }
    return request;
  }
}
