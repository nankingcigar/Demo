/*
 * @Author: Chao Yang
 * @Date: 2017-08-25 08:01:36
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-05 08:10:27
 */
import { Component, Renderer2 } from '@angular/core';

import { RouteService } from './services/route/route.service';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'nankingcigar-demo-app',
  templateUrl: './app.component.html'
})
export class AppComponent {

  constructor(
    private _renderer: Renderer2,
    private _routeService: RouteService
  ) {
    this._routeService.setRenerder(this._renderer);
  }
}
