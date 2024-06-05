import { Component } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-calandar',
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent {
  constructor(private router : Router){}
  goToEvent(){
    this.router.navigateByUrl('/addEvent')
  }
  toToCalander(){
    this.router.navigateByUrl('/calandar');
  }
}
