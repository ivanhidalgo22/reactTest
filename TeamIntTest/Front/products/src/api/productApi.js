/**
 * @description: This file is mocking a web API by hitting hard coded data.
 * @author Ivan Alejandro Hidalgo.
 * @version 1.0
 * @date 10-03-2019.
 */

var products = require('./productData').products;

/**
 * Returns cloned copy so that the item is passed by value instead of by reference.
 * @param {Product} item 
 */
var _clone = function(item) {
	return JSON.parse(JSON.stringify(item));
};

var ProductApi = {

	/**
	 * Gets Products collection from Product's API.
	 */
	getAllProducts: function() {
		return _clone(products); 
	},

	/**
	 *  We get the API response and receive data in JSON format.
	 */
	getAllProductsAsync: function() {		
		return fetch(`http://localhost:51843/api/v1/products`);
	  }
};

module.exports = ProductApi;