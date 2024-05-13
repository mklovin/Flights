import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { SearchFlighsComponent } from './search-flighs/search-flighs.component';
import { BookFlightComponent } from './book-flight/book-flight.component';
import { RegisterPassengerComponent } from './register-passenger/register-passenger.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    SearchFlighsComponent,
    BookFlightComponent,
    RegisterPassengerComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: SearchFlighsComponent, pathMatch: 'full' },
      { path: 'search-flights', component: SearchFlighsComponent },
      { path: 'book-flight/:flightId', component: BookFlightComponent },
      { path: 'register-passenger', component: RegisterPassengerComponent }

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
