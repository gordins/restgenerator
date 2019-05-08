import { Component, OnInit } from '@angular/core';
import { DataService, Api } from '../shared';

@Component({
    selector: 'app-apis',
    templateUrl: './apis.component.html',
    styleUrls: ['./apis.component.scss']
})
export class ApisComponent implements OnInit {

    selectedApi: Api;
    apis: Api[];

    constructor(private readonly dataService: DataService) { }

    ngOnInit() {
        this.getApis();
    }

    onSelect(api: Api): void {
        this.selectedApi = api;
    }

    getApis(): void {
        this.dataService.getApis().subscribe(apis => this.apis = apis);
    }
}
