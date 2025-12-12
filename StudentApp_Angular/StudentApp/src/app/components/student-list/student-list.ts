import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgFor } from '@angular/common';

import { Student } from '../../models/student.model';
import { StudentService } from '../../services/student.service';

@Component({
  selector: 'app-student-list',
  standalone: true,
  templateUrl: './student-list.html',
  styleUrls: ['./student-list.css'],
  imports: [CommonModule, NgFor] // <-- THIS FIXES YOUR ERROR
})
export class StudentListComponent implements OnInit {

  students: Student[] = [];

  constructor(private studentService: StudentService) {}

  ngOnInit() {
    console.log("StudentListComponent loaded");
    this.students = this.studentService.getStudents();
    console.log(this.students);
  }
}





