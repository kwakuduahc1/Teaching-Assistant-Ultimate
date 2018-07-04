import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { IResults } from '../model/IResults';

@Injectable()
export class ResultsHttpProvider {

    getAll(id:number): Observable<IResults[]> {
        return this.http.get<IResults[]>(`/Results/List?id=${id}`);
    }

    find(id: number): Observable<IResults> {
        return this.http.get<IResults>(`/Results/Find?id=${id}`);
    }

    add(res: IResults[]): Observable<IResults[]> {
        return this.http.post<IResults[]>('/Results/Create', res);
    }

    edit(res: IResults): Observable<IResults> {
        return this.http.post<IResults>('/Results/Edit', res);
    }

    delete(res: IResults): Observable<IResults> {
        return this.http.post<IResults>('/Results/Delete', res);
    }

    constructor(private http: HttpClient) {

    }
}