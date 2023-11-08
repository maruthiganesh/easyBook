import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from "@angular/common/http"
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MovieCardComponent } from './movie-card/movie-card.component';

import { NavBarComponent } from './nav-bar/nav-bar.component';
import { MovieService } from './services/movie.service';
import {UserService} from './services/user.service';
import {AlertifyService} from './services/alertify.service';
import {AuthService} from './services/auth.service';
import { MovieListComponent } from './movie-list/movie-list.component';

import { Routes, RouterModule } from '@angular/router';
import { MyBookingsComponent } from './my-bookings/my-bookings.component';
import { UserLoginComponent } from './User/user-login/user-login.component';
import { UserRegisterComponent } from './User/user-register/user-register.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { FilterPipe } from './pipe/filter.pipe';
import { SortPipe } from './pipe/sort.pipe';
import { TheaterDetailsComponent } from './theater-details/theater-details/theater-details.component';
import { TheaterCardComponent } from './theater-card/theater-card/theater-card.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DatePipe } from '@angular/common';

const appRoutes:Routes=[
  {path: '', component: MovieListComponent},
  {path:'my-bookings',component:MyBookingsComponent},
  {path:'login',component:UserLoginComponent},
  {path:'register',component:UserRegisterComponent},
  {path:'movie-details/:id',component:TheaterDetailsComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    MovieCardComponent,
    NavBarComponent,
    MovieListComponent,
    MyBookingsComponent,
    UserLoginComponent,
    UserRegisterComponent,
    FilterPipe,
    SortPipe,
    TheaterDetailsComponent,
    TheaterCardComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    BrowserAnimationsModule
  ],
  providers: [MovieService,UserService,AlertifyService,AuthService,DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
