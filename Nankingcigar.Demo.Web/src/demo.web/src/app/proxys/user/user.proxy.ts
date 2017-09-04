/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 07:13:37
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-04 09:15:27
 */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { BaseProxy } from '../base.proxy';
import { api } from '../../app.global';
import { User } from '../../models/user/user';

@Injectable()
export class UserProxy extends BaseProxy {
    getCurrentUser(httpParams?): Observable<User> {
        return this._http.get<User>(
            api.user.getCurrentUser
        );
    }
}
