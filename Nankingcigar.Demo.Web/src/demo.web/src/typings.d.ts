/* SystemJS module definition */
declare var module: NodeModule;
interface NodeModule {
  id: string;
}

declare var $: any;

declare var Pace: Pace;
interface Pace {
  restart(): void;
  stop(): void;
}

declare var toastr: Toastr;
interface Toastr {
  options: any;
  info(subTitle: string, title: string): void;
  success(subTitle: string, title: string): void;
  warning(subTitle: string, title: string): void;
  error(subTitle: string, title: string): void;
}

declare var app: App;
interface App {
  system: string;
  author: string;
  year: number;
  moduleRef: NgModuleRef;
  environment: Environment;
}

interface Type<T>{
}

interface Injector{
  get<T>(token: Type<T>): T;
}

interface NgModuleRef {
  injector: Injector;
}

interface Environment{
  classPrefix: string,
  titlePrefix: string,
  defaultTitle: string,
  sessionKey: string,
  languageKey: string
}