import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {TokenInterceptor} from "../interceptors";
import {Observable, throwError} from "rxjs";
import {environment} from "../../../environments/environment";
import {catchError, retry} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  private static formatErrors(err: any){
    return throwError(err.error)
  }

  get<T>(path: string, params: HttpParams = new HttpParams()): Observable<T> {
    return this.http.get<T>(`${environment.apiUrl}${path}`, { params })
      .pipe(retry(1), catchError(ApiService.formatErrors));
  }

  put(path: string, body: Object = {}): Observable<any> {
    return this.http.put(`${environment.apiUrl}${path}`, JSON.stringify(body))
      .pipe(retry(1), catchError(ApiService.formatErrors));
  }

  post<T>(path: string, body: Object = {}): Observable<T> {
    return this.http.post<T>(`${environment.apiUrl}${path}`, JSON.stringify(body))
      .pipe(retry(1), catchError(ApiService.formatErrors));
  }

  delete(path): Observable<any> {
    return this.http.delete(`${environment}${path}`)
      .pipe(retry(1), catchError(ApiService.formatErrors));
  }
}
