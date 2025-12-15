import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class StudentService {
  private apiUrl = 'http://localhost:5092/api/students';

  constructor(private http: HttpClient) {}

  private getHeaders() {
    const token = localStorage.getItem('token');
    return {
      headers: new HttpHeaders({
        Authorization: `Bearer ${token}`,
        'Content-Type': 'application/json'
      })
    };
  }

  getStudents() {
    return this.http.get<any[]>(this.apiUrl, this.getHeaders());
  }

  addStudent(student: any) {
    return this.http.post(this.apiUrl, student, this.getHeaders());
  }

  deleteStudent(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`, this.getHeaders());
  }
}
