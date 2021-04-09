import { Component, OnInit } from '@angular/core';
import { ShopAddress } from 'src/app/models/ShopAddress';
import { WebapiService } from 'src/app/services/webapi.service';

@Component({
  selector: 'app-shop-address',
  templateUrl: './shop-address.component.html',
  styleUrls: ['./shop-address.component.scss']
})
export class ShopAddressComponent implements OnInit {

  shopAddress: ShopAddress;
  shopAddresses: ShopAddress[];

  showForm: boolean = false;
  isEditing: boolean = false;

  shopAddressApi: string = "api/shopAddress/";

  constructor(private service: WebapiService<ShopAddress,any>) { 
    this.shopAddress = new ShopAddress();
    this.shopAddresses = [];

    this.GetAllShopAddresses();
  }

  ngOnInit(): void {
  }

  OnSubmit(){
    if(this.isEditing === true){
      this.Edit();
    }else{
      this.Create();
    }
  }

  Create(){
    const api = `${this.shopAddressApi}CreateShopAddress`;
    this.service.Create(this.shopAddress, api).subscribe(
      success => {
        this.ResetForm();
        this.GetAllShopAddresses();
        this.showForm = false;
      }, 
      err =>{
        console.log(err);
        alert('Error: Contact the administrator.');
      }
    )
  }

  Delete(shop: ShopAddress){
    const api = `${this.shopAddressApi}DeleteShopAddress`;
    this.service.Delete(shop, api).subscribe(
      success => {
        this.GetAllShopAddresses();
        this.ResetForm();
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.');
      }
    )
  }

  Edit(){
    const api = `${this.shopAddressApi}UpdateShopAddress`;
    this.service.Edit(this.shopAddress, api).subscribe(
      success => {
        this.ResetForm();
        this.GetAllShopAddresses();
        this.isEditing = false;
        this.showForm = false;
      },
      err =>{
        console.log(err);
        alert('Error: Contact the administrator.');
      }
    )
  }

  EditInput(shop: ShopAddress){
    this.showForm = true;
    this.isEditing = true;
    this.shopAddress = shop;
  }

  GetAllShopAddresses(){
    const api = `${this.shopAddressApi}GetAllShopAddresses`
    this.service.GetAll(api).subscribe(
      shops => {
        this.shopAddresses = shops;
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.');
      }
    )
  }

  ResetForm(){
    this.shopAddress = {
      name: '',
      street: '',      
      number: 0,
      city: '',
      state: ''
    }
  }
}
