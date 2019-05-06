import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { take } from 'rxjs/operators';
import { Api } from '../models';

const apiUrl: string = '/api/api';
const resourceUrl: string = '/api/resource';
const fieldUrl: string = '/api/field';

@Injectable()
export class DataService {
    apis: Api[] = null;

    constructor(private readonly http: HttpClient) { }

    getAllApis(): Api[] {
        if (this.apis === null) {
            this.http.get<Api[]>(apiUrl).pipe(take(1)).subscribe((apis: Api[]) => {
                this.apis = apis;
            });
        }
        return this.apis;
    }

}
