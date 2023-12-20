import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyHomePageComponent } from './my-home-page.component';

describe('HomePageComponent', () => {
  let component: MyHomePageComponent;
  let fixture: ComponentFixture<MyHomePageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MyHomePageComponent]
    });
    fixture = TestBed.createComponent(MyHomePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
