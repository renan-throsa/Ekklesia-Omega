import { Component, OnInit } from '@angular/core'
import { Router } from '@angular/router'
import { IdentityService } from 'src/app/services/identity.service'
import { FaIconLibrary } from '@fortawesome/angular-fontawesome'
import {
  faArrowRightFromBracket,
  faArrowRightToBracket,
} from '@fortawesome/free-solid-svg-icons'

@Component({
  selector: 'app-custom-profile',
  templateUrl: './custom-profile.component.html',
})
export class CustomProfileComponent implements OnInit {
  userName: string | undefined
  constructor(
    private _accountService: IdentityService,
    private _router: Router,
    private _library: FaIconLibrary,
  ) {
    this._library.addIcons(faArrowRightFromBracket, faArrowRightToBracket)
    this.userName = ''
  }

  ngOnInit(): void {}

  isLoggedIn(): boolean {    
    if (this._accountService.isAuthenticated) {
      this.userName = this._accountService.User.name
      return true
    }
    return false
  }

  logOut() {
    this._accountService.logOut();    
    this._router.navigate(['/account'])
  }
}
