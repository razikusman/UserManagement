import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { UserAppModule } from './app/user-management/user-app.module';


platformBrowserDynamic().bootstrapModule(UserAppModule)
  .catch(err => console.error(err));
