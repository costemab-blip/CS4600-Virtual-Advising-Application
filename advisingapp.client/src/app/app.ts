import { HttpClient } from '@angular/common/http';
import { Component, OnInit, signal } from '@angular/core';

interface CourseItem {
  courseTopic: string | null;
  courseCode: string | null;
  title: string | null;
  units: string | null;
  grade: string | null;
}

@Component({
  selector: 'app-root',
  standalone: false,
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App implements OnInit {
  public remainingCourses: CourseItem[] = [];
  public isLoading = signal(true);
  public errorMessage = signal('');

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get<CourseItem[]>('/api/remaining-courses').subscribe({
      next: (courses) => {
        this.remainingCourses = courses;
        this.isLoading.set(false);
      },
      error: (error: unknown) => {
        console.error('Failed to load remaining courses:', error);
        this.errorMessage.set('Unable to load remaining courses.');
        this.isLoading.set(false);
      },
    });
  }
}