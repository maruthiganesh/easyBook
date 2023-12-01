interface TheaterDetails {
  screen_id: number;
  screen_name: string;
  show_id: number [];
  times: string [];
  theater_name: string;
  theater_location: string;

}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify.service';
import { MovieService } from 'src/app/services/movie.service';
import { DatePipe } from '@angular/common';
import { BookingInfoService } from 'src/app/services/booking-info.service';

@Component({
  selector: 'app-theater-details',
  templateUrl: './theater-details.component.html',
  styleUrls: ['./theater-details.component.css']
})
export class TheaterDetailsComponent implements OnInit{
  public movieName:string="";
  public para:string="";
  public movieId:number=0;
  public Movie:any={};
  public month:number=0; //{"30":[4,6,9,11],"31":[]}
  public odds=[4,6,9,11];
  public Movie_details:any;
  public Theater_details:any;
  flag:boolean=false;
  public minDate:any;
  public holder:number=0;
  public maxDate:any;
  public date:number=0;
  public theater_data:any=[];
  public selectedDate: string = '';
  checkedArray: Array<any> = [];
  public theaterDictionary: Record<string, TheaterDetails> = {};
  public theaterArray: [string, TheaterDetails][] = [];
  public pickedDate: string = '';
  constructor(private route:ActivatedRoute,
              private movieService:MovieService,
              private router:Router,
              private alerter:AlertifyService,
              private datePipe: DatePipe,
              private bookingService: BookingInfoService

              ){

  }

  ngOnInit(): void {


    const mD = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
    this.minDate=mD;
    this.date= + this.minDate.substring(8,10);
    this.month= + this.minDate.substring(5,7);
    // console.log(typeof(this.date));
    // console.log(typeof(this.month));
    if(this.month===2)
    {
      this.holder=29;

    }
    else if(this.odds.includes(this.month))
    {
      this.holder=31;
    }
    else this.holder=32;
// console.log("holder",this.holder);

if(this.date+7<this.holder)
{
  if(this.date+7<10)
  this.maxDate=this.minDate.substring(0,8)+"0"+ (this.date+7);
else
        this.maxDate=this.minDate.substring(0,8)+(this.date+7);
      }
      else
      {
        const p=this.date+7-this.holder-1;
        // console.log("p value",p);
        if(this.month<9)
        this.maxDate=this.minDate.substring(0,5)+"0"+(this.month+1)+"-"+p;
      else
      this.maxDate=this.minDate.substring(0,5)+(this.month+1)+"-"+p;
      }

      // console.log(this.minDate);
      // console.log(this.maxDate);


    this.route.params.subscribe(data=>{this.para=data['id']});
    const x=this.para.split('_');
    this.movieName=x[0];
    this.movieId=+x[1];

    this.movieService.getMovieDetails(this.movieId).subscribe(data=>{
      this.Movie=data;
      this.bookingService.movieDetails = this.Movie;
      // console.log(this.bookingService.movieDetails);
      console.log(this.Movie);
    })
    // this.movieService.getAllDetails(this.checkedArray).subscribe(
    //   (data:any) => {
    //     console.log(data);
    //     this.Movie = data;

    //     for(const item of this.Movie){
    //       if(item.movie_name===this.movieName)
    //       {
    //         this.flag=true;

    //         this.Movie_details=item;
    //       }

    //     }
    //     if(!this.flag){
    //       this.router.navigate(['/']);
    //       this.alerter.error('Error in movie name');

    //     }

    //   },
    //   error => {
    //     console.log(error);
    //   }

    //   );

      this.movieService.checkedArray$.subscribe(checkedArray => {
        this.checkedArray = checkedArray;
      });


      // console.log(this.checkedArray);

      this.movieService.getTheaterDetails(this.movieId).subscribe(
        data => {
          this.Theater_details = data;
          console.log(this.Theater_details);
          //this.theater_data=this.Theater_details;
           this.helper_theater();

        },
        error => {
        console.log(error);
      }

      );
    // console.log(this.Theater_details);
  }

  helper_theater():void{

    for (let i = 0; i < this.Theater_details.length; i++) {
      const theater = this.Theater_details[i];
      if(this.theaterDictionary[theater.theater_id]!== undefined)
      {
        this.theaterDictionary[theater.theater_id].show_id.push(theater.show_id)
        this.theaterDictionary[theater.theater_id].times.push(theater.show_time)
      }
      else
      {
        this.theaterDictionary[theater.theater_id] = {
          theater_name: theater.theater_name,
          screen_id: theater.screen_id,
          show_id: [theater.show_id],
          theater_location: theater.theater_location,
          times: [theater.show_time],
          screen_name: theater.screen_name,
        };
      }
    }

    console.log(this.theaterDictionary)
    this.theaterArray = Object.entries(this.theaterDictionary);
  }

  // helper_theater():void{
  //   // console.log(this.Theater_details);

  //   for(let i=0;i<this.Theater_details.length;i++)
  //   {
  //     //console.log(this.movieName)
  //     // console.log("Tlist",this.Theater_details[i].tList[this.movieName]);
  //     // console.log("Screen number",this.Theater_details[i].tList.movieName);
  //     if( this.Theater_details[i].tList[this.movieName]!= undefined)
  //     {
  //       let tname=this.Theater_details[i].tName;
  //       let tlocation=this.Theater_details[i].tLocation;
  //       // console.log(this.Theater_details[i])
  //       let x=this.Theater_details[i].tList[this.movieName]
  //       // console.log(x);
  //       this.theater_data=[...this.theater_data,{'tname':tname,'tlocation':tlocation,'tdetails': this.Theater_details[i].tMovies[x][this.movieName]}];
  //       // console.log(this.theater_data);
  //     }


  //   }


  // }

  loggedin(){
    return localStorage.getItem('token');
  }



}
