import { Injectable } from '@angular/core';
import { ISubjects } from '../model/ISubjects';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { IQuestions } from '../model/IQuestsions';
import { ITests } from '../model/ITests';
import { ITopics } from '../model/ITopics';

@Injectable()
export class HttpProvider {
    genQuestions(args: ITests): Observable<IQuestions[]> {
        return this.http.post<IQuestions[]>("/Questions/Generate", args)
    }
    addQuestion(quest: IQuestions): Observable<IQuestions> {
        return this.http.post<IQuestions>("/Questions/Create", quest);
    }
    addSubject(sub: ISubjects): Observable<ISubjects> {
        return this.http.post<ISubjects>("/Subjects/Create", sub);
    }

    getSubjects(): Observable<ISubjects[]> {
        return this.http.get<ISubjects[]>("/Subjects/List");
    }

    getSubject(id: number): Observable<ISubjects> {
        return this.http.get<ISubjects>(`/Subjects/Find?id=${id}`);
    }

    editSubject(sub: ISubjects): Observable<ISubjects> {
        return this.http.post<ISubjects>("/Subjects/Edit", sub);
    }

    deleteSubject(sub: ISubjects) {
        return this.http.post("/Subjects/Delete", sub);
    }

    getQuestions(id: number): Observable<IQuestions[]> {
        return this.http.get<IQuestions[]>(`/Questions/List?id=${id}`);
    }

    getTopics(id: number): Observable<ITopics[]> {
        return this.http.get<ITopics[]>(`/Questions/Topics/${id}`);
    }

    print() {
        return this.http.get('/Print/Index');
    }
    constructor(private http: HttpClient) {

    }
}