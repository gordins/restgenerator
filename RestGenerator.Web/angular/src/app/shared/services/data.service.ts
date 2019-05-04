import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Api } from '../models';

@Injectable()
export class DataService {
    api: BehaviorSubject<Api> = new BehaviorSubject<Api>(new Api());
    changeApi(newApi: Api): void {
        this.api.next(newApi);
    }
    //resource: BehaviorSubject<Resource> = new BehaviorSubject<Resource>(new Resource());
    //changeResource(newResource: Resource): void {
    //  this.resource.next(newResource);
    //}
}
