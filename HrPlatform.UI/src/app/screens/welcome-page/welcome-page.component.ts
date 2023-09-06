import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-welcome-page',
  templateUrl: './welcome-page.component.html',
  styleUrls: ['./welcome-page.component.css']
})
export class WelcomePageComponent {

  constructor(private route:Router){}

  gotoCompany():void
  {
    this.route.navigate(["/company"]);
  }
}
