import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AllUsersComponent } from './all-users/all-users.component';
import { AddUserComponent } from './add-user/add-user.component';
import { APP_INITIALIZER } from '@angular/core';
import { SignalrService } from './services/signalr.service';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { StoreModule } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';
import { provideStore } from '@ngrx/store';
import { appEffects, appStore } from './store/store';
import { UserService } from './user.service';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { NgbAlertModule, NgbDatepickerModule, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { MoviesComponent } from './movies/movies.component';

@NgModule({
  declarations: [
    AppComponent,
    AllUsersComponent,
    AddUserComponent,
    MoviesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NgbModule,    
    BsDatepickerModule.forRoot(),
    NgbDatepickerModule,
    NgbAlertModule
  ],
  providers: [
    SignalrService,
    {
      provide: APP_INITIALIZER,
      useFactory: (signalrService: SignalrService) => () => signalrService.initiateSignalrConnection(),
      deps: [SignalrService],
      multi: true,
    },
    provideStore(appStore),
    provideEffects(appEffects),
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
