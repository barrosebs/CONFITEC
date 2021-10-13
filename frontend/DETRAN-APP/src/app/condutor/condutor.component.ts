import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-condutor',
  templateUrl: './condutor.component.html',
  styleUrls: ['./condutor.component.scss']
})
export class CondutorComponent implements OnInit {
  titlePage = 'CONDUTOR';

  condutores: any = [];
  

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getCondutor();
  }
  getCondutor(){
    this.http.get('http://localhost:5000/condutor').subscribe(
      response => { this.condutores = response ;},
      error => {
        console.log(error);
      });
      
  }

}
