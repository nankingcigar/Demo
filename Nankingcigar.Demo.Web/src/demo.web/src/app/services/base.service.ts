/*
 * @Author: Chao Yang
 * @Date: 2017-08-31 03:01:41
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-31 08:39:19
 */
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/fromPromise';

@Injectable()
export abstract class BaseService {
    protected observable(lambda) {
        const promise = new Promise((resolve, reject) => {
            lambda(resolve, reject);
        });
        return Observable.fromPromise(promise);
    }
}
