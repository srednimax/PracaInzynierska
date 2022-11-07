import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeBorrowedBooksComponent } from './employee-borrowed-books.component';

describe('EmployeeBorrowedBooksComponent', () => {
  let component: EmployeeBorrowedBooksComponent;
  let fixture: ComponentFixture<EmployeeBorrowedBooksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeBorrowedBooksComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeeBorrowedBooksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
