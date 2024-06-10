import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Person } from '../shared/models/person';
import { environment } from '../../environments/environment';
import { map } from 'rxjs';
import { saveAs } from 'file-saver';

@Injectable({
  providedIn: 'root',
})
export class AdminService {
  private personEndPointURL: string = environment.apiUrl + '/api/Persons';
  private exportEndPoint: string = environment.apiUrl + '/api/Export';
  constructor(private httpClient: HttpClient) {}
  createPerson(person: Person) {
    return this.httpClient.post<Person>(this.personEndPointURL, person);
  }
  updatePerson(person: Person) {
    return this.httpClient.put(
      this.personEndPointURL + '/' + person.id,
      person
    );
  }
  deletePerson(id: number) {
    return this.httpClient.delete(this.personEndPointURL + '/' + id);
  }
  uploadImage(file: File) {
    const formData = new FormData();
    formData.append('image', file, file.name);
    return this.httpClient.post(
      this.personEndPointURL + '/uploadImage',
      formData,
      { responseType: 'text' }
    );
  }
  updateUserImage(id: number, file: File) {
    const formData = new FormData();
    formData.append('image', file, file.name);

    let params = new HttpParams();
    params = params.append('id', id);
    return this.httpClient.post(
      this.personEndPointURL + '/updatePersonImage',
      formData,
      { params, responseType: 'text' }
    );
  }
  isEmailExists(email: string) {
    let params = new HttpParams().set('Email', email);
    return this.httpClient.get(this.personEndPointURL + '/isMailExists', {
      params,
    });
  }
  exportPersonsToExcel() {
    return this.httpClient.get(this.exportEndPoint + '/ExportListToExcel',
      { responseType: 'blob' }).pipe(
        map(blob => {
          saveAs(blob, 'DataExport.xlsx');
        })
    );
  }
}
