import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/of';


import { ICar } from './car';

@Injectable()
export class CarService {

    // api/companies/{companyId}/cars
    private baseUrl = 'api/cars';

    constructor(private http: Http) { }

    getCars(): Observable<ICar[]> {
        return this.http.get(this.baseUrl)
            .map(this.extractData)
            .do(data => console.log('getProducts: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    getCar(id: string): Observable<ICar> {
        if (id === null) {
            return Observable.of(this.initializeCar());
        }

        const url = `${this.baseUrl}/${id}`;
        return this.http.get(url)
            .map(this.extractData)
            .do(data => console.log('getProduct: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private extractData(response: Response) {
        let body = response.json();
        return body.data || {};
    }

    private handleError(error: Response): Observable<any> {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

    initializeCar(): ICar {
        return {
            id: null,
            carModel: null,
            carName: null,
            description: null,
            rating: null,
            imageUrl: null
        };
    }
}

