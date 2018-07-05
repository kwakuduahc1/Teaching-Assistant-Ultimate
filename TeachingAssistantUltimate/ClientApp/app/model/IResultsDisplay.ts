import { IStudentSum } from "./IStudentSum";

export interface IResultsDisplay {
    studentsID: number;
    name: string;
    results: IStudentSum[];
}