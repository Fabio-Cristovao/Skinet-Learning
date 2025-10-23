import { ApplicationConfig, inject, provideAppInitializer, provideBrowserGlobalErrorListeners, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { errorInterceptor } from './core/interceptors/error-interceptor';
import { loadingInterceptor } from './core/interceptors/loading-interceptor';
import { InitService } from './core/services/init.service';
import { lastValueFrom, of } from 'rxjs';
import { MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material/dialog';
import { authInterceptor } from './core/interceptors/auth-interceptor';

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(withInterceptors([
      errorInterceptor, 
      loadingInterceptor,
      authInterceptor
    ])),
    provideAppInitializer(async () => {
      const initService = inject(InitService);
      // initService.init() may return an Observable or undefined/void in some code paths;
      // ensure we always pass an Observable to lastValueFrom by falling back to of(null).
      const initResult = initService.init() as any;
      const initObservable = initResult ?? of(null);
      return lastValueFrom(initObservable).finally(() => {
        const splash = document.getElementById('initial-splash');
        if (splash) {
          splash.remove();
        }
      });
    }),
    {
      provide: MAT_DIALOG_DEFAULT_OPTIONS,
      useValue: {autoFocus: 'dialog', restoreFocus: true}
    }
  ]
};
