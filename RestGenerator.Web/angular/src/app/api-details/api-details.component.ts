import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Api, DataService } from '../shared';

@Component({
    selector: 'app-api-details',
    templateUrl: './api-details.component.html',
    styleUrls: ['./api-details.component.scss']
})
export class ApiDetailsComponent implements OnInit {
    @Input() api: Api;

    constructor(private readonly route: ActivatedRoute,
        private readonly dataService: DataService) { }

    ngOnInit(): void {
        this.getApi();
    }

    getApi(): void {
        const id = this.route.snapshot.paramMap.get('id');
        this.dataService.getApi(id).subscribe(api => {
            this.api = api;
        });
    }

}
