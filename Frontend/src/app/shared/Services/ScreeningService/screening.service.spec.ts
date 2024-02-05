import { TestBed } from '@angular/core/testing';

import { ScreeningService } from './screening.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('ScreeningService', () => {
  let service: ScreeningService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports:[HttpClientTestingModule],
      providers:[ScreeningService]
    });
    service = TestBed.inject(ScreeningService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it('GetScreeningDataById',()=>{
    const data=
    {   soW_CandidateId: 0,
      sowId: 0,
      candidateId: 0,
      statusId: 0,
      type: "string",
      soName: "string",
      candidateName: "string",
      candidateUid: "string",
      statusName: "string",
      mappingDate: "2024-01-08T05:47:06.422Z"
      }
      
    
    service.GetScreeningDataByID(data.soW_CandidateId,new Date(),new Date());
      })


      it('GetProfilesBySo',()=>{
        const data=
        {   soW_CandidateId: 0,
          sowId: 0,
          candidateId: 0,
          statusId: 0,
          type: "string",
          soName: "string",
          candidateName: "string",
          candidateUid: "string",
          statusName: "string",
          mappingDate: "2024-01-08T05:47:06.422Z"
          }
          
        
        service.GetProfilesBySo(data,new Date(),new Date());
          })
    
      })
    
    


