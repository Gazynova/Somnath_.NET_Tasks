import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { LoginComponent } from '../../auth/login/login.component'; // ✅ Adjust the path if needed
import { RegisterComponent } from '../../auth/register/register.component';

declare var bootstrap: any;

@Component({
  selector: 'app-header',
  standalone: true,
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  imports: [CommonModule, LoginComponent,RegisterComponent] 
})
export class HeaderComponent {
  @Input() showLogout: boolean = false;
  @Output() onShowLogin = new EventEmitter<void>();
  @Output() onShowRegister = new EventEmitter<void>();

  constructor(private router: Router) { }

  logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }

  openLoginModal() {
    const loginModal = new bootstrap.Modal(document.getElementById('loginModal'));
    loginModal.show();
  }

  openRegisterModal() {
    const registerModal = new bootstrap.Modal(document.getElementById('registerModal'));
    registerModal.show();
  }

  openRegisterFromLogin() {
    const loginModalEl = document.getElementById('loginModal');
    const loginModal = bootstrap.Modal.getInstance(loginModalEl);
    loginModal?.hide();

    setTimeout(() => this.openRegisterModal(), 300); // small delay for smooth transition
  }

  openLoginFromRegister() {
    const registerModalEl = document.getElementById('registerModal');
    const registerModal = bootstrap.Modal.getInstance(registerModalEl);
    registerModal?.hide();

    setTimeout(() => this.openLoginModal(), 300);
  }

}
