import { Injectable } from '@angular/core';
import { Student } from '../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  private students: Student[] = [
    {
      id: 1,
      name: 'Aarav Sharma',
      className: 'Class 7',
      gender: 'Male',
      hasHobby: true,
      hobby: 'Drawing',
      favoriteSubject: 'Mathematics'
    },
    {
      id: 2,
      name: 'Maya Singh',
      className: 'Class 9',
      gender: 'Female',
      hasHobby: false,
      hobby: null,
      favoriteSubject: 'Science'
    }
  ];

  getStudents(): Student[] {
    return this.students;
  }

  addStudent(student: Student) {
    student.id = this.students.length + 1;
    this.students.push(student);
  }
}
