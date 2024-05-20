import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginResponseDto } from '../Dtos/LoginResponseDto';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private apiUrl = 'https://localhost:7144'
  constructor(private httpClient : HttpClient) { }

  login(username : string, password: string): Observable<LoginResponseDto>{
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.httpClient.post<LoginResponseDto>(`${this.apiUrl}/login?username=${username}&password=${password}`,{headers});
  }
}
