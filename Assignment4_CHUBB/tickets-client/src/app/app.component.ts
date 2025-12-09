import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { TicketService } from './services/ticket.service';
import { Ticket } from './models/ticket.model';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [HttpClientModule, CommonModule],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class AppComponent implements OnInit {
  tickets: Ticket[] = [];

  constructor(
    private ticketService: TicketService,
    private cd: ChangeDetectorRef   
  ) {}

  ngOnInit() {
    this.ticketService.getTickets().subscribe({
      next: (data) => {
        console.log("RAW API DATA:", data);
        this.tickets = data;

        this.cd.detectChanges();   
      },
      error: (err) => console.error("API ERROR:", err)
    });
  }
}







