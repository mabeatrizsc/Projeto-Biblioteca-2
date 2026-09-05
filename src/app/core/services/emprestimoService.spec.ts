import { TestBed } from '@angular/core/testing';

import { EmprestimoService } from './emprestimoService';

describe('Emprestimo', () => {
  let service: EmprestimoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EmprestimoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
