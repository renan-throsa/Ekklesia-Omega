import { HttpClientModule } from '@angular/common/http'
import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component'
import { CustomNavigationModule } from './components/custom-navigation/custom-navigation.module'

import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { ToastrModule } from 'ngx-toastr'
import { IdentityGard } from './services/identity.guard'
import { InputGuard } from './services/input.guard'
import { NgxSpinnerModule } from 'ngx-spinner'

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    CustomNavigationModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NgxSpinnerModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      preventDuplicates: true,
      closeButton: true,
      progressBar: true,
    }),
  ],
  providers: [IdentityGard, InputGuard],
  bootstrap: [AppComponent],
})
export class AppModule {}
