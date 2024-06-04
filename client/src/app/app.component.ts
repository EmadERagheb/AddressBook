import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent implements OnInit {
  title = 'Address Book';
  constructor(private accountService: AccountService) {}
  ngOnInit(): void {
    this.loadCurrentUser();
  }
  loadCurrentUser() {
    const token = localStorage.getItem('token');
    this.accountService.getCurrentUser(token).subscribe({
      next: (data) => {
        console.log(data);
      },
    });
  }
}
