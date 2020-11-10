import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable, ReplaySubject} from "rxjs";
import {distinctUntilChanged, map} from "rxjs/operators";
import { User } from "../models";
import { Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";


import {ApiService} from "./api.service";
import { environment } from "../../../environments/environment";

@Injectable({ providedIn: 'root' })
export class AccountService {

  private userSubject: BehaviorSubject<User>;
  public user: Observable<User>;

  private currentUserSubject = new BehaviorSubject<User>({} as User);
  public currentUser = this.currentUserSubject.asObservable().pipe(distinctUntilChanged());

  private isAuthenticatedSubject = new ReplaySubject<boolean>(1);
  public isAuthenticated = this.isAuthenticatedSubject.asObservable();

  constructor(
    private router: Router, private http: HttpClient, private api: ApiService) {
    this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('user')));
    this.user = this.userSubject.asObservable();
  }

  public get userValue(): User {
    return this.userSubject.value;
  }

  getCurrentUser(): User {
    return this.currentUserSubject.value;
  }

  login(email, password) {
    return this.http.post<User>(`${environment.apiUrl}/user/login`, {email, password})
      .pipe(map(user => {
        localStorage.setItem('user', JSON.stringify(user));
        this.userSubject.next(user);
        return user;
      }));
  }

  logout(){
    localStorage.removeItem('user');
    this.userSubject.next(null);
    this.router.navigate(['/login']);
  }

  register(user: User): Observable<User> {
    // return this.http.post(`${environment.apiUrl}/users/register`, user);
    return this.api.post('/user/register', user);
  }

  getAll(): Observable<User[]> {
    // return this.http.get<User[]>(`${environment.apiUrl}/user`);
    return this.api.get<User[]>('/user');
  }

  getById(id: string): Observable<User> {
    // return this.http.get<User>(`${environment.apiUrl}/user/${id}`);
    return this.api.get<User>('/user')
  }

  update(id, params) {
    return this.http.put(`${environment.apiUrl}/users/${id}`, params)
      .pipe(map(x => {
        // update stored user if the logged in user updated their own record
        if (id == this.userValue.id) {
          // update local storage
          const user = { ...this.userValue, ...params };
          localStorage.setItem('user', JSON.stringify(user));

          // publish updated user to subscribers
          this.userSubject.next(user);
        }
        return x;
      }));
  }

  delete(id: string) {
    return this.http.delete(`${environment.apiUrl}/users/${id}`)
      .pipe(map(x => {
        // auto logout if the logged in user deleted their own record
        if (id == this.userValue.id) {
          this.logout();
        }
        return x;
      }));
  }
}
