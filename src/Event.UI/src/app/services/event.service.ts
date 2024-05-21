import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EventModel } from '../model/EventModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  private baseUrl = ''
  constructor(private httpClient : HttpClient) 
  {
    
  }


  post(e : EventModel): Observable<EventModel>{
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.httpClient.post<EventModel>(`${this.baseUrl}/event/create`,e,{headers})
  }
}
