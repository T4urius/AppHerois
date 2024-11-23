import { Component, OnInit } from '@angular/core';
import { HeroisDetalhesService } from '../../shared/herois-detalhes.service';
import { NgForm } from '@angular/forms';
import { HeroisDetalhe } from '../../shared/herois-detalhe.model';
import { ToastrService } from 'ngx-toastr';
import { SuperpoderDetalhesService } from '../../shared/superpoder-detalhes.service';

@Component({
  selector: 'app-frmherois-detalhes',
  standalone: false,
  
  templateUrl: './frmherois-detalhes.component.html',
  styleUrl: './frmherois-detalhes.component.css'
})
export class FrmheroisDetalhesComponent implements OnInit {

  idsuperpoder = '';
  constructor(public service: HeroisDetalhesService, private toastr: ToastrService, public superpoderService: SuperpoderDetalhesService) {}

  ngOnInit(): void {
    this.superpoderService.refreshList();
  }

  onSubmit(form: NgForm) {
    if(form.valid) {
        if(this.service.formData.id == 0) {
          if(this.service.list.find(item => item.nomeHeroi === form.form.value.nomeHeroi)) {
            this.toastr.warning(form.form.value.nomeHeroi + ' Já existe!!!')
          } else {
            this.insertRecord(form)
          }
        } else {
          this.updateRecord(form)
        }
    } else {
      this.toastr.warning('Preencha corretamente os campos e tente novamente!','Algo deu errado');
    }
  }

  insertRecord(form: NgForm) {
    this.service.postHeroisDetalhes()
        .subscribe({
          next: res => {
            this.service.list.push(res as HeroisDetalhe);
            this.service.resetForm(form);
            this.toastr.success('Inserido com sucesso','Registro do herói');
          },
          error: err => {console.log(err)}
        })
  }
  updateRecord(form: NgForm) {
    this.service.putHeroisDetalhes()
        .subscribe({
          next: res => {
            this.service.list = res as HeroisDetalhe[];
            this.service.resetForm(form);
            this.toastr.info('Atualizado com sucesso','Registro do herói');
          },
          error: err => {console.log(err)}
        })
  }
}
