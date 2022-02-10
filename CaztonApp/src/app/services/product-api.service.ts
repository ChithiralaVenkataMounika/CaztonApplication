import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { ProductModel } from './../Models/ProductModel'
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ProductApiService {
  url = environment.baseurl+'/Product';
  constructor(private http: HttpClient) { }
  getAllProduct(): Observable<ProductModel[]>{
    return this.http.get<ProductModel[]>(this.url + '/AllProducts');
  }
  getProductById(productId: string): Observable<ProductModel> {
    return this.http.get<ProductModel>(this.url + '/GetProductById/' + productId);
  }
  updateProduct(product: ProductModel): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.put<any>(this.url + '/UpdateProduct/', product, httpOptions);
  }
  deleteProduct(productId: string): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.delete<any>(this.url + '/DeleteProduct/'+ productId, httpOptions);
  }
  addProduct(product: ProductModel): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };
    return this.http.post<any>(this.url + '/CreateProduct/', product, httpOptions);
  }
}
