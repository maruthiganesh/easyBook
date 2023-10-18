
import { Component, OnInit } from '@angular/core';
import { MovieService } from '../services/movie.service';
@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent implements OnInit {

  Movie: Array<any> ;
constructor(private movieService:MovieService)
{
  this.Movie=[];
}

ngOnInit(): void {

  this.movieService.getAllDetails().subscribe( 
    data=>{
    this.Movie=data;},
    error=>
    {console.log(error);}
  );

}

}
