import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchFlighsComponent } from './search-flighs.component';

describe('SearchFlighsComponent', () => {
  let component: SearchFlighsComponent;
  let fixture: ComponentFixture<SearchFlighsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchFlighsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SearchFlighsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
