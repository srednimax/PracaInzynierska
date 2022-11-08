import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserProfilePenaltyComponent } from './user-profile-penalty.component';

describe('UserProfilePenaltyComponent', () => {
  let component: UserProfilePenaltyComponent;
  let fixture: ComponentFixture<UserProfilePenaltyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserProfilePenaltyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserProfilePenaltyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
