import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { PersonCardComponent } from './person-card/person-card.component';
import { SharedModule } from '../shared/shared.module';
import { PersonDetailsComponent } from './person-details/person-details.component';



@NgModule({
  declarations: [
    HomeComponent,
    PersonCardComponent,
    PersonDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class HomeModule  { }
