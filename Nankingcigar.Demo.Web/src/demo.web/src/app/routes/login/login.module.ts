/*
 * @Author: Chao Yang
 * @Date: 2017-08-31 05:47:44
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-31 10:00:32
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';

import { LoginComponent } from './login.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    TranslateModule.forChild(),
    RouterModule.forChild(
      [
        {
          path: 'login',
          component: LoginComponent,
          data: {
            pageClass: 'page-login',
            title: 'Login - Sign in'
          }
        }
      ]
    )
  ],
  declarations: [
    LoginComponent
  ],
  exports: [
    LoginComponent
  ]
})
export class LoginModule { }
