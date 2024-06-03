import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonsComponent } from './persons/persons.component';
import { AdminRoutingModule } from './admin-routing.module';
import { SharedModule } from '../shared/shared.module';
import { PersonEditComponent } from './person-edit/person-edit.component';




@NgModule({
  declarations: [
    PersonsComponent,
    PersonEditComponent
  ],
  imports: [
    CommonModule,
   
    
    AdminRoutingModule,
    SharedModule
  ]
})
export class AdminModule { }
