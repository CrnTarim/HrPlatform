import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from '../models/company';
import { environment } from 'environments/environment';
import { HttpClient } from '@angular/common/http';
import { HrAutho } from '../models/HrAutho';
import { switchMap } from 'rxjs/operators'; 

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  
  private url="Company"

  constructor(private http:HttpClient) { }

  public createCompany(company :Company): Observable<Company[]>{
   
    return this.http.post<Company[]>(`${environment.apiUrl}/${this.url}`,company);
  }


}
