import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BillinglistComponent } from './billinglist.component';
import { BillingService } from '../billing.service';
import { ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { RegionService } from '../shared/Services/RegionService/region.service';
import { EmployeeService } from '../shared/Services/EmployeeService/employee.service';
import { CustomerService } from '../shared/Services/CustomerService/customer.service';
import { ProjectService } from '../shared/Services/ProjectService/ProjectService/project.service';
import { ContractCategoryService } from '../shared/Services/ContractCategoryService/contract-category.service';
import { ProjectManagerService } from '../shared/Services/ProjectManagerService/project-manager.service';
import { LocationTypeService } from '../shared/Services/LocationTypeService/location-type.service';
import { JobcodeService } from '../shared/Services/JobCodeService/jobcode.service';
import { UstTpmService } from '../shared/Services/UsttpmService/ust-tpm.service';
import { BusinessUnitService } from '../shared/Services/BUService/business-unit.service';
import { CandidateService } from '../shared/Services/CandidateService/candidate.service';
import { DepartmentService } from '../shared/Services/DepartmentService/department.service';
import { FrequencyService } from '../shared/Services/FrequencyService/frequency.service';
import { CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { of, throwError } from 'rxjs';
describe('BillinglistComponent', () => {
  let component: BillinglistComponent;
  let fixture: ComponentFixture<BillinglistComponent>;
  let mockBillingService: any,mocksnackBar:any,mockRegionService:any, mockEmployeeService:any,
  mockCustomerService:any, mockProjectService:any, mockContractCategoryService:any,mockProjectManagerService:any,
  mockLocationTypeService:any, mockJobcodeService:any,mockUstTpmService:any, mockBusinessUnitService:any,
  mockCandidateService:any, mockDepartmentService:any, mockFrequencyService:any,mockBillingdata:any
  
  beforeEach(() => {
    mockBillingService=jasmine.createSpyObj('BillingService',['GetBillingById','UpdateBillingData','DeleteBillingData','GetAllBillingData','PostBillingData'])
   
 
mockRegionService=jasmine.createSpyObj('RegionService',['GetAllRegionData'])
mockEmployeeService=jasmine.createSpyObj('EmployeeService',['GetAllEmployeeData'])
mockCustomerService=jasmine.createSpyObj('CustomerService',['GetAllCustomerData'])
mockProjectService=jasmine.createSpyObj('ProjectService',['GetAllProjectData'])
mockContractCategoryService=jasmine.createSpyObj('ContractCategoryService',['GetAllCategoryData','GetAllContractCategoryData'])
mockProjectManagerService=jasmine.createSpyObj('ProjectManagerService',['GetAllManagerData','GetAllProjectManagerData'])
mockLocationTypeService=jasmine.createSpyObj('LocationTypeService',['GetAllLocationTypeData'])
mockJobcodeService=jasmine.createSpyObj('JobcodeService',['GetAlljobcodeData','GetAllJobcodeData'])
mockUstTpmService=jasmine.createSpyObj('UstTpmService',['GetAllUSTTPMData'])
mockBusinessUnitService=jasmine.createSpyObj('BusinessUnitService',['GetAllBUData'])
mockCandidateService=jasmine.createSpyObj('CandidateService',['GetAllCandidatesData'])
mockDepartmentService=jasmine.createSpyObj('DepartmentService',['GetAllDeptData','GetAllDepartmentData'])
mockFrequencyService=jasmine.createSpyObj('FrequencyService',['GetAllFreqData','GetAllFrequencyData'])
    TestBed.configureTestingModule({
      declarations: [BillinglistComponent],
      providers: [{provide:BillingService, useValue:mockBillingService},
       
      
      {provide:RegionService, useValue:mockRegionService},
      {provide:EmployeeService, useValue:mockEmployeeService},
      {provide:CustomerService, useValue:mockCustomerService},
      {provide:ProjectService, useValue:mockProjectService},
      {provide:ContractCategoryService, useValue:mockContractCategoryService},
      {provide:ProjectManagerService, useValue:mockProjectManagerService},
      {provide:LocationTypeService, useValue:mockLocationTypeService},
      {provide:JobcodeService, useValue:mockJobcodeService},
      {provide:UstTpmService, useValue:mockUstTpmService},
      {provide:BusinessUnitService, useValue:mockBusinessUnitService},
      {provide:CandidateService, useValue:mockCandidateService},
      {provide:DepartmentService, useValue:mockDepartmentService},
      {provide:FrequencyService, useValue:mockFrequencyService},

    ],
    schemas:[NO_ERRORS_SCHEMA,CUSTOM_ELEMENTS_SCHEMA]
    })
    .compileComponents()
    fixture = TestBed.createComponent(BillinglistComponent);
    component = fixture.componentInstance;
    let mockBillingData=[
      {
        "billingId": 0,
        "resourceStartDate": "2024-01-04T09:21:10.889Z",
        "resourceEndDate": "2024-01-04T09:21:10.889Z",
        "domain": "string",
        "currency": "string",
        "billRate": 0,
        "hours": 0,
        "totalBilledhrs": 0,
        "sowId": 0,
        "candidateId": 0,
        "type": "string",
        "employeeId": 0,
        "customerTypeId": 0,
        "projectTypeId": 0,
        "billable": true,
        "clientProjectRole": "string",
        "clientProjectRoleDesc": "string",
        "aliasName": "string",
        "allocationPercentage": 0,
        "comments": "string",
        "projectManagerTypeId": 0,
        "contractCategoryId": 0,
        "jobCodeId": 0,
        "frequencyId": 0,
        "bussinessUnitId": 0,
        "departmentTypeId": 0,
        "candidateName": "string",
        "candidateUid": "string",
        "contractCategory": "string",
        "customerId": "string",
        "customerName": "string",
        "departmentId": 0,
        "departmentDescription": "string",
        "employeeType": "string",
        "frequency": "string",
        "jobCode": "string",
        "jobDescription": "string",
        "projectManagerId": "string",
        "projectManagerName": "string",
        "projectStartDate": "2024-01-04T09:21:10.889Z",
        "projectEndDate": "2024-01-04T09:21:10.889Z",
        "projectId": "string",
        "projectDescription": "string",
        "joiningDate": "2024-01-04T09:21:10.889Z",
        "bussinessUnit": "string",
        "bussinessUnitDescription": "string",
        "locationTypeId": 0,
        "locationId": "string",
        "locationDescription": "string",
        "regionId": 0,
        "region": "string",
        "usttpmId": 0,
        "usttpmName": "string",
        "usttpmuid": "string",
        "terminationDate": "2024-01-04T09:21:10.889Z",
        "obu": 0,
        "obuDescription": "string"
      }
    ]
    let mockcandidatedata=[
      {
        "candidateId": 9,
        "candidateName": "Malleboina Mahesh",
        "candidateUid": "Ex-21839780",
        "mobileNo": "9346851294",
        "gender": "MALE",
        "dob": "1900-01-30T00:00:00",
        "email": "malleboina.mahesh04@gmail.com",
        "location": "HYD",
        "skills": "c#",
        "joiningDate": "1900-01-30T00:00:00",
        "address": "<<<No Data>>>",
        "status": "Rejected",
        "pincode": "<<<No Data",
        "isInternal": false,
        "terminationDate": null,
        "type": null
      }]
      let mockcustomerdata=[
        {
          "customerTypeId": 9,
          "customerId": "98063385",
          "customerName": "DELL, Inc.",
          "type": ""
        }]
        let mockempdata=[
          {
            "employeeId": 4,
            "employeeType": "Temporary",
            "type": ""
          }
        ]
        let mockprojectdata=[
          {
            
              "projectTypeId": 130,
              "projectId": "WSTN-0007-01-01",
              "projectDescription": "Striker( Fork OT) Platform Val",
              "projectStartDate": "2023-08-01T00:00:00",
              "projectEndDate": "2023-11-30T00:00:00",
              "type": ""
          
          }
        ]
        let mockcategorydata=[
          {
            "contractCategoryId": 7,
            "contractCategory": "T & M",
            "type": ""
          },
        ]
        let mockprojectmanagerdata=[
          {
            "projectManagerTypeId": 2,
            "projectManagerId": "U23181",
            "projectManagerName": "Venkata Narendra Peram",
            "type": ""
          },
        ]
        let mockcountrydata=[
          {
            "regionId": 8,
            "region": "PH",
            "type": ""
          }
        ]
        let mocklocationdata=[
          {
            "locationTypeId": 35,
            "locationId": "USAWFH049",
            "locationDescription": "USA-Working from Home-TX",
            "regionId": 4,
            "type": ""
          }
        ]
        let mockjobcodedata=[
          {
            "jobCodeId": 105,
            "jobCode": "F44B11",
            "jobDescription": "ML Engineer I",
            "type": null
          }
        ]
        let mockfrequencydata=[
          {
            "frequencyId": 3,
            "frequency": "NA",
            "type": null
          }
        ]
        let mockmanagerdata=[
          {
            "usttpmId": 187,
            "usttpmName": "Latha K",
            "usttpmuid": "<<<No Data>>>",
            "type": "",
            "projectId": "",
            "accountManager": "",
            "dellManagerName": "",
            "projectDescription": ""
          }
        ]
        let mockbusinessunitdata=[
          {
            "bussinessUnit": "USI01",
            "bussinessUnitDescription": "UST-USA-IT",
            "type": null,
            "bussinessUnitId": 13
          }
        ]
        let mockdepartmentdata=[
          {
            "departmentTypeId": 9,
            "departmentId": 3015295,
            "departmentDescription": "G&A - Hitech1",
            "type": ""
          }
        ]


    mockBillingService.GetAllBillingData.and.returnValue(of(mockBillingdata))
    mockCandidateService.GetAllCandidatesData.and.returnValue(of(mockcandidatedata))
    mockCustomerService.GetAllCustomerData.and.returnValue(of(mockcustomerdata))
    mockEmployeeService.GetAllEmployeeData.and.returnValue(of(mockempdata))
    mockProjectService.GetAllProjectData.and.returnValue(of(mockprojectdata))
    mockContractCategoryService.GetAllContractCategoryData.and.returnValue(of(mockcategorydata))
    mockProjectManagerService.GetAllProjectManagerData.and.returnValue(of(mockprojectmanagerdata))
    mockRegionService.GetAllRegionData.and.returnValue(of(mockcountrydata))
    mockLocationTypeService.GetAllLocationTypeData.and.returnValue(of(mocklocationdata))
    mockJobcodeService.GetAllJobcodeData.and.returnValue(of(mockjobcodedata))
    mockFrequencyService.GetAllFrequencyData.and.returnValue(of(mockfrequencydata))
    mockUstTpmService.GetAllUSTTPMData.and.returnValue(of(mockmanagerdata))
    mockBusinessUnitService.GetAllBUData.and.returnValue(of(mockbusinessunitdata))
    mockDepartmentService.GetAllDepartmentData.and.returnValue(of(mockdepartmentdata))



    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('GetBillingdata',()=>{
    component.GetBillingdata();
  })
  it('updateCandidateName',()=>{
    const event = 1;
    component.updateCandidateName(event)
    
  })
  it('updateCustomerName',()=>{
    const event=1;
    component.updateCustomerName(event)
  })
  it('updateProjectmanagerName',()=>{
    const event=1;
    component.updateProjectmanagerName(event)
  })
  it('updateManagerName',()=>{
    const event=1;
    component.updateManagerName(event)
  })
  it('updateProjectDescription',()=>{
    const event=1;
    component.updateProjectDescription(event)
  })
  it('updateLocationDescription',()=>{
    const event=1;
    component.updateLocationDescription(event)
  })
  it('updateJobCodeDescription',()=>{
    const event=1;
    component.updateJobCodeDescription(event)
  })
  it('updatedepartmentDescr',()=>{
    const event=1;
    component.updatedepartmentDescr(event)
  })
  it('updatebudescription',()=>{
    const event=1;
    component.updatebudescription(event)
  })
  it('onSubmit',()=>{
   mockBillingService.PostBillingData.and.returnValue(throwError(() => {
    new Error("no candidate data")
   
  
   }))
   component.onSubmit()
  })
  it('markAllFieldsAsUntouched',()=>{
    component.markAllFieldsAsUntouched()
  })
});
