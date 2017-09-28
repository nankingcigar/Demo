/*
 * @Author: Chao Yang
 * @Date: 2017-08-31 05:47:44
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-01 09:11:24
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes, Router } from '@angular/router';
import { LoadedRouterConfig } from '@angular/router/src/config.d';
import { TranslateModule } from '@ngx-translate/core';
import { DropdownModule } from 'primeng/primeng';
import * as Enumerable from 'linq/linq';

import { LoginComponent } from './login.component';
import { RoutesService } from '../../services/route/routes.service';

export const ROUTES: Routes = [
  {
    path: '',
    component: LoginComponent,
    data: {
      pageClass: 'page-login',
      title: 'Login - Sign in'
    }
  }
];

@NgModule({
  imports: [
    CommonModule,
    DropdownModule,
    FormsModule,
    TranslateModule.forChild(),
    RouterModule.forChild(
      []
    )
  ],
  declarations: [
    LoginComponent
  ],
  entryComponents: [
    LoginComponent
  ]
})
export class LoginModule {
  constructor(
    private _routesService: RoutesService
  ) {
    this._routesService.get(this.constructor.name);
  }
}
