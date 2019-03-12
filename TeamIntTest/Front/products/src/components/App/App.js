/**
* App.js
*
* @description: The App component defines the application layout. 
* @author Ivan Alejandro Hidalgo.
* @version 1.0
* @date 10-03-2019.
*
**/

import  React, { Component } from 'react';
import './App.css';
import Header from '../common/header';
import Main from '../common/Main';

class App extends Component {
  render() {
    return (
      <div className="App">
        <Header />
        <Main />
      </div>
    );
  }
}

export default App;
