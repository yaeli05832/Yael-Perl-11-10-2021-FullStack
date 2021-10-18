import logo from './logo.svg';
import './App.css';
import './list';
import axios from 'axios';
import React, { Component } from "react";
import ReactDOM from "react-dom";
import {  } from "module";


class  Welcome extends React.Component {
 
  render() {
    return <div>
    <label htmlFor="input">Enter city name:</label>
    <input
      type="text"
      id="input"
      onChange={(e) => send(e.target.value)}
    />
  </div>
  }

   
}

async function send(params: string) {
  let array: Array<string> = new Array<string>();
  let inputValue=(document.getElementById("input") as HTMLInputElement).value;
  //the call to server
  await fetch("https://localhost:44331/api/Cities/GetCity/"+inputValue)
      .then(res => res.json())
      .then(data => {
          data.map((item: any) =>
              array.push(item))
      }).catch();
      alert(array);
  return array;
}

//call the Welcome Component by default
export default Welcome;

