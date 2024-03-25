import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment.prod';
import { Purchase } from '../models/purchase';

@Injectable({
  providedIn: 'root'
})
export class PurchaseService {
  private apiUrl = `${environment.apiUrl}Purchase`;

  constructor(private http: HttpClient) {}

  savePurchases(purchases: Purchase[]): Observable<any> {
    return this.http.post(`${this.apiUrl}/SavePurchases`, purchases);
  }
}
