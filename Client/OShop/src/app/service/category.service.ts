import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const baseUrl = 'http://localhost:57385/api/';
const httpOptions = {
  headers: new HttpHeaders({'Content-Type':  'application/json'})
};

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  getAll() {
    const url = baseUrl + 'category';
    return this.http.get(url);
  }
}
