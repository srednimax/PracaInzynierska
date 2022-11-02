import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserProfileBorrowedBooksComponent } from './user-profile-borrowed-books.component';

describe('UserProfileBorrowedBooksComponent', () => {
  let component: UserProfileBorrowedBooksComponent;
  let fixture: ComponentFixture<UserProfileBorrowedBooksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserProfileBorrowedBooksComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserProfileBorrowedBooksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
