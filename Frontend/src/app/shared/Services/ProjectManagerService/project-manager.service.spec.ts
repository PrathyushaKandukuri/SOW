import { TestBed } from '@angular/core/testing';

import { ProjectManagerService } from './project-manager.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('ProjectManagerService', () => {
  let service: ProjectManagerService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports:[HttpClientTestingModule],
      providers:[ProjectManagerService]
    });
    service = TestBed.inject(ProjectManagerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it('GetAllProjectManagerData', () => {
    const obj = [{  projectManagerTypeId: 3,
      projectManagerId: "string123",
      projectManagerName: "string1234567",
      projectStartDate: "2023-10-09T06:14:09.41",
      projectEndDate: "2023-10-09T06:14:09.41",
      type: ""
    }, { 
      projectManagerTypeId: 2,
      projectManagerId: "string",
      projectManagerName: "string1234567",
      projectStartDate: "2023-10-09T06:14:09.41",
      projectEndDate: "2023-10-09T06:14:09.41",
      type: ""
     }];

    service.GetAllProjectManagerData().subscribe((data) => {
      expect(data).toEqual(obj);
    });
  });
  it('GetAllManagerData', () => {
    const obj = [{    projectManagerTypeId: 3,
      projectManagerId: "string123",
      projectManagerName: "string1234567",
      projectStartDate: "2023-10-09T06:14:09.41",
      projectEndDate: "2023-10-09T06:14:09.41",
      type: ""
    }, { 
      projectManagerTypeId: 2,
      projectManagerId: "string",
      projectManagerName: "string1234567",
      projectStartDate: "2023-10-09T06:14:09.41",
      projectEndDate: "2023-10-09T06:14:09.41",
      type: ""
     }];

    service.GetAllManagerData().subscribe((data) => {
      expect(data).toEqual(obj);
    });
  });
    it('PostManagerata', () => {
      const obj = { projectManagerTypeId: 2,
        projectManagerId: "string",
        projectManagerName: "string1234567",
        projectStartDate: "2023-10-09T06:14:09.41",
        projectEndDate: "2023-10-09T06:14:09.41",
        type: ""};
  
      service.PostManagerata(obj).subscribe((response) => {
        expect(response).toEqual(obj);
      });
    
  });
  it('DeleteManagerData',()=>{
    const obj={ projectManagerTypeId: 2,
      projectManagerId: "string",
      projectManagerName: "string1234567",
      projectStartDate: "2023-10-09T06:14:09.41",
      projectEndDate: "2023-10-09T06:14:09.41",
      type: ""}
      service.DeleteManagerData(obj.projectManagerTypeId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
     
  })
  it('UpdateManagerData',()=>{
    const obj={  projectManagerTypeId: 2,
      projectManagerId: "string",
      projectManagerName: "string1234567",
      projectStartDate: "2023-10-09T06:14:09.41",
      projectEndDate: "2023-10-09T06:14:09.41",
      type: ""}
      service.UpdateManagerData(obj.projectManagerTypeId,obj).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
     
  })
  it('GetManageryId',()=>{
    const obj={  projectManagerTypeId: 2,
      projectManagerId: "string",
      projectManagerName: "string1234567",
      projectStartDate: "2023-10-09T06:14:09.41",
      projectEndDate: "2023-10-09T06:14:09.41",
      type: ""}
      service.GetManageryId(obj.projectManagerTypeId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
      
      
  })
});
