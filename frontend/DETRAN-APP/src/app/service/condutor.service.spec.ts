/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CondutorService } from './condutor.service';

describe('Service: Condutor', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CondutorService]
    });
  });

  it('should ...', inject([CondutorService], (service: CondutorService) => {
    expect(service).toBeTruthy();
  }));
});
