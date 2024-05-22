import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  constructor() { }

  setItem(key: string, value: any) : void{
    const jsonData = JSON.stringify(value)
    localStorage.setItem(key,jsonData)
  }

  getItem(key: string): any | null {
    const jsonData = localStorage.getItem(key)
    return jsonData ? JSON.parse(jsonData) : null;
  }
}
