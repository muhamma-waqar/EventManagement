import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddEventCommand } from '../../model/AddEventCommand';
import { EventQuery } from '../../model/EventQuery';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  constructor(private httpClient : HttpClient) { }

  post(e : AddEventCommand): Observable<AddEventCommand>{
    return this.httpClient.post<AddEventCommand>('https://localhost:7144/event/create',e)
  }
  get(query: EventQuery ): Observable<Event[]>{
    return this.httpClient.post<Event[]>('https://localhost:7144/getAll/events',query)
  }
}
