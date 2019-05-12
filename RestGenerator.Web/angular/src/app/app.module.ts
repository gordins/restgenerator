import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppMaterialModule } from './app-material.module';

import { AppComponent } from './app.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { DashboardComponent } from './dashboard/dashboard.component';

import { ApisComponent } from './apis/apis.component';
import { ApiDetailsComponent } from './api-details/api-details.component';
import { ApiSearchComponent } from './api-search/api-search.component';

import { DataService } from './shared';
@NgModule({
    declarations: [
        ApisComponent,
        ApiDetailsComponent,
        ApiSearchComponent,
        AppComponent,
        DashboardComponent,
        NotFoundComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        BrowserAnimationsModule,
        HttpClientModule,
        AppRoutingModule,
        AppMaterialModule
    ],
    providers: [
        DataService
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }
