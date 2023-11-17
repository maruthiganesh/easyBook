import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-theater-card',
  templateUrl: './theater-card.component.html',
  styleUrls: ['./theater-card.component.css']
})
export class TheaterCardComponent implements OnInit{
  @Input () Theater_details: any
  @Input () movie_details:any


  ngOnInit(): void {

      // console.log("fytf",this.Theater_details)
  }

}
