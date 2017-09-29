/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 07:14:26
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-29 01:24:57
 */
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

import { BaseService } from '../base.service';
import { RoutesService } from '../route/routes.service';
import { AccountProxy } from '../../proxies/account/account.proxy';
import { LoginInput } from '../../models/account/login/input';
import { RegisterInput } from '../../models/account/register/input';

@Injectable()
export class AccountService extends BaseService {
  constructor(
    private _accountProxy: AccountProxy,
    private _cookieService: CookieService,
    private _routesService: RoutesService
  ) {
    super();
  }

  authenticate(input: LoginInput) {
    return this.observable((resolve, reject) => {
      this._accountProxy.authenticate(input).subscribe(data => {
        this._cookieService.set(app.environment.sessionKey, input.userName);
        this._routesService.reset('HomeModule').subscribe(() => {
          resolve(data);
        });
      });
    });
  }

  register(input: RegisterInput) {
    return this._accountProxy.register(input);
  }

  canActivate() {
    return this._cookieService.check(app.environment.sessionKey);
  }

  logOut() {
    this._cookieService.delete(app.environment.sessionKey);
    return this._accountProxy.logOut();
  }
}
