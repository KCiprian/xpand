import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddUpdatePlanetComponent } from './add-update-planet.component';

describe('AddUpdatePlanetComponent', () => {
  let component: AddUpdatePlanetComponent;
  let fixture: ComponentFixture<AddUpdatePlanetComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddUpdatePlanetComponent]
    });
    fixture = TestBed.createComponent(AddUpdatePlanetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
