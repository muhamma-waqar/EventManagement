import { Component } from '@angular/core';
import { MenuComponent } from '../menuBar/menu/menu.component';
import { CalendarModule } from 'angular-calendar';

@Component({
  selector: 'app-calander',
  standalone: true,
  imports: [MenuComponent, CalanderComponent, CalendarModule],
  templateUrl: './calander.component.html',
  styleUrl: './calander.component.css'
})
export class CalanderComponent {

}
