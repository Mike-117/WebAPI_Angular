import { Component, OnInit } from '@angular/core';

// this component is inserted into the Bootstrap container
@Component({
  selector: 'app-payment-details',
  templateUrl: './payment-details.component.html',
  // app.component/css is replaced with inline styling
  // styleUrls: ['./app.component/css']
  styles: []
})
export class PaymentDetailsComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}