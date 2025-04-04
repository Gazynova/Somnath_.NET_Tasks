
import { Component, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  name: string = '';
  email: string = '';
  username: string = '';
  password: string = '';
  confirmPassword: string = '';

  constructor(private router: Router, private authService: AuthService) {}
@Output() switchToLogin = new EventEmitter<void>();


  register() {
    if (this.password === this.confirmPassword) {
      const userData = { 
        name: this.name, 
        email: this.email, 
        username: this.username, 
        password: this.password, 
        confirmPassword: this.confirmPassword 
      };
  
      this.authService.register(userData).subscribe({
        next: (response) => {
          alert('Registered successfully');
          this.router.navigate(['/login']);
        },
        error: (error) => {
          alert('Registration failed');
          console.error('Registration error:', error);
        }
      });
    } else {
      alert('Passwords do not match');
    }
  }
  

  // navigateToLogin() {
  //   this.router.navigate(['/login']);
  // }

  navigateToLogin() {
    this.switchToLogin.emit();
  }

  
}
