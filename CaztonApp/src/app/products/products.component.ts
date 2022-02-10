import { Component, OnInit } from '@angular/core';
import {ProductApiService} from './../services/product-api.service';
@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  listOfproducts:any[];
  constructor(private productApi:ProductApiService) { }

  ngOnInit(): void {
  }
  getAllProducts(){
    this.productApi.getAllProduct().subscribe(data=>{
      console.log(data);
    })
  }

}
