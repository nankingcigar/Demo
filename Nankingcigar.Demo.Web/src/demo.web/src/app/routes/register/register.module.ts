/*
 * @Author: Chao Yang
 * @Date: 2017-08-31 05:47:48
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-31 07:14:19
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes, Router } from '@angular/router';
import { LoadedRouterConfig } from '@angular/router/src/config.d';
import { FormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';

import { RegisterComponent } from './register.component';
import { RoutesService } from '../../services/route/routes.service';

/*
export const ROUTES: Routes = [
  {
    path: '',
    component: RegisterComponent,
    data: {
      pageClass: 'page-register',
      title: 'Login - Sign up'
      }
    }
];
*/
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    TranslateModule.forChild(),
    RouterModule.forChild(
      []
    )
  ],
  declarations: [
    RegisterComponent
  ],
  entryComponents: [
    RegisterComponent
  ]
})
export class RegisterModule {
  constructor(
    private _routesService: RoutesService
  ) {
    this._routesService.get(this.constructor.name);
  }
}
