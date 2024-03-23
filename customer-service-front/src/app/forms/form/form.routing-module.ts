import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditComponent } from './edit/edit.component';
import { FormComponent } from './form.component';



const routes: Routes = [
    {
        path: '',
        component: FormComponent
    },
    {
        path: 'edit/:id',
        component: EditComponent,
        data: {
            action: 'edit'
        }
    },
    {
        path: 'add',
        component: EditComponent,
        data: {
            action: 'add'
        }
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class FormRoutingModule {
}
