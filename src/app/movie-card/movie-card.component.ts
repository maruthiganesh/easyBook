

import { Component , Input} from "@angular/core";

@Component(

    {
        selector:'app-movie-card',
        //template:`<h3>movie ticket booking<h3>`
        templateUrl:'movie-card.component.html',
        styleUrls: ['movie-card.component.css'],

    }
)

export class MovieCardComponent{
   
    @Input () movie_details: any 

    // clickOnCard()
    // {
    //     this.router.navigate([details']);
    // }
}