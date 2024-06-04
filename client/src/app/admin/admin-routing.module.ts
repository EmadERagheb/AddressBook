import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { PersonsComponent } from './persons/persons.component';
import { PersonEditComponent } from './person-edit/person-edit.component';
import { PersonCreateComponent } from './person-create/person-create.component';
import { JobComponent } from './job/job.component';
import { DepartmentComponent } from './department/department.component';

const routes: Routes = [
  { path: 'persons', component: PersonsComponent },
  { path: 'jobs', component: JobComponent },
  { path: 'departments', component: DepartmentComponent },
  { path: 'persons/:id', component: PersonEditComponent },
  { path: 'create-person', component: PersonCreateComponent },
];

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
