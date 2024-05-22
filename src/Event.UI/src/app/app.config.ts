import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, provideHttpClient, withFetch, withInterceptors, withInterceptorsFromDi } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';
import {JwtModule } from '@auth0/angular-jwt';
import {loggerInterceptor } from './auth/jwtInterceptor';

export function tokenGetter() : string{
  const token =  localStorage.getItem("token") ?? "";
  console.log('tokn', token);
  return token;
}

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes), 
    provideClientHydration(), 
    provideHttpClient(withInterceptors([loggerInterceptor])),  provideAnimations(),

  ],
};
