import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private apiUrl = 'https://productsinventoryapi.azurewebsites.net/api/auth';

  constructor(private http: HttpClient) {}

  register(data: { username: string; password: string }) {
    return this.http.post(`${this.apiUrl}/register`, data);
  }

  login(data: { username: string; password: string }) {
    return this.http.post(`${this.apiUrl}/login`, data);
  }
}

