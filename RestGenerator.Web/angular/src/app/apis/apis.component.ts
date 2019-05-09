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

    ngOnInit(): void {
        this.getApis();
    }

    getApis(): void {
        this.dataService.getApis().subscribe(apis => this.apis = apis);
    }

    delete(api: Api): void {
        this.apis = this.apis.filter(a => a.id !== api.id);
        this.dataService.deleteApi(api.id).subscribe();
    }
}
