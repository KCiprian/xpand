import { Component } from '@angular/core';
import { PlanetStatusEnum } from 'src/core/models/enums/PlanetStatus';
import { PlanetDetailsDto } from 'src/core/models/planet/PlanetDetailsDto';
import { PlanetService } from 'src/core/services/planet.service';

@Component({
  selector: 'app-planets',
  templateUrl: './planets.component.html',
  styleUrls: ['./planets.component.scss']
})
export class PlanetsComponent {
  constructor(private planetService: PlanetService) {}
  planets: PlanetDetailsDto[] = [];
  ngOnInit() {
    this.getPlanets();
  }
  getPlanets(): void{
    this.planetService.getPlanets().subscribe(planets => {this.planets = planets;});
  }
}
