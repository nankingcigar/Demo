/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 07:14:26
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-05 09:09:50
 */
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

import { BaseService } from '../base.service';
import { AccountProxy } from '../../proxys/account/account.proxy';
import { LoginInput } from '../../models/account/login/input';
import { RegisterInput } from '../../models/account/register/input';

@Injectable()
export class AccountService extends BaseService {
    constructor(
        private _accountProxy: AccountProxy,
        private _cookieService: CookieService) {
        super();
    }

    authenticate(input: LoginInput) {
        return this.observable(
            (resolve, reject) => {
                this._accountProxy.authenticate(input).subscribe(
                    data => {
                        this._cookieService.set(app.environment.sessionKey, input.userName);
                        resolve(data);
                    },
                    err => {
                        reject(err);
                    }
                );
            }
        );
    }

    register(input: RegisterInput) {
        return this._accountProxy.register(input);
    }

    canActivate() {
        return this._cookieService.check(app.environment.sessionKey);
    }

    logOut() {
        this._cookieService.delete(app.environment.sessionKey);
        return this.observable(
            (resolve, reject) => {
                this._accountProxy.logOut().subscribe(
                    data => {
                        resolve(data);
                    },
                    err => {
                        reject(err);
                    }
                );
            }
        );
    }
}
