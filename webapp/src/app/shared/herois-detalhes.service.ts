import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from '../../environments/environment.development';
import { HeroisDetalhe } from './herois-detalhe.model';
import { NgForm } from '@angular/forms';

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
    return this.http.post(this.url,this.formData)
  }

  putHeroisDetalhes() {
    return this.http.put(this.url + '/' + this.formData.id, this.formData)
  }

  searchHeroisDetalhesById(id: number) {
    return this.http.get(this.url + '/' + id)
  }

  deleteHeroisDetalhes(id: number) {
    return this.http.delete(this.url + '/' + id)
  }

  resetForm(form:NgForm) {
    form.form.reset()
    this.formData = new HeroisDetalhe()
  }
}
