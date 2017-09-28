/*
 * @Author: Chao Yang
 * @Date: 2017-08-30 07:53:04
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-09-19 02:35:33
 */
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/delay';
import { TranslateService } from '@ngx-translate/core';

import { AccountService } from '../../services/account/account.service';
import { UserService } from '../../services/user/user.service';
import { LandingUser } from '../../models/user/landing';
import { languageKeys } from '../../app.global';

@Component({
  selector: 'nankingcigar-demo-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  _user: LandingUser;
  _displayName: string;
  _languageKeys: any = languageKeys.page.home;
  _logoText: string;
  _smallLogoText: string;
  _app = app;

  constructor(
    private _accountService: AccountService,
    private _router: Router,
    private _userService: UserService,
    private _translateService: TranslateService
  ) {
  }

  ngOnInit(): void {
    this.initUserInfo();
    this.initSettings();
    this.initSidebarEvents();
    this.initNavigationEvents();
    this.sidebarAndContentHeight();
    window.onresize = this.sidebarAndContentHeight;
    Observable.of(this).delay(100).subscribe(e => {
      $('.slimscroll').slimscroll({
        allowPageScroll: true
      });
    });
  }

  private initUserInfo(): void {
    this._displayName = '';
    this._userService.getCurrentUser()
      .subscribe(user => {
        this._user = user;
        this._displayName = this._user.display;
        this.welcome();
      });
  }

  private welcome() {
    this._translateService.get(
      [
        'Welcome to {{ system }}!',
        'Hi {{ name }},'
      ],
      {
        system: app.system,
        name: this._displayName
      }).subscribe((translations: any) => {
        toastr.success(translations['Welcome to {{ system }}!'], translations['Hi {{ name }},'], {
          closeButton: true,
          progressBar: true,
          showMethod: 'fadeIn',
          hideMethod: 'fadeOut',
          timeOut: 2000
        });
      });
  }

  private initSettings(): void {
    const elems = Array.prototype.slice.call(document.querySelectorAll('.js-switch'));
    elems.forEach(function (html) {
      const switchery = new Switchery(html, {
        color: '#23B7E5',
        secondaryColor: '#121212',
        jackColor: '#fff'
      });
    });
  }

  private initNavigationEvents(): void {
    this.initLayoutEvents();
  }

  private initLayoutEvents(): void {
    const sidebarAndContentHeight = this.sidebarAndContentHeight;
    const fixedHeaderCheck = <HTMLFormElement>document.querySelector('.fixed-header-check'),
      fixedSidebarCheck = <HTMLFormElement>document.querySelector('.fixed-sidebar-check'),
      horizontalBarCheck = <HTMLFormElement>document.querySelector('.horizontal-bar-check'),
      toggleSidebarCheck = <HTMLFormElement>document.querySelector('.toggle-sidebar-check'),
      boxedLayoutCheck = <HTMLFormElement>document.querySelector('.boxed-layout-check'),
      compactMenuCheck = <HTMLFormElement>document.querySelector('.compact-menu-check'),
      hoverMenuCheck = <HTMLFormElement>document.querySelector('.hover-menu-check'),
      defaultOptions = function () {
        if (
          ($('body').hasClass('small-sidebar')) &&
          (toggleSidebarCheck.checked === true)
        ) {
          toggleSidebarCheck.click();
        }
        if (
          ($('body').hasClass('page-header-fixed')) &&
          (fixedHeaderCheck.checked === true)
        ) {
          fixedHeaderCheck.click();
        }
        if (
          ($('body').hasClass('page-sidebar-fixed')) &&
          (fixedSidebarCheck.checked === true)
        ) {
          fixedSidebarCheck.click();
        }
        if (
          ($('body').hasClass('page-horizontal-bar')) &&
          (horizontalBarCheck.checked === true)
        ) {
          horizontalBarCheck.click();
        }
        if (
          ($('body').hasClass('compact-menu')) &&
          (compactMenuCheck.checked === true)
        ) {
          compactMenuCheck.click();
        }
        if (
          ($('body').hasClass('hover-menu')) &&
          (hoverMenuCheck.checked === true)
        ) {
          hoverMenuCheck.click();
        }
        if (
          ($('.page-content').hasClass('container')) &&
          (boxedLayoutCheck.checked === true)
        ) {
          boxedLayoutCheck.click();
        }
        sidebarAndContentHeight();
      },
      fixedHeader = function () {
        if (
          ($('body').hasClass('page-horizontal-bar')) &&
          ($('body').hasClass('page-sidebar-fixed')) &&
          ($('body').hasClass('page-header-fixed'))
        ) {
          fixedSidebarCheck.click();
        }
        $('body').toggleClass('page-header-fixed');
        sidebarAndContentHeight();
      },
      fixedSidebar = function () {
        if (
          ($('body').hasClass('page-horizontal-bar')) &&
          (!$('body').hasClass('page-sidebar-fixed')) &&
          (!$('body').hasClass('page-header-fixed'))
        ) {
          fixedHeaderCheck.click();
        }
        if (
          ($('body').hasClass('hover-menu')) &&
          (!$('body').hasClass('page-sidebar-fixed'))
        ) {
          hoverMenuCheck.click();
        }
        $('body').toggleClass('page-sidebar-fixed');
        if ($('body').hasClass('.page-sidebar-fixed')) {
          $('.page-sidebar-inner').slimScroll({
            destroy: true
          });
        }
        $('.page-sidebar-inner').slimScroll();
        sidebarAndContentHeight();
      },
      horizontalBar = function () {
        $('.sidebar').toggleClass('horizontal-bar');
        $('.sidebar').toggleClass('page-sidebar');
        $('body').toggleClass('page-horizontal-bar');
        if (
          ($('body').hasClass('page-sidebar-fixed')) &&
          (!$('body').hasClass('page-header-fixed'))
        ) {
          fixedHeaderCheck.click();
        }
        sidebarAndContentHeight();
      },
      boxedLayout = function () {
        $('.page-content').toggleClass('container');
        sidebarAndContentHeight();
      },
      compactMenu = function () {
        $('body').toggleClass('compact-menu');
        sidebarAndContentHeight();
      },
      hoverMenu = function () {
        if (
          (!$('body').hasClass('hover-menu')) &&
          ($('body').hasClass('page-sidebar-fixed'))
        ) {
          fixedSidebarCheck.click();
        }
        $('body').toggleClass('hover-menu');
        sidebarAndContentHeight();
      };

    fixedHeaderCheck.onchange = function () {
      fixedHeader();
    };

    fixedSidebarCheck.onchange = function () {
      fixedSidebar();
    };

    horizontalBarCheck.onchange = function () {
      horizontalBar();
    };

    toggleSidebarCheck.onchange = this.collapseSidebar;
    $('.sidebar-toggle').click(function (e) {
      e.preventDefault();
      toggleSidebarCheck.click();
    });

    compactMenuCheck.onchange = function (e) {
      e.preventDefault();
      compactMenu();
    };

    hoverMenuCheck.onchange = function (e) {
      e.preventDefault();
      hoverMenu();
    };

    boxedLayoutCheck.onchange = function (e) {
      e.preventDefault();
      boxedLayout();
    };

    $('.reset-options').click(function (e) {
      e.preventDefault();
      defaultOptions();
    });
  }

  private initSidebarEvents() {
    const sidebarAndContentHeight = this.sidebarAndContentHeight;
    $('.sidebar .accordion-menu > li.droplink > a').click(function (e) {
      e.preventDefault();
      if (
        !($('body').hasClass('small-sidebar')) &&
        (!$('body').hasClass('page-horizontal-bar')) &&
        (!$('body').hasClass('hover-menu'))
      ) {
        const menu = $('.sidebar .menu'),
          sidebar = $('.page-sidebar-inner'),
          page = $('.page-content'),
          sub = $(this).next(),
          el = $(this);
        menu.find('li').removeClass('open');
        $('.sub-menu').slideUp(200, function () {
          sidebarAndContentHeight();
        });
        sidebarAndContentHeight();
        if (!sub.is(':visible')) {
          $(this).parent('li').addClass('open');
          $(this).next('.sub-menu').slideDown(200, function () {
            sidebarAndContentHeight();
          });
        } else {
          sub.slideUp(200, function () {
            sidebarAndContentHeight();
          });
        }
        return;
      }
      if (
        ($('body').hasClass('small-sidebar')) &&
        ($('body').hasClass('page-sidebar-fixed'))
      ) {
        const menu = $('.sidebar .menu'),
          sidebar = $('.page-sidebar-inner'),
          page = $('.page-content'),
          sub = $(this).next(),
          el = $(this);
        menu.find('li').removeClass('open');
        $('.sub-menu').slideUp(200, function () {
          sidebarAndContentHeight();
        });
        sidebarAndContentHeight();
        if (!sub.is(':visible')) {
          $(this).parent('li').addClass('open');
          $(this).next('.sub-menu').slideDown(200, function () {
            sidebarAndContentHeight();
          });
        } else {
          sub.slideUp(200, function () {
            sidebarAndContentHeight();
          });
        }
        return;
      }
    });
  }

  toggleProfileMenu(e: UIEvent): void {
    e.preventDefault();
    $('body').toggleClass('show-menu');
  }

  toggeleNavigationMenu(e: UIEvent): void {
    e.preventDefault();
    $('.top-menu').toggleClass('show-navigation');
  }

  openNavitionMenu(e: UIEvent): void {
    e.preventDefault();
    $('.cd-nav-container, .cd-overlay').toggleClass('is-visible', true);
    $('main').toggleClass('scale-down', true);
    $('body').toggleClass('navigation-visible', true);
  }

  closeNavigationMenu(e: UIEvent): void {
    e.preventDefault();
    if ($(e.target).closest('li').hasClass('cd-selected')) {
      return;
    }
    $('.cd-nav-container, .cd-overlay').toggleClass('is-visible', false);
    $('main').toggleClass('scale-down', false);
    $('body').toggleClass('navigation-visible', false);
  }

  collapseSidebar(e: UIEvent): void {
    e.preventDefault();
    $('body').toggleClass('small-sidebar');
    if ($('body').hasClass('small-sidebar')) {
      $('.sidebar-toggle i').removeClass('fa-dedent').addClass('fa-indent');
    } else {
      $('.sidebar-toggle i').removeClass('fa-indent').addClass('fa-dedent');
    }
    if (!this._logoText) {
      this._logoText = $('.navbar .logo-box a span').text();
      this._smallLogoText = this._logoText.slice(0, 1);
    }
    $('.navbar .logo-box a span').html($('.navbar .logo-box a span').text() === this._logoText ? this._smallLogoText : this._logoText);
    this.sidebarAndContentHeight();
  }

  collapseSidebar2(e: UIEvent): void {
    e.preventDefault();
    $('.sidebar').toggleClass('visible');
    $('.page-inner').toggleClass('sidebar-visible');
  }

  private sidebarAndContentHeight(e?: UIEvent): void {
    if (e) {
      e.preventDefault();
    }
    const content = $('.page-inner'),
      sidebar = $('.page-sidebar'),
      body = $('body'),
      footerHeight = $('.page-footer').outerHeight(),
      pageContentHeight = $('.page-content').height();
    let height;
    content.attr('style', 'min-height:' + sidebar.height() + 'px !important');
    if (body.hasClass('page-sidebar-fixed')) {
      height = sidebar.height() + footerHeight;
    } else {
      height = sidebar.height() + footerHeight;
      if (height < $(window).height()) {
        height = $(window).height();
      }
    }
    if (height >= content.height()) {
      content.attr('style', 'min-height:' + height + 'px !important');
    }
  }

  logOut(e: UIEvent) {
    e.preventDefault();
    this._accountService.logOut().subscribe(
      data => this._router.navigate(['login']),
      err => this._router.navigate(['login'])
    );
  }
}
