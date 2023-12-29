import React, { Component } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
    static displayName = NavMenu.name;

    constructor(props) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true,
            isLoggedIn: window.sessionStorage.getItem('isLoggedIn')
        }
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    renderAuthLinks() {

        function onLogout() {
            window.sessionStorage.setItem('isLoggedIn', false)
            this.setState({ isLoggedIn: false })
        }

        if (this.state.isLoggedIn) {
            return (
                <NavItem>
                    <NavLink tag={Link} className="text-dark" to="/" onClick={onLogout}>Logout</NavLink>
                </NavItem>
            );
        } else {
            return (
                <>
                    <NavItem>
                        <NavLink tag={Link} className="text-dark" to="/login">Login</NavLink>
                    </NavItem>
                    <NavItem>
                        <NavLink tag={Link} className="text-dark" to="/register">Register</NavLink>
                    </NavItem>
                </>
            );
        }
    }

    render() {
        return (
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
                    <NavbarBrand tag={Link} to="/">Canteen Management System</NavbarBrand>
                    <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
                    <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
                        <ul className="navbar-nav flex-grow">
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/items">Menu</NavLink>
                            </NavItem>
                            {this.renderAuthLinks()}
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/cart">Cart (0)</NavLink>
                            </NavItem>
                        </ul>
                    </Collapse>
                </Navbar>
            </header>
        );
    }
}
