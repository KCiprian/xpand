import { Injectable } from '@angular/core';
import { REST_API } from '../globals/Constants';
import { HttpService } from '../helpers/http.service';
import { Observable } from 'rxjs';
import { TeamModel } from '../models/team/TeamModel';
import { AddTeamModel } from '../models/team/AddTeamModel';
import { UpdateTeamModel } from '../models/team/UpdateTeamModel';

const URL = REST_API + 'team';

@Injectable({
  providedIn: 'root'
})
export class TeamService {

  constructor(private httpService: HttpService) { }

  getTeams(): Observable<TeamModel[]> {
    return this.httpService.get(URL);
  }

  getTeam(Id: Number): Observable<TeamModel> {
    return this.httpService.get(URL + '/' + Id);
  }

  add(teamModel: AddTeamModel): Observable<any> {
    return this.httpService.post(URL, teamModel);
  }

  update(Id: number, teamModel: UpdateTeamModel): Observable<any> {
    return this.httpService.patch(URL + '/' + Id, teamModel);
  }

  delete(Id: number): Observable<any> {
    return this.httpService.delete(URL + '/' + Id);
  }
}
