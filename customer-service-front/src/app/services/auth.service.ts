import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs';
import { environment } from '../environments/environment.prod';
import { jwtDecode as jwt_decode } from 'jwt-decode';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
    readonly localUrl = environment.apiUrl;
    private token: string | null = null;
    public Id: number | null = null;


  constructor(
    private http: HttpClient
  ) { }

  isAuthenticated(): boolean {
    var a = this.getToken();
    return a == null? false : true;
  }

  login(username: string, password: string) {
    const options = {
      responseType: 'text' as 'json'
    };
  
    return this.http.post<string>(
      `${this.localUrl}CustomerService/login`,
      { username, password },
      options 
    ).pipe(
      tap((response: string) => {
        this.token = response;
        const decodedToken: any = jwt_decode(this.token); 
        this.Id = decodedToken.nameid
        localStorage.setItem('userId', JSON.stringify(this.Id));
        // JSON.parse(localStorage.getItem('userId'));
      })
    );
  }  

  logout(){
    this.token = null;
  }

  getToken() : string{
    return this.token;
  }

}


