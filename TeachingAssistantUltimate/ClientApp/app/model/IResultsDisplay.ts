import { IStudentSum } from "./IStudentSum";

export interface IResultsDisplay {
    types: Array<{
        assessmentType: string,
        assessmentTypesID: number,
        total: number
    }>;
    results: Array<{
        studentsID: number;
        name: string;
        results: IStudentSum[]
    }>;
}