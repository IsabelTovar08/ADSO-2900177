import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { CrearProducto, Producto } from '../models/producto.models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductoServiceService {

  constructor() { }

  private http = inject(HttpClient);
  private url = environment.url + '/api/productos';
  private urlPruebaSigec = environment.url ;



  public ObtenerTodo(entidad: string){
    return this.http.get<any>(`${this.urlPruebaSigec}${entidad}/select`);
  }

  public ObteberClima(){
    return this.http.get<any>(this.url);
  }

  public ObtenerProductos() :Observable<Producto[]>{
    return this.http.get<Producto[]>(this.url);
  }

  public ObtenerProductoPorId(id: number) :Observable<Producto>{
    return this.http.get<Producto>(`${this.url}/${id}`)
  }

  public CrearProducto(producto: CrearProducto){
    return this.http.post(this.url, producto)
  }

  public EditarProducto(id: number, producto: CrearProducto){
    return this.http.put(`${this.url}/${id}`, producto)
  }

  public Eliminar(id:number){
    return this.http.delete(`${this.url}/${id}`)
  }
}
