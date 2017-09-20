/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 07:13:37
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-19 06:00:44
 */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { BaseProxy } from '../base.proxy';
import { api } from '../../app.global';
import { LandingUser } from '../../models/user/landing';
import { GridUser } from '../../models/user/grid';
import { HttpHeaders } from '@angular/common/http';

@Injectable()
export class UserProxy extends BaseProxy {
  getCurrentUser(httpParams?): Observable<LandingUser> {
    return this._http.get<LandingUser>(
      api.user.get
    );
  }

  getAll(httpParams?): Observable<GridUser[]> {
    return this._http.get<GridUser[]>(
      api.user.getAll
    );
  }
}
