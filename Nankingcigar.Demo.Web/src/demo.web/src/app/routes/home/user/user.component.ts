/*
 * @Author: Chao Yang
 * @Date: 2017-09-18 09:15:46
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-19 10:09:36
 */
import { Component, OnInit } from '@angular/core';

import { GridUser } from '../../../models/user/grid';
import { UserService } from '../../../services/user/user.service';
import { languageKeys } from '../../../app.global';

@Component({
  selector: selector(),
  templateUrl: './user.component.html',
})
export class UserComponent implements OnInit {
  _users: GridUser[];
  _languageKeys = languageKeys.page.user;

  constructor(private _userService: UserService) { }

  ngOnInit(): void {
    this._userService.getAll().subscribe(users => {
      this._users = users;
    });
  }

}

function selector(): string {
  return 'nankingcigar-demo-user';
}
