/**
* Main.js
*
* @description: The Main component renders one of the five provided Routes (provided that one matches). 
* @author Ivan Alejandro Hidalgo.
* @version 1.0
* @date 10-03-2019.
*
**/

import React from 'react'
import { Switch, Route } from 'react-router-dom'
import Home from '../home/Home'
import Product from "../products/Product";
import Contact from '../about/Contact';
import Client from '../client/Client';

/**
 * Renders one of the five provided Routes (provided that one matches). 
 */
const Main = () => (
  <main>
        <Switch> 
            <Route path="/" component={Home} exact/>
            <Route path="/home" component={Home} exact/>
            <Route path="/products" component={Product} />
            <Route path="/clients" component={Client} />
            <Route path="/contact" component={Contact} />
        </Switch>
  </main>
)

export default Main
