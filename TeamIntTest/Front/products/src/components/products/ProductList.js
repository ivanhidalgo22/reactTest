/**
* ProductList.js
*
* @description: Creates a new product.
* @author Ivan Alejandro Hidalgo.
* @version 1.0
* @date 10-03-2019.
*
**/

import React from 'react';
import CurrencyFormat from 'react-currency-format';

class ProductList extends React.Component {

  /**
   * Returns new product that will be shown inside Product component.
   */
  render() {

    /**
     * Creates new product.
     * @param {*} product Product that will be shown.
     */
    var createproductRow = function(product) {
      return (
        <div className="container" key={product.id}>
          <div className="col-sm-12">
              {this.props.isDefaultState ? (
                <div><p className="text-sm-left">Showing: {this.props.productsToShow} products - Hidden: {this.props.productsToHide}</p></div>
              ): (
                <div><p className="text-sm-left"> Showing: {this.props.productsToShow} products </p></div>
              )}
              <div className="card text-left">
                  <div className="card-body">
                    <h5 className="card-title text-left">{product.name}</h5>
                    <p className="text-left"><small>{product.categories.map(e => e.categoryType).join(", ")}- {product.brand}</small></p>
                    <table className="table table-borderless">
                      <tbody>
                        <tr>
                          <td><img src={product.photo} alt="30" height="130"/></td>
                          <td>
                            <p className="card-text">{product.description}</p>
                            <p className="font-weight-bold">Stock: {product.stock} </p> 
                            <p className="font-weight-bold">Price: <CurrencyFormat value={product.price} displayType={'text'} thousandSeparator={true} prefix={'$'} /> </p>
                          </td>
                        </tr>
                      </tbody>
                    </table>
                </div>
              </div>
            </div>
        </div>
      );
  }

  /**
   * Returns new product that will be shown inside Product component.
   */
  return (
      <div>
        {this.props.products.map(createproductRow, this)}     
      </div>
    );
  }
}

export default ProductList;
