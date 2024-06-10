import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonsComponent } from './persons/persons.component';
import { AdminRoutingModule } from './admin-routing.module';
import { SharedModule } from '../shared/shared.module';
import { PersonEditComponent } from './person-edit/person-edit.component';
import { PersonCreateComponent } from './person-create/person-create.component';
import { JobComponent } from './job/job.component';
import { DepartmentComponent } from './department/department.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';




@NgModule({
  declarations: [
    PersonsComponent,
    PersonEditComponent,
    PersonCreateComponent,
    JobComponent,
    DepartmentComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    SharedModule,
    BsDatepickerModule.forRoot(),

  ]
})
export class AdminModule { }
