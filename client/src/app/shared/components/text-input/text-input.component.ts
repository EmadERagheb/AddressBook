import { Component, Input, Self, input } from '@angular/core';
import { FormControl, NgControl } from '@angular/forms';

@Component({
  selector: 'app-text-input',
  templateUrl: './text-input.component.html',
  styleUrl: './text-input.component.scss'
})
export class TextInputComponent {
  @Input() feedBack:boolean = true;
  @Input() accept="*";
  @Input() type = 'text';
  @Input() label = '';
  @Input() characters = '';
  @Input() patternHint = '';
  constructor(@Self() public controlDir: NgControl) {
    this.controlDir.valueAccessor = this;
  }
  writeValue(obj: any): void {}
  registerOnChange(fn: any): void {}
  registerOnTouched(fn: any): void {}
  get control(): FormControl {
    return this.controlDir.control as FormControl;
  }
}


