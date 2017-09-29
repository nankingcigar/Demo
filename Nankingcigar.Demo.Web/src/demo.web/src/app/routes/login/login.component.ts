/*
 * @Author: Chao Yang
 * @Date: 2017-08-25 14:22:26
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-29 00:43:25
 */
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { languages, languageKeys } from '../../app.global';
import { AccountService } from '../../services/account/account.service';
import { LocalizationService } from '../../services/localization/localization.service';
import { LoginInput } from '../../models/account/login/input';

@Component({
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
  _language: string;

  constructor(
    private _accountService: AccountService,
    private _router: Router,
    private _localizationService: LocalizationService
  ) { }

  ngOnInit(): void {
    this._loginInput = new LoginInput();
    this._language = this._localizationService.getLanuage();
  }

  onBlur(e): void {
    this._loginInput.userName = this._loginInput.userName.trim();
  }

  onSubmit(): void {
    this._accountService.authenticate(this._loginInput).subscribe(
      data => {
        if (this._error.hidden === false) {
          this._error.hidden = true;
        }
        this._router.navigate(['app']);
      },
      err => {
        if (this._error.hidden === true) {
          this._error.hidden = false;
        }
        this._error.message = err.message;
      }
    );
  }

  onChange(e): void {
    this._localizationService.setLanguage(e.value);
  }
}
