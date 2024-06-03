import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TextInputComponent } from './components/text-input/text-input.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { PagerComponent } from './components/pager/pager.component';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@NgModule({
  declarations: [TextInputComponent, PagerComponent, PagingHeaderComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    PaginationModule.forRoot(),
    BsDropdownModule.forRoot(),
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
  ],
})
export class SharedModule {}
