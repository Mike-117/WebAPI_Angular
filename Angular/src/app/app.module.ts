import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
// needed to make the form work
import { FormsModule } from "@angular/forms"; 
import { HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// toastr added to provide a notification message when the form is submitted
import { ToastrModule } from 'ngx-toastr'; 
import { AppComponent } from './app.component';
import { PaymentDetailsComponent } from './payment-details/payment-details.component';
import { PaymentDetailComponent } from './payment-details/payment-detail/payment-detail.component';
import { PaymentDetailListComponent } from './payment-details/payment-detail-list/payment-detail-list.component';
// automatically imported when provider added
import { PaymentDetailService } from './shared/payment-detail.service'; 

@NgModule({
  declarations: [
    AppComponent,
    PaymentDetailsComponent,
    PaymentDetailComponent,
    PaymentDetailListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  // the class is injected here in order for the payment-detail and payment detail-list to access the payment-detail.model
  providers: [PaymentDetailService], 
  bootstrap: [AppComponent]
})
export class AppModule { }