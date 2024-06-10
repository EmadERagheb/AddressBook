import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpClientModule, HttpParams } from '@angular/common/http';
import { PersonParams } from '../shared/models/person-params';
import { PersonCard } from '../shared/models/person-card';
import { Job } from '../shared/models/job';
import { Department } from '../shared/models/department';
import { Paging } from '../shared/models/paging';
import { PersonDetails } from '../shared/models/person-details';

@Injectable({
  providedIn: 'root',
})
export class HomeService {
  private personEndPointURL: string = environment.apiUrl+'/api/Persons';
  private jobEndPoint: string = environment.apiUrl + '/api/Jobs';
  private DepartmentEndPoint: string = environment.apiUrl + '/api/Departments';

  constructor(private httpClient: HttpClient) {}
  getAllPersons(personParams: PersonParams) {
    let params = this.buildGetAllPersonsParams(personParams);
    return this.httpClient.get<Paging<PersonCard[]>>(this.personEndPointURL, {
      params,
    });
  }
  getPerson(id: number) {
    return this.httpClient.get<PersonDetails>(
      this.personEndPointURL + '/' + id
    );
  }
  getAllJobs() {
    return this.httpClient.get<Job[]>(this.jobEndPoint);
  }
  getAllDepartments(jobId: number) {
    let params = new HttpParams();
    if (jobId > 0) params = params.append('JobId', jobId);
    return this.httpClient.get<Department[]>(this.DepartmentEndPoint, {
      params,
    });
  }
  private buildGetAllPersonsParams(personParams: PersonParams): HttpParams {
    let params = new HttpParams();
    params = params.append('PageSize', personParams.pageSize);
    params = params.append('PageIndex', personParams.pageIndex);
    params = params.append('Sort', personParams.sort);
    if (personParams.departmentId > 0)
      params = params.append('DepartmentId', personParams.departmentId);
    if (personParams.jobId > 0)
      params = params.append('JobId', personParams.jobId);
    if (personParams.fullName)
      params = params.append('FullName', personParams.fullName);
    if (personParams.email) params = params.append('Email', personParams.email);
    if (personParams.city) params = params.append('City', personParams.city);
    if (personParams.birthDate)
      params = params.append('BirthDate', personParams.birthDate);
    return params;
  }
}
