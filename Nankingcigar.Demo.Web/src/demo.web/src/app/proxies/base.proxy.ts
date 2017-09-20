/*
 * @Author: Chao Yang
 * @Date: 2017-08-31 01:56:28
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-31 02:03:14
 */
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export abstract class BaseProxy {
    constructor(protected _http: HttpClient) {
    }
}
