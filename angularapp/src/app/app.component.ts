import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'libraryapp';

  constructor(private http: HttpClient) { }

  getData() {
    //return this.http.get('https://www.googleapis.com/books/v1/volumes?q=trees');
    return this.http.get('https://localhost:7299/book');
  }
}
