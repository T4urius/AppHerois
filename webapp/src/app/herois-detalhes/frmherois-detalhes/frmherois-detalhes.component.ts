import { Component } from '@angular/core';
import { HeroisDetalhesService } from '../../shared/herois-detalhes.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-frmherois-detalhes',
  standalone: false,
  
  templateUrl: './frmherois-detalhes.component.html',
  styleUrl: './frmherois-detalhes.component.css'
})
export class FrmheroisDetalhesComponent {

  constructor(public service: HeroisDetalhesService) {
    
  }

  onSubmit(form: NgForm) {
    this.service.postHeroisDetalhes()
    .subscribe({
      next: res => {
        console.log(res);
      },
      error: err => {console.log}
    })
  }
}
