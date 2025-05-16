import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { CrearLaptop, Laptop } from '../models/laptop.models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LaptopService {

  constructor() { }
  private http = inject(HttpClient);
  private urlBase = environment.apiURL + '/api/laptops';

  public ObtenerTodos(): Observable<Laptop[]>{
    return this.http.get<Laptop[]>(this.urlBase);
  }

  public ObtenerPorId(id: number): Observable<Laptop>{
    return this.http.get<Laptop>(`${this.urlBase}/${id}`);
  }

  public CrearLaptop(laptop: CrearLaptop){
    console.log("Se esta ingresando a crear laptop")
    return this.http.post(this.urlBase, laptop);
  }

  public ActualizarLaptop(id: number, laptop: CrearLaptop){
    return this.http.put(`${this.urlBase}/${id}`, laptop);
  }

  public EliminarLaptop(id: number){
    return this.http.delete(`${this.urlBase}/${id}`);
  }
}
