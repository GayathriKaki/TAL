import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CalculatorComponent } from './home/calculator.component';
import { MemberService } from './services/member.service';
import { DataService } from './services/data.service';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,  
    CalculatorComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: CalculatorComponent, pathMatch: 'full'  },
     
    ])
  ],
  providers: [MemberService, DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
