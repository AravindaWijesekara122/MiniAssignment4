import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentShowsComponent } from './current-shows.component';

describe('CurrentShowsComponent', () => {
  let component: CurrentShowsComponent;
  let fixture: ComponentFixture<CurrentShowsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CurrentShowsComponent]
    });
    fixture = TestBed.createComponent(CurrentShowsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
