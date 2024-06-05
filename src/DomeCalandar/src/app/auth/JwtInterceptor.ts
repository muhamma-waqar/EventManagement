import {HttpInterceptorFn } from '@angular/common/http';

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