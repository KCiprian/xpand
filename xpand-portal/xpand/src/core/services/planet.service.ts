import { Injectable } from '@angular/core';
import { REST_API } from '../globals/Constants';
import { HttpService } from '../helpers/http.service';
import { Observable } from 'rxjs';
import { PlanetModel } from '../models/planet/PlanetModel';
import { PlanetDetailsDto } from '../models/planet/PlanetDetailsDto';
import { AddPlanetModel } from '../models/planet/AddPlanetModel';
import { UpdatePlanetModel } from '../models/planet/UpdatePlanetModel';
import { ReturnStatement } from '@angular/compiler';

const URL = REST_API + 'Planet';

@Injectable({
  providedIn: 'root',
})

export class PlanetService {

  constructor(private httpService: HttpService) { }

  getPlanets(): Observable<PlanetDetailsDto[]> {
    return this.httpService.get(URL);
  }

  getPlanet(Id: number): Observable<PlanetModel> {
    return this.httpService.get(URL + '/' + Id);
  }

  add(planetModel: AddPlanetModel): Observable<any> {
    return this.httpService.post(URL, planetModel);
  }

  update(Id: number, planetModel: UpdatePlanetModel): Observable<any> {
    console.log("update called with id: " + Id + " model: " + planetModel.description + " " + planetModel.name + " " + planetModel.status);
    return this.httpService.patch(URL + '/' + Id, planetModel);
  }

  delete(Id: number): Observable<any> {
    return this.httpService.delete(URL + '/' + Id);
  }
}
