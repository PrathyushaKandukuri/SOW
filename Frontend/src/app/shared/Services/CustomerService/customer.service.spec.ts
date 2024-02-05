import { TestBed } from '@angular/core/testing';

import { CustomerService } from './customer.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('CustomerService', () => {
  let service: CustomerService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [CustomerService]
    });
    service = TestBed.inject(CustomerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it('GetAllCustomerData', () => {
    const obj = [{  customerTypeId: 5,
    customerId: "1000003516",
    customerName: "DELL International Services India",
    type: ""
    }, { 
      customerTypeId: 6,
      customerId: "1000234516",
      customerName: "DELL",
      type: ""
     }];

    service.GetAllCustomerData().subscribe((data) => {
      expect(data).toEqual(obj);
    });
  });
    it('PostCustomerData', () => {
      const obj = { customerTypeId: 6,
        customerId: "1000234516",
        customerName: "DELL",
        type: ""};
  
      service.PostCustomerData(obj).subscribe((response) => {
        expect(response).toEqual(obj);
      });
    
  });
  it('DeleteCustomerData',()=>{
    const obj={customerTypeId: 6,
      customerId: "1000234516",
      customerName: "DELL",
      type: ""}
      service.DeleteCustomerData(obj.customerTypeId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
     
  })
  it('UpdateCustomerData',()=>{
    const obj={customerTypeId: 6,
      customerId: "1000234516",
      customerName: "DELL",
      type: ""}
      service.UpdateCustomerData(obj.customerTypeId,obj).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
     
  })
  it('GetCustomerById',()=>{
    const obj={customerTypeId: 6,
      customerId: "1000234516",
      customerName: "DELL",
      type: ""}
      service.GetCustomerById(obj.customerTypeId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
      
      
  })
});
