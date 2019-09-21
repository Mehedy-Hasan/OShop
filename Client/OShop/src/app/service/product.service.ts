import { FormBuilder, Validators } from '@angular/forms';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const baseUrl = 'http://localhost:57385/api/';
const httpOptions = {
  headers: new HttpHeaders({'Content-Type':  'application/json'})
};

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient, private fb: FormBuilder) { }

  formModel = this.fb.group({
    Name: ['', Validators.required],
    Price: ['', Validators.required],
    category: [''],
    imageUrl: ['', Validators.required]
  });

  Create() {
    const product = {
      Name: this.formModel.value.Name,
      Price: this.formModel.value.Price,
      CategoryId: this.formModel.value.category,
      Description: this.formModel.value.imageUrl
    };

    const products =  this.http.post(baseUrl + 'products', product, httpOptions);
    return products;
  }

}
