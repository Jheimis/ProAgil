import { Component, OnInit, TemplateRef } from '@angular/core';
import {EventoService} from '../_services/evento.service'
import { Evento } from '../_models/Evento';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {
  eventosFiltrados: Evento[];
  eventos: Evento[];
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImagem = false;
  modalRef: BsModalRef;
  registerForm: FormGroup;

  _filtroLista = '';

  constructor(
    private eventoService : EventoService,
    private modalService: BsModalService
    ) { }
  
  get filtroLista(): string{
    return this._filtroLista;
  }
  set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }

  ngOnInit() {
    this.getEventos();
  }  

  filtrarEventos(filtrarPor: string){
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );
    }
    
    alterarImagem(){
      this.mostrarImagem = !this.mostrarImagem;
    }

    validation(){
      this.registerForm = new FormGroup ({
        tema: new FormControl,
        local: new FormControl,
        dataEvento: new FormControl,
        qtdPessoas: new FormControl,
        imageURL: new FormControl,
        telefone: new FormControl,
        email: new FormControl
      })
    }

    salvarAlteracao(){

    }
    
    getEventos() {
      this.eventoService.getAllEvento().subscribe(( _eventos : Evento[]) => {
        this.eventos = _eventos;
        this.eventosFiltrados = this.eventos;
        console.log(_eventos);
      }, 
      error => {console.log(error); }
      );
    }
    
  }
  