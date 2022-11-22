import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeGenreComponent } from './employee-genre.component';

describe('EmployeeGenreComponent', () => {
  let component: EmployeeGenreComponent;
  let fixture: ComponentFixture<EmployeeGenreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeGenreComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeeGenreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
