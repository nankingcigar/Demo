/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 07:13:37
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-19 05:22:02
 */
import { Injectable } from '@angular/core';
import { Routes } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { BaseProxy } from '../base.proxy';
import { api } from '../../app.global';

@Injectable()
export class RouteProxy extends BaseProxy {

  get(module: string, httpParams?): Observable<any> {
    return this._http.get<any>(
      api.route.get + module,
      httpParams
    );
  }
}
