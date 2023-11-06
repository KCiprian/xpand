import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { REST_API } from '../globals/Constants';
import { HttpService } from '../helpers/http.service';
import { HumanModel } from '../models/human/HumanModel';
import { AddHumanModel } from '../models/human/AddHumanModel';
import { UpdateHumanModel } from '../models/human/UpdateHumanModel';

const URL = REST_API + 'human';

@Injectable({
  providedIn: 'root'
})

export class HumanService {

  constructor(private httpService: HttpService) { }

  getHumans(): Observable<HumanModel[]> {
    return this.httpService.get(URL);
  }

  getHuman(Id: number): Observable<HumanModel> {
    return this.httpService.get(URL + '/' + Id);
  }

  add(humanModel: AddHumanModel): Observable<any> {
    return this.httpService.post(URL, humanModel);
  }

  update(Id: number, humanModel: UpdateHumanModel): Observable<any> {
    return this.httpService.patch(URL + '/' + Id, humanModel);
  }

  delete(Id: number): Observable<any> {
    return this.httpService.delete(URL + '/' + Id);
  }
}
