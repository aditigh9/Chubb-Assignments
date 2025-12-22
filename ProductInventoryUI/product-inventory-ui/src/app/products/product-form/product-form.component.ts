import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { ProductService } from '../../services/product.service';

@Component({
  standalone: true,
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css'],
  imports: [
    CommonModule,
    FormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCheckboxModule
  ]
})
export class ProductFormComponent {
  product: any;
  isEdit = false;

  constructor(
    private productService: ProductService,
    private dialogRef: MatDialogRef<ProductFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    if (data?.mode === 'edit') {
  this.isEdit = true;

  this.product = {
    ...data.product,
    isActive: data.product.isActive === true || data.product.status === 'Active'
  };
}
 else {
      this.product = {
        name: '',
        category: '',
        description: '',
        price: null,
        quantity: null,
        isActive: true,
        createdDate: new Date()
      };
    }
  }

  save() {
    if (this.isEdit) {
      this.productService
        .updateProduct(this.product.id, this.product)
        .subscribe(() => this.dialogRef.close(true));
    } else {
      this.productService
        .addProduct(this.product)
        .subscribe(() => this.dialogRef.close(true));
    }
  }

  cancel() {
    this.dialogRef.close();
  }
}
