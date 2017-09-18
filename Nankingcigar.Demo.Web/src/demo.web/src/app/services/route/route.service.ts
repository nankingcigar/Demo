/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 07:14:26
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-14 06:56:13
 */
import { Injectable } from '@angular/core';
import { RoutesRecognized, Router, Event } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/filter';

import { BaseService } from '../base.service';
import { AccountService } from '../account/account.service';
import { LocalizationService } from '../localization/localization.service';
import { languageKeys } from '../../app.global';

@Injectable()
export class RouteService extends BaseService {
  _routeClass: string;
  _pageClass: string;

  constructor(
    private _cookieService: CookieService,
    private _accountService: AccountService,
    private _router: Router,
    private _localizationService: LocalizationService
  ) {
    super();
    this._router.events.filter(event => {
      return event instanceof RoutesRecognized;
    }).subscribe(event => this.routeChange(<RoutesRecognized>event));
  }

  private routeChange(event: RoutesRecognized): void {
    let route = event.state.root;
    let parentRoute = route;
    while (route.children.length > 0) {
      route = route.firstChild;
      if (parentRoute.data && parentRoute.data.toAuth === true) {
        if (!route.data) {
          route.data = {};
        }
        if (!route.data.toAuth) {
          route.data = Object.assign({ toAuth: true }, route.data);
        }
      }
      parentRoute = route;
    }
    if (route.data.toAuth) {
      if (this._accountService.canActivate() === false) {
        this._router.navigate(['login']);
        return;
      }
    } else {
      if (this._accountService.canActivate() === true) {
        this._router.navigate(['app/dashboard']);
        return;
      }
    }
    languageKeys.page.home.subTitle = languageKeys.page.home[route.routeConfig.path];
    if (this._routeClass) {
      $('body').removeClass(this._routeClass);
      this._routeClass = undefined;
    }
    this._routeClass = event.urlAfterRedirects.slice(1).replace(/[/]/g, '-');
    if (this._routeClass === '') {
      this._routeClass = undefined;
    } else {
      this._routeClass = app.environment.classPrefix + this._routeClass;
    }
    if (this._routeClass) {
      $('body').addClass(this._routeClass);
    }
    if (this._pageClass) {
      $('body').removeClass(this._pageClass);
      this._pageClass = undefined;
    }
    if (route.data) {
      if (route.data.pageClass && route.data.pageClass !== '') {
        this._pageClass = route.data.pageClass;
        $('body').addClass(this._pageClass);
      }
      if (route.data.title && route.data.title !== '') {
        this._localizationService.setPageTitle(app.environment.titlePrefix + route.data.title);
      } else {
        this._localizationService.setPageTitle(app.environment.defaultTitle);
      }
    } else {
      this._localizationService.setPageTitle(app.environment.defaultTitle);
    }
  }
}
