import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';

import { HomeComponent } from './home.component';
import { DashboardComponent } from './dashboard/dashboard.component';

export const ROUTES: Routes = [
  {
    path: 'app',
    component: HomeComponent,
    data: {
      toAuth: true,
    },
    children: [
      {
        path: 'dashboard',
        component: DashboardComponent,
        data: {
          pageClass: 'page-dashboard',
          title: 'Dashboard'
        }
      },
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'dashboard'
      }
    ]
  }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(
      ROUTES
    ),
    FormsModule,
    HttpClientModule,
    TranslateModule.forChild()
  ],
  declarations: [
    HomeComponent,
    DashboardComponent
  ],
  exports: [
    HomeComponent,
    DashboardComponent
  ]
})
export class HomeModule { }
