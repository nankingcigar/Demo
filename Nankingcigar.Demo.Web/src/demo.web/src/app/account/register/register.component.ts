/*
 * @Author: Chao Yang
 * @Date: 2017-08-25 08:19:27
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-28 03:39:23
 */
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { RegisterInput } from './registerInput.entity';

@Component({
  selector: 'app-account-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  _registerInput: RegisterInput;

  constructor(private _http: HttpClient) {
  }

  ngOnInit() {
    this._registerInput = new RegisterInput();
  }

  onSubmit() {
    this._http.post(
      'api/services/app/account/Register',
      this._registerInput
    ).subscribe(
      data => console.log(data)
    );
  }
}
