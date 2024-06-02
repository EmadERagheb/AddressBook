import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TextInputComponent } from './components/text-input/text-input.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    TextInputComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  exports:[
    TextInputComponent,
    ReactiveFormsModule

  ]
})
export class SharedModule { }
