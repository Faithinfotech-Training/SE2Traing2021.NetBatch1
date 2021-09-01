import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "src/environments/environment";

@Injectable()
export class InsightService {
    apiUrl="http://localhost:25083/api/Visits"
    constructor(private httpClient: HttpClient) {}

    public getPageVisits(): Observable<any> {
        return this.httpClient.get<any>(
          `${this.apiUrl}`
        );
      }

      public Visited(page: String): Observable<any> {
        const httpOptions = {
          headers: new HttpHeaders({
            "Content-Type": "application/json",
          }),
        };
        return this.httpClient.post<any>(
          `http://localhost:25083/api/Visits/page/${page}`,
          httpOptions
        );
      }
}