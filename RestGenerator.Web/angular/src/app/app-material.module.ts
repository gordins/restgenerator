import { NgModule } from '@angular/core';

import { MatIconModule } from '@angular/material';

const materialModules = [
  MatIconModule
];

@NgModule({
  imports: materialModules,
  exports: materialModules
})
export class AppMaterialModule { }
