import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { CompanyListComponent } from './company-list.component';

import { CompanyFilterPipe } from './company-filter.pipe';
import { CompanyService } from './company.service';

import { SharedModule } from '../shared/shared.module';

@NgModule({
    imports: [
        SharedModule,
        RouterModule.forChild([
                {path: '', component: CompanyListComponent }
        ])
    ],
    declarations: [CompanyListComponent, CompanyFilterPipe],
    providers: [CompanyService]
})
export class CompanyModule {}