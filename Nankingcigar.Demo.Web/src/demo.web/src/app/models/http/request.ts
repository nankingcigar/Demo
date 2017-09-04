/*
 * @Author: Chao Yang
 * @Date: 2017-09-04 07:29:48
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-04 09:58:51
 */
import { HttpEvent } from '@angular/common/http';
import { Subject } from 'rxjs/Subject';
import { Observable } from 'rxjs/Observable';

export class Request {
    public requestBroadCaster: Subject<HttpEvent<any>>;
    public events: Observable<HttpEvent<any>>;

    constructor(
        public urlWithParams: string,
        public body: any,
        public method: string
    ) {
        this.requestBroadCaster = new Subject<HttpEvent<any>>();
        this.events = this.requestBroadCaster.asObservable();
    }
}
