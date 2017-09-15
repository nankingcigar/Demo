var app;
(function () {
  'use strict';
  app = {
    year: (new Date()).getFullYear()
  };

  window.paceOptions = {
    restartOnPushState: true,
    restartOnRequestAfter: true,
    ajax: {
      trackMethods: [
        'GET',
        'POST',
        'PUT',
        'Delete'
      ]
    }
  };
})();
