/*
 * @Author: Chao Yang
 * @Date: 2017-08-31 06:38:41
 * @Last Modified by: Chao Yang
 * @Last Modified time: 2017-08-31 08:40:48
 */
export const environment = {
  production: false,
  app: 'demo',
  classPrefix: 'nankingcigar-demo-',
  author: 'Chao(Nankingcigar)',
  titlePrefix: 'Demo | ',
  defaultTitle: 'Demo',
  sessionKey: 'nankingcigar-demo-session'
};

export const api = {
  account: {
      authenicate: 'api/account',
      register: 'api/services/app/account/register'
  }
};

export const languages = [
  {
    label: 'English',
    value: 'en'
  },
  {
    label: '简体中文',
    value: 'cn'
  }
];
