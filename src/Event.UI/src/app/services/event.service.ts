import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AddEventCommand } from '../model/AddEventCommand';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  private baseUrl = 'https://localhost:7144'
  constructor(private httpClient : HttpClient) { }

  post(e : AddEventCommand): Observable<AddEventCommand>{
    return this.httpClient.post<AddEventCommand>('https://localhost:7144/event/create',e)
  }
}
