import React, { Component } from 'react';
import ParcelPricingPage from './ParcelPricingPage';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <ParcelPricingPage/>
      </div>
    );
  }
}
