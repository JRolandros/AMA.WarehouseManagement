import { Component } from '@angular/core';
import { Product } from '../models/products';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-product-list',
  imports: [],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.less'
})
export class ProductListComponent {
  products: Product[] = [];
  readonly limit = 10;
  offset:number=0;
  totalProducts=0;
  constructor(private _productService: ProductService) {}

  ngOnInit(): void {
    this.loadPage();
    this.totalProducts=30;// I could have set and endpoint to bring the total items or just overload the productDto object to include data and the size.
  }

  loadPage(): void {
    this._productService.getPage(this.offset, this.limit).subscribe(
      {
        next: (data) => {
          this.products = data;
        },
        error : (e)=>{console.log(e);
        }
      }
    );
  }

  get currentPage(): number {
    return Math.floor(this.offset / this.limit);
  }
  get totalPages(): number {
    return Math.ceil(this.totalProducts / this.limit);
  }

  firstPage(): void {
    this.offset = 0;
    this.loadPage();
  }
  lastPage(): void {
    this.offset = (this.totalPages - 1) * this.limit;
    this.loadPage();
  }

  nextPage():void{
    this.offset += this.limit;
    this.loadPage();
  }
  prevPage(): void {
    if (this.offset >= this.limit) {
      this.offset -= this.limit;
      this.loadPage();
    }
  }

  isLastPage(): boolean {
    return this.offset + this.limit >= this.totalProducts;
  }

}
