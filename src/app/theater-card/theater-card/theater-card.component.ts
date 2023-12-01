import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute,Router } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify.service';
import { BookingInfoService } from 'src/app/services/booking-info.service';

@Component({
  selector: 'app-theater-card',
  templateUrl: './theater-card.component.html',
  styleUrls: ['./theater-card.component.css']
})
export class TheaterCardComponent implements OnInit{
  @Input () Theater_details: any
  @Input () movie_details:any
  @Input () TheaterId: any
  @Input () pickedDate:any

  public showTime:any
  constructor(private route: ActivatedRoute, private router: Router, private bookingService: BookingInfoService, private alerter:AlertifyService) {}

  ngOnInit(): void {


  }
  selectTheater(event: Event, theaterDetails: any, item:string): void {
    event.preventDefault();
      this.bookingService.showTime=item;
      this.bookingService.theaterDetails = theaterDetails;
      this.bookingService.pickedDate=this.pickedDate;
      this.router.navigate(['/seating/'+`${this.movie_details.movie_name}`+'_'+`${this.Theater_details.theater_name}`+ '_'+`${item}`])

}
selectDate():void{
  this.alerter.error("Please Select Date");
}

}
