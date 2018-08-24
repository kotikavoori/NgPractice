import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';

import { catchError, map, tap } from 'rxjs/operators';

import { AppConfig } from '../config/config';

import { BaseService } from './base.service';
import { Helpers } from 'src/app/helpers/Helpers';


@Injectable({
  providedIn: 'root'
})
export class TokenService extends BaseService {
  private pathAPI = this.config.setting['PathAPI'];

  public errorMessage: string;

  constructor(private http: HttpClient, private config: AppConfig, helper: Helpers) { super(helper); }

  auth(data: any): any {

    const body = JSON.stringify(data);

    return this.getToken(body);

}

private getToken (body: any): Observable<any> {

  return this.http.post<any>(this.pathAPI + 'token', body, super.header()).pipe(

      catchError(super.handleError)

    );

}
}
