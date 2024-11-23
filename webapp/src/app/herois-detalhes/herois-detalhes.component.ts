import { Component, model, OnInit } from '@angular/core';
import { HeroisDetalhesService } from '../shared/herois-detalhes.service';
import { HeroisDetalhe } from '../shared/herois-detalhe.model';
import { ToastrService } from 'ngx-toastr';
import { SuperpoderDetalhesService } from '../shared/superpoder-detalhes.service';

@Component({
  selector: 'app-herois-detalhes',
  standalone: false,
  
  templateUrl: './herois-detalhes.component.html',
  styleUrl: './herois-detalhes.component.css'
})
export class HeroisDetalhesComponent implements OnInit{

  idPesquisa: number = 0;
  
  constructor(public heroisService: HeroisDetalhesService, private toastr: ToastrService, private superpoderService: SuperpoderDetalhesService) {  }

  ngOnInit(): void {
    this.heroisService.refreshList();
  }

  pesquisar() {
    this.heroisService.searchHeroisDetalhesById(this.idPesquisa)
    .subscribe({
      next: res => {
        if (res == null) {
          this.toastr.warning('Nenhum herói encontrado com este código', 'Aviso');
        } else {
          this.heroisService.list = res as HeroisDetalhe[];
        }
      },
      error: err => {console.log(err)}
    });
  }

  selecionarLinha(selectedRecord:HeroisDetalhe) {
    this.heroisService.formData = Object.assign({},selectedRecord);
  }

  onDelete(id: number) {
    if(confirm('Tem certeza que deseja excluir esse herói?')) {
      this.heroisService.deleteHeroisDetalhes(id)
      .subscribe({
        next: res => {
          this.heroisService.list = res as HeroisDetalhe[];
          this.toastr.error('Deletado com sucesso','Registro do herói');
        },
        error: err => {console.log(err)}
      })
    }
  }
}
