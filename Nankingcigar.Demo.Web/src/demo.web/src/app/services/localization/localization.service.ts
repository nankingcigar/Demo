/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 07:14:26
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-13 07:52:42
 */
import { Injectable, EventEmitter } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Observable } from 'rxjs/Observable';
import { TranslateService, LangChangeEvent } from '@ngx-translate/core';
import { CookieService } from 'ngx-cookie-service';

import { languageKeys } from '../../app.global';
import { BaseService } from '../base.service';

@Injectable()
export class LocalizationService extends BaseService {
  _pageTitle: string;

  constructor(
    private _translateService: TranslateService,
    private _title: Title,
    private _cookieService: CookieService
  ) {
    super();
    this._translateService.setDefaultLang('en');
    if (this._cookieService.check(app.environment.languageKey)) {
      this._translateService.use(this._cookieService.get(app.environment.languageKey));
    }
    this.setApp();
    this._translateService.onLangChange.subscribe(e => {
      this.setApp();
      this.setPageTitle();
    });
  }

  setLanguage(language: string): void {
    this._cookieService.set(app.environment.languageKey, language);
    this._translateService.use(language);
  }

  getLanuage(): string {
    if (this._cookieService.check(app.environment.languageKey)) {
      return this._cookieService.get(app.environment.languageKey);
    } else {
      return this._translateService.getDefaultLang();
    }
  }

  get(key: string | string[], interpolateParams?: Object): Observable<string | any> {
    return this._translateService.get(key, interpolateParams);
  }

  public setPageTitle(title?: string): void {
    if (title) {
      this._pageTitle = title;
    }
    this.get(this._pageTitle, app).subscribe((translation: string) => {
      this._title.setTitle(translation);
    });
  }

  private setApp() {
    this.get([languageKeys.system, languageKeys.author]).subscribe((translation: any) => {
      app.system = translation[languageKeys.system];
      app.author = translation[languageKeys.author];
    });
  }
}
