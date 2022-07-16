import { HttpClientModule } from '@angular/common/http'
import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component'
import { CustomNavigationModule } from './components/custom-navigation/custom-navigation.module'
import { MemberService } from './services/member.service'

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    CustomNavigationModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  bootstrap: [AppComponent],
  providers: [MemberService],
})
export class AppModule {}
