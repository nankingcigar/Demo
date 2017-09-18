/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 07:13:37
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-18 09:24:59
 */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { BaseProxy } from '../base.proxy';
import { api } from '../../app.global';
import { User } from '../../models/user/user';
import { User2 } from '../../models/user/user2';

@Injectable()
export class UserProxy extends BaseProxy {
    getCurrentUser(httpParams?): Observable<User> {
        return this._http.get<User>(
            api.user.get
        );
    }

    getAll(httpParams?): Observable<User2> {
      return this._http.get<User2>(
          api.user.getAll
      );
  }
}
