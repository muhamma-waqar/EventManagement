import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EventModel } from '../model/EventModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  private baseUrl = 'https://localhost:7144'
  constructor(private httpClient : HttpClient) 
  {
    
  }


  post(e : EventModel): Observable<EventModel>{
    return this.httpClient.post<EventModel>(`${this.baseUrl}/event/create`,e)
  }
}
