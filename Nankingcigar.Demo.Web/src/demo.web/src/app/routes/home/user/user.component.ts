/*
 * @Author: Chao Yang
 * @Date: 2017-09-18 09:15:46
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-18 09:26:59
 */
import { Component, OnInit } from '@angular/core';

import { User2 } from '../../../models/user/user2';
import { UserService } from '../../../services/user/user.service';

@Component({
  selector: selector(),
  templateUrl: './user.component.html',
})
export class UserComponent implements OnInit {
  _users: User2;

  constructor(private _userService: UserService) { }

  ngOnInit(): void {
    this._userService.getAll().subscribe(users => {
      console.log(users);
      this._users = users;
    });
  }

}

function selector(): string {
  return 'nankingcigar-demo-user';
}
