import { TestBed } from '@angular/core/testing';

import { Livros } from './livrosService';

describe('Livros', () => {
  let service: Livros;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Livros);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
