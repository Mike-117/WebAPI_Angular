// create a service class to interact with ASP.NET Core Web API- shared/payment-detail.service.ts
import { PaymentDetail } from './payment-detail.model';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})

// use the payment-detail.model as a property of PaymentDetailService in order to design the form inside the payment-detail component
export class PaymentDetailService {
  formData: PaymentDetail= {
    CVV: null,
    CardNumber: null,
    CardOwnerName: null,
    ExpirationDate: null,
    PMId: null
  };
  
  // defines the route for the corresponding WebAPI method for the CRUD operations
  readonly rootURL = 'http://localhost:58424/api';
  // creates an array of PaymentDetail objects from the database
  list : PaymentDetail[];

  // HttpClient injected into constructor in order to use this class
  constructor(private http: HttpClient) { }

  // this function submits the form data to the WebAPI PaymentDetailController.PostPaymentDetail function, and returns an observer
  postPaymentDetail() {
    return this.http.post(this.rootURL + '/PaymentDetail', this.formData);
  }
  putPaymentDetail() {
    return this.http.put(this.rootURL + '/PaymentDetail/'+ this.formData.PMId, this.formData);
  }
  deletePaymentDetail(id) {
    return this.http.delete(this.rootURL + '/PaymentDetail/'+ id);
  }

  // utilizes the GetPaymentDetails from the WebAPI, to display the list when the database is updated
  refreshList(){
    this.http.get(this.rootURL + '/PaymentDetail')
    // converts the observer
    .toPromise()
    .then(res => this.list = res as PaymentDetail[]);
  }
}