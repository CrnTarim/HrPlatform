import { Component, Input } from '@angular/core';
import { Company } from './models/company';
import { CompanyService } from './services/company.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'HrPlatform.UI';
 
  constructor(private route:Router){}

  ngOnInit():void {

  }

  gotoCompany()
  {
    this.route.navigate(["/company"]);
  }
   
}
