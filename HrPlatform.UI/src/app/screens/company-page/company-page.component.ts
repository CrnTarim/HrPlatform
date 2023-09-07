import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HrAutho } from 'src/app/models/HrAutho';
import { Company } from 'src/app/models/company';
import { CompanyService } from 'src/app/services/company.service';

@Component({
  selector: 'app-company-page',
  templateUrl: './company-page.component.html',
  styleUrls: ['./company-page.component.css']
})
export class CompanyPageComponent {
  
  company: Company = new Company();
  
  constructor(private companyService: CompanyService,private route:Router){}

  ngOnInit():void {

  }

  createCompany(company: Company){

    this.companyService.createCompany(this.company).subscribe(response => {
      console.log('Company created:', response);  
    });

    localStorage.setItem('companyGuid', company.companyId);
  }

  gotoLogin():void
  {
    this.route.navigate(["/login"]);
  }

}
