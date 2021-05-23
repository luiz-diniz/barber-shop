import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FormatService {

  constructor() { }

  FormatCPF(cpf: string){
    return cpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, "$1.$2.$3-$4");
  }

  FormatPhone(phone: string){
    return phone.replace(/(\d{2})(\d{5})(\d{4})/, "($1) $2-$3");
  }
}