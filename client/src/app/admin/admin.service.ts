import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Person } from '../shared/models/person';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AdminService {
  private personEndPointURL: string = environment.apiUrl + '/api/Persons';
  constructor(private httpClient: HttpClient) {}
  updatePerson(person: Person) {
    return this.httpClient.put(this.personEndPointURL+'/'+person.id, person);
  }
}
