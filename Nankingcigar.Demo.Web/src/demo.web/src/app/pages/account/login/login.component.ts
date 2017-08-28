/*
 * @Author: Chao Yang
 * @Date: 2017-08-25 14:22:26
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-28 08:00:22
 */
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { LoginInput } from '../../../models/account/login/input';

@Component({
  selector: 'app-demo-account-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  _loginInput: LoginInput;

  constructor(private _http: HttpClient) { }

  ngOnInit() {
    this._loginInput = new LoginInput();
  }

  onSubmit() {
    this._http.post(
      'api/account',
      this._loginInput
    ).subscribe(
      data => console.log(data)
    );
  }
}
