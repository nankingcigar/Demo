/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 10:21:46
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-04 09:55:48
 */
import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpResponse, HttpErrorResponse, HttpUserEvent } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import * as Enumerable from 'linq/linq';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/delay';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';

import { Request } from './models/http/request';

@Injectable()
export class DemoInterceptor implements HttpInterceptor {
    private _requestQueue: Request[] = [];

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (this.containsRequest(req)) {
            if (req.method !== 'GET') {
                return Observable.of(null);
            }
            const queueKey = this.getRequestFromQueue(req);
            return queueKey.events;
        }
        this.setRequestQueue(req);
        return next.handle(req)
            .map((event) => {
                if (event instanceof HttpResponse) {
                    const queueKey = this.removeRequestQueue(req);
                    if (event.body !== undefined) {
                        if (event.body.__abp === true) {
                            if (event.body.success === false) {
                                queueKey.requestBroadCaster.error(event.body.error);
                                return Observable.throw(event.body.error);
                            }
                            event = event.clone(
                                {
                                    body: event.body.result
                                }
                            );
                        }
                    }
                    queueKey.requestBroadCaster.next(event);
                    return event;
                }
            })
            .catch((err: any, caught) => {
                if (err instanceof HttpErrorResponse) {
                    const queueKey = this.removeRequestQueue(req);
                    if (err.error) {
                        if (err.error.__abp === true) {
                            queueKey.requestBroadCaster.error(err.error.error);
                            return Observable.throw(err.error.error);
                        }
                    }
                }
            });
    }

    containsRequest(req: HttpRequest<any>): boolean {
        const queueKey = this.getRequestFromQueue(req);
        return queueKey !== null;
    }

    setRequestQueue(req: HttpRequest<any>): void {
        if (this._requestQueue.length === 0) {
            Pace.restart();
        }
        const queueKey = new Request(
            req.urlWithParams,
            req.body,
            req.method
        );
        this._requestQueue.push(queueKey);
    }

    removeRequestQueue(req: HttpRequest<any>): Request {
        const queueKey = this.getRequestFromQueue(req);
        Observable.of(this._requestQueue)
            .delay(2000)
            .subscribe(data => {
                if (this._requestQueue.length === 1) {
                    Pace.stop();
                }
                const index = this._requestQueue.indexOf(queueKey);
                this._requestQueue.splice(index, 1);
            });
        return queueKey;
    }

    getRequestFromQueue(req: HttpRequest<any>): Request {
        return Enumerable.from(this._requestQueue)
            .firstOrDefault(p => p.urlWithParams === req.urlWithParams
                && p.body === req.body
                && p.method === req.method
            );
    }
}
