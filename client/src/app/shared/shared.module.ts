import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TextInputComponent } from './components/text-input/text-input.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { PagerComponent } from './components/pager/pager.component';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ConfirmationModelComponent } from './confirmation-model/confirmation-model.component';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [TextInputComponent, PagerComponent, PagingHeaderComponent, ConfirmationModelComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    PaginationModule.forRoot(),
    BsDropdownModule.forRoot(),
    NgbModalModule,
  ],
  exports: [
    CommonModule,
    TextInputComponent,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    PaginationModule,
    PagingHeaderComponent,
    PagerComponent,
    BsDropdownModule,
    NgbModalModule,
  ],
})
export class SharedModule {}
