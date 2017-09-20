/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 07:13:37
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-19 05:22:02
 */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { BaseProxy } from '../base.proxy';
import { LoginInput } from '../../models/account/login/input';
import { RegisterInput } from '../../models/account/register/input';
import { api } from '../../app.global';

@Injectable()
export class AccountProxy extends BaseProxy {
    authenticate(input: LoginInput, httpParams?): Observable<any> {
        return this._http.post(
            api.account.authenticate,
            input,
            httpParams);
    }

    register(input: RegisterInput, httpParams?): Observable<any> {
        return this._http.post(
            api.account.register,
            input,
            httpParams
        );
    }

    logOut(httpParams?): Observable<any> {
        return this._http.get(
            api.account.logOut,
            httpParams
        );
    }
}
