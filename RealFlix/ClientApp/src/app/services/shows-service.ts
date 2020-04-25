import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Show } from '../models/show';
import { SearchCriteria } from '../models/SearchCriteria';

@Injectable({
  providedIn: 'root',
})
export class ShowsService {
  baseUrl = environment.apiBaseUrl;
  constructor(private http: HttpClient) {}

  getShows(): Observable<Array<Show>> {
    return this.http
      .get<Array<Show>>(`${this.baseUrl}shows`)
      .pipe(retry(1), catchError(this.errorHandler));
  }

  getSearch(search: SearchCriteria): Observable<Array<Show>> {
    const options = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
        params: new HttpParams()
            .set('searchType', search.Type)
            .set('searchCriteria', search.Criteria)
    };
    return this.http
      .get<Array<Show>>(`${this.baseUrl}shows/Search`, options)
      .pipe(retry(1), catchError(this.errorHandler));
  }

  saveShow(show: Show): Observable<Show> {
    return this.http
      .post<Show>(`${this.baseUrl}shows`, show);
  }

  updateShow(show: Show): Observable<Show> {
    return this.http
      .put<Show>(`${this.baseUrl}shows/${show.Id}`, show);
  }

  deleteShow(showId: number): Observable<Show> {
    return this.http
      .delete<Show>(`${this.baseUrl}shows/${showId}`);
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
