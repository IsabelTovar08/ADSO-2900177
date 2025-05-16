import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Laptop, LaptopCreacion } from '../models/laptop.models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LaptopService {

  constructor() { }

    private http = inject(HttpClient)
    private urlBase = environment.apiUrl + '/api/laptops'

    public ObtenerTodos() :Observable<Laptop[]>{
      return this.http.get<Laptop[]>(this.urlBase);
    }

    public ObtenerPorId(id: number): Observable<Laptop> {
      return this.http.get<Laptop>(`${this.urlBase}/${id}`);
    }

    public ExistePorNombre(nombre: string, id: string): Observable<boolean> {
      let params = new HttpParams();
      params = params.append('id', id);
      return this.http.get<boolean>(`${this.urlBase}/${nombre}/existe`, {params});
    }

    public CrearLaptop(laptop: LaptopCreacion){
      return this.http.post(this.urlBase, laptop);
    }

    public Actualizar(id:number, laptop:LaptopCreacion){
      return this.http.put(`${this.urlBase}/${id}`, laptop);
    }

    public Eliminar(id:number){
      return this.http.delete(`${this.urlBase}/${id}`);
    }
}
