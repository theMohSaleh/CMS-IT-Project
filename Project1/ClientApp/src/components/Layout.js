import React, { Component } from 'react';
import { Container } from 'reactstrap';
import NavBar from './NavBar';
import Footer from './Footer';
export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <div>
            <NavBar />
        <Container>
          {this.props.children}
            </Container>
            <Footer />
      </div>
    );
  }
}
