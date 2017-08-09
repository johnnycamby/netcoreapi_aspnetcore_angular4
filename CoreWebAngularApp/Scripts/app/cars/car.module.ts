import { NgModule } from '@angular/core';
// import { RouterModule } from '@angular/router';

import { CarListComponent } from './car-list.component';

import { CarService } from './car.service';

@NgModule({
    imports: [],
    declarations: [CarListComponent],
    providers:[CarService]
})
export class CarModule {
    
}