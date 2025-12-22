import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { HttpErrorResponse } from '@angular/common/http';

import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product.model';
import { ProductFormComponent } from '../product-form/product-form.component';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule
  ],
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements AfterViewInit {

  displayedColumns: string[] = [
    'id',
    'name',
    'category',
    'description',
    'price',
    'quantity',
    'status',
    'createdDate',
    'actions'
  ];

  dataSource = new MatTableDataSource<Product>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private productService: ProductService,
    private dialog: MatDialog
  ) {}

  ngAfterViewInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
    this.productService.getProducts().subscribe({
      next: (data: Product[]) => {
        this.dataSource.data = data;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error: (err: HttpErrorResponse) => {
        console.error('Failed to load products', err);
      }
    });
  }

  applyFilter(value: string): void {
    this.dataSource.filter = value.trim().toLowerCase();
    this.dataSource.paginator?.firstPage();
  }

 addProduct() {
  const dialogRef = this.dialog.open(ProductFormComponent, {
    width: '600px',
    data: { mode: 'add' }
  });

  dialogRef.afterClosed().subscribe(result => {
    if (result) {
      this.loadProducts();
    }
  });
}


 editProduct(product: any) {
  const dialogRef = this.dialog.open(ProductFormComponent, {
    width: '600px',
    data: {
      mode: 'edit',
      product
    }
  });

  dialogRef.afterClosed().subscribe(result => {
    if (result) {
      this.loadProducts();
    }
  });
}




  deleteProduct(id: number): void {
    if (confirm('Are you sure you want to delete this product?')) {
      this.productService.deleteProduct(id).subscribe({
        next: () => this.loadProducts(),
        error: (err: HttpErrorResponse) => console.error(err)
      });
    }
  }
}
