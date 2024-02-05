import { TestBed } from '@angular/core/testing';

import { LocationTypeService } from './location-type.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('LocationTypeService', () => {
  let service: LocationTypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports:[HttpClientTestingModule],
      providers:[LocationTypeService]
    });
    service = TestBed.inject(LocationTypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it('GetAllLocationTypeData', () => {
    const obj = [{ locationTypeId: 4,
    locationId: "INDHYDC01",
    locationDescription: "string",
    regionId: 1,
    type: ""
    }, { 
      locationTypeId: 3,
    locationId: "STRING",
    locationDescription: "string",
    regionId: 1,
    type: ""
     }];

    service.GetAllLocationTypeData().subscribe((data) => {
      expect(data).toEqual(obj);
    });
  });
    it('stlocData', () => {
      const obj = {  locationTypeId: 3,
        locationId: "STRING",
        locationDescription: "string",
        regionId: 1,
        type: ""};
  
      service.stlocData(obj).subscribe((response) => {
        expect(response).toEqual(obj);
      });
    
  });
  it('DeletelocData',()=>{
    const obj={ locationTypeId: 3,
      locationId: "STRING",
      locationDescription: "string",
      regionId: 1,
      type: ""}
      service.DeletelocData(obj.locationTypeId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
     
  })
  it('UpdatelocData',()=>{
    const obj={ locationTypeId: 3,
      locationId: "STRING",
      locationDescription: "string",
      regionId: 1,
      type: ""}
      service.UpdatelocData(obj.locationTypeId,obj).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
     
  })
  it('GetlocById',()=>{
    const obj={ locationTypeId: 3,
      locationId: "STRING",
      locationDescription: "string",
      regionId: 1,
      type: ""}
      service.GetlocById(obj.locationTypeId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
      
      
  })
});
