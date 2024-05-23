import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';
import {Interceptor } from './auth/jwtInterceptor';

export function tokenGetter() : string{
  const token =  localStorage.getItem("token") ?? "";
  console.log('tokn', token);
  return token;
}

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes), 
    provideClientHydration(), 
    provideHttpClient(withInterceptors([Interceptor])),  provideAnimations(),

  ],
};
