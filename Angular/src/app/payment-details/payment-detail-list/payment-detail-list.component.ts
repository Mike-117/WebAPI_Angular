import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { PaymentDetail } from 'src/app/shared/payment-detail.model';
import { PaymentDetailService } from 'src/app/shared/payment-detail.service';

// this component is inserted into the second column of the Bootstrap container
@Component({
  selector: 'app-payment-detail-list',
  templateUrl: './payment-detail-list.component.html',
  styles: [
  ]
})
export class PaymentDetailListComponent implements OnInit {

  constructor(public service: PaymentDetailService, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  // this function is invoked when the list event handler is clicked, and puts list data back inside the form
  populateForm(pd:PaymentDetail) {
    this.service.formData = Object.assign({}, pd);
  }

  onDelete(PMId ) {
    // method will only run if user confirms
    if(confirm('Are you sure you want to delete this record?')) {
    this.service.deletePaymentDetail(PMId)
    .subscribe(res =>{
      this.service.refreshList();
      this.toastr.warning('Deleted successfully', 'Payment Detail Register');
    },
     err =>{
       console.log(err);
     } )
  }
}
}

