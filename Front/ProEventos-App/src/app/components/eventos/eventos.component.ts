import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { Evento } from 'src/app/models/Evento';
import { EventoService } from 'src/app/services/evento.service';



@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})

export class EventosComponent implements OnInit {
  modalRef?: BsModalRef;
  public eventosFiltrados: Evento[] = [];
  public eventos: Evento[] = [];

  public imgWidth = 50;
  public imgMargin = 2;
  public isImage = true;

  private _filtroLista: string = '';

  public get filtroLista(): string{
    return this._filtroLista;
  }
  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarElementos(this.filtroLista) : this.eventos;
  }

  public filtrarElementos(filtrarPor: string): Evento[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter((evento: { tema: string; }) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1)
  }


  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
    ) { }

  ngOnInit() {
    this.spinner.show();
    this.getEventos();
  }

  public getEventos(): void{
    this.eventoService.getEventos().subscribe(
      {
          next: (eventos: Evento[]) =>{
            this.eventos = eventos;
            this.eventosFiltrados = this.eventos;
          },

          error: (error: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao consultar os eventos','Erro');
          },

          complete: () => this.spinner.hide()
      }
    );

    this.spinner.show();

    setTimeout(() => {
      /** spinner ends after 5 seconds */
      this.spinner.hide();
    }, 5000);
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    if(this.modalRef){
      this.modalRef.hide();
      this.toastr.success('O evento foi deletado com sucesso!', 'Deletado');
    }

  }

  decline(): void {
    if(this.modalRef){
      this.modalRef.hide();
    }
  }


}
