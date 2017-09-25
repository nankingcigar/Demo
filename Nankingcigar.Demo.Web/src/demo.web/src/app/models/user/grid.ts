/*
 * @Author: Chao Yang
 * @Date: 2017-09-19 01:29:03
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-19 05:59:19
 */
import { LandingUser } from './landing';

export class GridUser extends LandingUser {
  public id: number;
  public name: string;
  public email: string;
  public lastLoginTime: number;
}
