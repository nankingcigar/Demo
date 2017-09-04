/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 07:53:04
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-31 09:00:03
 */
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AccountService } from '../../services/account/account.service';
import { UserService } from '../../services/user/user.service';
import { User } from '../../models/user/user';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'nankingcigar-demo-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  private _user: User;

  constructor(
    private _accountService: AccountService,
    private _router: Router,
    private _userService: UserService
  ) {
  }

  ngOnInit() {
    this._userService.getCurrentUser()
      .subscribe(user => this._user = user);
  }

  logOut() {
    this._accountService.logOut().subscribe(
      data => this._router.navigate(['login']),
      err => this._router.navigate(['login'])
    );
  }

  showName() {
    if (this._user.displayName) {
      return this._user.displayName;
    }
    return this._user.userName;
  }
}
