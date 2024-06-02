import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpClientModule, HttpParams } from '@angular/common/http';
import { PersonParams } from '../shared/models/person-params';
import { PersonCard } from '../shared/models/person-card';
import { Job } from '../shared/models/job';
import { Department } from '../shared/models/department';

@Injectable({
  providedIn: 'root',
})
export class HomeService {
  personEndPointURL: string = environment.apiUrl + 'Persons';
  jobEndPoint: string = environment.apiUrl + 'Jobs';
  DepartmentEndPoint: string = environment.apiUrl + 'Departments';

  constructor(private httpClient: HttpClient) {}
  getAllPersons(personParams: PersonParams) {
    let params = this.buildGetAllPersonsParams(personParams);
    return this.httpClient.get<PersonCard[]>(this.personEndPointURL, {
      params,
    });
  }
  getAllJobs() {
     return this.httpClient.get<Job[]>(this.jobEndPoint);
  }
  getAllDepartments(){
    return this.httpClient.get<Department[]>(this.DepartmentEndPoint) 
  }
  private buildGetAllPersonsParams(personParams: PersonParams): HttpParams {
    let params = new HttpParams();
    params = params.append('PageSize', personParams.pageSize);
    params = params.append('PageIndex', personParams.pageIndex);
    params = params.append('Sort', personParams.sort);
    if (personParams.departmentId > 0)
      params = params.append('DepartmentId', personParams.departmentId);
    if (personParams.fullName)
      params = params.append('FullName', personParams.fullName);
    if (personParams.email) params = params.append('Email', personParams.email);
    if (personParams.city) params = params.append('City', personParams.city);
    if (personParams.birthDate)
      params = params.append('BirthDate', personParams.birthDate);
    return params;
  }
}
