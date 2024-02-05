import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BillingComponent } from './billing.component';
import { BehaviorSubject, of, throwError } from 'rxjs';
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
import { COMPOSITION_BUFFER_MODE } from '@angular/forms';

describe('BillingComponent', () => {
  let component: BillingComponent;
  let fixture: ComponentFixture<BillingComponent>;
   let mockBillingService: any,mockActivatedRoute:any,mocksnackBar:any,mockRegionService:any, mockEmployeeService:any,
   mockCustomerService:any, mockProjectService:any, mockContractCategoryService:any,mockProjectManagerService:any,
   mockLocationTypeService:any, mockJobcodeService:any,mockUstTpmService:any, mockBusinessUnitService:any,
   mockCandidateService:any, mockDepartmentService:any, mockFrequencyService:any,mockBillingdata:any
   
  beforeEach(() => {
    mockBillingService=jasmine.createSpyObj('BillingService',['GetBillingById','UpdateBillingData','DeleteBillingData'])
    let mockprojectData = {
      "projectId": "BRIN-0000-00-00",
    }
    mockActivatedRoute = {

      queryParams: new BehaviorSubject<any>( {projectdetails:btoa(JSON.stringify(mockprojectData))}),

    };
    mocksnackBar=jasmine.createSpyObj('MatSnackBar',['open'])
mockRegionService=jasmine.createSpyObj('RegionService',['GetAllRegionData'])
mockEmployeeService=jasmine.createSpyObj('EmployeeService',['GetAllEmployeeData'])
mockCustomerService=jasmine.createSpyObj('CustomerService',['GetAllCustomerData'])
mockProjectService=jasmine.createSpyObj('ProjectService',['GetAllProjectData'])
mockContractCategoryService=jasmine.createSpyObj('ContractCategoryService',['GetAllCategoryData'])
mockProjectManagerService=jasmine.createSpyObj('ProjectManagerService',['GetAllManagerData'])
mockLocationTypeService=jasmine.createSpyObj('LocationTypeService',['GetAllLocationTypeData'])
mockJobcodeService=jasmine.createSpyObj('JobcodeService',['GetAlljobcodeData'])
mockUstTpmService=jasmine.createSpyObj('UstTpmService',['GetAllUSTTPMData'])
mockBusinessUnitService=jasmine.createSpyObj('BusinessUnitService',['GetAllBUData'])
mockCandidateService=jasmine.createSpyObj('CandidateService',['GetAllCandidatesData'])
mockDepartmentService=jasmine.createSpyObj('DepartmentService',['GetAllDeptData'])
mockFrequencyService=jasmine.createSpyObj('FrequencyService',['GetAllFreqData'])


    TestBed.configureTestingModule({
      declarations: [BillingComponent],
    
      providers: [{provide:BillingService, useValue:mockBillingService},
        {provide:ActivatedRoute, useValue:mockActivatedRoute},
      {provide:MatSnackBar, useValue:mocksnackBar},
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
    .compileComponents();
    let mockuserData = {
      "EmailId": "admin@gmail.com",
      "oldPassword": "Sow@123",
      "newPassword": "Abc@123",
      "type": "update"
    }

    sessionStorage.setItem('author', JSON.stringify(mockuserData))
    sessionStorage.setItem('userData', JSON.stringify(mockuserData))
    fixture = TestBed.createComponent(BillingComponent);
    component = fixture.componentInstance;
     mockBillingdata=[
      {
        "billingId": 1,
        "resourceStartDate": "2024-01-05T00:00:00",
        "resourceEndDate": "2024-01-05T00:00:00",
        "domain": "string",
        "currency": "INR",
        "billRate": 0,
        "hours": 0,
        "totalBilledhrs": 0,
        "sowId": 2,
        "candidateId": 9,
        "type": "",
        "employeeId": 1,
        "customerTypeId": 1,
        "projectTypeId": 1,
        "billable": true,
        "clientProjectRole": "string",
        "clientProjectRoleDesc": "string",
        "aliasName": "string",
        "allocationPercentage": 0,
        "comments": "string",
        "projectManagerTypeId": 1,
        "contractCategoryId": 1,
        "jobCodeId": 1,
        "frequencyId": 1,
        "bussinessUnitId": 1,
        "departmentTypeId": 1,
        "candidateName": "Malleboina Mahesh",
        "candidateUid": "Ex-21839780",
        "contractCategory": "Account-Delivery",
        "customerId": "1000003512",
        "customerName": "Dell Global Business Center Sdn Bhd",
        "departmentId": 1015295,
        "departmentDescription": "Delivery - Hitech1",
        "employeeType": "Employee",
        "frequency": "Hourly",
        "jobCode": "A26A21",
        "jobDescription": "Associate II - HR",
        "projectManagerId": "U11164",
        "projectManagerName": "Ramachandra Prasan Vyas",
        "projectStartDate": "2017-12-04T00:00:00",
        "projectEndDate": "2023-12-31T00:00:00",
        "projectId": "BRIN-0000-00-00",
        "projectDescription": "ADA Testing Team",
        "joiningDate": "1900-01-30T00:00:00",
        "bussinessUnit": "INI01",
        "bussinessUnitDescription": "UST-Trivandrum-Technopark-IT",
        "locationTypeId": 1,
        "locationId": "INDBAN001",
        "locationDescription": "Bangalore",
        "regionId": 1,
        "region": "IN",
        "usttpmId": 153,
        "usttpmName": "Srinivas Chalamala",
        "usttpmuid": "150900",
        "terminationDate": "1900-01-01T00:00:00",
        "obu": 0,
        "obuDescription": "string"
      }
    ]
    mockBillingService.GetBillingById.and.returnValue(of(mockBillingdata))
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
 it('markAllFieldsAsUntouched',()=>{
  component.markAllFieldsAsUntouched()
  expect(component.markAllFieldsAsUntouched).toBeDefined()
 })
 it('canExit',()=>{
 
  component.canExit();
  expect(component.canExit).toBeDefined()
 })
it('toggleFormVisibility',()=>{
  component.toggleFormVisibility();
  expect(component.toggleFormVisibility).toBeDefined()
})
it('restCustomFilter',()=>{
  spyOn(component,'customFilter')
  spyOn(component,'toggleFormVisibility')
  component.restCustomFilter()
  expect(component.restCustomFilter).toBeDefined()
})
it('clearFormField',()=>{
  const fieldName = ' abcd'
  spyOn(component,'customFilter')
  component.clearFormField(fieldName)
  
})
it('customFilter',()=>{
  component.customFilter()
  expect(component.customFilter).toBeDefined()
})
it('formatdate',()=>{
  const date= "2024-01-01"
  component.formatdate(date)
})
it('deleteDetails',()=>{
  const obj={
    billingId: 1,
    resourceStartDate: "2024-01-05T00:00:00",
    resourceEndDate: "2024-01-05T00:00:00",
    domain: "string",
    currency: "INR",
    billRate: 0,
    hours: 0,
    totalBilledhrs: 0,
    sowId: 2,
    candidateId: 9,
    type: "",
    employeeId: 1,
    customerTypeId: 1,
    projectTypeId: 1,
    billable: true,
    clientProjectRole: "string",
    clientProjectRoleDesc: "string",
    aliasName: "string",
    allocationPercentage: 0,
    comments: "string",
    projectManagerTypeId: 1,
contractCategoryId: 1,
    jobCodeId: 1,
    frequencyId: 1,
    bussinessUnitId: 1,
    departmentTypeId: 1,
    candidateName: "Malleboina Mahesh",
    candidateUid: "Ex-21839780",
    contractCategory: "Account-Delivery",
    customerId: "1000003512",
    customerName: "Dell Global Business Center Sdn Bhd",
    departmentId: 1015295,
    departmentDescription: "Delivery - Hitech1",
    employeeType: "Employee",
    frequency: "Hourly",
    jobCode: "A26A21",
    jobDescription: "Associate II - HR",
    projectManagerId: "U11164",
    projectManagerName: "Ramachandra Prasan Vyas",
    projectStartDate: "2017-12-04T00:00:00",
    projectEndDate: "2023-12-31T00:00:00",
    projectId: "BRIN-0000-00-00",
    projectDescription: "ADA Testing Team",
    joiningDate: "1900-01-30T00:00:00",
  bussinessUnit: "INI01",
    bussinessUnitDescription: "UST-Trivandrum-Technopark-IT",
    locationTypeId: 1,
    locationId: "INDBAN001",
    locationDescription: "Bangalore",
  regionId: 1,
    region: "IN",
    usttpmId: 153,
    usttpmName: "Srinivas Chalamala",
    usttpmuid: "150900",
    terminationDate: "1900-01-01T00:00:00",
    obu: 0,
    obuDescription: "string"
  }
    spyOn(window,'confirm').and.returnValue(true)
  mockBillingService.DeleteBillingData.and.returnValue(of(obj.billingId))
  component.deleteDetails(obj.billingId)
})
it('GetDropdown12',()=>{
  const freq=
    {
      "frequencyId": 3,
      "frequency": "NA",
      "type": null
    }
  
  mockFrequencyService.GetAllFreqData.and.returnValue(of(freq))
  component.GetDropdown12()
}
)
it('GetDropdown11',()=>{
  const candidate=
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
    }
  
  mockCandidateService.GetAllCandidatesData.and.returnValue(of(candidate))
  component.GetDropdown11()
}
)
it('GetDropdown10',()=>{
  const bu=
    {
      "bussinessUnit": "USI01",
      "bussinessUnitDescription": "UST-USA-IT",
      "type": null,
      "bussinessUnitId": 13
    }
  
  mockBusinessUnitService.GetAllBUData.and.returnValue(of(bu))
  component.GetDropdown10()
}
)
it('GetDropdown9',()=>{
  const customer=
    {
      "customerTypeId": 9,
      "customerId": "98063385",
      "customerName": "DELL, Inc.",
      "type": ""
    }
  
  mockCustomerService.GetAllCustomerData.and.returnValue(of(customer))
  component.GetDropdown9()
}
)
it('GetDropdown8',()=>{
  const emp=
    {
      "employeeId": 4,
      "employeeType": "Temporary",
      "type": ""
    }
  
  mockEmployeeService.GetAllEmployeeData.and.returnValue(of(emp))
  component.GetDropdown8()
}
)
it('GetDropdown7',()=>{
  const region=
    {
      "regionId": 8,
      "region": "PH",
      "type": ""
    }
  
  mockRegionService.GetAllRegionData.and.returnValue(of(region))
  component.GetDropdown7()
}
)
it('GetDropdown6',()=>{
  const project=
    {
      "projectTypeId": 130,
      "projectId": "WSTN-0007-01-01",
      "projectDescription": "Striker( Fork OT) Platform Val",
      "projectStartDate": "2023-08-01T00:00:00",
      "projectEndDate": "2023-11-30T00:00:00",
      "type": ""
    }
  
  mockProjectService.GetAllProjectData.and.returnValue(of(project))
  component.GetDropdown6()
}
)
it('GetDropdown5',()=>{
  const category=
    {
      "contractCategoryId": 7,
    "contractCategory": "T & M",
    "type": ""
    }
  
  mockContractCategoryService.GetAllCategoryData.and.returnValue(of(category))
  component.GetDropdown5()
}
)
it('GetDropdown4',()=>{
  const manager=
    {
      "projectManagerTypeId": 2,
      "projectManagerId": "U23181",
      "projectManagerName": "Venkata Narendra Peram",
      "type": ""
    }
  
  mockProjectManagerService.GetAllManagerData.and.returnValue(of(manager))
  component.GetDropdown4()
}
)
it('GetDropdown3',()=>{
  const location=
    {
      "projectManagerTypeId": 2,
      "projectManagerId": "U23181",
      "projectManagerName": "Venkata Narendra Peram",
      "type": ""
    }
  
  mockLocationTypeService.GetAllLocationTypeData.and.returnValue(of(location))
  component.GetDropdown3()
}
)
it('GetDropdown2',()=>{
  const jobcode=
    {
      "jobCodeId": 105,
    "jobCode": "F44B11",
    "jobDescription": "ML Engineer I",
    "type": null
    }
  
  mockJobcodeService.GetAlljobcodeData.and.returnValue(of(jobcode))
  component.GetDropdown2()
}
)
it('GetDropdown1',()=>{
  const usttpm=
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
  
  mockUstTpmService.GetAllUSTTPMData.and.returnValue(of(usttpm))
  component.GetDropdown1()
}
)
it('GetDropdown',()=>{
  const dept=
    {
      "departmentTypeId": 9,
    "departmentId": 3015295,
    "departmentDescription": "G&A - Hitech1",
    "type": ""
    }
  
  mockDepartmentService.GetAllDeptData.and.returnValue(of(dept))
  component.GetDropdown()
}
)
it('openSnackBar',()=>{
  const message="successfully added"
  const action = "ok"
  component.openSnackBar(message,action)
})
it('UpdatebillingData',()=>{
  const obj={
    billingId: 1,
    resourceStartDate: "2024-01-05T00:00:00",
    resourceEndDate: "2024-01-05T00:00:00",
    domain: "string",
    currency: "INR",
    billRate: 0,
    hours: 0,
    totalBilledhrs: 0,
    sowId: 2,
    candidateId: 9,
    type: "",
    employeeId: 1,
    customerTypeId: 1,
    projectTypeId: 1,
    billable: true,
    clientProjectRole: "string",
    clientProjectRoleDesc: "string",
    aliasName: "string",
    allocationPercentage: 0,
    comments: "string",
    projectManagerTypeId: 1,
contractCategoryId: 1,
    jobCodeId: 1,
    frequencyId: 1,
    bussinessUnitId: 1,
    departmentTypeId: 1,
    candidateName: "Malleboina Mahesh",
    candidateUid: "Ex-21839780",
    contractCategory: "Account-Delivery",
    customerId: "1000003512",
    customerName: "Dell Global Business Center Sdn Bhd",
    departmentId: 1015295,
    departmentDescription: "Delivery - Hitech1",
    employeeType: "Employee",
    frequency: "Hourly",
    jobCode: "A26A21",
    jobDescription: "Associate II - HR",
    projectManagerId: "U11164",
    projectManagerName: "Ramachandra Prasan Vyas",
    projectStartDate: "2017-12-04T00:00:00",
    projectEndDate: "2023-12-31T00:00:00",
    projectId: "BRIN-0000-00-00",
    projectDescription: "ADA Testing Team",
    joiningDate: "1900-01-30T00:00:00",
  bussinessUnit: "INI01",
    bussinessUnitDescription: "UST-Trivandrum-Technopark-IT",
    locationTypeId: 1,
    locationId: "INDBAN001",
    locationDescription: "Bangalore",
  regionId: 1,
    region: "IN",
    usttpmId: 153,
    usttpmName: "Srinivas Chalamala",
    usttpmuid: "150900",
    terminationDate: "1900-01-01T00:00:00",
    obu: 0,
    obuDescription: "string"
  }
  mockBillingService.UpdateBillingData.and.returnValue(of(obj.billingId,obj))
  component.UpdatebillingData(obj)
})
it('UpdateBillingData for err',()=>{
  const obj ={
    billingId: 1,
    resourceStartDate: "2024-01-05T00:00:00",
    resourceEndDate: "2024-01-05T00:00:00",
    domain: "string",
    currency: "INR",
    billRate: 0,
    hours: 0,
    totalBilledhrs: 0,
    sowId: 2,
    candidateId: 9,
    type: "",
    employeeId: 1,
    customerTypeId: 1,
    projectTypeId: 1,
    billable: true,
    clientProjectRole: "string",
    clientProjectRoleDesc: "string",
    aliasName: "string",
    allocationPercentage: 0,
    comments: "string",
    projectManagerTypeId: 1,
contractCategoryId: 1,
    jobCodeId: 1,
    frequencyId: 1,
    bussinessUnitId: 1,
    departmentTypeId: 1,
    candidateName: "Malleboina Mahesh",
    candidateUid: "Ex-21839780",
    contractCategory: "Account-Delivery",
    customerId: "1000003512",
    customerName: "Dell Global Business Center Sdn Bhd",
    departmentId: 1015295,
    departmentDescription: "Delivery - Hitech1",
    employeeType: "Employee",
    frequency: "Hourly",
    jobCode: "A26A21",
    jobDescription: "Associate II - HR",
    projectManagerId: "U11164",
    projectManagerName: "Ramachandra Prasan Vyas",
    projectStartDate: "2017-12-04T00:00:00",
    projectEndDate: "2023-12-31T00:00:00",
    projectId: "BRIN-0000-00-00",
    projectDescription: "ADA Testing Team",
    joiningDate: "1900-01-30T00:00:00",
  bussinessUnit: "INI01",
    bussinessUnitDescription: "UST-Trivandrum-Technopark-IT",
    locationTypeId: 1,
    locationId: "INDBAN001",
    locationDescription: "Bangalore",
  regionId: 1,
    region: "IN",
    usttpmId: 153,
    usttpmName: "Srinivas Chalamala",
    usttpmuid: "150900",
    terminationDate: "1900-01-01T00:00:00",
    obu: 0,
    obuDescription: "string"

  }
  mockBillingService.UpdateBillingData.and.returnValue(throwError(()=>{
    new Error('not updated ')

  }))
  component.UpdatebillingData(obj)
})
it('selectRow',()=>{
  const obj=
  {

  }
  component.selectRow(obj)
})
it('cancelUpadte',()=>{
  const obj = 
  {

  }
  component.cancelUpdate(obj)
  
})
it('getRegionName',()=>{
  const id = 1
  component.getRegionName(id)
})
});
