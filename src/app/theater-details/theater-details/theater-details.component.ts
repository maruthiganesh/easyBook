import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify.service';
import { MovieService } from 'src/app/services/movie.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-theater-details',
  templateUrl: './theater-details.component.html',
  styleUrls: ['./theater-details.component.css']
})
export class TheaterDetailsComponent implements OnInit{
  public movieName:string="";
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
  public selectedDate: string = '';
  checkedArray: Array<any> = [];
  constructor(private route:ActivatedRoute, private movieService:MovieService,private router:Router,private alerter:AlertifyService,private datePipe: DatePipe){
    
  }

  ngOnInit(): void {

    const mD = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
    this.minDate=mD;
    this.date= + this.minDate.substring(8,10);
    this.month= + this.minDate.substring(5,7);
    console.log(typeof(this.date));
    console.log(typeof(this.month));
    if(this.month===2)
    {
      this.holder=29;
      
    }  
    else if(this.odds.includes(this.month))
    {
        this.holder=31;
    }
    else this.holder=32;
console.log("holder",this.holder);

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
        console.log("p value",p);
        if(this.month<9)
        this.maxDate=this.minDate.substring(0,5)+"0"+(this.month+1)+"-"+p;
      else
      this.maxDate=this.minDate.substring(0,5)+(this.month+1)+"-"+p;
      }

      console.log(this.minDate);
      console.log(this.maxDate);


    this.route.params.subscribe(data=>{this.movieName=data['id']});
    this.movieService.getAllDetails().subscribe(
      (data:any) => {
        this.Movie = data;

        for(const item of this.Movie){
          if(item.Name===this.movieName)
          {
            this.flag=true;
          
            this.Movie_details=item;
          }
    
        }
        if(!this.flag){
          this.router.navigate(['/']);
          this.alerter.error('Error in movie name');
          
        }
  
      },
      error => {
        console.log(error);
      }
      
    );

    this.movieService.checkedArray$.subscribe(checkedArray => {
      this.checkedArray = checkedArray;
    });
    console.log(this.checkedArray);

    this.movieService.getTheaterDetails().subscribe(
      data => {
        this.Theater_details = data;
      },
      error => {
        console.log(error);
      }

    );
    
  }

  loggedin(){
    return localStorage.getItem('token');
  }
  

  


}
