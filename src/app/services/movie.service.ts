// import { Injectable } from '@angular/core';
// import { HttpClient } from '@angular/common/http';
// import { map } from 'rxjs/operators';
// import { Observable, BehaviorSubject } from 'rxjs';

// @Injectable({
//   providedIn: 'root'
// })

// export class MovieService {

//   constructor(private http:HttpClient) { }

//   getAllDetails(): Observable<MovieDetails[]> {
//     return this.http.get<MovieDetails>('data/movie_details.json').pipe(
//       map((data: MovieDetails) => {
//         const movieArray: MovieDetails[] = Object.values(data);
//         return movieArray;
//       })
//     );
//   }

//   private checkedArraySource = new BehaviorSubject<Array<any>>([]);
//   checkedArray$ = this.checkedArraySource.asObservable();

//   updateCheckedArray(checkedArray: Array<any>) {
//     this.checkedArraySource.next(checkedArray);
// }
// }
// interface MovieDetails {
  
//   ID: string;
//   Name: string;
//   Genre:string;
//   Type:string;
//   Price:string;
//   City:string;

// }


import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class MovieService {
  checkedArray$: BehaviorSubject<Array<any>> = new BehaviorSubject<Array<any>>([]); // Initialize with an empty array

  constructor(private http: HttpClient) { }

  getAllDetails(): Observable<MovieDetails[]> {
    return this.http.get<MovieDetails>('data/movie_details.json').pipe(
      map((data: MovieDetails) => {
        const movieArray: MovieDetails[] = Object.values(data);
        return movieArray;
      })
    );
  }

  getTheaterDetails(): Observable<TheaterDetails[]> {
    return this.http.get<TheaterDetails>('data/theater_details.json').pipe(
      map((data: TheaterDetails) => {
        const theaterArray: TheaterDetails[] = Object.values(data);
        return theaterArray;
      })
    );
  }

  updateCheckedArray(checkedArray: Array<any>) {
    this.checkedArray$.next(checkedArray); // Update the BehaviorSubject directly
  }
}

interface MovieDetails {
  ID: string;
  Name: string;
  Genre: string;
  Type: string;
  Language:string;
  Rating:string;
  Duration:string;
  Release_date:string;
  City: string;
}

interface TheaterDetails{
  tName:string;
  tLocation:string;
  tMovies:object;
}
