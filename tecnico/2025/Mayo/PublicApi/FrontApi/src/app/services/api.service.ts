import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }
  urlBase = environment.URL;

  public ObtenerTodo(entidad: string) {
    return this.http.get<any>(`${this.urlBase}/${entidad}`);
  }

  public ObtenerPorId(entidad: string, id: number) {
    return this.http.get<any>(`${this.urlBase}/${entidad}/${id}`);
  }
  public Crear(entidad: string, objeto: any) {
    return this.http.post<any>(`${this.urlBase}/${entidad}`, objeto);
  }
  public update(entidad: string, data: any, id: number) {
    return this.http.put(`${this.urlBase}/${entidad}/${id}`, data);
  }
  public delete(entidad: string, id: number) {
    return this.http.delete(`${this.urlBase}/${entidad}/${id}`);
  }
}
