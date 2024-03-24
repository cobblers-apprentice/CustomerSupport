import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment.prod';
import { Agent } from '../models/agent';
import { Form } from '../models/form'; // Import the Form model

@Injectable({
  providedIn: 'root'
})
export class FormService {
  apiUrl: string = environment.apiUrl;
  formUrl: string = 'Form'; // URL for the FormController

  constructor(private http: HttpClient) {}

  public getAgents() {
    return this.http.get<Agent[]>(this.apiUrl + 'Agent/getAgents');
  }

  public getFormsByAgentIdAndDate() {
    return this.http.get<Form[]>(`${this.apiUrl}${this.formUrl}/GetFormsByAgentIdAndDate`);
  }
  public getAgentId() {
    return this.http.get<number>(`${this.apiUrl}${this.formUrl}/getAgentId`);
  }

  public saveForm(form: Form) {
    return this.http.post<Form>(`${this.apiUrl}${this.formUrl}/SaveForm`, form);
  }

  public deleteForm(formId: number) {
    return this.http.delete(`${this.apiUrl}${this.formUrl}/DeleteForm/${formId}`);
  }

  public getCustomerData(customerId: string) {
    return this.http.get(`${this.apiUrl}CustomerService/getCustomerData?id=${customerId}`);
  }
}
