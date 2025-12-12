import { Routes } from '@angular/router';
import { StudentListComponent } from './components/student-list/student-list';
import { AddStudentComponent } from './components/add-student/add-student';

export const routes: Routes = [
  { path: '', component: StudentListComponent },
  { path: 'add', component: AddStudentComponent }
];







