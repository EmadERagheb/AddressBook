import { NgModule } from '@angular/core';
import { RouterModule, Routes, provideRouter, withHashLocation } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PersonDetailsComponent } from './home/person-details/person-details.component';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { AuthGuard } from './core/guards/auth.guard';
import { ErrorTestComponent } from './core/error-test/error-test.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home',
  canActivate:[AuthGuard],
   component: HomeComponent  },
  {
    path: 'account',
    
    loadChildren: () =>
      import('./account/account.module').then((m) => m.AccountModule),
  },
  { path: 'error-test', component: ErrorTestComponent },
  { path: 'person/:id', 
  canActivate:[AuthGuard],
  component: PersonDetailsComponent },
  {
    canActivate:[AuthGuard],
    path: 'admin',
    loadChildren: () =>
      import('./admin/admin.module').then((m) => m.AdminModule),
  },
  { path: 'not-found', component: NotFoundComponent },
  { path: 'server-error', component: ServerErrorComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [
    provideRouter(routes, withHashLocation())
  ]
})
export class AppRoutingModule {}
