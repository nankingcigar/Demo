/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 07:14:26
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-04 08:40:04
 */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { BaseService } from '../base.service';
import { UserProxy } from '../../proxys/user/user.proxy';
import { User } from '../../models/user/user';
import { environment } from '../../../environments/environment';

@Injectable()
export class UserService extends BaseService {
    constructor(
        private _userProxy: UserProxy) {
        super();
    }

    getCurrentUser(): Observable<User> {
        return this._userProxy.getCurrentUser();
    }
}
