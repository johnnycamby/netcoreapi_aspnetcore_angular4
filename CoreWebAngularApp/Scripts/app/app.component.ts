﻿
import { Component } from '@angular/core';
import { Router, Event, NavigationStart, NavigationEnd, NavigationError, NavigationCancel } from '@angular/router';

@Component({
    selector: 'x-app',
    templateUrl:'./app/app.component.html'
})

export class AppComponent {

    pageTitle: string = 'Xplicit Cars';
    loading: boolean = true;
    
    constructor(private router: Router) {
        router.events.subscribe((routerEvent: Event) => { this.checkRouterEvent(routerEvent) });
    }

    checkRouterEvent(routerEvent: Event): void {

        if (routerEvent instanceof NavigationStart) {
            this.loading = true;
        }
        if (routerEvent instanceof NavigationEnd || routerEvent instanceof NavigationCancel || routerEvent instanceof NavigationError) {
            this.loading = false;
        }
    }
}