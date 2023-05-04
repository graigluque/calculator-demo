import { TestBed } from '@angular/core/testing';

import { ServicebusService } from './servicebus.service';

describe('ServicebusService', () => {
  let service: ServicebusService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServicebusService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
