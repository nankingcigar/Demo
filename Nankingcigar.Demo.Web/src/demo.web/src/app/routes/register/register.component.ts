/*
 * @Author: Chao Yang
 * @Date: 2017-08-25 08:19:27
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-14 06:51:08
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
  _error = {
    hidden: true,
    message: ''
  };
  _languageKeys = languageKeys.page.register;
  _app = app;

  constructor(
    private _accountService: AccountService,
    private _router: Router) {
  }

  ngOnInit() {
    this._registerInput = new RegisterInput();
    const checkBox = $('input[type=checkbox]:not(.switchery), input[type=radio]:not(.no-uniform)');
    if (checkBox.length > 0) {
      checkBox.each(function () {
        $(this).uniform();
      });
    }
  }

  onSubmit() {
    this._accountService.register(this._registerInput).subscribe(
      data => this._router.navigate(['login']),
      err => {
        if (this._error.hidden === true) {
          this._error.hidden = false;
        }
        this._error.message = err.message;
      }
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
