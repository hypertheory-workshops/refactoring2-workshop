import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountComponent } from './account.component';
import { OrdersComponent } from './container/orders/orders.component';

const routes: Routes = [
  {
    // http://app.hypertheory.com/account/order-history
    path: '',
    component: AccountComponent,
    children: [
      {
        path: 'order-history',
        component: OrdersComponent,
      },
    ],
  },
];

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AccountRoutingModule {}
