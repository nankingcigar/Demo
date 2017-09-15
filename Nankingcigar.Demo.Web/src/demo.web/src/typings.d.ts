/* SystemJS module definition */
declare var module: NodeModule;
interface NodeModule {
  id: string;
}

/* app global variable */
declare var app: App;
interface App {
  system: string;
  author: string;
  year: number;
  moduleRef: NgModuleRef;
  environment: Environment;
}

interface Type<T> {
}

interface Injector {
  get<T>(token: Type<T>): T;
}

interface NgModuleRef {
  injector: Injector;
}

interface Environment {
  classPrefix: string,
  titlePrefix: string,
  defaultTitle: string,
  sessionKey: string,
  languageKey: string
}
/* app global variable */

/* plugins */
declare var $: any;

declare var toastr: Toastr;
interface Toastr {
  options: any;
  info(subTitle: string, title?: string, options?: any): void;
  success(subTitle: string, title?: string, options?: any): void;
  warning(subTitle: string, title?: string, options?: any): void;
  error(subTitle: string, title?: string, options?: any): void;
}

declare var Waves: Waves;
interface Waves {
  init(config?: any): void;
  attach(elements: any, classes: any): void;
  ripple(elements: any, options: any): void;
  calm(elements: any): void;
}

declare function Switchery(element: any, options?: any): void;
/* plugins */
