import { Component, OnInit, Renderer2, ChangeDetectorRef, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-seating',
  templateUrl: './seating.component.html',
  styleUrls: ['./seating.component.css']
})

export class SeatingComponent implements OnInit {
  @ViewChild('count', { static: true }) countElement!: ElementRef;
  @ViewChild('total', { static: true }) totalElement!: ElementRef;
  @ViewChild('movieSelect', { static: true }) movieSelectElement!: ElementRef;

  public container: any;
  public seats: any;
  public rows: number = 0;
  public columns: number = 0;
  public isBalconyAvailable: boolean = false;
  public balconyRows: number = 0;
  public balconyColumns: number = 0;
  public StempRow: Array<number> = []
  public TotalPrice: number = 0;
  public seatPrice: number = 100;
  public BalSeatPrice: number = 50;

  constructor(private renderer: Renderer2, private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.container = document.querySelector('.container');
    this.seats = document.querySelectorAll('.row .seat:not(.occupied)');

    this.movieSelectElement.nativeElement.value; // Accessing the value directly
    let ticketPrice = +this.movieSelectElement.nativeElement.value;


    this.rows = 13; // Number of rows
    for (let i = 1; i <= this.rows; i++) {
      this.StempRow.push(i);
    }
    this.columns = 13; // Number of columns
    this.balconyColumns = 13;
    this.balconyRows = 2;
    this.isBalconyAvailable = true;

    // Update total and count
    const updateSelectedCount = () => {
      const selectedSeats = document.querySelectorAll('.row .seat.selected');
      const selectedSeatsCount = selectedSeats.length;
    
      // Update count
      if (this.countElement && this.countElement.nativeElement) {
        this.renderer.setProperty(this.countElement.nativeElement, 'innerText', selectedSeatsCount);
      }
    
      // Update total price
      this.TotalPrice = selectedSeatsCount * ticketPrice;
    
      if (this.totalElement && this.totalElement.nativeElement) {
        this.renderer.setProperty(this.totalElement.nativeElement, 'innerText', this.TotalPrice);
      }
    
      this.cdr.detectChanges();
    };
    

    this.movieSelectElement.nativeElement.addEventListener('change', (e: Event) => {
      ticketPrice = +((e.target as HTMLSelectElement).value);
      updateSelectedCount();
    });

    // Seat click event
    this.container.addEventListener('click', (e: MouseEvent) => {
      const target = e.target as HTMLElement;
      if (target.classList && target.classList.contains('seat') && !target.classList.contains('occupied')) {
        target.classList.toggle('selected');
      }
      updateSelectedCount();
    });
  
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

  getSeatId(row: number, col: number): string {
    let x = String.fromCharCode(row + 65);
    // console.log(x+col)
    return `${x}${col}`;
  }
}
