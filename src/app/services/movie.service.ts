import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})

export class MovieService {

  constructor(private http:HttpClient) { }

  getAllDetails(): Observable<MovieDetails[]> {
    return this.http.get<MovieDetails>('data/movie_details.json').pipe(
      map((data: MovieDetails) => {
        const movieArray: MovieDetails[] = Object.values(data);
        return movieArray;
      })
    );
  }
}
interface MovieDetails {
  
  ID: string;
  Name: string;
  Genre:string;
  Type:string;
  Price:string;

}
