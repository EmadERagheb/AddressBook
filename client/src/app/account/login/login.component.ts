import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AccountService } from '../account.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Login } from '../../shared/models/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent {
  returnUrl: string;
  constructor(
    private fb: FormBuilder,
    private accountService: AccountService,
    private router: Router,
    private activateRouter: ActivatedRoute
  ) {
    this.returnUrl = this.activateRouter.snapshot.queryParams['returnUrl'];
  }

  loginForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required],
  });
  get email() {
    return this.loginForm.get('email');
  }
  get password() {
    return this.loginForm.get('password');
  }

  onSubmit() {
    const login = this.loginForm.value as Login;
    this.accountService.login(login).subscribe({
      next: () => {
        if (this.returnUrl) this.router.navigate([this.returnUrl]);
        else this.router.navigateByUrl('/');
      },
    });
  }
}
