import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Delete } from '../../Models/delete.models';

@Injectable({
  providedIn: 'root'
})
export class GatewayService {

  constructor(private http: HttpClient) { }
  urlBase = 'http://localhost:5063/api/Gateway';
  urlBasePublic = 'http://localhost:5063/api/PublicGateway';


  enviarUsers(users: any[]) {
    return this.http.post(`${this.urlBase}/guardar-user`, users);
  }

    getUsers(){
    return this.http.get<any>(`${this.urlBase}`);
  }

      getUsersPublic(){
    return this.http.get<any>(`${this.urlBasePublic}`);
  }

  
    updateUsers(user: any){
    return this.http.put<any>(`${this.urlBase}/actualizar-user`, user);
  }

   public deleteUser(id: number){
    return this.http.delete(`${this.urlBase}/eliminar-user/${id}`);
  }

}
