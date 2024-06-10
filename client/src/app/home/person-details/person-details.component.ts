import { Component, OnInit } from '@angular/core';
import { PersonDetails } from '../../shared/models/person-details';
import { HomeService } from '../home.service';
import { environment } from '../../../environments/environment';
import { AccountService } from '../../account/account.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-person-details',
  templateUrl: './person-details.component.html',
  styleUrl: './person-details.component.scss',
})
export class PersonDetailsComponent implements OnInit {
  person?: PersonDetails;
  constructor(
    private homeService: HomeService,
  ) {}
  ngOnInit(): void {
    this.loadPerson();
  }
  loadPerson() {
    const id = this.activeRouter.snapshot.paramMap.get('id');
    if (id) {
      this.homeService.getPerson(+id).subscribe({
        next: (data) => {
          this.person = data;
        },
      });
    }
  }
  goBack() {
    history.back();
  }
}
