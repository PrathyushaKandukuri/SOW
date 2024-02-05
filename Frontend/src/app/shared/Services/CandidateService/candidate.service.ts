import { HttpClient, HttpEvent, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CandidateService {
  apiUrl = environment.apiUrl;
  baseUrl: string = this.apiUrl + "/Candidate";
  private header = new HttpHeaders({ "content-type": "application/json" });

  constructor(private http: HttpClient) { }

  PostCandidateDuplicateCheck(data: any): Observable<any> {
    let DATA = { candidates: data };
    return this.http
      .post(`${this.baseUrl}/ImportData`, DATA, {
        headers: this.header,

      })

  }

  importCandidatePAN(data: any): Observable<string> {
    let DATA = { candidates: data };
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
     console.log(DATA)
    return this.http.post<string>(`${this.apiUrl}/ImportPAN`, DATA, { headers })
      .pipe(
        catchError(this.handleError)
      );
  }
  private handleError(error: any): Observable<never> {
    console.error('An error occurred:', error);
    return throwError('Something went wrong. Please try again later.');
  }


  PostCandidateDuplicatepdfCheck(data: any): Observable<any> {
    let DATA = { candidates: data };
    return this.http
      .post(`${this.baseUrl}/ImportpdfData`, DATA, {
        headers: this.header,

      })

  }

  PostCandidatePAN(data: any): Observable<any> {
    let DATA = { candidates: data };
    return this.http
      .post(`${this.baseUrl}/ImportPAN`, DATA, {
        headers: this.header,

      })

  }


  GetAllCandidatesData(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}`);
  }
  PostCandidateData(data: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}`, data);
  }
  DeleteCandidateData(id: any): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/${id}`);
  }
  UpdateCandidateData(id: any, data: any): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/${id}`, data);
  }
  GetCandidateById(id: any): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/${id}`);
  }
  GetCandidateByDate(startDate: any, endDate: any): Observable<any> {
    return this.http.get<any>(
      `${this.baseUrl}/GetDate?StartDate=${startDate}&EndDate=${endDate}`
    );
  }
  GetAllCandidateDataForSoCandidateMapping(): Observable<any> {
    console.log(`${this.baseUrl}/SoCandidate`)
    return this.http.get<any>(`${this.baseUrl}/SoCandidate`);
  }


}
