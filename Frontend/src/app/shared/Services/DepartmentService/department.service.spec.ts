import { TestBed } from '@angular/core/testing';

import { DepartmentService } from './department.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('DepartmentService', () => {
  let service: DepartmentService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [DepartmentService]
    });
    service = TestBed.inject(DepartmentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it('GetAllDepartmentData', () => {
    const obj = [{  departmentTypeId: 2,
    departmentId: 2,
    departmentDescription: "string12343",
    "type": ""
    }, { 
      departmentTypeId: 3,
      departmentId: 4,
      departmentDescription: "string",
      "type": ""
     }];

    service.GetAllDepartmentData().subscribe((data) => {
      expect(data).toEqual(obj);
    });
  });
  it('GetAllDeptData', () => {
    const obj = [{   departmentTypeId: 2,
      departmentId: 2,
      departmentDescription: "string12343",
      "type": ""
    }, { 
      departmentTypeId: 2,
      departmentId: 2,
      departmentDescription: "string12343",
      "type": ""
     }];

    service.GetAllDeptData().subscribe((data) => {
      expect(data).toEqual(obj);
    });
  });
    it('PostDeptdata', () => {
      const obj = {  departmentTypeId: 2,
        departmentId: 2,
        departmentDescription: "string12343",
        "type": ""};
  
      service.PostDeptdata(obj).subscribe((response) => {
        expect(response).toEqual(obj);
      });
    
  });
  it('DeleteDeptData',()=>{
    const obj={ departmentTypeId: 2,
      departmentId: 2,
      departmentDescription: "string12343",
      "type": ""}
      service.DeleteDeptData(obj.departmentTypeId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
     
  })
  it('UpdateDeptData',()=>{
    const obj={ departmentTypeId: 2,
      departmentId: 2,
      departmentDescription: "string12343",
      "type": ""}
      service.UpdateDeptData(obj.departmentTypeId,obj).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
     
  })
  it('GetDeptId',()=>{
    const obj={ departmentTypeId: 2,
      departmentId: 2,
      departmentDescription: "string12343",
      "type": ""}
      service.GetDeptId(obj.departmentTypeId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
      
      
  })
  
 

});
