import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { SharedModule } from '../shared/shared.module';
import { AccountRoutingModule } from './account-routing.module';

@NgModule({
  declarations: [LoginComponent],
  imports: [CommonModule, SharedModule, AccountRoutingModule],
})
export class AccountModule {}
