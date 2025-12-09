import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Ticket } from '../models/ticket.model';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  private apiUrl = 'http://localhost:5255/api/Tickets';

  constructor(private http: HttpClient) {}

  getTickets(): Observable<Ticket[]> {
    return this.http.get<Ticket[]>(this.apiUrl);
  }
}


