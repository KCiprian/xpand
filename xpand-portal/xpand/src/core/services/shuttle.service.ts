import { Injectable } from '@angular/core';
import { REST_API } from '../globals/Constants';
import { HttpService } from '../helpers/http.service';
import { Observable } from 'rxjs';
import { ShuttleModel } from '../models/shuttle/ShuttleModel';
import { AddShuttleModel } from '../models/shuttle/AddShuttleModel';
import { UpdateShuttleModel } from '../models/shuttle/UpdateShuttleModel';

const URL = REST_API + 'shuttle';

@Injectable({
  providedIn: 'root'
})
export class ShuttleService {

  constructor(private httpService: HttpService) { }

  GetShuttles(): Observable<ShuttleModel[]> {
    return this.httpService.get(URL);
  }

  GetShuttle(Id: number): Observable<ShuttleModel> {
    return this.httpService.get(URL + '/' + Id);
  }

  add(shuttleModel: AddShuttleModel): Observable<any> {
    return this.httpService.post(URL, shuttleModel);
  }

  update(Id: number, shuttleModel: UpdateShuttleModel): Observable<any> {
    return this.httpService.patch(URL + '/' + Id, shuttleModel);
  }

  delete(Id: number): Observable<any> {
    return this.httpService.delete(URL + '/' + Id);
  }
}
