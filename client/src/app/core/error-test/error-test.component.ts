import { Component } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-error-test',
  templateUrl: './error-test.component.html',
  styleUrl: './error-test.component.scss'
})
export class ErrorTestComponent {

  baseUrl = environment.apiUrl+'/api/TestErrors/';
  validationsErrors:string[]=[]
  constructor(private httpClient: HttpClient) {}
  get404Error() {
    
    this.httpClient.get(this.baseUrl + 'notFound').subscribe({
      next: (response) => console.log(response),
      error: (error) => console.log(error),
    });
  }
  get500Error() {
    console.log(this.baseUrl)
    this.httpClient.get(this.baseUrl + 'serverError').subscribe({
      next: (response) => console.log(response),
      error: (error) => console.log(error),
    });
  }
  get400ValidationError() {
    this.httpClient.get(this.baseUrl + 'badRequest/fortyTwo').subscribe({
      next: (response) => console.log(response),
      error: (error) => {
        this.validationsErrors=error.errors
        console.log(this.validationsErrors);}
    });
  }
  get400Error() {
    this.httpClient.get(this.baseUrl + 'badRequest').subscribe({
      next: (response) => console.log(response),
      error: (error) => console.log(error),
    });
  }
}

