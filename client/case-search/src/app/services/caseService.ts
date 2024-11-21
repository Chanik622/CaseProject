import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { filterCase } from "../models/filterCase";

@Injectable({
    providedIn: 'root'
  })
  export class CaseService {
    private baseUrl = 'http://localhost:5000/api/cases/GetCaseDetails'; 
    constructor(private http: HttpClient) {
        console.log()
    }
  
    getCaseDetails(filter: filterCase): Observable<any> {
     debugger;
      return this.http.post(this.baseUrl, filter); 
    }
  }
  