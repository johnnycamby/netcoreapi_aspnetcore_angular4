
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ICompany } from './company';
import { CompanyService } from './company.service';

@Component({
    templateUrl: './app/companies/company-list.component.html', 
    styleUrls: ['./app/companies/company-list.component.css']
})
export class CompanyListComponent implements OnInit {

    pageTitle: string = 'Companies List';
    imageWidth: number = 80;
    imageMargin: number = 2;
    listFilter: string;
    errorMessage: string;

    companies: ICompany[];

    constructor(private companyService: CompanyService, private route: ActivatedRoute) {}

    ngOnInit(): void {
        this.listFilter = this.route.snapshot.queryParams["filterBy"] || '';
        this.companyService.getCompanies()
            .subscribe(companies => this.companies = companies, error => this.errorMessage = <any>error);
    }
}