import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Task } from '../models/task.interface';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }
  url = 'http://localhost:5117/api/Tareas';
  urlCLima = 'http://localhost:5117/WeatherForecast';

  public ObtenerApi(){
    return this.http.get<any>(this.urlCLima);
  }
  public ObtenerTareas(){
    return this.http.get<any>(this.url);
  }

  public ObtenerPorId(id: number): Observable<Task>{
    return this.http.get<Task>(`${this.url}/${id}`)
  }

  public CrearTarea(tarea: Task){
    return this.http.post(this.url, tarea);
  }
  public EditarTarea( id: number, tarea: Task ){
    return this.http.put(`${this.url}/${id}`, tarea);
  }
  public EliminarTarea(id : number){
    return this.http.delete(`${this.url}/${id}`)
  }
}
