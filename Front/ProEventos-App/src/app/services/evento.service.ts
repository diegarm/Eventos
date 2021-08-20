import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

@Injectable()
export class EventoService {

  baseURL = 'https://localhost:44351/api/eventos';

constructor(private http:HttpClient) { }


  getEventos() : Observable<Evento[]>
  {
    return this.http.get<Evento[]>(this.baseURL);
  }

  getEventosByTema(tema: string) : Observable<Evento[]>
  {
    return this.http.get<Evento[]>(`${this.baseURL}/tema/${tema}`);
  }

  getEvento(id: number) : Observable<Evento>
  {
    return this.http.get<Evento>(`${this.baseURL}/${id}`);
  }


}
