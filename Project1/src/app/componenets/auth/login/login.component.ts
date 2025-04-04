import { Component, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../auth.service';

declare var bootstrap: any; // 👈 Required for using Bootstrap modal

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = '';
  password: string = '';

  constructor(private router: Router, private authService: AuthService) {}
  @Output() switchToRegister = new EventEmitter<void>();


  login() {
    if (this.email && this.password) {
      this.authService.login(this.email, this.password).subscribe(
        (response) => {
          alert('Logged in successfully');

          // 👇 Close the modal after successful login
          const modalElement = document.getElementById('loginModal');
          if (modalElement) {
            const modalInstance = bootstrap.Modal.getInstance(modalElement);
            modalInstance?.hide();
          }

          const userrole = this.authService.getUserRole();
          console.log(userrole);
          if (userrole === 'Administrator') {
            this.router.navigate(['/admindashboard']);
          } else {
            this.router.navigate(['/userdashboard']);
          }
        },
        (error) => {
          alert('Login failed');
        }
      );
    }
  }

  // navigateToRegister() {
  //   this.router.navigate(['/register']);
  // }

  navigateToRegister() {
    this.switchToRegister.emit();
  }
}
