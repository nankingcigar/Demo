/*
 * @Author: Chao Yang
 * @Date: 2017-09-25 07:14:28
 * @Last Modified by:   Chao Yang
 * @Last Modified time: 2017-09-25 07:14:28
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { DataTableModule, SharedModule } from 'primeng/primeng';

import { HomeComponent } from './home.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ProfileComponent } from './profile/profile.component';
import { UserComponent } from './user/user.component';
import { LogComponent } from './log/log.component';
import { AboutComponent } from './about/about.component';
import { RoutesService } from '../../services/route/routes.service';

export const ROUTES: Routes = [
  {
    path: '',
    component: HomeComponent,
    data: {
      toAuth: true
    },
    children: [
      {
        path: 'dashboard',
        component: DashboardComponent,
        data: {
          pageClass: 'page-home-dashboard',
          title: 'Admin Dashboard Template'
        }
      },
      {
        path: 'profile',
        component: ProfileComponent,
        data: {
          pageClass: 'page-home-profile',
          title: 'Profile'
        }
      },
      {
        path: 'user',
        component: UserComponent,
        data: {
          pageClass: 'page-home-user',
          title: 'Users'
        }
      },
      {
        path: 'log',
        component: LogComponent,
        data: {
          pageClass: 'page-home-log',
          title: 'Logs'
        }
      },
      {
        path: 'about',
        component: AboutComponent,
        data: {
          pageClass: 'page-home-about',
          title: 'About'
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
      []
    ),
    FormsModule,
    HttpClientModule,
    TranslateModule.forChild(),
    SharedModule,
    DataTableModule
  ],
  declarations: [
    HomeComponent,
    DashboardComponent,
    ProfileComponent,
    UserComponent,
    LogComponent,
    AboutComponent
  ],
  entryComponents: [
    HomeComponent,
    DashboardComponent,
    ProfileComponent,
    UserComponent,
    LogComponent,
    AboutComponent
  ]
})
export class HomeModule {
  constructor(
    private _routesService: RoutesService) {
    this._routesService.get(this.constructor.name);
  }
}
