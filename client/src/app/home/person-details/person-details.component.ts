import { Component, OnInit } from '@angular/core';
import { PersonDetails } from '../../shared/models/person-details';
import { HomeService } from '../home.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-person-details',
  templateUrl: './person-details.component.html',
  styleUrl: './person-details.component.scss',
})
export class PersonDetailsComponent implements OnInit {
  person?: PersonDetails;
  constructor(
    private homeService: HomeService,
    private activeRouter: ActivatedRoute
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
}
