import { Agent } from "./agent";

export class Form {
    formId: number;
    formName: string;
    agentId: number;
    customerId: number;
    createdDate: Date;
    agent?: Agent;
    discount: number;
}