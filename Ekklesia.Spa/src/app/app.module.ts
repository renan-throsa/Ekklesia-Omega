import { HttpClientModule } from '@angular/common/http'
import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component'
import { CustomNavigationModule } from './components/custom-navigation/custom-navigation.module'

import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { ToastrModule } from 'ngx-toastr'
import { AuthGard } from './services/auth.guard'
import { InputGuard } from './services/input.guard'

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    CustomNavigationModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      preventDuplicates: true,
      closeButton: true,
      progressBar: true,
    }),
  ],
  providers: [AuthGard, InputGuard],
  bootstrap: [AppComponent],
})
export class AppModule {}
