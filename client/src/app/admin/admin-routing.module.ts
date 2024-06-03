import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { PersonsComponent } from './persons/persons.component';
import { PersonEditComponent } from './person-edit/person-edit.component';

const routes: Routes = [
  { path: 'persons', component: PersonsComponent },
  { path: 'persons/:id', component: PersonEditComponent },
];

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
