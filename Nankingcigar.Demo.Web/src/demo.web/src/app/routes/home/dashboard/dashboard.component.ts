/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 07:53:24
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-06 04:06:17
 */
import { Component, OnInit } from '@angular/core';

import { languageKeys } from '../../../app.global';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'nankingcigar-demo-home-dashboard',
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent implements OnInit {
  _languageKeys = languageKeys.page.dashboard;
  _app = app;

  constructor() { }

  ngOnInit() {
    $('.counter').counterUp({
        delay: 10,
        time: 1000
    });
  }

}
