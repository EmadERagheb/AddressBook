
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

    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
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

    if (!this.isRefreshing) {
      this.isRefreshing = true;
      this.refreshTokenSubject.next(null);

      return this.accountService.isValidRefreshToken().pipe(
        switchMap((user) => {
          this.isRefreshing = false;
        }),
        catchError((error) => {
          this.isRefreshing = false;
          this.accountService.logout();
          return throwError(() => new Error(error.message));
        })
      );
    } else {
      return this.refreshTokenSubject.pipe(
        take(1),
      );
    }
  }

    if (token) {
    }
    return request;
  }
}

