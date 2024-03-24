import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  username: string = 'bond';
  password: string = '123';
  proba: string;

  constructor(private authService: AuthService, private router: Router) {}

 

  login() {
    // Call the login method in your AuthService
    this.authService.login(this.username, this.password).subscribe(
      (response) => {
        
        this.router.navigate(['/form']); 
      },
      (error) => {
        // Handle login failure, show error message, etc.
        console.error('Login failed:', error);
      }
    );
  }
}
