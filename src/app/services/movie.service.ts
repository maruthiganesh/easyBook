import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map,catchError } from 'rxjs/operators';
import { Observable, BehaviorSubject,throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class MovieService {
  checkedArray$: BehaviorSubject<Array<any>> = new BehaviorSubject<Array<any>>([]); // Initialize with an empty array

  constructor(private http: HttpClient) { }
  getMovieDetails(id:number): Observable<any>{
    const url = `http://localhost:5224/api/movies/${id}`;
    const movieData=this.http.get<any>(url);
    // console.log(movieData);
    return movieData;
  }
  getAllDetails(locations: string[]): Observable<any> {
    const url = 'http://localhost:5224/api/movies';
    // return this.http.get<MovieDetails>('data/movie_details.json').pipe(
    //   map((data: MovieDetails) => {
    //     const movieArray: MovieDetails[] = Object.values(data);
    //     return movieArray;
      // })
    // );
    const payload = { locations: locations };
    console.log(payload);

    var movieData= this.http.post<MovieDetails[]>(url,payload);
     console.log(movieData);

    return  movieData;
  }

  getCityDetails(): Observable<string[]> {
    console.log(this.checkedArray$);
    console.log(typeof(this.checkedArray$));
    const url = 'http://localhost:5224/api/theater';
    const headers = new HttpHeaders({
                'Content-Type': 'application/json'
          });
    return this.http.get<string[]>(url, { headers }).pipe(
      map(Data => {
        let pArray: string[] = [];
        for (const key in Data) {
          pArray=[...pArray, Data[key]];
        }
        return pArray;
      })
    );
  }


  getTheaterDetails(movie_id: number): Observable<any> {
    // return this.http.get<TheaterDetails>('data/theater_details.json').pipe(
    //   map((data: TheaterDetails) => {
    //     const theaterArray: TheaterDetails[] = Object.values(data);
    //     return theaterArray;
    //   })
    // );
    const url=`http://localhost:5224/api/theater/details/${movie_id}`;
    var tD= this.http.get<any>(url).pipe(
      map(Data => {
        let pArray: string[] = [];
        for (const key in Data) {
          pArray=[...pArray, Data[key]];
        }
        return pArray;
      })
    );
    // console.log(tD);
    return tD;
  }

  updateCheckedArray(checkedArray: Array<any>) {
    this.checkedArray$.next(checkedArray); // Update the BehaviorSubject directly
  }
}

interface MovieDetails {
  ID: Number;
  Name: string;
  Genre: string;
  Language:string;
  Duration:string;
  Release_date:string;

}


