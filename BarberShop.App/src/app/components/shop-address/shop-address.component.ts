import { Component, OnInit } from '@angular/core';
import { ShopAddress } from 'src/app/models/ShopAddress';
import { WebapiService } from 'src/app/services/webapi.service';

@Component({
  selector: 'app-shop-address',
  templateUrl: './shop-address.component.html',
  styleUrls: ['./shop-address.component.scss']
})
export class ShopAddressComponent implements OnInit {

  showForm: boolean = false;
  isEditing: boolean = false;

  shopAddress: ShopAddress;
  shopAddresses: ShopAddress[];

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
        alert('Error: Contact the administrator.')
      }
    )
  }

  Edit(){

  }

  GetAllShopAddresses(){

  }

  ResetForm(){

  }
}
