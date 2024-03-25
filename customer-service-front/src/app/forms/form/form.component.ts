import { Component, OnInit } from '@angular/core';
import { Agent } from 'src/app/models/agent';
import { Purchase } from 'src/app/models/purchase';
import { FormService } from 'src/app/services/form.service';
import * as Papa from 'papaparse';
import { PurchaseService } from 'src/app/services/purchase.service';
import { MatTableDataSource } from '@angular/material/table';


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent implements OnInit {
  agents: Agent[] = []; 
  selectedAgentId: number | null = null;
  forms = new MatTableDataSource<any>();
  displayedColumns: string[] = ['rb','formId', 'formName', 'agentId', 'customerId', 'createdDate', 'discount', 'delete'];


  constructor(private formService: FormService, private purchaseService: PurchaseService ) {}

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

onFileChange(event: any) {
  const file = event.target.files[0];
  Papa.parse(file, {
    header: true,
    skipEmptyLines: true,
    complete: (result) => {
      const purchases = result.data.map((purchase: any) => ({
        ...purchase,
        PurchaseAmount: parseInt(purchase.PurchaseAmount, 10),
        CreatedDate: this.parseDate(purchase.CreatedDate),
      }));
      console.log(purchases);
      this.purchaseService.savePurchases(purchases).subscribe({
        next: () => {
          console.log('Purchases saved successfully');
        },
        error: (error) => {
          console.error('Error saving purchases:', error);
        },
      });
    },
  });
}

parseDate(dateString: string): Date | null {
  const [day, month, year] = dateString.split('-').map((part) => parseInt(part, 10));
  if (!isNaN(day) && !isNaN(month) && !isNaN(year)) {
    return new Date(year + 2000, month - 1, day +1);
  }
  return null;
}




  onAgentSelectionChange(): void {
    // this.selectedAgentId = agentId;
    this.formService.getFormsByAgentIdAndDate().subscribe(forms => {
      this.forms.data = forms;
    });
  }
}
