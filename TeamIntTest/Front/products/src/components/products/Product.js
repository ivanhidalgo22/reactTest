/**
* Product.js
*
* @description: Creates a new product list.
* @author Ivan Alejandro Hidalgo.
* @version 1.0
* @date 10-03-2019.
*
**/

import React from 'react';
import ProductApi from '../../api/productApi.js';
import ProductList from './ProductList';

const productFilters = [
  { id: 1, text: "all" },
  { id: 2, text: "service" },
  { id: 3, text: "tech" },
  { id: 4, text: "office" }
];

class Product extends React.Component {

  isMount = false;

  /**
   * Product component constructor.
   * @param {Component properties} props 
   * @param {Component context} context 
   */
  constructor(props, context) {
    super(props, context);

    this.state = {
      isLoading: true,
      productTypeSelected: "all",
      products: [],
      productsFiltered: [],
      error: null
    };
  };

  /**
   * Gets all products through Product Api.
   */
  getProducts() {
    ProductApi.getAllProductsAsync().then(response => response.json())
    .then(data => {
      this.setState({
        products: data.products,
        productsFiltered: data.products,
        isLoading: false,
      });
    },
    )
    .catch(error => this.setState({ error, isLoading: false }));;
  }

  /**
   * Initializes product state by getting products from Product's API.
   */
  componentDidMount() {
    if (!this.isMount) {
      this.getProducts();
    }
    this.isMount = true;
  }

  /**
   * Cleans product array.
   */
  componentWillUnmount() {
    this.setState({products: []});
    this.isMount = false;
  }

  /**
   * Updates Product array.
   * @param {Properties that were updated.} nextProps 
   * @param {States that were updated.} nextState 
   */
  shouldComponentUpdate(nextProps, nextState) {
    if(this.state.productTypeSelected !== nextState.productTypeSelected) {
      this.filterItems(nextState.productTypeSelected);
    }
    return true;
  }

  /**
   * Filters product list by a product type.
   * @param {Product type filter selected} type 
   */
  filterItems(type) {
    switch (type) {
      case 'all':
        this.setState({
          productsFiltered: this.state.products,
        });
        break;
      default:
        const arrayfiltred = this.state.products.filter( product => product.categories.find(category => category.categoryType === type)); 
        this.setState({
          productsFiltered: arrayfiltred,
        });
        break;
    }
  }

  /**
   * Changes product type that was selected by the user.
   */
  changeOption = (e) => {
    this.setState({productTypeSelected: e.target.value});
  }
  
  /**
   * Creates a new product list by calling its nested component.
   */
  render() {
    const isDefaultState = this.state.productTypeSelected !== 'all';
    return (
      <div>
        <div className="container">
              <h4>Filter by Product Type</h4>
              <select className="custom-select col-sm-2" value={this.state.productTypeSelected} onChange={this.changeOption.bind(this)}>
                {productFilters.map(function(data) {
                  return ( <option key={data.id} value={data.text}>{data.text}</option> )
                })}
              </select>
        </div>
        <ProductList products = {
          this.state.productsFiltered} 
          productsToShow = {this.state.productsFiltered.length} 
          productsToHide = {this.state.products.length - this.state.productsFiltered.length}
          isDefaultState = {isDefaultState}>
        </ProductList>
      </div>
    );
  }
}

export default Product;
