import { Component, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { PlanetService } from 'src/core/services/planet.service';
import { PlanetDetailsDto } from 'src/core/models/planet/PlanetDetailsDto';
import { UpdatePlanetModel } from 'src/core/models/planet/UpdatePlanetModel';

interface AddUpdatePlanetForm {
  name: FormControl<string>;
  description: FormControl<string>;
  status: FormControl<number>;
}

@Component({
  selector: 'app-add-update-planet',
  templateUrl: './add-update-planet.component.html',
  styleUrls: ['./add-update-planet.component.scss']
})
export class AddUpdatePlanetComponent {
  title!: string;
  action!: string;
  loading = false;
  planets: PlanetDetailsDto[] = [];

  formGroup = new FormGroup<AddUpdatePlanetForm>({
    name: new FormControl<string>('', {
      validators: [Validators.minLength(1)],
      nonNullable: true,
    }),
    description: new FormControl<string>('', {
      nonNullable: true,
    }),
    status: new FormControl<number>(0, {
      validators: [Validators.pattern("^[0-9]*$")],
      nonNullable: true,
    }),
  });

  file!: File;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: PlanetDetailsDto,
    private planetService: PlanetService,
    private dialogRef: MatDialogRef<AddUpdatePlanetComponent>,
    ) {}

  ngOnInit() {
    this.title = 'Edit Planet';
    this.action = 'Edit';

    this.planetService.getPlanets().subscribe((planets) => {
      this.planets = planets
    });
  }

  onFilechange(event: any) {
    this.file = event.target.files[0]
  }

  onSubmit() {
    console.log("onSubmit");
    if (this.formGroup.invalid) {
      return;
    }
    this.loading = true;

    const updatePlanetModel: UpdatePlanetModel = {
      name: this.formGroup.controls.name.value,
      description: this.formGroup.controls.description.value,
      status: this.formGroup.controls.status.value,
      image: this.file,
    };
    console.table(updatePlanetModel);
    
    this.planetService.update(this.data.planetId, updatePlanetModel)
    .subscribe({
      next: () => {
        //alert success
        this.loading = false;
        console.log("close dialogref");
        this.dialogRef.close(true);
      },
      error: (error) => {
        //alert error
      },
    });
  }
}
