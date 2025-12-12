import { bootstrapApplication } from '@angular/platform-browser';
import { App } from './app/app';
import { routes } from './app/app.routes';
import { provideRouter } from '@angular/router';
import { importProvidersFrom } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

bootstrapApplication(App, {
  providers: [
    provideRouter(routes),
    importProvidersFrom(FormsModule, ReactiveFormsModule)
  ]
});


