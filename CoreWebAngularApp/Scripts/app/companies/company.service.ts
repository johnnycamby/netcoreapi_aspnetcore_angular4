import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/of';

import { ICompany} from './company';

@Injectable()
export class CompanyService {

    private baseUrl = 'api/companies';

    constructor(private http: Http) { }

    getCompanies(): Observable<ICompany[]> {
        return this.http.get(this.baseUrl)
            .map(this.retrieveData)
            .do(data => console.log('getCompanies: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private retrieveData(response: Response) {
        let body = response.json();
        return body.data || {};
    }

    private handleError(error: Response): Observable<any> {

        // TODO: send the server to some remote logging infrastructure, instead of just logging it to the console
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}
