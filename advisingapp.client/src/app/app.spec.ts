import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { App } from './app';

describe('App', () => {
  let component: App;
  let fixture: ComponentFixture<App>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [App],
      imports: [HttpClientTestingModule],
    }).compileComponents();

    fixture = TestBed.createComponent(App);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create the app', () => {
    expect(component).toBeTruthy();
  });

  it('should retrieve remaining courses from the server', () => {
    const mockCourses = [
      {
        courseTopic: 'CS',
        courseCode: '1010',
        title: 'Intro to Computer Science',
        units: '3',
        grade: null,
      },
    ];

    component.ngOnInit();

    const req = httpMock.expectOne('/api/remaining-courses');
    expect(req.request.method).toBe('GET');
    req.flush(mockCourses);

    expect(component.remainingCourses).toEqual(mockCourses);
    expect(component.isLoading).toBe(false);
  });

  it('should show an error when remaining courses cannot be loaded', () => {
    component.ngOnInit();

    const req = httpMock.expectOne('/api/remaining-courses');
    req.flush('Server error', {
      status: 500,
      statusText: 'Internal Server Error',
    });

    expect(component.errorMessage).toBe('Unable to load remaining courses.');
    expect(component.isLoading).toBe(false);
  });
});