import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyPageComponent } from './screens/company-page/company-page.component';
import { WelcomePageComponent } from './screens/welcome-page/welcome-page.component';
import { CompanyService } from './services/company.service';
import { LoginPageComponent } from './screens/login-page/login-page.component';

const routes: Routes = [

  {path: 'company',component:CompanyPageComponent},
  {path:'welcome',component:WelcomePageComponent},
  {path:'login',component:LoginPageComponent},


  {path:"",redirectTo:"welcome",pathMatch:"full"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
