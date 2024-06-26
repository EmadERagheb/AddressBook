import { Component } from '@angular/core';
import { AdminService } from '../admin.service';
import { HomeService } from '../../home/home.service';
import { AbstractControl, AsyncValidatorFn, FormBuilder, Validators } from '@angular/forms';
import { Department } from '../../shared/models/department';
import { Job } from '../../shared/models/job';
import { Person } from '../../shared/models/person';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { debounceTime, take, switchMap, map } from 'rxjs';

@Component({
  selector: 'app-person-create',
  templateUrl: './person-create.component.html',
  styleUrl: './person-create.component.scss',
})
export class PersonCreateComponent {
  selectedFile!: File;
  onFileSelected(event: any) {
    this.selectedFile = event.target.files[0];
  }
  constructor(
    private toastr: ToastrService,
    private adminService: AdminService,
    private homeService: HomeService,
    private fb: FormBuilder,
    private router: Router
  ) {}
  departments: Department[] = [];
  jobs: Job[] = [];
  createPersonForm = this.fb.group({
    fullName: ['', Validators.required],
    mobile: ['', [Validators.required, Validators.pattern('[0-9]{6,}')]],
    email: ['', [Validators.required, Validators.email],
    [this.validateEmailIfExist()]
  ],
    image: [null, Validators.required],
    birthDate: ['', Validators.required],
    street: ['', Validators.required],
    city: ['', Validators.required],
    state: ['', Validators.required],
    postalCode: ['', Validators.required],
    departmentId: ['0', [Validators.required, Validators.pattern('[1-9]{1,}')]],
    jobId: [0],
  });
  validateEmailIfExist(): AsyncValidatorFn {
    return (control: AbstractControl) => {
      return control.valueChanges.pipe(
        debounceTime(1000),
        take(1),
        switchMap(() => {
          return this.adminService
            .isEmailExists(control.value)
            .pipe(map((result) => (result ? { emailExists: true } : null)));
        })
      );
    };
  }
  get departmentId() {
    return this.createPersonForm.get('departmentId');
  }
  get jobId() {
    return this.createPersonForm.get('jobId');
  }

  ngOnInit(): void {
    this.loadDepartments();
    this.loadJob();
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
        this.jobs = [{ id: 0, name: 'All' }, ...data];
      },
    });
  }
  onJobSelected() {
    this.loadDepartments();
    this.departmentId?.setValue('0');
  }
  saveChanges() {
    const departmentId = Number(this.departmentId?.value);
    const newPersonData: Person = {
      ...this.createPersonForm.value,
      departmentId: departmentId,
    } as Person;
    this.adminService.uploadImage(this.selectedFile).subscribe({
      next: (data: any) => {
        newPersonData.imageUrl = data;
        this.adminService.createPerson(newPersonData).subscribe({
          next: (data) => {
            this.router.navigate(['/person', data.id]);
            this.toastr.show('person created success','success')
          },
        });
      },
    });
  }
}
