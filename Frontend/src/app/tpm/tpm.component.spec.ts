import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TPMComponent } from './tpm.component';
import { UstTpmService } from '../shared/Services/UsttpmService/ust-tpm.service';
import { Router } from '@angular/router';
import { CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';
import { of, throwError } from 'rxjs';

describe('TPMComponent', () => {
  let component: TPMComponent;
  let fixture: ComponentFixture<TPMComponent>;
  let mockusttpmservice : any, mockrouter:any;
  beforeEach(() => {
    mockusttpmservice=jasmine.createSpyObj('UstTpmService',['GetUSTTPMByTPMName'])
    mockrouter=jasmine.createSpyObj('Router',['navigate'])
    TestBed.configureTestingModule({
      declarations: [TPMComponent],
      providers:[{provide:UstTpmService,useValue:mockusttpmservice},
      {provide:Router,useValue:mockrouter}],
      schemas:[NO_ERRORS_SCHEMA,CUSTOM_ELEMENTS_SCHEMA]

    })
    .compileComponents()
    fixture = TestBed.createComponent(TPMComponent);
    component = fixture.componentInstance;
    let mockuserData = {
      "EmailId": "admin@gmail.com",
      "oldPassword": "Sow@123",
      "newPassword": "Abc@123",
      "type": "update"
    }
    sessionStorage.setItem('userData', JSON.stringify(mockuserData))
    let mockusttpmdata={
      "usttpmId": 187,
      "usttpmName": "Latha K",
      "usttpmuid": "<<<No Data>>>",
      "type": "",
      "projectId": "",
      "accountManager": "",
      "dellManagerName": "",
      "projectDescription": ""
    }
    mockusttpmservice.GetUSTTPMByTPMName.and.returnValue(of(mockusttpmdata))
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('GetUstTPMID',()=>{
    mockusttpmservice.GetUSTTPMByTPMName.and.returnValue(throwError(()=>{
      new Error("no tpm data")

    }))
    component.GetUstTPMID()
  })
  it('applyFilter', ()=>{
    
    component.applyFilter("")
  })
  it('onRowClick', ()=>{
    component.onRowClick("")
  })
});
