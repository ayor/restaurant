import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  url = 'https://localhost:3000/api/user'
  constructor(private http: HttpClient) { }

  Get(){
    return this.http.get(this.url)
  }

  Add(data){
    return this.http.post(this.url + '/register', data)
  }

  Authenticate(data){
    return this.http.post(this.url + '/login', data)
  }

}
