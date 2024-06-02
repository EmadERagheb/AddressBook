import { Component, OnInit } from '@angular/core';
import { HomeService } from './home.service';
import { PersonCard } from '../shared/models/person-card';
import { PersonParams } from '../shared/models/person-params';
import { Department } from '../shared/models/department';
import { Job } from '../shared/models/job';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent implements OnInit {
  persons: PersonCard[] = [];
  departments: Department[] = [];
  jobs: Job[] = [];
  personsParams = new PersonParams();
  constructor(private homeService: HomeService) {}
  ngOnInit(): void {
    this.loadPersons();
    this.loadDepartments();
    this.loadJob();
  }
  loadPersons() {
    this.homeService.getAllPersons(this.personsParams).subscribe({
      next: (response) => {
        this.persons = response;
      },
    });
  }
  loadDepartments() {
    this.homeService.getAllDepartments().subscribe({
      next: (data) => {
        this.departments = data;
      },
    });
  }
  loadJob() {
    this.homeService.getAllJobs().subscribe({
      next: (data) => {
        this.jobs = data;
      },
    });
  }
}
