import { Component, OnInit } from '@angular/core'
import { UntypedFormBuilder } from '@angular/forms'
import { Router } from '@angular/router'
import { IdentityService } from 'src/app/services/identity.service'

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: [],
})
export class ProfileComponent implements OnInit {
  constructor(
    private _formBuilder: UntypedFormBuilder,
    private _accountService: IdentityService,
    private _router: Router,
  ) {}

  ngOnInit(): void {}
}
