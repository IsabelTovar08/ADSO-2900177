import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Libro, LibroCrear } from '../Models/Libro.nodels';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LibrosService {

  private http = inject(HttpClient)
  private urlBase = environment.url + '/Api/Libros';
  constructor() { }

  public ObtenerLibros(){
    return this.http.get<any>(this.urlBase);
  }
  public ObtenrrLibroPorId(id: number): Observable<Libro>{
    return this.http.get<Libro>(`${this.urlBase}/${id}`)
  }
  public CrearLibro(libro: LibroCrear){
    return this.http.post<LibroCrear>(this.urlBase, libro);
  }
  public ActualizarLibro(id:number, libro: LibroCrear){
    return this.http.put(`${this.urlBase}/${id}`, libro);
  }
  public EliminarLibro(id:number){
    return this.http.delete(`${this.urlBase}/${id}`)
  }
}
