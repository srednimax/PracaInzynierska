import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";

@Injectable({
  providedIn: "root",
})
export class JwtInterceptor implements HttpInterceptor {
  private readonly token: string | null;

  constructor(private _router: Router) {
    this.token = localStorage.getItem("token");
  }

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (this.token) {
      const modReq = req.clone({
        setHeaders: {
          Authorization: `Bearer ${this.token}`,
        },
      });
      return next.handle(modReq).pipe(
        catchError((error: HttpErrorResponse) => {
          let errorMsg = "";
          if (error.error instanceof ErrorEvent) {
            errorMsg = `Error: ${error.error.message}`;
          } else {
            errorMsg = `Error Code: ${error.status},  Message: ${error.message}`;
          }
          if (error.status == 401 || error.status == 403) {
            this._router.navigate(["/signInUp"]);
          }
          if (error.status == 500) {
            errorMsg = error.error.detail;
          }

          return throwError(() => errorMsg);
        })
      );
    }
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        let errorMsg = "";
        console.log(error);
        if (error.error instanceof ErrorEvent) {
          errorMsg = `Error: ${error.error.message}`;
        } else {
          errorMsg = `Error Code: ${error.status},  Message: ${error.message}`;
        }
        if (error.status == 401 || error.status == 403) {
          this._router.navigate(["/signInUp"]);
        }
        if (error.status == 500) {
          errorMsg = error.error.detail;
        }
        return throwError(() => errorMsg);
      })
    );
  }
}
