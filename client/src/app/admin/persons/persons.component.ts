import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../home/home.service';
import { PersonCard } from '../../shared/models/person-card';
import { PersonParams } from '../../shared/models/person-params';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationModelComponent } from '../../shared/confirmation-model/confirmation-model.component';
import { AdminService } from '../admin.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrl: './persons.component.scss',
})
export class PersonsComponent implements OnInit {
  persons: PersonCard[] = [];
  personsParams: PersonParams = new PersonParams();
  total = 0;
  constructor(
    private homeService: HomeService,
    private modelService: NgbModal,
    private adminService: AdminService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.loadPersons();
  }
  loadPersons() {
    this.homeService.getAllPersons(this.personsParams).subscribe({
      next: (response) => {
        this.persons = response.data;
        this.total = response.count;
      },
    });
  }
  onPageChange(event: any) {
    if (this.personsParams.pageIndex != event) {
      this.personsParams.pageIndex = event;
      this.loadPersons();
    }
  }
  delete(id: number, fullName: string) {
    let modal = ConfirmationModelComponent;
    let modalRef = this.modelService.open(modal);
    modalRef.componentInstance.userName = fullName;
    modalRef.closed.subscribe({
      next: (res) => {
        this.adminService.deletePerson(id).subscribe({
          next: () => {
            this.loadPersons();
            this.toastr.success('user deleted success', 'success');
          },
        });
      },
    });
  }
}
