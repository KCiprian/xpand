import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

@Injectable({
    providedIn: 'root',
})
export class HttpService {
    constructor(private http: HttpClient) {}

    get(route: string): Observable<any> {
        return this.http.get(route);
    }

    post(route: string, body: any): Observable<any> {
        return this.http.post(route, body, httpOptions);
    }

    patch(route: string, body: any): Observable<any> {
        return this.http.patch(route, body, httpOptions);
    }

    put(route: string, body: any): Observable<any> {
        return this.http.put(route, body, httpOptions);
    }

    delete(route: string): Observable<any> {
        return this.http.delete(route);
    }
}