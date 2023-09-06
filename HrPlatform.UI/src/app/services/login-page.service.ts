import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HrAutho } from '../models/HrAutho';
import { environment } from 'environments/environment.prod';
import { Observable, map, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginPageService {

  private url1="Hr/register";
  private url2="Hr/login";

  constructor(private http:HttpClient,private router:Router) { }

  public register(admin :HrAutho): Observable<any>{  
    return this.http.post<any>(`${environment.apiUrl}/${this.url1}`,admin);
  }
  
  public login(admin :HrAutho): Observable<string>{  
    return this.http.post(`${environment.apiUrl}/${this.url2}`,admin,{responseType: 'text'});
  }

  // public login(admin :UserAutho): Observable<string>{  
  //   return this.http.post(`${environment.apiUrl}/${this.url2}`,admin,{responseType: 'text',})
  //   .pipe(
  //     tap((response: string) => {
  //       if (response.length > 20) {
  //         this.router.navigate(['/mainPage]);
  //       }
  //     }));
  // }


}
