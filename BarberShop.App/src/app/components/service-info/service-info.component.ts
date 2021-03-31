import { Component, OnInit } from '@angular/core';
import { ServiceInfo } from 'src/app/models/ServiceInfo';
import { WebapiService } from 'src/app/services/webapi.service';

@Component({
  selector: 'app-service-info',
  templateUrl: './service-info.component.html',
  styleUrls: ['./service-info.component.scss']
})

export class ServiceInfoComponent implements OnInit {

  showForm: boolean = false;
  isEditing: boolean = false;
  
  serviceInfo: ServiceInfo;

  serviceInfoApi: string = "api/serviceinfo/";

  constructor(private service: WebapiService<ServiceInfo, any>) { 
    this.serviceInfo = new ServiceInfo();
  }

  ngOnInit(): void {
  }

  OnSubmit(){
    if(this.isEditing === true){

    }else{
      this.Create();
    }
  }

  Create(){
    this.serviceInfo.value = parseFloat(this.serviceInfo.value.toString());
    console.log(this.serviceInfo)
    const api = `${this.serviceInfoApi}CreateServiceInfo`
    this.service.Create(this.serviceInfo, api).subscribe(
      success => {
        console.log("foi");
      }, 
      err => {
        console.log(err);
        console.log("erro");
      }
    )
  }
}