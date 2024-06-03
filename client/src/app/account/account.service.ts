import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable, ReplaySubject, map, of } from 'rxjs';
import { User } from '../shared/models/user';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { Login } from '../shared/models/login';
import { TokenDTO } from '../shared/models/token-dto';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseURL: string = environment.apiUrl + '/api/Accounts';
  private userSource = new ReplaySubject<null | User>(1);
  public userSource$ = this.userSource.asObservable();
  constructor(private httpClient: HttpClient, private router: Router) {}
  getCurrentUser(token: string | null) {
    if (token == null) {
      this.userSource.next(null);
      return of(null);
    } else {
      let headers = new HttpHeaders();
      headers = headers.set('Content-Type', 'application/json; charset=utf-8');
      headers = headers.set('Authorization', `Bearer ${token}`);
      return this.httpClient
        .get<User>(this.baseURL + '/getCurrentUser', { headers })
        .pipe(
          map((user) => {
            if (user) {
              localStorage.setItem('token', user.token);
              localStorage.setItem('refresh-token', user.refreshToken);
              this.userSource.next(user);
              return user;
            } else {
              console.log('no user');
              this.userSource.next(null);
              return null;
            }
          })
        );
    }
  }
  login(login: Login) {
    return this.httpClient.post<User>(this.baseURL + '/login', login).pipe(
      map((user) => {
        this.userSource.next(user);
        localStorage.setItem('token', user.token);
        localStorage.setItem('refresh-token', user.refreshToken);
      })
    );
  }
  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('refresh-token');
    this.userSource.next(null);
    this.router.navigateByUrl('account/login');
  }

  isValidRefreshToken(): Observable<User | null> {
    const token = localStorage.getItem('token');
    const refreshToken = localStorage.getItem('refresh-token');
    const tokenDto: TokenDTO = {
      token: token ?? '',
      refreshToken: refreshToken ?? '',
    };

    return this.httpClient
      .post<User>(`${this.baseURL}/isValidRefreshToken`, tokenDto)
      .pipe(
        map((user) => {
          localStorage.setItem('token', user.token);
          localStorage.setItem('refresh-token', user.refreshToken);
          return user;
        })
        // catchError((error) => {
        //   localStorage.clear();
        //   return throwError(() => new Error(error.message));
        // })
      );
  }
}
