import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import {ICar} from './car';
import { CarService } from './car.service';

@Component({
    templateUrl: './app/cars/car-list.component.html',
    styleUrls:['./app/cars/car-list.component.css']
})
export class CarListComponent implements OnInit {

    pageTitle: string = 'Xplicit Car List::-';
    imageWidth: number = 50;
    imageMargin: number = 2;
    showImage: boolean = false;
    listFilter: string;
    errorMessage: string;

    cars: ICar[];

    constructor(private carService: CarService, private route: ActivatedRoute) { }

    toggleImage(): void {
        this.showImage = !this.showImage;
    }

    ngOnInit(): void {
        this.listFilter = this.route.snapshot.queryParams['filterBy'] || '';

        // NB: params are always string thus setting a 'true' rather than true
        this.showImage = this.route.snapshot.queryParams["showImage"] === 'true';
        this.carService.getCars()
            .subscribe(cars => this.cars = cars, error => this.errorMessage = <any>error);
    }
}
