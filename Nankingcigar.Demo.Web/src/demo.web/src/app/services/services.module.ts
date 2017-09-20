/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 08:28:23
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-19 02:32:11
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CookieService } from 'ngx-cookie-service';

import { ProxiesModule } from '../proxies/proxies.module';
import { AccountService } from './account/account.service';
import { UserService } from './user/user.service';
import { LocalizationService } from './localization/localization.service';
import { RouteService } from './route/route.service';

@NgModule({
  imports: [
    CommonModule,
    ProxiesModule
  ],
  providers: [
    AccountService,
    CookieService,
    UserService,
    LocalizationService,
    RouteService
  ]
})
export class ServicesModule { }
