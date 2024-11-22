import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from '../../environments/environment.development';
import { HeroisDetalhe } from './herois-detalhe.model';

@Injectable({
  providedIn: 'root'
})
export class HeroisDetalhesService {

  url: string = environment.apiBaseUrl + '/Herois'
  list: HeroisDetalhe[] = []
  formData : HeroisDetalhe = new HeroisDetalhe()

  constructor(private http: HttpClient) { }

  refreshList() {
    this.http.get(this.url)
      .subscribe({
        next: res => {
          this.list = res as HeroisDetalhe[]
        },
        error: err => { console.log(err)}
      })
  }

  postHeroisDetalhes() {
    debugger;
    return this.http.post(this.url,this.formData)
  }
}
