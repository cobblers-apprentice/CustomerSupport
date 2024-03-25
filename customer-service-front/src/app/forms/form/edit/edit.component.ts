import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs';
import { Form } from 'src/app/models/Form';
import { Agent } from 'src/app/models/agent';
import { FormService } from 'src/app/services/form.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {
  formGroup: FormGroup;
  customer: any;
  agents: Agent[] = [];
  formData =  new Form();

  constructor(
    private formService: FormService, 
    private route: ActivatedRoute,
    private location: Location

    ) {
    this.formGroup = new FormGroup({
      formName: new FormControl('', [Validators.required]),
      agentId: new FormControl('', Validators.required),
      customerId: new FormControl('', Validators.required),
      createdDate: new FormControl(''), 
      discount: new FormControl('', Validators.required)
    });
  }
  ngOnInit(): void {
    const Id = this.route.snapshot.params['id'];

    this.formService.getAgents().subscribe(
      (agents) => {
        this.agents = agents;
      },
      (error) => {
        console.error('Error fetching agents:', error);
      }
    );

  if (Id > 0){

    this.formService.getFormsByAgentIdAndDate().subscribe({
      next: res => {
        this.formGroup.patchValue(res.find(a => a.formId == Id))
        this.formData = res.find(a => a.formId == Id);
      }
    })}
    else{
      let agentId: number;
      this.formService.getAgentId()
      .subscribe({
        next: res=> {
          agentId = res;
          this.formGroup.patchValue({
            agentId: agentId
          })
        }
      });
      
    }
  }

  submit(){
    if(this.formGroup.valid){

      const createdDate = new Date();
createdDate.setHours(createdDate.getHours() + 1);
      let form: Form = {
        formId: this.formData.formId == null? null: this.formData.formId, 
        formName: this.formGroup.get('formName').value, 
        agentId: this.formGroup.get('agentId').value, 
        customerId: this.formGroup.get('customerId').value, 
        createdDate: createdDate, 
        agent:null, 
        discount: this.formGroup.get('discount').value
      }

      this.formService.getFormsByAgentIdAndDate().pipe(
        switchMap((forms) => {
          if (forms.length >= 5) {
            throw new Error('Limit of 5 forms per agent per day reached.');
          }
          return this.formService.saveForm(form);
        })
      ).subscribe({
        next: (res) => {
          this.location.back();
        },
        error: (error) => {
          if (error.message === 'Limit of 5 forms per agent per day reached.') {
            console.log(error.message);
          } else {
            console.error('Error:', error);
          }
        }
      });
    }
    else{
      this.formGroup.markAllAsTouched();
    }

  }

  getCustomerData() {
    const customerId = this.formGroup.get('customerId')?.value;
    this.formService.getCustomerData(customerId).subscribe(
      (data) => {
        this.customer = data;
      },
      (error) => {
        console.error('Error fetching customer data:', error);
      }
    );
  }
}
