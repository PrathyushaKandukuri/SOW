import { TestBed } from '@angular/core/testing';

import { ContractCategoryService } from './contract-category.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('ContractCategoryService', () => {
  let service: ContractCategoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ContractCategoryService]
    });
    service = TestBed.inject(ContractCategoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it('GetAllContractCategoryData', () => {
    const obj = [{  contractCategoryId: 1,
    contractCategory: "T & M",
    type: ""
    }, { 
      contractCategoryId: 2,
      contractCategory: "T",
      type: ""
     }];

    service.GetAllContractCategoryData().subscribe((data) => {
      expect(data).toEqual(obj);
    });
  });
  it('GetAllCategoryData', () => {
    const obj = [{  contractCategoryId: 1,
    contractCategory: "T & M",
    type: ""
    }, { 
      contractCategoryId: 2,
      contractCategory: "T",
      type: ""
     }];

    service.GetAllCategoryData().subscribe((data) => {
      expect(data).toEqual(obj);
    });
  });
    it('PostCategoryata', () => {
      const obj = {  contractCategoryId: 1,
        contractCategory: "T & M",
        type: ""};
  
      service.PostCategoryata(obj).subscribe((response) => {
        expect(response).toEqual(obj);
      });
    
  });
  it('DeleteCategoryData',()=>{
    const obj={contractCategoryId: 1,
      contractCategory: "T & M",
      type: ""}
      service.DeleteCategoryData(obj.contractCategoryId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
     
  })
  it('UpdateCategoryData',()=>{
    const obj={contractCategoryId: 1,
      contractCategory: "T & M",
      type: ""}
      service.UpdateCategoryData(obj.contractCategoryId,obj).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
     
  })
  it('GetCategoryId',()=>{
    const obj={contractCategoryId: 1,
      contractCategory: "T & M",
      type: ""}
      service.GetCategoryId(obj.contractCategoryId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
      
      
  })
  it('GetCategoryCategoryId',()=>{
    const obj={contractCategoryId: 1,
      contractCategory: "T & M",
      type: ""}
      service.GetContractCategoryById(obj.contractCategoryId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
      
      
  })
});
