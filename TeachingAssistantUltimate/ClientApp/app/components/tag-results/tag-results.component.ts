import { Component } from '@angular/core';
import { ITags } from '../../model/ITags';
import { ISubjects } from '../../model/ISubjects';
import { IResults } from '../../model/IResults';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpHandler } from '../../providers/HttpHandler';
import { ResultsHttpProvider } from '../../providers/results-http-provider';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IClasses } from '../../model/IClasses';
import { HttpErrorResponse } from '@angular/common/http';
import { IResultsDisplay } from '../../model/IResultsDisplay';

@Component({
    selector: 'bs-tag-results',
    templateUrl: './tag-results.component.html',
    styleUrls: ['./tag-results.component.css']
})
/** tag-results component*/
export class TagResultsComponent {
    tags: ITags[];
    _class: IClasses;
    subjects: ISubjects[];
    results: IResultsDisplay[] = [];
    form: FormGroup;
    editForm!: FormGroup;
    status: boolean = true;
    constructor(route: ActivatedRoute, public hand: HttpHandler, private http: ResultsHttpProvider, private router: Router) {
        this.tags = route.snapshot.data["tags"] as ITags[];
        this.subjects = route.snapshot.data["subjects"] as ISubjects[];
        this._class = route.snapshot.data["class"] as IClasses;
        this.form = new FormBuilder().group({
            tag: ["", Validators.compose([Validators.required, Validators.min(1)])],
            subjectsID: ["", Validators.compose([Validators.required, Validators.min(1)])]
        })
    }

    search(fm: { tag: ITags, subjectsID: number }) {
        this.hand.processing = true;
        this.hand.error = false;
        this.http.resultsByTags(fm.tag.tag, this._class.classesID, fm.subjectsID).subscribe(res => this.results = res, (err: HttpErrorResponse) => this.hand.handleError(err))
        this.hand.processing = false;
    }
}