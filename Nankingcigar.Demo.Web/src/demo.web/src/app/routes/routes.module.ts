
/*
 * @Author: Chao Yang
 * @Date: 2017-08-28 07:55:28
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-31 10:03:54
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { LoginModule } from './login/login.module';
import { RegisterModule } from './register/register.module';
import { HomeModule } from './home/home.module';
import { TranslateModule } from '@ngx-translate/core';
import { ServicesModule } from '../services/services.module';

export const ROUTES: Routes = [
  /*
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
  */
  {
    path: '**',
    redirectTo: 'app',
    pathMatch: 'full'
  },
  {
    path: '',
    redirectTo: 'app',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(
      ROUTES
    ),
    ServicesModule,
    LoginModule,
    RegisterModule,
    HomeModule
  ],
  declarations: []
})
export class RoutesModule { }
