/*
 * @Author: Chao Yang
 * @Date: 2017-08-25 08:01:36
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-15 06:25:21
 */
import { Component } from '@angular/core';

import { RouteService } from './services/route/route.service';

@Component({
  selector: selector(),
  templateUrl: './app.component.html'
})
export class AppComponent {

  constructor(
    private _routeService: RouteService
  ) {
    Waves.init();
  }
}

function selector(): string {
    return 'nankingcigar-demo-app';
}
