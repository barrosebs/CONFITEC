import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CondutorService {
baseUrl = 'http://localhost:5000/condutor';
constructor(private http: HttpClient) { }
getCondutor(){
  return this.http.get(this.baseUrl);
}
}
