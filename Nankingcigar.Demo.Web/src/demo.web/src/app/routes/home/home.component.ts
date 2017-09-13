/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 07:53:04
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-13 08:15:03
 */
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/delay';
import { TranslateService } from '@ngx-translate/core';

import { AccountService } from '../../services/account/account.service';
import { UserService } from '../../services/user/user.service';
import { User } from '../../models/user/user';
import { languageKeys } from '../../app.global';

@Component({
  selector: selector(),
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  _user: User;
  _displayName: string;
  _languageKeys = languageKeys.page.home;

  constructor(
    private _accountService: AccountService,
    private _router: Router,
    private _userService: UserService,
    private _translateService: TranslateService
  ) {
  }

  ngOnInit() {
    this._displayName = '';
    this._userService.getCurrentUser()
      .subscribe(user => {
        this._user = user;
        this._displayName = this._user.displayName;
        if (!this._displayName) {
          this._displayName = this._user.userName;
        }
        toastr.options = {
          closeButton: true,
          progressBar: true,
          showMethod: 'fadeIn',
          hideMethod: 'fadeOut',
          timeOut: 5000
        };
        this._translateService.get(
          [
            'Welcome to {{ system }}!',
            'Hi {{ name }},'
          ],
          {
            system: app.system,
            name: this._displayName
          }).subscribe((translations: any) => {
            toastr.success(translations['Welcome to {{ system }}!'], translations['Hi {{ name }},']);
          });
      });
    $(window).trigger('resize');
  }

  logOut() {
    this._accountService.logOut().subscribe(
      data => this._router.navigate(['login']),
      err => this._router.navigate(['login'])
    );
  }
}

function selector(): string {
  return 'nankingcigar-demo-home';
}
