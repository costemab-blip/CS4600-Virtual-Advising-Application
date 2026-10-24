import { HttpClient } from '@angular/common/http';
import { Component, OnInit, signal } from '@angular/core';

interface UNICourseItem {
  courseTopic: string;
  courseCode: string;
  title: string;
  units: string;
  grade: string;
}

@Component({
  selector: 'app-root',
  standalone: false,
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App implements OnInit {
  public remainingCourses: UNICourseItem[] = [];
  public isLoading = true;
  public errorMessage = 'error';
  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getRemainingCourses();
  }

  getRemainingCourses(): void {
    this.http
      .get<UNICourseItem[]>('/api/courses/remaining')
      .subscribe({
        next: (courses) => {
          this.remainingCourses = courses;
          this.isLoading = false;
        },
        error: (error) => {
          console.error("Unable to load remaining courses:", error);
          this.errorMessage = "Unable to load remaining courses.";
          this.isLoading = false;    
        },         
      });
  }
  protected readonly title = signal('advisingapp.client');
}
