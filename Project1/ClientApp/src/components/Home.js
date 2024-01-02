import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
        <div>
            <h1>Welcome to our restaurant's – your entryway to a delightful meal.!</h1>
            <p>Make sure to sign in to be able to view and place your order.</p>
            <p>You can create an account for free if you do not already have one!</p>
        </div>
    );
  }
}
