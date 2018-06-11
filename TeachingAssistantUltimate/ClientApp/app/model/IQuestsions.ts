import { IOptions } from "./IOptions";

export interface IQuestions {
  questionsID: number;
  question: string;
  topic: string;
  subjectsID: number;
  concurrency: string;
  options: IOptions[];
}
