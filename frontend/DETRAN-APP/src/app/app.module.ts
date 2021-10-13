import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { APP_BASE_HREF } from '@angular/common';
import { CondutorComponent } from './condutor/condutor.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [		
    AppComponent,
      NavComponent,
      CondutorComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
   // {provide: APP_BASE_HREF, useValue: 'detranapp'}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
