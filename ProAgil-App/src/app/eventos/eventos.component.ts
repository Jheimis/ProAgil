import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  eventos : any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  getEventos(){
    this.eventos = ;
  }

}
