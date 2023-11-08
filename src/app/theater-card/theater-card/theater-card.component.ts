import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-theater-card',
  templateUrl: './theater-card.component.html',
  styleUrls: ['./theater-card.component.css']
})
export class TheaterCardComponent {
  @Input () Theater_details: any 

}
