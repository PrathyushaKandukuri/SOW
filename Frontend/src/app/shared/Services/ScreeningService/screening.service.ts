import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ScreeningService {

  constructor(private http: HttpClient) { }
  apiUrl=environment.apiUrl;
  baseUrl: string =this.apiUrl+ "/ScreeningProfile";
  // GetScreeningData()
  // {
  //   return this.http.get<any>(`${this.baseUrl}`);
  // }
 
 
  GetScreeningDataByID(id:any,startdate:any,endDate:any)
  {
  
    return this.http.get<any>(`${this.baseUrl}/${id}?startdate=${startdate}&enddate=${endDate}`)
  }
  GetProfilesBySo(data:any,startdate:any,endDate:any)
  {

    // console.log(`${this.baseUrl}/profiles/${data.type}?sowid=${data.sowid}`)
    return this.http.get<any>(`${this.baseUrl}/profiles/${data.type}?sowid=${data.sowid}&startdate=${startdate}&enddate=${endDate}`)
  }

}
