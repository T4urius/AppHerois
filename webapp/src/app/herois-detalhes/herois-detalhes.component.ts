import { Component, OnInit } from '@angular/core';
import { HeroisDetalhesService } from '../shared/herois-detalhes.service';

@Component({
  selector: 'app-herois-detalhes',
  standalone: false,
  
  templateUrl: './herois-detalhes.component.html',
  styleUrl: './herois-detalhes.component.css'
})
export class HeroisDetalhesComponent implements OnInit{

  constructor(public service: HeroisDetalhesService) {  }

  ngOnInit(): void {
    this.service.refreshList();
  }
}
