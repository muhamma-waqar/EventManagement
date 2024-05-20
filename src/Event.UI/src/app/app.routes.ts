import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuComponent } from './components/menuBar/menu/menu.component';
import { LoginComponent } from './components/login/login.component';
import { EventComponent } from './components/event/event.component';

export const routes: Routes = [
    {path:'', component: LoginComponent} ,
    {path:'menu', component: MenuComponent},
    {path:'addEvent', component:EventComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }