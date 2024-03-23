import { Component, OnInit } from '@angular/core';
import { Agent } from 'src/app/models/agent';
import { FormService } from 'src/app/services/form.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent implements OnInit {
  agents: Agent[] = []; 
  selectedAgentId: number | null = null;
  forms: any[] = []; // Assuming the forms are of type 'any', adjust as needed
  displayedColumns: string[] = ['formId', 'formName', 'agentId', 'customerId', 'createdDate'];


  constructor(private formService: FormService) {}

  ngOnInit(): void {
    this.formService.getAgents().subscribe(agents => {
      this.agents = agents;
    });
  }

  onAgentSelectionChange(agentId: number): void {
    this.selectedAgentId = agentId;
    // this.formService.getFormsByAgentId(agentId).subscribe(forms => {
    //   this.forms = forms;
    // });
  }
}
