import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { StudentService } from '../../services/student.service';
import { Router } from '@angular/router';
import { Student } from '../../models/student.model';

@Component({
  selector: 'app-add-student',
  standalone: true,
  templateUrl: './add-student.html',
  styleUrls: ['./add-student.css'],
  imports: [CommonModule, ReactiveFormsModule]
})
export class AddStudentComponent implements OnInit {

  studentForm!: FormGroup;

  classes = ['Class 6', 'Class 7', 'Class 8', 'Class 9'];
  subjects = ['Mathematics', 'Science', 'English', 'History', 'Geography'];

  constructor(
    private fb: FormBuilder,
    private studentService: StudentService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.studentForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(5)]],
      className: ['', Validators.required],
      gender: ['', Validators.required],
      hasHobby: [false],
      hobby: [''],
      favoriteSubject: ['']
    });

    this.studentForm.get('hasHobby')!.valueChanges.subscribe(h => {
      if (!h) {
        this.studentForm.get('hobby')!.setValue('');
      }
    });
  }

  get name() { return this.studentForm.get('name'); }
  get className() { return this.studentForm.get('className'); }
  get gender() { return this.studentForm.get('gender'); }
  get hasHobby() { return this.studentForm.get('hasHobby'); }

  save() {
    if (this.studentForm.invalid) {
      this.studentForm.markAllAsTouched();
      return;
    }

    const formValue = this.studentForm.value;

    const newStudent: Student = {
      id: 0,
      name: formValue.name,
      className: formValue.className,
      gender: formValue.gender,
      hasHobby: !!formValue.hasHobby,
      hobby: formValue.hasHobby ? formValue.hobby : null,
      favoriteSubject: formValue.favoriteSubject || null
    };

    this.studentService.addStudent(newStudent);
    this.router.navigate(['/']);
  }
}

