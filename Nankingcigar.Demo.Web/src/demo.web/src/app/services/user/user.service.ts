/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 07:14:26
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-19 06:00:38
 */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { BaseService } from '../base.service';
import { UserProxy } from '../../proxies/user/user.proxy';
import { LandingUser } from '../../models/user/landing';
import { GridUser } from '../../models/user/grid';

@Injectable()
export class UserService extends BaseService {
  constructor(
    private _userProxy: UserProxy) {
    super();
  }

  getCurrentUser(): Observable<LandingUser> {
    return this._userProxy.getCurrentUser();
  }

  getAll(): Observable<GridUser[]> {
    return this._userProxy.getAll();
  }
}
