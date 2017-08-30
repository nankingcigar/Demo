/*
 * @Author: Chao Yang
 * @Date: 2017-08-25 07:52:42
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-29 07:54:13
 */
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { environment } from '../environments/environment';
import { RoutesModule } from './routes/routes.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(
      [],
      {
        enableTracing: environment.production ? false : true,
        useHash: true
      }
    ),
    RoutesModule
  ],
  providers: [
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
