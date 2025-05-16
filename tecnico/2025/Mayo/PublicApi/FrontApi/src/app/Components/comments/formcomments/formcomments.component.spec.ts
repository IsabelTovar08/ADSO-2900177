import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormcommentsComponent } from './formcomments.component';

describe('FormcommentsComponent', () => {
  let component: FormcommentsComponent;
  let fixture: ComponentFixture<FormcommentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormcommentsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormcommentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
