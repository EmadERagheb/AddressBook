import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-confirmation-model',
  templateUrl: './confirmation-model.component.html',
  styleUrl: './confirmation-model.component.scss'
})
export class ConfirmationModelComponent {
  @Input() userName:string=""
  constructor(public modal: NgbActiveModal) {}
}
