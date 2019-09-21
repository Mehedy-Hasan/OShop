import { ToastrService } from 'ngx-toastr';
import { ProductService } from './../../service/product.service';
import { Component, OnInit, EventEmitter } from '@angular/core';
import { CategoryService } from 'src/app/service/category.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent implements OnInit {
  category;

  constructor(
    private categoryService: CategoryService,
    private productService: ProductService,
    private toaster: ToastrService,
    private router: Router) { }

  ngOnInit() {
    this.categoryService.getAll().subscribe(categoryList => {
      this.category = categoryList;
      // console.log('category', this.category);
    });
  }

  save() {
    this.productService.Create().subscribe(
      (res: any) => {
          this.productService.formModel.reset();
          this.toaster.success('New user created', 'User Registration');
          this.router.navigate(['/admin/products']);
      },
      err => {
        console.log(err);
      }
    );
  }

}
