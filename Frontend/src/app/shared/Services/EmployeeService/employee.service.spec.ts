import { TestBed } from '@angular/core/testing';

import { EmployeeService } from './employee.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('EmployeeService', () => {
  let service: EmployeeService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [EmployeeService]
    });
    service = TestBed.inject(EmployeeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it('GetAllEmployeeData', () => {
    const obj = [{  employeeId: 4,
      employeeType: "Temporary",
      type: ""
    }, { 
      employeeId: 3,
    employeeType: "Contract",
    type: ""
     }];

    service.GetAllEmployeeData().subscribe((data) => {
      expect(data).toEqual(obj);
    });
  });
  it('GetEmployeeById',()=>{
    const obj={employeeId: 4,
    employeeType: "Temporary",
    type: ""}
      service.GetEmployeeById(obj.employeeId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
      
      
  })
});
