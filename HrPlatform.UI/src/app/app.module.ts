import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { EmailVerifyPageComponent } from './screens/email-verify-page/email-verify-page.component';
import { CompanyPageComponent } from './screens/company-page/company-page.component';
import { WelcomePageComponent } from './screens/welcome-page/welcome-page.component';
import { LoginPageComponent } from './screens/login-page/login-page.component';


@NgModule({
  declarations: [
    
    AppComponent,
          EmailVerifyPageComponent,
          CompanyPageComponent,
          WelcomePageComponent,
          LoginPageComponent,
         
          
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, 
    HttpClientModule,
    FormsModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
