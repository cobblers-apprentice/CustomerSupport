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
  displayedColumns: string[] = ['formId', 'formName', 'agentId', 'customerId', 'createdDate', 'delete'];


  constructor(private formService: FormService) {}

  ngOnInit(): void {
    // this.formService.getAgents().subscribe(agents => {
    //   this.agents = agents;
    // });
    this.onAgentSelectionChange();
  }
deleteForm(event:Event, id: number){
event.stopPropagation();
this.formService.deleteForm(id).subscribe(a=> {
  this.onAgentSelectionChange();
})
}
  onAgentSelectionChange(): void {
    // this.selectedAgentId = agentId;
    this.formService.getFormsByAgentIdAndDate().subscribe(forms => {
      this.forms = forms;
    });
  }
}
