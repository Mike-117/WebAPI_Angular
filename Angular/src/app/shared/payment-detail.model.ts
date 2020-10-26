// there is no specific command to create a model class in Angular, so .model is included in name
// update the model class with properties corresponding to .Net Core API PaymentDetail model properties
export class PaymentDetail {
    PMId :number;
    CardOwnerName: string;
    CardNumber: string;
    ExpirationDate: string;
    CVV: string;
}