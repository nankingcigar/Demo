/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 07:14:26
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-29 01:25:41
 */
import { Location } from '@angular/common';
import { Injectable } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import { LoadedRouterConfig } from '@angular/router/src/config.d';
import { Observable } from 'rxjs/Observable';

import { BaseService } from '../base.service';
import { RouteProxy } from '../../proxies/route/route.proxy';

@Injectable()
export class RoutesService extends BaseService {
  private _url: String;
  private _urls: String[];
  private i = 0;
  private _dict = new Map<String, any>();

  constructor(
    private _routeProxy: RouteProxy,
    private _router: Router,
    private _location: Location) {
    super();
    const url = this._location.path().replace('/', '');
    const urls = url.split('/');
    this._urls = [];
    this._urls.push(urls[0]);
    this._urls.push(url);
  }

  reset(module: string) {
    if (!this._dict.has(module)) {
      return Observable.of(this);
    }
    this.i++;
    return this._routeProxy.get(module).map(routes => {
      this.i--;
      this._dict.get(module)(routes);
      return routes;
    });
  }

  get(module: string): void {
    this.i++;
    this._routeProxy.get(module).subscribe(routes2 => {
      this.initRoutes(routes2);
      const route: ActivatedRoute = this.getCurrentRoute();
      this._dict.set(module, (routes) => {
        const loadedRouterConfig: LoadedRouterConfig = (<any>(route.routeConfig))._loadedConfig;
        const factories = Array.from(loadedRouterConfig.module.componentFactoryResolver['_factories'].keys());
        this.processRoutes(factories, routes);
        loadedRouterConfig.routes = routes;
        this._router.resetConfig(this._router.config);
      });
    }, (error) => {
      this.i--;
      this._urls = [];
      if (error.code === 3) {
        const route: ActivatedRoute = this.getCurrentRoute();
        if (!route.routeConfig.data) {
          route.routeConfig.data = {};
        }
        route.routeConfig.data['toAuth'] = true;
        this._dict.set(module, (routes) => {
          const loadedRouterConfig: LoadedRouterConfig = (<any>(route.routeConfig))._loadedConfig;
          const factories = Array.from(loadedRouterConfig.module.componentFactoryResolver['_factories'].keys());
          this.processRoutes(factories, routes);
          loadedRouterConfig.routes = routes;
          this._router.resetConfig(this._router.config);
        });
        this._router.navigate(['']);
      }
    });
  }

  isStop(): boolean {
    return this.i === 0;
  }

  private initRoutes(routes: any): void {
    this.i--;
    this._url = this._location.path().replace('/', '');
    if (this._urls.length > 0) {
      this._url = this._urls.shift();
    }
    const route: ActivatedRoute = this.getCurrentRoute();
    if (route.routeConfig === null) {
      this._router.resetConfig(routes);
      this._router.navigate([this._url]);
      return;
    }
    const loadedRouterConfig: LoadedRouterConfig = (<any>(route.routeConfig))._loadedConfig;
    const factories = Array.from(loadedRouterConfig.module.componentFactoryResolver['_factories'].keys());
    this.processRoutes(factories, routes);
    loadedRouterConfig.routes = routes;
    this._router.resetConfig(this._router.config);
    this._router.navigate([this._url]);
  }

  private getCurrentRoute(): ActivatedRoute {
    let route: ActivatedRoute = this._router.routerState.root;
    let parentRoute: ActivatedRoute = route;
    while (route.children.length > 0) {
      route = route.firstChild;
      parentRoute = route;
    }
    return route;
  }

  private processRoutes(factories: any, routes: any): void {
    routes.forEach((route) => {
      if (route.component) {
        const factoryClass = <Type<any>>factories.find((factory: any) => factory.name === route.component);
        route.component = factoryClass;
        if (route.children.length > 0) {
          this.processRoutes(factories, route.children);
        }
      }
    });
  }
}
