import { TestBed } from '@angular/core/testing';

import { JobcodeService } from './jobcode.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('JobcodeService', () => {
  let service: JobcodeService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports:[HttpClientTestingModule],
      providers:[JobcodeService]
    });
    service = TestBed.inject(JobcodeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it('GetAllJobcodeData', () => {
    const obj = [{  jobCodeId: 1002,
    jobCode: "string12222",
   jobDescription: "stringdesc",
    type: null
    }, { 
      jobCodeId: 4,
      jobCode: "string3221",
      jobDescription: "string",
      type: null
     }];

    service.GetAllJobcodeData().subscribe((data) => {
      expect(data).toEqual(obj);
    });
  });
  it('GetAlljobcodeData', () => {
    const obj = [{   jobCodeId: 1002,
      jobCode: "string12222",
     jobDescription: "stringdesc",
      type: null
    }, { 
      jobCodeId: 4,
      jobCode: "string3221",
      jobDescription: "string",
      type: null
     }];

    service.GetAlljobcodeData().subscribe((data) => {
      expect(data).toEqual(obj);
    });
  });
    it('Postjobcodedata', () => {
      const obj = {  jobCodeId: 4,
        jobCode: "string3221",
        jobDescription: "string",
        type: null};
  
      service.Postjobcodedata(obj).subscribe((response) => {
        expect(response).toEqual(obj);
      });
    
  });
  it('DeletejobcodeData',()=>{
    const obj={  jobCodeId: 4,
      jobCode: "string3221",
      jobDescription: "string",
      type: null}
      service.DeletejobcodeData(obj.jobCodeId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
     
  })
  it('UpdatejobcodeData',()=>{
    const obj={  jobCodeId: 4,
      jobCode: "string3221",
      jobDescription: "string",
      type: null}
      service.UpdatejobcodeData(obj.jobCodeId,obj).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
     
  })
  it('GetjobcodeId',()=>{
    const obj={  jobCodeId: 4,
      jobCode: "string3221",
      jobDescription: "string",
      type: null}
      service.GetjobcodeId(obj.jobCodeId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
      
      
  })
});
