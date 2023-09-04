import { Button } from '@mui/material';
import axios from 'axios';
import { useEffect, useState } from 'react';
import { Product } from '../../app/models/product';
import ProductList from './ProductList';

export default function Catalog() {
  const [products, setProducts] = useState<Product[]>([]);

  function addProduct() {
    console.log('adding product');
  }

  useEffect(() => {
    axios.get('http://localhost:5000/api/products').then(response => setProducts(response.data));
  }, []);

  return (
    <>
      <ProductList products={products} />
      <Button variant='contained' onClick={addProduct}>
        Add product
      </Button>
    </>
  );
}
