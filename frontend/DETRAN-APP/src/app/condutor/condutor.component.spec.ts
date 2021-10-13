/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CondutorComponent } from './condutor.component';

describe('CondutorComponent', () => {
  let component: CondutorComponent;
  let fixture: ComponentFixture<CondutorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CondutorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CondutorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
