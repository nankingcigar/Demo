/*
 * @Author: Chao Yang
 * @Date: 2017-08-31 05:47:48
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-31 07:14:19
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';

import { RegisterComponent } from './register.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    TranslateModule.forChild(),
    RouterModule.forChild(
      [
        {
          path: 'register',
          component: RegisterComponent,
          data: {
            pageClass: 'page-register',
            title: 'Login - Sign up'
          }
        }
      ]
    )
  ],
  declarations: [
    RegisterComponent
  ],
  exports: [
  ]
})
export class RegisterModule { }
