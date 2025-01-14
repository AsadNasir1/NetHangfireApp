import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {
  searchQuery: string = '';
  movies: any[] = [];

  private apiUrl = 'https://localhost:7267/api/movies';
  private apiKey = '3f69f22b-eca3-409e-8439-64056a61cbc6';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getMovies();
  }

  getMovies(): void {
    this.http
      .get<any[]>(`${this.apiUrl}?apiKey=${this.apiKey}`)
      .subscribe((response) => {
        this.movies = response;
      });
  }

  searchMovies(): void {
    if (this.searchQuery.trim() === '') {
      this.getMovies();
    } else {
      this.http
        .get<any[]>(`${this.apiUrl}?s=${this.searchQuery}&apiKey=${this.apiKey}`)
        .subscribe((response) => {
          this.movies = response;
        });
    }
  }
}
