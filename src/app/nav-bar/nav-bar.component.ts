import { Component } from '@angular/core';
import { MovieService } from '../services/movie.service';
import { take } from 'rxjs';

let mapper = new Map();
mapper.set("id_blore", "Bangalore");
mapper.set("id_hyd", "Hyderabad");
mapper.set("id_kol", "Kolkata");

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {

  constructor(private movieService: MovieService) { }

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
}
