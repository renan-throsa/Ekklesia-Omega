import { Component, OnInit } from '@angular/core'
import { FaIconLibrary } from '@fortawesome/angular-fontawesome'
import { faDove, faL } from '@fortawesome/free-solid-svg-icons'

@Component({
  selector: 'app-custom-menu',
  templateUrl: './custom-menu.component.html',
  styleUrls: [],
})
export class CustomMenuComponent implements OnInit {
  isCollapsed: boolean;
  constructor(library: FaIconLibrary) {
    library.addIcons(faDove)
    this.isCollapsed = true;
  }

  collapse(){
    this.isCollapsed = !this.isCollapsed;
    console.log(this.isCollapsed);
    
  }
  ngOnInit(): void {}
}
