import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component'
import { CustomNavigationModule } from './components/custom-navigation/custom-navigation.module';


@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, AppRoutingModule, CustomNavigationModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
