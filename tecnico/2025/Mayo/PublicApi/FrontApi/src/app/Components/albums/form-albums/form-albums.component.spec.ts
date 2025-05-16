import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormAlbumsComponent } from './form-albums.component';

describe('FormAlbumsComponent', () => {
  let component: FormAlbumsComponent;
  let fixture: ComponentFixture<FormAlbumsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormAlbumsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormAlbumsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
