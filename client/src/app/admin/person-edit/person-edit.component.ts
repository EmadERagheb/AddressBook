import { Component, OnInit } from '@angular/core';
import { Person } from '../../shared/models/person';
import { ActivatedRoute } from '@angular/router';
import { AdminService } from '../admin.service';
import { HomeService } from '../../home/home.service';
import { PersonDetails } from '../../shared/models/person-details';
import { FormBuilder, Validators } from '@angular/forms';
import { Department } from '../../shared/models/department';
import { Job } from '../../shared/models/job';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-person-edit',
  templateUrl: './person-edit.component.html',
  styleUrl: './person-edit.component.scss',
})
export class PersonEditComponent implements OnInit {
  constructor(
    private activatedRoute: ActivatedRoute,
    private adminService: AdminService,
    private homeService: HomeService,
    private fb: FormBuilder
  ) {}
  host = environment.apiUrl + '/';
  selectedFile!: File;
  person?: PersonDetails;
  departments: Department[] = [];
  jobs: Job[] = [];
  editPersonForm = this.fb.group({
    fullName: ['', Validators.required],
    mobile: ['', [Validators.required, Validators.pattern('[0-9]{6,}')]],
    email: ['', [Validators.required, Validators.email]],
    imageUrl: ['', Validators.required],
    birthDate: ['', Validators.required],
    id: [0],
    street: ['', Validators.required],
    city: ['', Validators.required],
    state: ['', Validators.required],
    postalCode: ['', Validators.required],
    departmentId: ['', [Validators.required, Validators.pattern('[1-9]{1,}')]],
    jobId: [0],
  });
  get departmentId() {
    return this.editPersonForm.get('departmentId');
  }
  get jobId() {
    return this.editPersonForm.get('jobId');
  }

  ngOnInit(): void {
    this.loadPerson();

    this.loadJob();
  }
  loadPerson() {
    let personId = this.activatedRoute.snapshot.paramMap.get('id');
    if (personId)
      this.homeService.getPerson(+personId).subscribe({
        next: (data) => {
          this.person = data;
          this.editPersonForm.reset({
            ...data,
            departmentId: data.departmentId.toString(),
          });
          this.loadDepartments();
        },
      });
  }
  loadDepartments() {
    this.homeService.getAllDepartments(this.jobId?.value || 0).subscribe({
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
        this.jobs = data;
      },
    });
  }
  onJobSelected() {
    // console.log(this.person)
    this.loadDepartments();
    this.departmentId?.setValue('0');
    console.log(this.editPersonForm.value);
  }
  saveChanges() {
    const personData = {
      ...this.editPersonForm.value,
      departmentId: Number(this.departmentId?.value),
    } as Person;
    this.adminService.updatePerson(personData).subscribe({
      next: () => {
        if (personData.id)
          this.homeService.getPerson(personData.id).subscribe({
            next: (data) => {
              this.person = data;
              this.editPersonForm.reset({
                ...data,
                departmentId: data.departmentId.toString(),
              });
            },
          });
      },
    });
  }
  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
    if (this.person?.id) {
      this.adminService
        .updateUserImage(this.person?.id, this.selectedFile)
        .subscribe({
          next: (res) => {
            this.loadPerson();
          },
        });
    }
  }
}
