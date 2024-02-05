import { TestBed } from '@angular/core/testing';

import { RoledetailsService } from './roledetails.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('RoledetailsService', () => {
  let service: RoledetailsService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [RoledetailsService]
    });
    service = TestBed.inject(RoledetailsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it('GetAllRoledetailsData', () => {
    const obj = [{    roleDetailsId: 3,
    roleDetailsName: "DW",
    type: null
  
    }];
 
    service.GetAllRoledetailsData().subscribe((data) => {
      expect(data).toEqual(obj);
    });
  });
    it('PostRoledetailsData', () => {
      const obj = {  
        roleDetailsId: 3,
        roleDetailsName: "DW",
        type: null
      
      };
      service.PostRoledetailsData(obj).subscribe((response) => {
        expect(response).toEqual(obj);
      });
  });
  it('DeleteRoledetailsData',()=>{
    const obj={ 
      roleDetailsId: 3,
      roleDetailsName: "DW",
      type: null

  }
      service.DeleteRoledetailsData(obj.roleDetailsId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
  })
  it('UpdateRoledetailsData',()=>{
    const obj={
     
      roleDetailsId: 3,
      roleDetailsName: "DWw",
      type: null
  
   }
      service.UpdateRoledetailsData(obj.roleDetailsId,obj).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
  })
  it('GetRoledetailsById',()=>{
    const obj={   
 
      roleDetailsId: 3,
      roleDetailsName: "DW",
      type: null
 }
      service.GetRoledetailsById(obj.roleDetailsId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])

  })
});
