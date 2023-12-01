import { Component, OnInit } from '@angular/core';
import { MovieService } from '../services/movie.service';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent implements OnInit {
  checkedArray: Array<any> = [];
  Movie: Array<any>;
  tA:Array<any>=[];

  constructor(private movieService: MovieService) {
    this.Movie = [];
  }

  ngOnInit(): void {
    this.movieService.checkedArray$.subscribe(checkedArray => {
      this.checkedArray = checkedArray;
      console.log(this.checkedArray)
      this.tA=this.checkedArray;

      if(this.checkedArray.length==0)
    {
        this.tA=["Hyderabad","Kolkata","Bangalore"];
    }
    this.movieService.getAllDetails(this.tA).subscribe(
      data => {
        // const serializedData = JSON.stringify(data);
        // console.log(serializedData);
        // console.dir(data);
        this.Movie = data;
        console.log("hello",this.Movie);

      },
      error => {
        console.log(error);
      }
    );

    });

    // console.log(this.checkedArray);



  }
}
