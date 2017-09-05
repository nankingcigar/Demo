/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 10:21:46
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-05 09:30:02
 */
import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpResponse, HttpErrorResponse, HttpUserEvent } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import * as Enumerable from 'linq/linq';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/delay';
import 'rxjs/add/operator/map';

import { Request } from './models/http/request';
import { AccountService } from './services/account/account.service';
import { LocalizationService } from './services/localization/localization.service';
import { languageKeys } from './app.global';

@Injectable()
export class DemoInterceptor implements HttpInterceptor {
    private _requestQueue: Request[] = [];
    private _accountService: AccountService;
    private _localizationService: LocalizationService;

    constructor(
        private _router: Router
    ) {
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (app.moduleRef) {
            this._accountService = app.moduleRef.injector.get<AccountService>(AccountService);
            this._localizationService = app.moduleRef.injector.get<LocalizationService>(LocalizationService);
        }
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
                    console.log(req);
                    console.log(err);
                    console.log(this._router);
                    if (err.status === 401) {
                        this._accountService.logOut();
                        this._router.navigate(['login']);
                    }
                    const queueKey = this.removeRequestQueue(req);
                    if (err.error) {
                        if (err.error.__abp === true) {
                            this._localizationService.get(languageKeys.errors[this._router.url][err.error.error.code])
                                .subscribe((translation: string) => {
                                    err.error.error.message = translation;
                                });
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
            .delay(1000)
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
