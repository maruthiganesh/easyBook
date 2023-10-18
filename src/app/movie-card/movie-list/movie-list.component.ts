import { Component } from '@angular/core';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent {

  Movie: Array<any> = [
    
    {
    "Id": "1",
    "Name":"Leo",
    "Type":"movie",
    "Price":"250"

    },

    {
      "Id": "2",
      "Name":"Marvels",
      "Type":"movie",
      "Price":"300"
  
    },
    {
        "Id": "3",
        "Name":"RRR",
        "Type":"movie",
        "Price":"250"
    
    },
    {
          "Id": "4",
          "Name":"Kalki",
          "Type":"movie",
          "Price":"250"
      
    },
    {
            "Id": "5",
            "Name":"OMG 2",
            "Type":"movie",
            "Price":"250"
        
    }
  
  
  ]

}
