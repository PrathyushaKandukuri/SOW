import { TestBed } from '@angular/core/testing';

import { BusinessUnitService } from './business-unit.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('BusinessUnitService', () => {
  let service: BusinessUnitService;  
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [BusinessUnitService]
    });
    service = TestBed.inject(BusinessUnitService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it('GetAllBUData', () => {
    const obj = [{  bussinessUnitId: 2,    
    bussinessUnit: "string123432",
    bussinessUnitDescription: "string123",
    type: ""
    }, { 
      bussinessUnitId: 3,    
      bussinessUnit: "string",
      bussinessUnitDescription: "string123457",
      type: ""
     }];

    service.GetAllBUData().subscribe((data) => {
      expect(data).toEqual(obj);
    });
  });
    it('PostBUData', () => {
      const obj = {  bussinessUnitId: 2,    
        bussinessUnit: "string123432",
        bussinessUnitDescription: "string123",
        type: ""};
  
      service.PostBUdata(obj).subscribe((response) => {
        expect(response).toEqual(obj);
      });
    
  });
  it('DeleteBUData',()=>{
    const obj={bussinessUnitId: 2,    
      bussinessUnit: "string123432",
      bussinessUnitDescription: "string123",
      type: ""}
      service.DeleteBUData(obj.bussinessUnitId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
     
  })
  it('UpdateBUData',()=>{
    const obj={bussinessUnitId: 2,    
      bussinessUnit: "string123432",
      bussinessUnitDescription: "string123",
      type: ""}
      service.UpdateBUData(obj.bussinessUnitId,obj).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
     
  })
  it('GetBUById',()=>{
    const obj={bussinessUnitId: 2,    
      bussinessUnit: "string123432",
      bussinessUnitDescription: "string123",
      type: ""}
      service.GetBUId(obj.bussinessUnitId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
      
      
  })
});
