import { Component } from '@angular/core';
import { AccountService } from '../../account/account.service';
import { AdminService } from '../../admin/admin.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.scss',
})
export class NavBarComponent {
  constructor(public accountService: AccountService,private adminServices:AdminService) {}
  downLoadPersons() {
    this.adminServices.exportPersonsToExcel().subscribe();
  }
}
