/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 08:28:23
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-31 08:37:27
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CookieService } from 'ngx-cookie-service';

import { ProxysModule } from '../proxys/proxys.module';
import { AccountService } from './account/account.service';

@NgModule({
  imports: [
    CommonModule,
    ProxysModule
  ],
  providers: [
    AccountService,
    CookieService
  ]
})
export class ServicesModule { }
