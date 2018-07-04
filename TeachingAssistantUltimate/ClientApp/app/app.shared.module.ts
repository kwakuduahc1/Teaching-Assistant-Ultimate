import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
//import { HttpClientModule } from '@angular/common/http';


import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { HttpProvider } from './providers/http-provider';
import { SubjectsComponent } from './components/subjects/subjects.component';
import { HttpHandler } from './providers/HttpHandler';
import { SubjectsResolver } from './resolvers/SubjectsResolver';
import { EditQuestionComponent } from './components/edit-question/edit-question.component';
import { EditSubjectComponent } from './components/edit-subject/edit-subject.component';
import { GeneratorComponent } from './components/generator/generator.component';
import { QuestionsComponent } from './components/questions/questions.component';
import { ViewQuestionComponent } from './components/view-question/view-question.component';
import { SubjectResolver } from './resolvers/SubjectResolver';
import { QuillEditorModule } from './Editor';
import { TopicsResolver } from './resolvers/TopicsResolver';
import { HttpClientModule } from '@angular/common/http';
import { PrintProviderService } from './providers/print-provider.service';
import { AssTypesComponent } from './components/ass-types/ass-types.component';
import { AssTypesResolver } from './resolvers/AssTypesResolver';
import { ResultsHttpProvider } from './providers/results-http-provider';
import { EditAssTypeComponent } from './components/edit-ass-type/edit-ass-type.component';
import { AssTypeResolver } from './resolvers/AssTypeResolver';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        SubjectsComponent,
        EditQuestionComponent,
        EditSubjectComponent,
        GeneratorComponent,
        QuestionsComponent,
        ViewQuestionComponent,
        AssTypesComponent,
        EditAssTypeComponent,
    ],
    providers: [HttpProvider, ResultsHttpProvider, HttpHandler, SubjectsResolver, SubjectResolver, TopicsResolver, PrintProviderService, AssTypesResolver, AssTypeResolver],
    exports: [RouterModule],
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        QuillEditorModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'subjects', component: SubjectsComponent, resolve: { subjects: SubjectsResolver } },
            { path: 'edit-subject/:id', component: EditSubjectComponent, resolve: { subject: SubjectResolver } },
            { path: 'add-question/:id', component: QuestionsComponent, resolve: { subject: SubjectResolver } },
            { path: 'generate/:id', component: GeneratorComponent, resolve: { subject: SubjectResolver, topics: TopicsResolver } },
            { path: 'types', component: AssTypesComponent, resolve: { types: AssTypesResolver } },
            { path: 'edit-type/:id', component: EditAssTypeComponent, resolve: { type: AssTypeResolver } },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
