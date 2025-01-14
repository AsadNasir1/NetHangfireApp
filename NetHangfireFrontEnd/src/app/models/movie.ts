import { numberAttribute } from "@angular/core";

  export class Movie {
    Id: number;
    title: string;
    releaseYear: string;
    poster: string;
    constructor(                              
    ) {
        this.Id = 0;
        this.title = '';
        this.releaseYear = '';
        this.poster = '';
    }
  }