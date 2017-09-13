/*
 * @Author: Chao Yang
 * @Date: 2017-08-25 08:19:27
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-13 08:14:18
 */
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { RegisterInput } from '../../models/account/register/input';
import { AccountService } from '../../services/account/account.service';
import { languageKeys } from '../../app.global';

@Component({
  selector: selector(),
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {
  _registerInput: RegisterInput;
  _languageKeys = languageKeys.page.register;
  _app = app;

  constructor(
    private _accountService: AccountService,
    private _router: Router) {
  }

  ngOnInit() {
    this._registerInput = new RegisterInput();
  }

  onSubmit() {
    this._accountService.register(this._registerInput).subscribe(
      data => this._router.navigate(['login'])
    );
  }

  onBlurUserName(e) {
    this._registerInput.userName = this._registerInput.userName.trim();
  }

  onBlurEmail(e) {
    this._registerInput.email = this._registerInput.email.trim();
  }
}

function selector(): string {
  return 'nankingcigar-demo-account-register';
}
