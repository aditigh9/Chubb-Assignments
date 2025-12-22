import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  imports: [CommonModule, FormsModule]
})

export class RegisterComponent {
  username = '';
  password = '';

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}

  register() {
    this.authService
      .register({
        username: this.username,
        password: this.password
      })
      .subscribe({
        next: () => {
          alert('Registered successfully ✅');
          this.router.navigate(['/login']);
        },
        error: (err) => {
          alert('Registration failed ❌');
          console.error(err);
        }
      });
  }
}
