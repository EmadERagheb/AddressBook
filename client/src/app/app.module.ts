import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import {  HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { HomeModule } from './home/home.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ErrorInterceptor } from './core/interceptors/error.interceptor';
import { JwtInterceptor } from './core/interceptors/jwt.interceptor';
import { LoadingInterceptor } from './core/interceptors/loading.interceptor';



@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CoreModule,
    HttpClientModule,
    HomeModule,
    NgbModule,
    
  ],
  providers: [
    {provide:HTTP_INTERCEPTORS,useClass:LoadingInterceptor,multi:true},
    {provide:HTTP_INTERCEPTORS,useClass:ErrorInterceptor,multi:true},
    {provide:HTTP_INTERCEPTORS,useClass:JwtInterceptor,multi:true},

  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
