import { Component } from '@angular/core';
import { MenuComponent } from '../menuBar/menu/menu.component';
import { MatCardContent, MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-event',
  standalone: true,
  imports: [MenuComponent,MatCardModule,MatCardContent],
  templateUrl: './event.component.html',
  styleUrl: './event.component.css'
})
export class EventComponent {

}
