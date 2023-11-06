import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { PlanetStatusEnum } from 'src/core/models/enums/PlanetStatus';
import { PlanetDetailsDto } from 'src/core/models/planet/PlanetDetailsDto';
import { PlanetService } from 'src/core/services/planet.service';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { AddUpdatePlanetComponent } from 'src/app/add-update-planet/add-update-planet.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-planet-card',
  templateUrl: './planet-card.component.html',
  styleUrls: ['./planet-card.component.scss'],
  standalone: true,
  imports: [MatCardModule, CommonModule, MatIconModule, MatButtonModule],
})
export class PlanetCardComponent {
  constructor(private planetService: PlanetService, private dialog: MatDialog) {}
  @Input()
  planet!: PlanetDetailsDto;
  enum = PlanetStatusEnum;
  getRobots(): string | undefined{
    return this.planet?.robots.map(o => o.name).join(', ');
  }

  getCaptains(): string | undefined{
    return this.planet?.captains.map(o => o.name).join(', ');
  }

  openModalUpdatePlanet(planet: PlanetDetailsDto) {
    const dialogRef = this.dialog.open(AddUpdatePlanetComponent, {
      data: planet,
    });
    dialogRef.afterClosed().subscribe((submitted: any) => {
      if (submitted) {
        console.log("submitted")
      }
    })
  }
}

