import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GatewayService {

  constructor(private http: HttpClient) { }
  urlBase = 'http://localhost:5063/api/Gateway';

  enviarUsers(users: any[]) {
    return this.http.post(`${this.urlBase}/guardar-user`, users);
  }

    getUsers(){
    return this.http.get<any>(`${this.urlBase}`);
  }
}
