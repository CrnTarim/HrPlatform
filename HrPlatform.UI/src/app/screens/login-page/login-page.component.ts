import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HrAutho } from 'src/app/models/HrAutho';
import { LoginPageService } from 'src/app/services/login-page.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {

  admin= new HrAutho();

  constructor(private adminService : LoginPageService, private router:Router ){}

  register(admin : HrAutho)
  {
    
    this.adminService.register(admin).subscribe();
  }

  login(admin : HrAutho)
  {
    this.adminService.login(admin).subscribe(
      (token: string)=>{localStorage.setItem('authToken', token)}

    );
      
  }

}
