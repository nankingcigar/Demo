/*
 * @Author: Chao Yang
 * @Date: 2017-08-25 07:52:42
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-31 04:18:55
 */
import { HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, PreloadAllModules, NoPreloading } from '@angular/router';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateModule, TranslateLoader, TranslateService } from '@ngx-translate/core';

import { AppComponent } from './app.component';
import { environment } from '../environments/environment';
import { RoutesModule } from './routes/routes.module';
import { DemoInterceptor } from './app.interceptor';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json?v=' + (new Date()).getTime());
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    NoopAnimationsModule,
    RouterModule.forRoot(
      [],
      {
        enableTracing: environment.production ? false : true,
        useHash: true,
        preloadingStrategy: environment.production ? PreloadAllModules : NoPreloading
      }
    ),
    RoutesModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: (HttpLoaderFactory),
        deps: [HttpClient]
      }
    })
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: DemoInterceptor,
      multi: true
    }
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
