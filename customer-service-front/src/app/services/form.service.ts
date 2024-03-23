import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment.prod';
import { Agent } from '../models/agent';


@Injectable({
  providedIn: 'root'
})

export class FormService {

  constructor(
    private http: HttpClient
  ) { }

  apiUrl: string = environment.apiUrl;
  url: string = 'Agent/getAgents';

  public getAgents(){
    return this.http.get<Agent[]>(this.apiUrl + this.url);
  }
}
