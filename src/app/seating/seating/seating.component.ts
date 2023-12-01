// import { Component, OnInit, Renderer2, ChangeDetectorRef, ViewChild, ElementRef } from '@angular/core';

// @Component({
//   selector: 'app-seating',
//   templateUrl: './seating.component.html',
//   styleUrls: ['./seating.component.css']
// })

// export class SeatingComponent implements OnInit {
//   @ViewChild('count', { static: true }) countElement!: ElementRef;
//   @ViewChild('total', { static: true }) totalElement!: ElementRef;
//   @ViewChild('movieSelect', { static: true }) movieSelectElement!: ElementRef;

//   public container: any;
//   public seats: any;
//   public rows: number = 0;
//   public columns: number = 0;
//   public isBalconyAvailable: boolean = false;
//   public balconyRows: number = 0;
//   public balconyColumns: number = 0;
//   public StempRow: Array<number> = []
//   public TotalPrice: number = 0;
//   public seatPrice: number = 100;
//   public BalSeatPrice: number = 50;

//   constructor(private renderer: Renderer2, private cdr: ChangeDetectorRef) {}

//   ngOnInit(): void {
//     this.container = document.querySelector('.container');
//     this.seats = document.querySelectorAll('.row .seat:not(.occupied)');

//     this.movieSelectElement.nativeElement.value; // Accessing the value directly
//     let ticketPrice = +this.movieSelectElement.nativeElement.value;


//     this.rows = 13; // Number of rows
//     for (let i = 1; i <= this.rows; i++) {
//       this.StempRow.push(i);
//     }
//     this.columns = 13; // Number of columns
//     this.balconyColumns = 13;
//     this.balconyRows = 2;
//     this.isBalconyAvailable = true;

//     // Update total and count
//     const updateSelectedCount = () => {
//       const selectedSeats = document.querySelectorAll('.row .seat.selected');
//       const selectedSeatsCount = selectedSeats.length;

//       // Update count
//       if (this.countElement && this.countElement.nativeElement) {
//         this.renderer.setProperty(this.countElement.nativeElement, 'innerText', selectedSeatsCount);
//       }

//       // Update total price
//       this.TotalPrice = selectedSeatsCount * ticketPrice;

//       if (this.totalElement && this.totalElement.nativeElement) {
//         this.renderer.setProperty(this.totalElement.nativeElement, 'innerText', this.TotalPrice);
//       }

//       this.cdr.detectChanges();
//     };


//     this.movieSelectElement.nativeElement.addEventListener('change', (e: Event) => {
//       ticketPrice = +((e.target as HTMLSelectElement).value);
//       updateSelectedCount();
//     });

//     // Seat click event
//     this.container.addEventListener('click', (e: MouseEvent) => {
//       const target = e.target as HTMLElement;
//       if (target.classList && target.classList.contains('seat') && !target.classList.contains('occupied')) {
//         target.classList.toggle('selected');
//       }
//       updateSelectedCount();
//     });

//   }

//   getBalconyRows(): number[] {
//     return Array(this.balconyRows).fill(0).map((_, index) => index);
//   }

//   getBalconyColumns(): number[] {
//     return Array(this.balconyColumns).fill(0).map((_, index) => index);
//   }

//   isSeatOccupiedBalcony(row: number, col: number): boolean {
//     if (row === col) return true;
//     return false;
//   }

//   getSeatIdBalcony(row: number, col: number): string {
//     return `balcony-${row}-${col}`;
//   }

//   getColumns(): number[] {
//     return Array(this.columns).fill(0).map((_, index) => index);
//   }

//   isSeatOccupied(row: number, col: number): boolean {
//     if (row === col) return true;
//     return false;
//   }

//   getSeatId(row: number, col: number): string {
//     let x = String.fromCharCode(row + 65);
//     // console.log(x+col)
//     return `${x}${col}`;
//   }
// }


// import { Component, OnInit, Renderer2, ChangeDetectorRef, ViewChild, ElementRef, AfterViewInit } from '@angular/core';

// @Component({
//   selector: 'app-seating',
//   templateUrl: './seating.component.html',
//   styleUrls: ['./seating.component.css']
// })
// export class SeatingComponent implements AfterViewInit {
//   @ViewChild('count', { static: true }) countElement!: ElementRef;
//   @ViewChild('total', { static: true }) totalElement!: ElementRef;
//   @ViewChild('movieSelect', { static: true }) movieSelectElement!: ElementRef;

//   public container: any;
//   public rows: number = 0;
//   public columns: number = 0;
//   public StempRow: Array<number> = [];
//   public selectedSeats: string[] = []; // Track selected seats
//   public TotalPrice: number = 0;
//   public seatPrice: number = 100;
//   public BalSeatPrice: number = 50;
//   public isBalconyAvailable: boolean = true;
//   balconyColumns = 13;
//   balconyRows = 2;
//   constructor(private renderer: Renderer2, private cdr: ChangeDetectorRef) {}

//   ngAfterViewInit(): void {
//     this.container = document.querySelector('.container');

//     // Assuming the following code to set initial values for rows and columns
//     this.rows = 13;
//     this.columns = 13;
//     for (let i = 1; i <= this.rows; i++) {
//       this.StempRow.push(i);
//     }

//     this.movieSelectElement.nativeElement.addEventListener('change', (e: Event) => {
//       const ticketPrice = +((e.target as HTMLSelectElement).value);
//       this.seatPrice = ticketPrice;
//       this.updateSelectedCount();
//     });

//     // Event listener for seat click
//     this.container.addEventListener('click', (e: MouseEvent) => {
//       const target = e.target as HTMLElement;
//       if (target.classList && target.classList.contains('seat') && !target.classList.contains('occupied')) {
//         const seatId = target.getAttribute('id') || '';
//         target.classList.toggle('selected');
//         this.toggleSelectedSeat(e,seatId);
//         this.updateSelectedCount();
//       }
//     });

//     // Event listener for movie select change



//   }

//   toggleSelectedSeat(event: Event, seatId: string): void {
//     event.stopPropagation();
//     const index = this.selectedSeats.indexOf(seatId);
//     if (index === -1) {
//       this.selectedSeats.push(seatId);
//     } else {
//       this.selectedSeats.splice(index, 1);
//     }

//     console.log(this.selectedSeats);
//   }

//   updateSelectedCount(): void {
//     const selectedSeatsCount = this.selectedSeats.length;
//     if (this.countElement && this.countElement.nativeElement) {
//       this.renderer.setProperty(this.countElement.nativeElement, 'innerText', selectedSeatsCount);
//     }

//     this.TotalPrice = selectedSeatsCount * this.seatPrice;
//     if (this.totalElement && this.totalElement.nativeElement) {
//       this.renderer.setProperty(this.totalElement.nativeElement, 'innerText', this.TotalPrice);
//     }

//     this.cdr.detectChanges();
//   }

//   getBalconyRows(): number[] {
//     return Array(this.balconyRows).fill(0).map((_, index) => index);
//   }

//   getBalconyColumns(): number[] {
//     return Array(this.balconyColumns).fill(0).map((_, index) => index);
//   }

//   isSeatOccupiedBalcony(row: number, col: number): boolean {
//     if (row === col) return true;
//     return false;
//   }

//   getSeatIdBalcony(row: number, col: number): string {
//     return `balcony-${row}-${col}`;
//   }

//   getColumns(): number[] {
//     return Array(this.columns).fill(0).map((_, index) => index);
//   }

//   isSeatOccupied(row: number, col: number): boolean {
//     if (row === col) return true;
//     return false;
//   }

//   getSeatId(row: number, col: number): string {
//     let x = String.fromCharCode(row + 65);
//     return `${x}${col}`;
//   }
// }



import { Component, Renderer2, ChangeDetectorRef, ViewChild, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify.service';
import { BookingInfoService } from 'src/app/services/booking-info.service';

@Component({
  selector: 'app-seating',
  templateUrl: './seating.component.html',
  styleUrls: ['./seating.component.css']
})
export class SeatingComponent {
  @ViewChild('count') countElement!: ElementRef;
  @ViewChild('total') totalElement!: ElementRef;
  public movieDetails:any;
  public theaterDetails:any;
  public rows: number = 0;
  public columns: number = 0;
  public StempRow: Array<number> = [];
  public selectedSeats: string[] = [];
  public TotalPrice: number = 0;
  public RegseatPrice: number = 100;
  public BalSeatPrice: number = 50;
  public isBalconyAvailable: boolean = true;
  public balconyColumns = 13;
  public balconyRows = 2;
  public bscount=0;
  public rscount=0;
  public pickedDate:any;
  public showTime:any;
  constructor(private renderer: Renderer2,private router: Router, private cdr: ChangeDetectorRef, private BookingService:BookingInfoService, private alerter:AlertifyService) {
    this.movieDetails = this.BookingService.movieDetails;
    this.theaterDetails = this.BookingService.theaterDetails;
    this.pickedDate=this.BookingService.pickedDate;
    this.showTime=this.BookingService.showTime;
  }

  ngAfterViewInit(): void {
    console.log("hello:",this.BookingService.movieDetails);

    this.rows = 13;
    this.columns = 13;
    for (let i = 1; i <= this.rows; i++) {
      this.StempRow.push(i);
    }
  }

  toggleSelectedSeat(seatId: string): void {
    const index = this.selectedSeats.indexOf(seatId);
    if (index === -1) {
      if(seatId.startsWith('b'))
      this.bscount+=1;
    else
    this.rscount+=1;
      this.selectedSeats.push(seatId);
    } else {
      if(seatId.startsWith('b'))
      this.bscount-=1;
    else this.rscount-=1;
      this.selectedSeats.splice(index, 1);
    }
    console.log(this.selectedSeats);

    this.updateSelectedCount();
  }

  updateSelectedCount(): void {
    const selectedSeatsCount = this.selectedSeats.length;
    if (this.countElement && this.countElement.nativeElement) {
      this.countElement.nativeElement.innerText = selectedSeatsCount;
    }

    this.TotalPrice = (this.bscount * this.BalSeatPrice)+(this.rscount*this.RegseatPrice);
    if (this.totalElement && this.totalElement.nativeElement) {
      this.totalElement.nativeElement.innerText = this.TotalPrice;
    }

    this.cdr.detectChanges();
  }

  getBalconyRows(): number[] {
    return Array(this.balconyRows).fill(0).map((_, index) => index);
  }

  getBalconyColumns(): number[] {
    return Array(this.balconyColumns).fill(0).map((_, index) => index);
  }

  isSeatOccupiedBalcony(row: number, col: number): boolean {
    if (row === col) return true;
    return false;
  }

  getSeatIdBalcony(row: number, col: number): string {
    return `balcony-${row}-${col}`;
  }

  getColumns(): number[] {
    return Array(this.columns).fill(0).map((_, index) => index);
  }

  isSeatOccupied(row: number, col: number): boolean {
    if (row === col) return true;
    return false;
  }

  getRegularSeatId(row: number, col: number): string {
    let x = String.fromCharCode(row + 65);
    return `r${x}${col}`;
  }

  getBalconySeatId(row: number, col: number): string {
    let x = String.fromCharCode(row + 65);
    return `b${x}${col}`;
  }

  isSelected(seatId: string): boolean {
    return this.selectedSeats.includes(seatId);
  }
  confirm_booking():void{
    if(this.loggedin()){

      this.BookingService.seatDeatils=this.selectedSeats;
      this.BookingService.totalAmount=this.TotalPrice;
      this.alerter.success("Booking Confirmed"); }

      else{
        this.router.navigate(['/login']);
        this.alerter.error('Please login to Book tickets');
      }

  }
  loggedin(){
    return localStorage.getItem('token');
  }

}

