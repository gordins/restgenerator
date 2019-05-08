import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { Api } from '../models';

const apiUrl: string = '/api/api';
// const resourceUrl: string = '/api/resource';
// const fieldUrl: string = '/api/field';

@Injectable()
export class DataService {
    // private apis: Observable<Api[]> = null;

    constructor(private readonly http: HttpClient) { }

    getApis(): Observable<Api[]> {
        return this.http.get<Api[]>(apiUrl).pipe(take(1));
    }

    addApi(api: Api): Observable<Api> {
        return this.http.post<Api>(apiUrl, api).pipe(take(1));
    }

    updateApi(api: Api): Observable<Api> {
        return this.http.put<Api>(`${apiUrl}/${api.id}`, api).pipe(take(1));
    }

    deleteApi(id: string): Observable<any> {
        return this.http.delete(`${apiUrl}/${id}`).pipe(take(1));
    }
}
