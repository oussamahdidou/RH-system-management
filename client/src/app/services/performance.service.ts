import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PerformanceService {
  constructor(
    private readonly authservice: AuthService,
    private readonly http: HttpClient
  ) {}
  getabscences(): Observable<any> {
    return this.http.get(`http://localhost:5111/api/Performance/Abscences`);
  }
  justifyabscence(id: number): Observable<any> {
    return this.http.get(`http://localhost:5111/api/Performance/Justify/${id}`);
  }
  addabscence(employerId: any, dateTime: any): Observable<any> {
    return this.http.post(`http://localhost:5111/api/Performance/AddAbscence`, {
      employerId: employerId,
      dateTime: dateTime,
    });
  }
  addsurtemps(employerId: any, dateTime: any): Observable<any> {
    return this.http.post(
      `http://localhost:5111/api/Performance/Heuressupplimentaire`,
      {
        employerId: employerId,
        dateTime: dateTime,
      }
    );
  }
  getconges(): Observable<any> {
    return this.http.get(`http://localhost:5111/api/Conges`);
  }
  approuver(id: any): Observable<any> {
    return this.http.get(`http://localhost:5111/api/Conges/Approuver/${id}`);
  }
  refuser(id: any): Observable<any> {
    return this.http.get(`http://localhost:5111/api/Conges/Refuser/${id}`);
  }
}
