import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventDetialComponent } from './event.detial.component';

describe('EventDetialComponent', () => {
  let component: EventDetialComponent;
  let fixture: ComponentFixture<EventDetialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EventDetialComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EventDetialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
