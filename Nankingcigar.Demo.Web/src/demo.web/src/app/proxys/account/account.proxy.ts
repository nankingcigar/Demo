/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 07:13:37
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-31 06:39:15
 */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { BaseProxy } from '../base.proxy';
import { LoginInput } from '../../models/account/login/input';
import { RegisterInput } from '../../models/account/register/input';
import { api } from '../../../environments/environment';

@Injectable()
export class AccountProxy extends BaseProxy {
    authenticate(input: LoginInput, httpParams?) {
        return this._http.post(
            api.account.authenicate,
            input,
            httpParams);
    }

    register(input: RegisterInput, httpParams?) {
        return this._http.post(
            api.account.register,
            input,
            httpParams
        );
    }
}
