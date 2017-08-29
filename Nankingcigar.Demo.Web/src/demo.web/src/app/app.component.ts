/*
 * @Author: Chao Yang
 * @Date: 2017-08-25 08:01:36
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-29 07:56:47
 */
import { Component, Renderer2 } from '@angular/core';
import { RoutesRecognized, Router, NavigationStart } from '@angular/router';

@Component({
  selector: 'app-demo-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  _pageClass: string;
  _bodyClass: string;

  constructor(private _renderer: Renderer2, private _router: Router) {
    this._router.events
      .subscribe(event => {
        if (event instanceof RoutesRecognized) {
          if (this._pageClass) {
            this._renderer.removeClass(document.body, this._pageClass);
            this._pageClass = undefined;
          }
          this._pageClass = event.urlAfterRedirects.slice(1).replace(/[/]/g, '-');
          this._renderer.addClass(document.body, this._pageClass);
          let route = event.state.root;
          while (route.children.length > 0) {
            route = route.firstChild;
          }
          if (this._bodyClass) {
            this._renderer.removeClass(document.body, this._bodyClass);
            this._bodyClass = undefined;
          }
          if (route.data && route.data.bodyClass) {
            this._bodyClass = route.data.bodyClass;
            this._renderer.addClass(document.body, this._bodyClass);
          }
        }
      });
  }
}
