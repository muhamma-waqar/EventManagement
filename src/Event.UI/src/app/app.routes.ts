import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuComponent } from './components/menuBar/menu/menu.component';
import { LoginComponent } from './components/login/login.component';
import { EventComponent } from './components/event/event.component';
import { HomeComponent } from './components/home/home.component';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { AuthGuard } from './auth.guard';

export const routes: Routes = [
    {path:'', component: LoginComponent, canActivate: [AuthGuard]},
    {path: 'menu', component: MenuComponent},
    {path: 'addEvent', component: EventComponent },
    {path: 'home', component: HomeComponent},
    {path: 'calandar', component: MenuComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes), 
        CalendarModule.forRoot({provide: DateAdapter, useFactory: adapterFactory}),
    ],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }