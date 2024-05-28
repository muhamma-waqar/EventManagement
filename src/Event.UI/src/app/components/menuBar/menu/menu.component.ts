import { Component } from '@angular/core';
import {MatMenuModule} from '@angular/material/menu';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar'
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [MatMenuModule,MatIconModule,MatButtonModule,MatToolbarModule, ],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent {

  constructor(private router : Router){}
  goToEvent(){
    this.router.navigateByUrl('/addEvent')
  }
  toToCalander(){
    this.router.navigateByUrl('/calander');
  }
}
