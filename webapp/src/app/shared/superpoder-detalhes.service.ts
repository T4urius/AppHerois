import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from '../../environments/environment.development';
import { HeroisDetalhe } from './herois-detalhe.model';
import { NgForm } from '@angular/forms';
import { SuperpoderDetalhe } from './superpoder-detalhe.model';

@Injectable({
  providedIn: 'root'
})
export class SuperpoderDetalhesService {

  url: string = environment.apiBaseUrl + '/Superpoderes'
  list: SuperpoderDetalhe[] = []
  formData : SuperpoderDetalhe = new SuperpoderDetalhe()

  constructor(private http: HttpClient) { }

  refreshList() {
    this.http.get(this.url)
      .subscribe({
        next: res => {
          this.list = res as SuperpoderDetalhe[]
        },
        error: err => { console.log(err)}
      })
  }

  postSuperpoderDetalhes() {
    return this.http.post(this.url,this.formData)
  }

  putSuperpoderDetalhes() {
    return this.http.put(this.url + '/' + this.formData.id, this.formData)
  }

  searchSuperpoderDetalhesById(id: number) {
    return this.http.get(this.url + '/' + id)
  }

  deleteSuperpoderDetalhes(id: number) {
    return this.http.delete(this.url + '/' + id)
  }

  resetForm(form:NgForm) {
    form.form.reset()
    this.formData = new SuperpoderDetalhe()
  }
}
