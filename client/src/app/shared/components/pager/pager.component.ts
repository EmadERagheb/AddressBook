import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrl: './pager.component.scss'
})
export class PagerComponent {
  @Input() totalItems?: number;
  @Input() pageSize?: number;
  @Output() pageChanges: EventEmitter<number> = new EventEmitter<number>();
  onPageChange(event: any) {
    this.pageChanges.emit(event.page);
  }
}
