import { Component, Input, input } from '@angular/core';
import { PersonCard } from '../../shared/models/person-card';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-person-card',
  templateUrl: './person-card.component.html',
  styleUrl: './person-card.component.scss'
})
export class PersonCardComponent {
@Input() person?:PersonCard
host=environment.apiUrl+'/'
}
