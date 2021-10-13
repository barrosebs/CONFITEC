import { Component, OnInit } from '@angular/core';
import { CondutorService } from '../service/condutor.service';

@Component({
  selector: 'app-condutor',
  templateUrl: './condutor.component.html',
  styleUrls: ['./condutor.component.scss']
})
export class CondutorComponent implements OnInit {
  _filtroList: string;
  get filtroList(): string{
    return this._filtroList;
  }

  set filtroList(value: string){
    this._filtroList = value;
    this.condutoresFiltrados = this._filtroList ? this.filtroCondutor(this.filtroList) : this.condutores;
  }
  condutoresFiltrados: any = [];
  
  titlePage = 'CONDUTOR';

  condutores: any = [];

  constructor(private condutorService: CondutorService) { }

  ngOnInit() {
    this.getCondutor();
  }
  filtroCondutor(filtrarPor: string): any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.condutores.filter(
      condutor => condutor.nome.toLocaleLowerCase().indexof(filtrarPor) !== -1
    );
  }
  getCondutor(){
    this.condutorService.getCondutor().subscribe(
      response => { this.condutores = response ;},
      error => {
        console.log(error);
      });
      
  }

}
