import { Form } from "./Form";

export class Purchase {
    purchaseID: number;
    purchaseAmount: number;
    purchaseType: string;
    formId: number;
    createdDate: Date;
    form: Form;
}