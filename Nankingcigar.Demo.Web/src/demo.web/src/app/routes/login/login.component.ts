/*
 * @Author: Chao Yang
 * @Date: 2017-08-25 14:22:26
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-05 03:08:48
 */
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

import { LoginInput } from '../../models/account/login/input';
import { AccountService } from '../../services/account/account.service';
import { languages, languageKeys } from '../../app.global';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'nankingcigar-demo-account-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  _loginInput: LoginInput;
  _error = {
    hidden: true,
    message: ''
  };
  _languages = languages;
  _languageKeys = languageKeys.page.login;
  _app = app;

  constructor(
    private _accountService: AccountService,
    private _router: Router,
    private _translateService: TranslateService
  ) { }

  ngOnInit(): void {
    this._loginInput = new LoginInput();
  }

  onBlur(e) {
    this._loginInput.userName = this._loginInput.userName.trim();
  }

  onSubmit() {
    this._accountService.authenticate(this._loginInput).subscribe(
      data => {
        if (this._error.hidden === false) {
          this._error.hidden = true;
        }
        this._router.navigate(['app/dashboard']);
      },
      err => {
        if (this._error.hidden === true) {
          this._error.hidden = false;
        }
        this._error.message = 'User Name or Password is incorrect.';
      }
    );
  }

  onChange(e) {
    this._translateService.use(e.value);
  }
}
