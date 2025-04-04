// auth.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import{jwtDecode} from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7176/api/auth';


  constructor(private http: HttpClient) {}

  login(email: string, password: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, { email, password }).pipe(
      tap((response: any) => {
        if (response.token) {
          localStorage.setItem('token', response.token);
          console.log(response.token);
          console.log(response.token.sub);
          console.log(response.token.email);
        //   const userrole = decodedtoken["roles"];
        const token=response.token;
        const decodedtoken : any= jwtDecode(token);
        const userrole = decodedtoken["roles"];
        const useremail = decodedtoken["email"];
        const userId = decodedtoken["uid"];
        
        console.log(userrole);

        localStorage.setItem('role',userrole);
         // Store user role
        localStorage.setItem('userId', userId);
        console.log(userId);
        localStorage.setItem('email',useremail);

        }
      })
    );
  }

  register(userData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, userData);
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('role');
    alert('Logged out successfully');
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem('token');
  }

  getUserRole(): string | null {
    return localStorage.getItem('role');
  }
  getUserName():string|null{
    return localStorage.getItem('');
  }
  getUserEmail():string|null{
    return localStorage.getItem('email');
  }

  getUserId():string|null{
    return localStorage.getItem('userId');
  }

  
}
