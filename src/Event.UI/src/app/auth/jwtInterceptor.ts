import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpInterceptorFn } from '@angular/common/http';
import { Observable } from 'rxjs';

export const Interceptor: HttpInterceptorFn = (req, next) =>{
    const token = localStorage.getItem('token');
    const removeQuote = token?.replace(/^"|"$/g, '');

    if (token) {
        req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${removeQuote}`
        }
      });
    }

    console.log('Request is on its way',removeQuote);
    console.log('reqeust', req);
    return next(req)
}
// @Injectable()
// export class JwtInterceptor implements HttpInterceptor {
//   intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
//     const token = localStorage.getItem('access_token');

//     if (token) {
//       request = request.clone({
//         setHeaders: {
//           Authorization: `Bearer ${token}`
//         }
//       });
//     }

//     return next.handle(request);
//   }
// }