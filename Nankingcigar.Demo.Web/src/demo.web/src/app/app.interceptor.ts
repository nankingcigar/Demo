/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 10:21:46
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-31 03:50:40
 */
import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class DemoInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req)
            .catch((err: any, caught) => {
                if (err instanceof HttpErrorResponse) {
                    if (err.error) {
                        if (err.error.__abp === true) {
                            return Observable.throw(err.error.error);
                        }
                    }
                }
            })
            .map((event) => {
                if (event instanceof HttpResponse) {
                    if (event.body !== undefined) {
                        if (event.body.__abp === true) {
                            if (event.body.success === false) {
                                return Observable.throw(event.body.error);
                            }
                            event = event.clone(
                                {
                                    body: event.body.result
                                }
                            );
                        }
                    }
                    return event;
                }
            })
            ;
    }
}
