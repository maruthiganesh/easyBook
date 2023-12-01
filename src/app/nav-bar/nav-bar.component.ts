import { Component, OnInit } from '@angular/core';
import { MovieService } from '../services/movie.service';
import { take } from 'rxjs';
import { AlertifyService } from '../services/alertify.service';
import { Router } from '@angular/router';


let mapper = new Map();
mapper.set("id_blore", "Bangalore");
mapper.set("id_hyd", "Hyderabad");
mapper.set("id_kol", "Kolkata");

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit{

  constructor(private movieService: MovieService, private alerter:AlertifyService,private router:Router) { }
  ngOnInit(): void {
    // this.movieService.getCityDetails().subscribe(
    //   data => console.log(data),
    //   error => console.error('Error fetching city details:', error) );
  }
  onChange(event: any) {
    let element = event.target;
    let eid = element.id;

    if (element.checked) {
      this.movieService.checkedArray$.pipe(take(1)).subscribe(checkedArray => {
        if (!checkedArray.includes(mapper.get(eid))) {
          const updatedArray = [...checkedArray, mapper.get(eid)];
          this.movieService.updateCheckedArray(updatedArray);

        }
      });
    } else  {
      this.movieService.checkedArray$.pipe(take(1)).subscribe(checkedArray => {
        console.log("==checked array in else===")

        const index = checkedArray.indexOf(mapper.get(eid));

        if (index !== -1) {

          const updatedArray = checkedArray.slice();

          updatedArray.splice(index, 1);

          this.movieService.updateCheckedArray(updatedArray);
        }

      });
    }
  }

  loggedin(){
    return localStorage.getItem('token');
  }
  onLogout(){
    localStorage.removeItem('token');
    this.router.navigate(["/"]);
    this.alerter.success('logged out Successfully');

  }
}
