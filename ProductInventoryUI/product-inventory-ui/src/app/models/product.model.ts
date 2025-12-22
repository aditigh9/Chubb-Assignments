export interface Product {
  id: number;
  name: string;
  description: string;
  category: string;
  price: number;
  quantity: number;
  isActive: boolean;
  createdDate: string;
}

export interface ProductCreate {
  name: string;
  description: string;
  category: string;
  price: number;
  quantity: number;
  isActive: boolean;
}

export interface ProductUpdate extends ProductCreate {}
