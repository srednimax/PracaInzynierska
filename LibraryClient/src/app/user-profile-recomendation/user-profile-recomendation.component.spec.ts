import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserProfileRecomendationComponent } from './user-profile-recomendation.component';

describe('UserProfileRecomendationComponent', () => {
  let component: UserProfileRecomendationComponent;
  let fixture: ComponentFixture<UserProfileRecomendationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserProfileRecomendationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserProfileRecomendationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
