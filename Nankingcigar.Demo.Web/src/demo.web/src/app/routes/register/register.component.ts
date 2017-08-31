/*
 * @Author: Chao Yang
 * @Date: 2017-08-25 08:19:27
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-31 05:49:29
 */
import { Component, OnInit } from '@angular/core';

import { RegisterInput } from '../../models/account/register/input';
import { AccountService } from '../../services/account/account.service';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'nankingcigar-demo-account-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {
  _registerInput: RegisterInput;

  constructor(private _accountService: AccountService) {
  }

  ngOnInit() {
    this._registerInput = new RegisterInput(undefined, undefined);
  }

  onSubmit() {
    this._accountService.register(this._registerInput).subscribe(
      data => console.log(data)
    );
  }
}
