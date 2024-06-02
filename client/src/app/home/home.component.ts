import { Component, OnInit } from '@angular/core';
import { HomeService } from './home.service';
import { PersonCard } from '../shared/models/person-card';
import { PersonParams } from '../shared/models/person-params';
import { Department } from '../shared/models/department';
import { Job } from '../shared/models/job';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent implements OnInit {
  persons: PersonCard[] = [];
  departments: Department[] = [];
  jobs: Job[] = [];
  total = 0;
  personsParams = new PersonParams();
  sortingOptions = [
    { name: 'Name:Ascending', value: 'name' },
    { name: 'Name:Descending', value: 'nameDesc' },
    { name: 'City: Ascending', value: 'priceAsc' },
    { name: 'City: Descending', value: 'priceDesc' },
  ];
  constructor(private homeService: HomeService, private fb: FormBuilder) {}
  searchForm = this.fb.group({
    fullName: [''],
    email: [''],
    city: [''],
    birthDate: [''],
  });
  ngOnInit(): void {
    this.loadAll();
  }
  loadPersons() {
    this.homeService.getAllPersons(this.personsParams).subscribe({
      next: (response) => {
        this.persons = response.data;
        this.total = response.count;
      },
    });
  }
  loadDepartments() {
    this.homeService.getAllDepartments(this.personsParams.jobId).subscribe({
      next: (data) => {
        this.departments = [
          {
            id: 0,
            jobId: 0,
            name: 'All',
          },
          ...data,
        ];
      },
    });
  }
  loadJob() {
    this.homeService.getAllJobs().subscribe({
      next: (data) => {
        this.jobs = [{ id: 0, name: 'All' }, ...data];
      },
    });
  }
  loadAll() {
    this.loadPersons();
    this.loadDepartments();
    this.loadJob()
  }
  onDepartmentSelected(departmentId: number, jobId: number) {
    this.personsParams.departmentId = departmentId;
    this.personsParams.jobId = jobId;
    this.personsParams.pageIndex = 1;
    this.loadAll();
  }
  onJobTypeSelected(jobId: number) {
    this.personsParams.jobId = jobId;
    this.personsParams.departmentId=0
    this.personsParams.pageIndex = 1;
    this.loadAll();
  }
  onSortSelected(event: any) {
    this.personsParams.sort = event.target.value;
    this.loadPersons();
  }
  onPageChange(event: any) {
    if (this.personsParams.pageIndex != event) {
      this.personsParams.pageIndex = event;
      this.loadPersons();
    }
  }
  onSearch() {
    if (this.searchForm.dirty) {
      this.personsParams = {
        ...this.personsParams,
        ...(this.searchForm.value as PersonParams),
      };

      this.loadPersons();
    }
  }
  onReset() {
    this.personsParams = new PersonParams();
    this.searchForm.reset();
    this.loadPersons();
  }
}
