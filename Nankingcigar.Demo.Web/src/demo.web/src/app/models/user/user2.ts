/*
 * @Author: Chao Yang
 * @Date: 2017-08-25 14:06:35
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-18 09:21:50
 */
import { User } from './user';

export class User2 extends User {
  public id: number;
  public email: string;
  public lastLoginTime: number;
}
