import { PaymentDetailService } from './../../shared/payment-detail.service';
import { Component, OnInit } from '@angular/core';
// allows the reset of the form
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

// this component is inserted into the first column of the Bootstrap container
@Component({
  selector: 'app-payment-detail',
  templateUrl: './payment-detail.component.html',
  styles: []
})
export class PaymentDetailComponent implements OnInit {

  // toastr injected into constructor
  constructor(public service: PaymentDetailService, private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

  // resets form controls to their default values, takes one parameter, the nullable "form" of the type NGForm
  resetForm(form?: NgForm) {
    // the function is only called is the form is not null
    if (form != null)
      form.form.reset();
    // this creates a new PaymentDetail model object with the following values
      this.service.formData = {
      PMId: 0,
      CardOwnerName: '',
      CardNumber: '',
      ExpirationDate: '',
      CVV: ''
    }
  }
// this function is called when the submit button is pressed, and a JSON object containing the values of the form is created and submitted into the WebAPI project
  onSubmit(form: NgForm) {
     // this checks to see there is already a record with these values; if so, then it performs an update to the record
     if (this.service.formData.PMId == 0)
     this.insertRecord(form);
     else
     this.updateRecord(form);
     
     res => {
      this.resetForm(form);
      // adds toastr notification
      this.toastr.success('Submitted successfully', 'Payment Detail Register');
    }
  }

  insertRecord(form: NgForm) {
    // subscribing to the observer that postPaymentDetail returns
    this.service.postPaymentDetail().subscribe(
      // success function, resets form controls to their default state
      res => {
        this.resetForm(form);
        this.toastr.success('Submitted successfully', 'Payment Detail Register');
        this.service.refreshList();
      },
      // error function, prints to a console
      err => {
        console.log(err);
      }
    )
  }
  updateRecord(form: NgForm) {
    this.service.putPaymentDetail().subscribe(
      res => {
        this.resetForm(form);
        this.toastr.info('Submitted successfully', 'Payment Detail Register');
        this.service.refreshList();
      },
      err => {
        console.log(err);
      }
    )
  }

}