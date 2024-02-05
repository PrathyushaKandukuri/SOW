

import { ComponentFixture, TestBed } from '@angular/core/testing';

 

import { CandidateMappingComponent } from './candidate-mapping.component';

import { CandidateMappingService } from '../shared/Services/CandidateMappingService/candidate-mapping.service';

import { CandidateService } from '../shared/Services/CandidateService/candidate.service';

import { SoService } from '../shared/Services/SoService/so.service';

import { StatusService } from '../shared/Services/StatusService/status.service';

import { ExcelService } from '../shared/Services/ExcelService/excel.service';

import { of, throwError } from 'rxjs';

import { CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';

import { AbstractControl, FormGroupDirective } from '@angular/forms';

import { MatDialog } from '@angular/material/dialog';

import { CandidateDetailsComponent } from '../candidate/candidate-details/candidate-details.component';

import { Dialog } from '@angular/cdk/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { formatDate } from '@angular/common';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';

 

 

describe('CandidateMappingComponent', () => {

  let component: CandidateMappingComponent;

  let fixture: ComponentFixture<CandidateMappingComponent>;
let mockformdirective:FormGroupDirective,mockevent:MatAutocompleteSelectedEvent
  let mockCandidatemappingService: any, mockcandidateService:any, mockSoService:any, mockStatusserviceService

    , mockExcelService:any, mockexceldata, mockCandidatedata, mockcandidatemappingdata, mockdialog: any,

    mocksodata, mockstatusdata,mockmatsnackbar:any
 

  beforeEach(() => {
    mockevent=jasmine.createSpyObj('MatAutocompleteSelectedEvent',['option'])
mockformdirective=jasmine.createSpyObj('FormGroupDirective',['resetForm'])
    mockcandidateService = jasmine.createSpyObj('CandidateService', ['GetAllCandidatesData', 'GetCandidateById','GetAllCandidateDataForSoCandidateMapping'])

    mockCandidatemappingService = jasmine.createSpyObj('CandidateMappingService', ['GetAllCandidateMappingData',

      'PostCandidateMappingData', 'UpdateCandidateMappingData', 'GetCandidateById', 'DeleteCandidateMappingData'])

    mockExcelService = jasmine.createSpyObj('ExcelService', ['jsonExportAsExcel'])

    mockSoService = jasmine.createSpyObj('SoService', ['GetAllSowData', 'GetSowById','GetAllSowDataForSoCandidateMapping'])

    mockStatusserviceService = jasmine.createSpyObj('StatusService', ['GetAllStatusData', 'GetStatusById', 'GetStatusByType'])

    mockdialog = jasmine.createSpyObj('MatDialog', ['open'])
    mockmatsnackbar=jasmine.createSpyObj('MatSnackBar',['open'])

    TestBed.configureTestingModule({

      declarations: [CandidateMappingComponent],

      providers: [{ provide: CandidateMappingService, useValue: mockCandidatemappingService },

      { provide: CandidateService, useValue: mockcandidateService },

      { provide: SoService, useValue: mockSoService }, 
      { provide: StatusService, useValue: mockStatusserviceService },

      { provide: ExcelService, useValue: mockExcelService },

      { provide: MatDialog, useValue: mockdialog },
      {provide:MatSnackBar,useValue:mockmatsnackbar},
      {provide:FormGroupDirective,useValue:mockformdirective},
      {provide:MatAutocompleteSelectedEvent,useValue:mockevent}

      ],

      schemas: [NO_ERRORS_SCHEMA,CUSTOM_ELEMENTS_SCHEMA]

 

    })

      .compileComponents();

    mocksodata = [

      {

        "sowId": 33,

        "soName": "SADFG",

        "jrCode": "234",

        "requestCreationDate": "2023-06-15T00:00:00",

        "accountId": 2,

        "technologyId": 184,

        "role": "Developer",

        "locationId": 5,

        "regionId": 1,

        "targetOpenPositions": 3,

        "positionsTobeClosed": 3,

        "ustpocId": 7,

        "recruiterId": 1,

        "usttpmId": 27,

        "dellManagerId": 38,

        "statusId": 3,

        "band": "SDFG",

        "projectId": "234WESD",

        "accountManager": "Darshan",

        "externalResource": "Darshan",

        "internalResource": "Darshan",

        "type": "",

        "technologyName": "UX - Product Designer",

        "accountName": "DL-US",

        "location": "BNG",

        "region": "IN",

        "ustpocName": "Chitralekha M / Practice",

        "recruiterName": "Abhishek P",

        "usttpmName": "Vasu K",

        "dellManagerName": "Bhadri Ravikanth",

        "statusName": "Closed"

      },

      {

        "sowId": 5,

        "soName": "Chaithra123",

        "jrCode": "1234",

        "requestCreationDate": "2023-04-04T13:06:55.02",

        "accountId": 4,

        "technologyId": 180,

        "role": "Developer",

        "locationId": 3,

        "regionId": 2,

        "targetOpenPositions": 1,

        "positionsTobeClosed": 1,

        "ustpocId": 41,

        "recruiterId": 28,

        "usttpmId": 63,

        "dellManagerId": 577,

        "statusId": 2,

        "band": "A",

        "projectId": "123",

        "accountManager": "mahesh",

        "externalResource": "bhagya",

        "internalResource": "bhagya",

        "type": "",

        "technologyName": "Validation Eng",

        "accountName": "DL-MY",

        "location": "SG",

        "region": "MY",

        "ustpocName": "Jaya/Kanika",

        "recruiterName": "Srivani Doli",

        "usttpmName": "Vijay Kumar",

        "dellManagerName": "Vinitha",

        "statusName": "Declined"

      },

      {

        "sowId": 4,

        "soName": "test",

        "jrCode": "14",

        "requestCreationDate": "2023-03-03T00:00:00",

        "accountId": 3,

        "technologyId": 178,

        "role": "Software Developer",

        "locationId": 2,

        "regionId": 3,

        "targetOpenPositions": 1,

        "positionsTobeClosed": 1,

        "ustpocId": 37,

        "recruiterId": 24,

        "usttpmId": 64,

        "dellManagerId": 581,

        "statusId": 1,

        "band": "c",

        "projectId": "12345",

        "accountManager": "mahesh",

        "externalResource": "test1",

        "internalResource": "wrfrwg",

        "type": "",

        "technologyName": "UX Designer",

        "accountName": "DL-USTI",

        "location": "HYD",

        "region": "SG",

        "ustpocName": "Selva",

        "recruiterName": "Soumya Dash",

        "usttpmName": "Ravi Jonnalagadda",

        "dellManagerName": "Vishwa",

        "statusName": "Offered"

      },

      {

        "sowId": 3,

        "soName": "Bhagya",

        "jrCode": "14",

        "requestCreationDate": "2023-04-04T13:26:08.807",

        "accountId": 3,

        "technologyId": 175,

        "role": "admin",

        "locationId": 3,

        "regionId": 3,

        "targetOpenPositions": 1,

        "positionsTobeClosed": 1,

        "ustpocId": 37,

        "recruiterId": 27,

        "usttpmId": 66,

        "dellManagerId": 573,

        "statusId": 3,

        "band": "A",

        "projectId": "dhhef",

        "accountManager": "mahesh",

        "externalResource": "test1",

        "internalResource": "chaithra",

        "type": "",

        "technologyName": "UI-Front end",

        "accountName": "DL-USTI",

        "location": "SG",

        "region": "SG",

        "ustpocName": "Selva",

        "recruiterName": "Srinivas",

        "usttpmName": "Lakshmi Narasimha Rao Kovuru",

        "dellManagerName": "Vikranth",

        "statusName": "Closed"

      },

      {

        "sowId": 2,

        "soName": "Chaithra",

        "jrCode": "1234",

        "requestCreationDate": "2023-04-04T13:06:55.02",

        "accountId": 4,

        "technologyId": 180,

        "role": "Developer",

        "locationId": 3,

        "regionId": 2,

        "targetOpenPositions": 1,

        "positionsTobeClosed": 1,

        "ustpocId": 41,

        "recruiterId": 28,

        "usttpmId": 63,

        "dellManagerId": 577,

        "statusId": 2,

        "band": "A",

        "projectId": "123",

        "accountManager": "mahesh",

        "externalResource": "bhagya",

        "internalResource": "bhagya",

        "type": "",

        "technologyName": "Validation Eng",

        "accountName": "DL-MY",

        "location": "SG",

        "region": "MY",

        "ustpocName": "Jaya/Kanika",

        "recruiterName": "Srivani Doli",

        "usttpmName": "Vijay Kumar",

        "dellManagerName": "Vinitha",

        "statusName": "Declined"

      },

      {

        "sowId": 1,

        "soName": "deepika",

        "jrCode": "142",

        "requestCreationDate": "2023-03-14T14:47:22.96",

        "accountId": 4,

        "technologyId": 180,

        "role": "Dev",

        "locationId": 3,

        "regionId": 2,

        "targetOpenPositions": 2,

        "positionsTobeClosed": 1,

        "ustpocId": 41,

        "recruiterId": 28,

        "usttpmId": 63,

        "dellManagerId": 577,

        "statusId": 2,

        "band": "A",

        "projectId": "12345",

        "accountManager": "sathish",

        "externalResource": "test1",

        "internalResource": "wrfrwgwe",

        "type": "",

        "technologyName": "Validation Eng",

        "accountName": "DL-MY",

        "location": "SG",

        "region": "MY",

        "ustpocName": "Jaya/Kanika",

        "recruiterName": "Srivani Doli",

        "usttpmName": "Vijay Kumar",

        "dellManagerName": "Vinitha",

        "statusName": "Declined"

      }

    ]

    mockCandidatedata = [

      {

 

        "candidateId": 1,

        "candidateName": "deeeeep",

        "candidateUid": null,

        "mobileNo": "9182737383",

        "gender": "Female",

        "dob": "2000-04-03T00:00:00",

        "email": "akuladeepika431@gmail.com",

        "location": "Bangalore",

        "skills": "Angular",

        "joiningDate": "2023-03-03T00:00:00",

        "address": "Ananthapur",

        "status": "Offered",

        "pincode": "456382",

        "isInternal": true

 

      },

      {

        "candidateId": 2034,

        "candidateName": "kandukuri prathyusha Reddy",

        "candidateUid": "237518",

        "mobileNo": "8522019567",

        "gender": "female",

        "dob": "2023-04-15T00:00:00",

        "email": "prathyushareddy2204@gmail.com",

        "location": "Hyderabad",

        "skills": "c#",

        "joiningDate": "2023-04-21T00:00:00",

        "address": "1-14,neeliagudem,thripuraram,nalgonda",

        "status": "Cancelled",

        "pincode": "500084",

        "isInternal": true

      },

      {

        "candidateId": 2026,

        "candidateName": "Kandukuri prathyusha",

        "candidateUid": "238023",

        "mobileNo": "8765344567",

        "gender": "Female",

        "dob": "2000-04-22T00:00:00",

        "email": "sadfgnd@asdv.com",

        "location": "Bengaluru",

        "skills": "Angular, .Net, Selenium, Jasmine.",

        "joiningDate": "2022-09-06T00:00:00",

        "address": "Bengaluru",

        "status": "Offered",

        "pincode": "875456",

        "isInternal": true

      },

      {

        "candidateId": 2023,

        "candidateName": "dvs",

        "candidateUid": "1234",

        "mobileNo": "9164292391",

        "gender": "Male",

        "dob": "2023-06-07T00:00:00",

        "email": "Darshan.Vinayakshejawadkar@Ust.Com",

        "location": "asd",

        "skills": "asd",

        "joiningDate": "2023-04-07T00:00:00",

        "address": "asdfvs",

        "status": "Cancelled",

        "pincode": "583217",

        "isInternal": false

      }]

 

    mockcandidatemappingdata = [

      {

        "soW_CandidateId": 16,
        "sowId": 9,
        "candidateId": 14,
        "statusId": 15,
        "type": "",
        "soName": "123Y6543SD-Abdul Jabbarkarpoor/APP",
        "candidateName": "123456sdfdsa/Bharathds",
        "candidateUid": "",
        "statusName": "Offer Accepted",
        "mappingDate": "2024-01-18T00:00:00",
        "startDate": "2024-01-05T13:19:32.7696756+05:30",
        "endDate": "2024-01-05T13:19:32.7696758+05:30"
  

      },

     
    ]

    mockexceldata = [{ "domainId": 12, "domainName": "EBI/DWH" }, { "domainId": 11, "domainName": "App Dev" }, { "domainId": 10, "domainName": "DB" }, { "domainId": 9, "domainName": "Support" }, { "domainId": 8, "domainName": "R&D" }]

    mockstatusdata = [{

      "statusId": 6,

      "statusName": "Rejected",

      "type": "",

      "statusType": "Candidate"

    },

    {

      "statusId": 5,

      "statusName": "Cancelled",

      "type": "",

      "statusType": "Candidate"

    },

    {

      "statusId": 4,

      "statusName": "Joined",

      "type": "",

      "statusType": "Candidate"

    },

    {

      "statusId": 3,

      "statusName": "Closed",

      "type": "",

      "statusType": "SO"

    },

    {

      "statusId": 2,

      "statusName": "Declined",

      "type": "",

      "statusType": "SO"

    },

    {

      "statusId": 1,

      "statusName": "Offered",

      "type": "",

      "statusType": "SO"

    }]

   

    fixture = TestBed.createComponent(CandidateMappingComponent);

    component = fixture.componentInstance;

    mockcandidateService.GetAllCandidatesData.and.returnValue(of(mockCandidatedata))

    mockCandidatemappingService.GetAllCandidateMappingData.and.returnValue(of(mockcandidatemappingdata))

    mockExcelService.jsonExportAsExcel.and.returnValue(of(mockexceldata))

    mockSoService.GetAllSowData.and.returnValue(of(mocksodata))

    mockCandidatemappingService.UpdateCandidateMappingData.and.returnValue(of(component.Id, mockcandidatemappingdata))

    mockCandidatemappingService.PostCandidateMappingData.and.returnValue(of(mockcandidatemappingdata))

    mockCandidatemappingService.DeleteCandidateMappingData.and.returnValue(of(mockcandidatemappingdata))

    mockStatusserviceService.GetAllStatusData.and.returnValue(of(mockstatusdata))

    mockStatusserviceService.GetStatusByType.and.returnValue(of(mockstatusdata))

    fixture.detectChanges();

 

 

  });

 

  it('should create', () => {

    expect(component).toBeTruthy();

  });

 

  
  it('GetCandidateMappingData', () => {

 

    mockCandidatemappingService.GetAllCandidateMappingData.and.returnValue(throwError(() => {

      new Error("no candidate data")

 

    }))

    component.GetCandidateMappingData();

  })

  it('UpdateCandidate', () => {

    const obj = {

      soW_CandidateId: 16,
      sowId: 9,
      candidateId: 14,
      statusId: 15,
      type: "",
      soName: "123Y6543SD-Abdul Jabbarkarpoor/APP",
      candidateName: "123456sdfdsa/Bharathds",
      candidateUid: "",
      statusName: "Offer Accepted",
      mappingDate: "2024-01-18",
      startDate: "2024-01-01",
      endDate: "2024-01-18"

    }

    mockCandidatemappingService.UpdateCandidateMappingData.and.returnValue(throwError(() => {

      new Error("no candidate data")

 

    }))

    component.UpdateCandidate(obj);

  })

 

 
 

  it('download', () => {

    component.filteredMappingArray = [

      {

        "soW_CandidateId": 2,

        "sowId": 6,

        "candidateId": 5,

        "statusId": 2,

        "type": "",

        "soName": "prathyusha123",

        "candidateName": "prathyushareddy12",

        "statusName": "Declined"

      }

    ]

 

 

    component.DownloadExcel()

    expect(component.DownloadExcel()).toBe()

  })

 

  it('isFieldInvalid', () => {

    const fieldName = 'email'; // Replace with the actual field name

    const control = { invalid: true, touched: true };

    spyOn(component.mapppingForm, 'get').and.returnValue(control as AbstractControl);

    expect(component.isFieldInvalid(fieldName)).toBe(true);

  });

 

  it('deleteDetails', () => {

    spyOn(window, 'confirm').and.returnValue(true)

    const formValue = {

      sowId: '7',

      candidateId: '7',

      statusId: '2',

    };

    const stringValue = {

      sowId: formValue.sowId.toString(),

      candidateId: formValue.candidateId.toString(),

      statusId: formValue.statusId.toString(),

    }

    component.mapppingForm.patchValue(stringValue)

    const obj = {

      "soW_CandidateId": 1,

      "sowId": 7,

      "candidateId": 7,

      "statusId": 2,

      "type": "",

    }

    component.deleteDetails(obj)

    expect(component.deleteDetails(obj)).toBe()

  })

 

  

 

  it('applyEdit', () => {

 

    const CandidateMapping = {

      "soW_CandidateId": 2,

      "sowId": 6,

      "candidateId": 5,

      "statusId": 2,

      "type": "",

      "soName": "prathyusha123",

      "candidateName": "prathyushareddy12",

      "statusName": "Declined",

      "isEditing": false

    }

    component.applyEdit(CandidateMapping)

    expect(CandidateMapping.isEditing).toBe(true);

  })

 

  it('cancelEdit', () => {

    const CandidateMapping = {

      "soW_CandidateId": 16,
      "sowId": 9,
      "candidateId": 14,
      "statusId": 15,
      "type": "",
      "soName": "123Y6543SD-Abdul Jabbarkarpoor/APP",
      "candidateName": "123456sdfdsa/Bharathds",
      "candidateUid": "",
      "statusName": "Offer Accepted",
      "mappingDate": "2024-01-18T00:00:00",
      "startDate": "2024-01-05T13:19:32.7696756+05:30",
      "endDate": "2024-01-05T13:19:32.7696758+05:30"

    }

    component.cancelEdit(CandidateMapping)

    

  })

 

 

  it('toggleFormVisibility', () => {

    component.toggleFormVisibility()

    expect(component.isFormVisible).toBeTrue();

  })

 

  it('get f', () => {

    expect(component.mapppingForm.controls).toEqual(component.f)

  })

 

  it('UpdateCandidate', () => {

 

    const obj = {

      soW_CandidateId: 16,
      sowId: 9,
      candidateId: 14,
      statusId: 15,
      type: "",
      soName: "123Y6543SD-Abdul Jabbarkarpoor/APP",
      candidateName: "123456sdfdsa/Bharathds",
      candidateUid: "",
      statusName: "Offer Accepted",
      mappingDate: "2024-01-18",
      startDate: "2024-01-01",
      endDate: "2024-01-18"

    }
    
    component.UpdateCandidate(obj);

  })
//  it('openModal',()=>{
//   component.openModal()
//  })
it('closeModal',()=>{
  component.closeModal(mockformdirective)
})
// it('onSubmit',()=>{
//   spyOn(component,'markAllFieldsAsUntouched')
//   component.onSubmit(mockformdirective)

// })
it('isFieldInvalid',()=>{
  const fieldName="abcd"
  component.isFieldInvalid(fieldName)
})
it('markAllFieldsAsUntouched',()=>{
  component.markAllFieldsAsUntouched()
})
it('GetStatusData',()=>{
  component.GetStatusData()
})
it('GetCandidateData',()=>{
  const obj={
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
  mockcandidateService.GetAllCandidateDataForSoCandidateMapping.and.returnValue(of(obj))
  component.GetCandidateData()
})
it('GetSOData',()=>{
  const obj={
    "sowId": 29,
    "soName": "App Dev",
    "jrCode": "597020212",
    "requestCreationDate": "2023-11-26T07:30:00",
    "accountId": 1,
    "technologyId": 5,
    "comments": "",
    "locationId": 3,
    "regionId": 1,
    "targetOpenPositions": 1,
    "positionsTobeClosed": 0,
    "ustpocId": 14,
    "recruiterId": 17,
    "usttpmId": 153,
    "dellManagerId": 300,
    "statusId": 4,
    "band": "b1/b2(max15lks)",
    "projectId": "dlin-0026-01-06",
    "accountManager": "udaya",
    "externalResource": "malleboina mahesh",
    "internalResource": "<<<No Data>>>",
    "type": "",
    "technologyName": ".Net Developer",
    "accountName": "DL-IN",
    "location": "HYD",
    "region": "IN",
    "ustpocName": "Divya P",
    "recruiterName": "Jhansi C",
    "usttpmName": "Srinivas Chalamala",
    "dellManagerName": "Raja Munishwar",
    "statusName": "Joined",
    "onboardingdate": "2023-12-10T07:30:00",
    "domainName": "",
    "domain": "",
    "jr": "",
    "account": "",
    "ustpoc": "",
    "recruiter": "",
    "usttpm": "",
    "dellManager": "",
    "status": "",
    "am": "",
    "isOnHold": false,
    "ageingColor": "Green",
    "jobDesc": "<<<No data>>>",
    "roleDetailsId": 1,
    "roleDetails": ".Net Developer",
    "experienceinyears": 5
  }
  mockSoService.GetAllSowDataForSoCandidateMapping.and.returnValue(of(obj))
  component.GetSOData()
})
// it('onOptionSelectedCandidate',()=>{
//  spyOn(component.mapppingForm,'get')
//   component.onOptionSelectedCandidate(mockevent)
// })
it('onAdd',()=>{
  component.onAdd(mockformdirective)
})


});

 