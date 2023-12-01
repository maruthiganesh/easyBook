import { Component } from '@angular/core';
import { BookingInfoService } from 'src/app/services/booking-info.service';

@Component({
  selector: 'app-confirmation',
  templateUrl: './confirmation.component.html',
  styleUrls: ['./confirmation.component.css']
})

export class ConfirmationComponent {
  public movieDetails:any;
  public theaterDetails:any;
  public showTime:any;
  public pickedDate:any;
  public seatDetails:any;
  public totalAmount:any;
  constructor(bookingService:BookingInfoService){
    this.movieDetails=bookingService.movieDetails;
    this.theaterDetails=bookingService.theaterDetails;
    this.seatDetails=bookingService.seatDeatils;
    this.pickedDate=bookingService.pickedDate;
    this.showTime=bookingService.showTime;
    this.totalAmount=bookingService.totalAmount;
  }

}
