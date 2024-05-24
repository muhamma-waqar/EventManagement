import { Component } from '@angular/core';
import { MenuComponent } from '../menuBar/menu/menu.component';
import { MatCardContent, MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MenuComponent , MatCardModule, MatCardContent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
