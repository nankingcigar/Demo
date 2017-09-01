
/*
 * @Author: Chao Yang
 * @Date: 2017-08-31 05:47:44
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-01 09:11:24
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { DropdownModule } from 'primeng/primeng';

import { LoginComponent } from './login.component';

@NgModule({
  imports: [
    CommonModule,
    DropdownModule,
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
