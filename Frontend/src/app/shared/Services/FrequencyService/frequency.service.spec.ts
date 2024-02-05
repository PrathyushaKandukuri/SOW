import { TestBed } from '@angular/core/testing';

import { FrequencyService } from './frequency.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('FrequencyService', () => {
  let service: FrequencyService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports:[HttpClientTestingModule],
      providers:[FrequencyService]
    });
    service = TestBed.inject(FrequencyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it('GetAllFrequencyData', () => {
    const obj = [{   frequencyId: 4,
    frequency: "stringfre",
    type: null
    }, { 
      frequencyId: 3,
    frequency: "string123",
    type: null
     }];

    service.GetAllFrequencyData().subscribe((data) => {
      expect(data).toEqual(obj);
    });
  });
  it('GetAllFreqData', () => {
    const obj = [{   frequencyId: 4,
      frequency: "stringfre",
      type: null
    }, { 
      frequencyId: 3,
      frequency: "string123",
      type: null
     }];

    service.GetAllFreqData().subscribe((data) => {
      expect(data).toEqual(obj);
    });
  });
    it('PostFreqdata', () => {
      const obj = {  frequencyId: 3,
        frequency: "string123",
        type: null};
  
      service.PostFreqdata(obj).subscribe((response) => {
        expect(response).toEqual(obj);
      });
    
  });
  it('DeleteFreqData',()=>{
    const obj={ frequencyId: 3,
      frequency: "string123",
      type: null}
      service.DeleteFreqData(obj.frequencyId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
     
  })
  it('UpdateFreqData',()=>{
    const obj={ frequencyId: 3,
      frequency: "string123",
      type: null}
      service.UpdateFreqData(obj.frequencyId,obj).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
     
  })
  it('GetFreqId',()=>{
    const obj={ frequencyId: 3,
      frequency: "string123",
      type: null}
      service.GetFreqId(obj.frequencyId).subscribe((x)=>[
        expect(x).toEqual(obj)
      ])
      
      
  })
});
