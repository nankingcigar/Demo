/*
 * @Author: Chao Yang
 * @Date: 2017-08-25 08:01:50
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-28 07:56:15
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AccountComponent } from './account.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';

export const ROUTES: Routes = [
  {
    path: 'account',
    component: AccountComponent,
    children: [
      {
        path: 'register',
        component: RegisterComponent
      },
      {
        path: 'login',
        component: LoginComponent
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
    HttpClientModule
  ],
  declarations: [
    AccountComponent,
    RegisterComponent,
    LoginComponent
  ],
  exports: [
    AccountComponent,
    RegisterComponent,
    LoginComponent
  ]
})
export class AccountModule { }
