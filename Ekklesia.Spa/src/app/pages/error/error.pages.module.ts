import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { RouterModule } from '@angular/router'
import { NotFoundComponent } from './not-found/not-found.component'
import { InternalServerErrorComponent } from './internal-server-error/internal-server-error.component'
import { UnauthorizedComponent } from './unauthorized/unauthorized.component'
import { ErrorPagesRoutingModule } from './error.pages-routing'
@NgModule({
  declarations: [
    NotFoundComponent,
    InternalServerErrorComponent,
    UnauthorizedComponent,
  ],
  imports: [CommonModule, RouterModule, ErrorPagesRoutingModule],
  exports: [
    NotFoundComponent,
    UnauthorizedComponent,
    InternalServerErrorComponent,
  ],
})
export class ErrorPagesModule {}
