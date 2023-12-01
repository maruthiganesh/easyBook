import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BookingInfoService {
  public theaterDetails: any;
 public movieDetails: any;
  public seatDeatils:any;
  public pickedDate:any;
  public showTime:any;
  public totalAmount:any;

  constructor() { }
}
