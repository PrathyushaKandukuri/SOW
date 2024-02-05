import { TestBed } from '@angular/core/testing';

import { ProjectService } from './project.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('ProjectService', () => {
  let service: ProjectService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports:[HttpClientTestingModule],
      providers:[ProjectService]
    });
    service = TestBed.inject(ProjectService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it('GetAllProjectData', () => {
    const obj = [{   projectTypeId: 2,
    projectId: "DLIN-0020-01-04",
    projectDescription: "CR3 NorthStar Acceleration -XA",
    type: ""
    }, { 
      projectTypeId: 1,
    projectId: "DLIN-0093-01-05",
    projectDescription: "CR9 Dell QEO Testing",
    type: ""
     }];

    service.GetAllProjectData().subscribe((data) => {
      expect(data).toEqual(obj);
    });
  });
    it('PostProjectData', () => {
      const obj = { projectTypeId: 1,
        projectId: "DLIN-0093-01-05",
        projectDescription: "CR9 Dell QEO Testing",
        type: ""};
  
      service.PostProjectData(obj).subscribe((response) => {
        expect(response).toEqual(obj);
      });
    
  });
  it('DeleteProjectData',()=>{
    const obj={projectTypeId: 1,
      projectId: "DLIN-0093-01-05",
      projectDescription: "CR9 Dell QEO Testing",
      type: ""}
      service.DeleteProjectData(obj.projectTypeId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
     
  })
  it('UpdateProjectData',()=>{
    const obj={projectTypeId: 1,
      projectId: "DLIN-0093-01-05",
      projectDescription: "CR9 Dell QEO Testing",
      type: ""}
      service.UpdateProjectData(obj.projectTypeId,obj).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
     
  })
  it('GetProjectById',()=>{
    const obj={projectTypeId: 1,
      projectId: "DLIN-0093-01-05",
      projectDescription: "CR9 Dell QEO Testing",
      type: ""}
      service.GetProjectById(obj.projectTypeId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
      
      
  })
});
