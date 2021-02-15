import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'AngularJSTutorial';
  products: any[];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/Products?pageSize=50').subscribe(
      (response: any) => {
        this.products = response.data;
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
