import { ProductService } from './../../service/product.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-products',
  templateUrl: './admin-products.component.html',
  styles: []
})
export class AdminProductsComponent implements OnInit {

  products$;

  constructor(private productService: ProductService) {
    this.products$ = this.productService.getAll();
  }

  ngOnInit() {
  }

}
