import { NgModule } from '@angular/core';

import {
    MatIconModule,
    MatToolbarModule,
    MatButtonModule,
    MatCardModule,
    MatSlideToggleModule
} from '@angular/material';

const materialModules = [
    MatIconModule,
    MatToolbarModule,
    MatButtonModule,
    MatCardModule,
    MatSlideToggleModule
];

@NgModule({
    imports: materialModules,
    exports: materialModules
})
export class AppMaterialModule { }
