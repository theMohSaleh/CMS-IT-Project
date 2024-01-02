import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
        <div>
            <img src="https://industryconnect.polytechnic.bh/PolytechnicLogo-Red-Horizontal.png" className="card-img-top" />
            <h1 className="display-3 mb-5 text-center">Welcome to our restaurant, your entryway to a delightful meal!</h1>
            <div className="card">
                <img src="https://www.timeoutbahrain.com/cloud/timeoutbahrain/2021/09/16/1PW1Fmvg-bahrain-2-1200x800.jpg" className="card-img-top border border-dark" />
            </div>
            <div className="display-3 mt-5 mb-5 text-center">
                <h2>Make sure to sign in to be able to view and place your order.</h2>
                <h2>You can create an account for free if you do not already have one!</h2>
            </div>
        </div>
    );
  }
}
