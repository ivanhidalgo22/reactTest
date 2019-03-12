/**
* Header.js
*
* @description: The Header component defines the routes that will be shown inside a nav element. 
* @author Ivan Alejandro Hidalgo.
* @version 1.0
* @date 10-03-2019.
*
**/

import React from 'react'
import { Link } from 'react-router-dom'

class Header extends React.Component {
	render()  {
		return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
              <Link to="/" className="navbar-brand">
                <img src={require('../../images/team.png')} alt="30" height="130"/>
              </Link>
              <div className="collapse navbar-collapse">
                <ul className="navbar-nav">
                    <li className="nav-item active">
                        <Link className="nav-link" to="/home">HOME</Link>
                    </li>
                    <li className="nav-item">
                        <Link className="nav-link" to="/products">PRODUCTS</Link>
                    </li>
                    <li className="nav-item">
                        <Link className="nav-link" to="/clients">CLIENTS</Link>
                    </li>
                    <li className="nav-item">
                        <Link className="nav-link" to="/contact">CONTACT</Link>
                    </li>
                </ul>
              </div>
          
        </nav>        
		);
	}
}

export default Header;