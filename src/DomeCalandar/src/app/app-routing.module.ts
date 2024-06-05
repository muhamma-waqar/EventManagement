import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuComponent } from './components/menu/menu.component';
import { LoginComponent } from './components/login/login/login.component';
import { HomeComponent } from './components/Home/home/home.component';

const routes: Routes = [
  {path:'', component:LoginComponent},
  {path:'home', component:HomeComponent},
  {path:'header', component:MenuComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
