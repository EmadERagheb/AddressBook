import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable, catchError, filter, switchMap, take, throwError } from "rxjs";
import { AccountService } from "../../account/account.service";
import { NavigationExtras, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  private isRefreshing = false;
  private refreshTokenSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  constructor(
    private accountService: AccountService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error && error.status === 401 && !request.url.includes('login') && !this.isRefreshing) {
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

  private handle401Error(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (!this.isRefreshing) {
      this.isRefreshing = true;
      this.refreshTokenSubject.next(null);

      return this.accountService.isValidRefreshToken().pipe(
        switchMap((user) => {
          this.isRefreshing = false;
          this.refreshTokenSubject.next(user?.token);
          return next.handle(this.addToken(request));
        }),
        catchError((error) => {
          this.isRefreshing = false;
          this.toastr.error('Session expired. Please log in again.', 'Unauthorized');
          this.accountService.logout();
          return throwError(() => new Error(error.message));
        })
      );
    } else {
      return this.refreshTokenSubject.pipe(
        filter(token => token != null),
        take(1),
        switchMap(token => next.handle(this.addToken(request)))
      );
    }
  }

  private addToken(request: HttpRequest<any>): HttpRequest<any> {
    const token = localStorage.getItem('token');
    if (token) {
      return request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`,
        },
      });
    }
    return request;
  }
}

