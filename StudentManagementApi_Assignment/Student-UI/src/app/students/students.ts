import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { StudentService } from '../services/student.service';

@Component({
  selector: 'app-students',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './students.html'
})
export class StudentsComponent implements OnInit {

  students: any[] = [];

  student = {
    name: '',
    className: '',
    section: ''
  };

  constructor(private studentService: StudentService) {}

  ngOnInit() {
    this.loadStudents();   // ✅ fetch from DB on page load
  }

  loadStudents() {
    this.studentService.getStudents().subscribe(data => {
      this.students = data;
    });
  }

  addStudent() {
    this.studentService.addStudent(this.student).subscribe(() => {
      this.student = { name: '', className: '', section: '' };
      this.loadStudents();   // refresh table
    });
  }

  deleteStudent(id: number) {
    this.studentService.deleteStudent(id).subscribe(() => {
      this.loadStudents();
    });
  }
}







