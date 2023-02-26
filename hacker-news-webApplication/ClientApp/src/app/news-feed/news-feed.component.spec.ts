import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { } from 'jasmine';
import { HttpClient } from '@angular/common/http';
import { NewsFeedComponent } from './news-feed.component';
import { FormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { MatCardModule } from "@angular/material/card";
import { HttpClientTestingModule } from '@angular/common/http/testing';

const BASE_URL = "";

describe('NewsFeedComponent', () => {
  let component: NewsFeedComponent;
  let fixture: ComponentFixture<NewsFeedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule, FormsModule, NgxPaginationModule, Ng2SearchPipeModule, MatCardModule, HttpClientTestingModule],
      declarations: [NewsFeedComponent],
      providers: [HttpClient, { provide: 'BASE_URL', useValue: BASE_URL }],
    }).compileComponents();
  }));
  beforeEach(() => {
    fixture = TestBed.createComponent(NewsFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });
  it('should create news-feed component', () => {
    expect(component).toBeTruthy();
  });
  it('should render title in a h1 tag', async(() => {
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h1').textContent).toContain('Hacker News Top Stories');
  }));
  afterEach(() => {
    document.body.removeChild(fixture.nativeElement);
  });
});
