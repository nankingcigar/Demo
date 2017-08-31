/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 08:28:31
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-31 06:01:04
 */
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { AccountProxy } from './account/account.proxy';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule
  ],
  providers: [
    AccountProxy
  ]
})
export class ProxysModule { }
