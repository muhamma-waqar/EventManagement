import { TestBed } from '@angular/core/testing';

import { LocalStoratesService } from './local-storates.service';

describe('LocalStoratesService', () => {
  let service: LocalStoratesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LocalStoratesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
