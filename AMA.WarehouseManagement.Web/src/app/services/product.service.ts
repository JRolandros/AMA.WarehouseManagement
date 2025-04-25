import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/products';

const apiRoutes = {
  getPage: (offset: number,limit:number) => `/api/products/getpage?offset=${offset}&limit=${limit}`
}

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private _http:HttpClient) { }


  getPage(offset:number,limit:number) : Observable<Product[]>{
    let headers=new HttpHeaders({
      'content-type': 'application/json'
    });

    return this._http.get<Product[]>(apiRoutes.getPage(offset,limit),{headers:headers});
  }
}
