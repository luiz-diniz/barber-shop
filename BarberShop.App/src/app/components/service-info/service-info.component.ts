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
  servicesInfo: ServiceInfo[];

  serviceInfoApi: string = "api/serviceinfo/";

  constructor(private service: WebapiService<ServiceInfo, any>) { 
    this.serviceInfo = new ServiceInfo();
    this.serviceInfo.value = 0;
    this.servicesInfo = [];
    this.GetAllServices();
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
    this.serviceInfo.value = parseFloat(this.serviceInfo.value.toString());

    const api = `${this.serviceInfoApi}CreateServiceInfo`;

    this.service.Create(this.serviceInfo, api).subscribe(
      success => {
        this.showForm = false;
        this.isEditing = false;
        this.GetAllServices();
        this.ResetForm();
      }, 
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }

  GetAllServices(){
    const api = `${this.serviceInfoApi}GetAllServices`;
    this.service.GetAll(api).subscribe(
      servicesInfo => {
        this.servicesInfo = servicesInfo;
        console.log(this.servicesInfo);
      }, 
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }

  Edit(){
    const api = `${this.serviceInfoApi}UpdateServiceInfo`;
    this.service.Edit(this.serviceInfo, api).subscribe(
      success => {
        this.showForm = false;
        this.isEditing = false;
        this.GetAllServices();
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }

  EditInput(serviceInfo: ServiceInfo){
    this.showForm = true;
    this.isEditing = true;
    this.serviceInfo = serviceInfo;
  }

  Delete(serviceInfo: ServiceInfo){
    const api = `${this.serviceInfoApi}DeleteServiceInfo`;
    this.service.Delete(serviceInfo, api).subscribe(
      success => {
        this.GetAllServices();
        this.ResetForm();
      },
      err => {
        console.log(err);
        alert('Error: Contact the administrator.')
      }
    )
  }

  ResetForm(){
    this.serviceInfo = {
      name: '',
      description: '',
      value: 0,
      hide: true
    }
  }
}