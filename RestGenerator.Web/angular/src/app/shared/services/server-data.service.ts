import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Api } from '..';

const getAllApisUrl: string = '/api/api';

@Injectable()
export class ServerDataService {

  constructor(private readonly httpClient: HttpClient) { }

  getApis(): Observable<Api[]> {
    return this.httpClient.get<Api[]>(getAllApisUrl);
  }
}
