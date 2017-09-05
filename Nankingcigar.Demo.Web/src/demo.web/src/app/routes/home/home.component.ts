/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 07:53:04
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-05 09:52:27
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
  // tslint:disable-next-line:component-selector
  selector: 'nankingcigar-demo-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  private _user: User;
  private _displayName: string;
  private _languageKeys = languageKeys.page.home;

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
          closeButton: false,
          debug: false,
          newestOnTop: true,
          progressBar: true,
          positionClass: 'toast-top-right',
          preventDuplicates: true,
          onclick: null,
          showDuration: 300,
          hideDuration: 1000,
          timeOut: 3000,
          extendedTimeOut: 1000,
          showEasing: 'swing',
          hideEasing: 'linear',
          showMethod: 'fadeIn',
          hideMethod: 'fadeOut'
        };
        this._translateService.get(
          [
            'Welcome to Demo!',
            'Hi {{ name }},'
          ],
          {
            name: this._displayName
          }).subscribe((translations: any) => {
            toastr.success(translations['Welcome to Demo!'], translations['Hi {{ name }},']);
          });
      });
  }

  logOut() {
    this._accountService.logOut().subscribe(
      data => this._router.navigate(['login']),
      err => this._router.navigate(['login'])
    );
  }
}
