import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';

import { catchError, map, tap } from 'rxjs/operators';

import { BaseService } from './base.service';

import { User } from '../models/user';

import { AppConfig } from '../config/config';
import { Helpers } from '../helpers/Helpers';


@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService {

  private pathAPI = this.config.setting['PathAPI'];

  constructor(private http: HttpClient, private config: AppConfig, helper: Helpers) { super(helper); }

  getUsers (): any {

    return this.http.get(this.pathAPI + 'user', super.header());
}
}
