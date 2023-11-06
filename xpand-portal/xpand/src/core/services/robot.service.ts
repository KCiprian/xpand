import { Injectable } from '@angular/core';
import { REST_API } from '../globals/Constants';
import { HttpService } from '../helpers/http.service';
import { Observable } from 'rxjs';
import { RobotModel } from '../models/robot/RobotModel';
import { AddRobotModel } from '../models/robot/AddRobotModel';
import { UpdateRobotModel } from '../models/robot/UpdateRobotModel';

const URL = REST_API + 'robot';

@Injectable({
  providedIn: 'root'
})

export class RobotService {

  constructor(private httpService: HttpService) { }

  getRobots(): Observable<RobotModel[]> {
    return this.httpService.get(URL);
  }

  getRobot(Id: number): Observable<RobotModel> {
    return this.httpService.get(URL + '/' + Id);
  }

  add(robotModel: AddRobotModel): Observable<any> {
    return this.httpService.post(URL, robotModel);
  }

  update(Id: number, robotModel: UpdateRobotModel): Observable<any> {
    return this.httpService.patch(URL + '/' + Id, robotModel);
  }

  delete(Id: number): Observable<any> {
    return this.httpService.delete(URL + '/' + Id);
  }
}
