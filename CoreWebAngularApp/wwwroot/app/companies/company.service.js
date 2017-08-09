"use strict";var __decorate=this&&this.__decorate||function(decorators,target,key,desc){var d,c=arguments.length,r=c<3?target:null===desc?desc=Object.getOwnPropertyDescriptor(target,key):desc;if("object"==typeof Reflect&&"function"==typeof Reflect.decorate)r=Reflect.decorate(decorators,target,key,desc);else for(var i=decorators.length-1;i>=0;i--)(d=decorators[i])&&(r=(c<3?d(r):c>3?d(target,key,r):d(target,key))||r);return c>3&&r&&Object.defineProperty(target,key,r),r},__metadata=this&&this.__metadata||function(k,v){if("object"==typeof Reflect&&"function"==typeof Reflect.metadata)return Reflect.metadata(k,v)},core_1=require("@angular/core"),http_1=require("@angular/http"),Observable_1=require("rxjs/Observable");require("rxjs/add/operator/do"),require("rxjs/add/operator/catch"),require("rxjs/add/observable/throw"),require("rxjs/add/operator/map"),require("rxjs/add/observable/of");var CompanyService=function(){function CompanyService(http){this.http=http,this.baseUrl="api/companies"}return CompanyService.prototype.getCompanies=function(){return this.http.get(this.baseUrl).map(this.retrieveData).do(function(data){return console.log("getCompanies: "+JSON.stringify(data))}).catch(this.handleError)},CompanyService.prototype.retrieveData=function(response){return response.json().data||{}},CompanyService.prototype.handleError=function(error){return console.error(error),Observable_1.Observable.throw(error.json().error||"Server error")},CompanyService}();CompanyService=__decorate([core_1.Injectable(),__metadata("design:paramtypes",[http_1.Http])],CompanyService),exports.CompanyService=CompanyService;
//# sourceMappingURL=company.service.js.map
