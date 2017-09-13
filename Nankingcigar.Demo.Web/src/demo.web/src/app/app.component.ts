/*
 * @Author: Chao Yang
 * @Date: 2017-08-25 08:01:36
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-13 08:13:43
 */
import { Component, Renderer2 } from '@angular/core';

import { RouteService } from './services/route/route.service';

@Component({
  selector: selector(),
  templateUrl: './app.component.html'
})
export class AppComponent {

  constructor(
    private _renderer: Renderer2,
    private _routeService: RouteService
  ) {
    Waves.init();
    this._routeService.setRenerder(this._renderer);
  }
}

function selector(): string {
    return 'nankingcigar-demo-app';
}
