/*
 * @Author: Chao Yang
 * @Date: 2017-08-28 07:55:28
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-28 01:57:43
 */
import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router } from '@angular/router';

import { AppModule } from '../app.module';
import { LocalizationService } from '../services/localization/localization.service';
import { RoutesService } from '../services/route/routes.service';

console.log(app.moduleRef);
export const ROUTES: Routes = [
  {
    path: 'login',
    loadChildren: './login/login.module#LoginModule'
  },
  {
    path: 'register',
    loadChildren: './register/register.module#RegisterModule'
  },
  {
    path: 'home',
    loadChildren: './home/home.module#HomeModule'
  },
  {
    path: '**',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(
      []
    )
  ],
  declarations: []
})
export class RoutesModule {
  constructor(
    private _routesService: RoutesService,
    private _localizationService: LocalizationService) {
    this._localizationService.init();
    this._routesService.get(this.constructor.name);
  }
}
