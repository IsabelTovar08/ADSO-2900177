import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }
  urlBase = environment.URL +'api';

  public ObtenerTodo(entidad: string){
    console.log("uuu")
    return this.http.get<any>(`${this.urlBase}/${entidad}`);
  }
  public Crear(entidad: string, objeto: any){
    return this.http.post<any>(`${this.urlBase}/${entidad}`, objeto);
  }

  public update(entidad:string, data: any) {
    return this.http.put(`${this.urlBase}/${entidad}/update/`,data);
  }
  public delete(entidad: string, id: number) {
    return this.http.delete(`${this.urlBase}/${entidad}/${id}`);
  }
  public deleteLogic(entidad: string, id: number) {
    return this.http.delete(`${this.urlBase}/${entidad}/toggleActive/${id}`);
  }
  public login(credentials: { userName: string, password: string }) {
    return this.http.post<any>(`${this.urlBase}/Auth/login`, credentials);
  }
}
