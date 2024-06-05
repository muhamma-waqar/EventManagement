import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuComponent } from './components/menu/menu.component';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { DemoComponent } from './swl/component/calandar/demo.component';
import { EventComponent } from './components/event/event.component';

const routes: Routes = [
  {path:'', component:LoginComponent},
  {path:'header', component:MenuComponent},
  {path:'home', component: HomeComponent},
  {path: 'calendar', component: DemoComponent},
  {path: 'event', component: EventComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
