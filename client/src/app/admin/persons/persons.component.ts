import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../home/home.service';
import { PersonCard } from '../../shared/models/person-card';
import { PersonParams } from '../../shared/models/person-params';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrl: './persons.component.scss',
})
export class PersonsComponent implements OnInit {
delete(arg0: number) {
throw new Error('Method not implemented.');
}
  persons: PersonCard[] = [];
  personsParams: PersonParams = new PersonParams();
  total = 0;
  constructor(private homeService: HomeService) {}

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
}
