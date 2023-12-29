import React from 'react';
import { Link } from 'react-router-dom';

export default function NavBar() {

    let check = window.sessionStorage.getItem('isLoggedIn')
    console.log("Check is set to: ", check)

    const [isLoggedIn, setIsLoggedIn] = React.useState(() => {
        return window.sessionStorage.getItem('isLoggedIn') === 'true';
    });

    React.useEffect(() => {
        console.log('isLoggedIn changed:', isLoggedIn);
        renderAuthLinks()
        adminLinks()
    }, []);

    function renderAuthLinks() {

        if (isLoggedIn == true) {
            console.log('Logout is being called');
            return (
                <>
                    <Link className="btn btn-primary me-3" to="/cart">Cart</Link>
                    <button className="btn btn-link px-3 me-2" onClick={onLogout} to="/login">Logout</button>
                </>
            );
        } else {
            console.log('login is being called');
            return (
                <>
                    <Link className="btn btn-link px-3 me-2" to="/login">Login</Link>
                    <Link className="btn btn-primary me-3" to="/register">Register</Link>
                </>
            );
        }
    }

    function adminLinks() {

        const userRole = window.sessionStorage.getItem('roleID')
        console.log('User Role: ', userRole);
        if (userRole == 2) {
            
            return (
                <>
                    <Link className="btn btn-link px-3 me-2" to="/login">Modify Menu</Link>
                    <Link className="btn btn-link px-3 me-2" to="/login">View Users</Link>
                    <Link className="btn btn-primary me-3" to="/addItem">Add Item</Link>
                    <Link className="btn btn-link px-3 me-2" to="/login">View Sales</Link>
                </>
            );
        } else {
            return (
                <>
                </>
            );
        }
    }

    function onLogout() {
        window.sessionStorage.setItem('isLoggedIn', false)
        setIsLoggedIn(false)
        window.sessionStorage.clear();
    }

    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-body-tertiary">
            <div className="container">
                <img
                    src="https://cdn-icons-png.flaticon.com/512/5223/5223909.png"
                    height="56"
                    alt="MDB Logo"
                    loading="lazy"
                    styles="margin-top: -1px;"
                />
                <button
                    data-mdb-collapse-init
                    className="navbar-toggler"
                    type="button"
                    data-mdb-target="#navbarButtonsExample"
                    aria-controls="navbarButtonsExample"
                    aria-expanded="false"
                    aria-label="Toggle navigation"
                >
                    <i className="fas fa-bars"></i>
                </button>
                <div className="collapse navbar-collapse" id="navbarButtonsExample">
                    <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                        <li className="nav-item">
                            <Link className="nav-link" to="/">Home</Link>
                        </li>
                        <li className="nav-item">
                            <Link className="nav-link" to="/items">Menu</Link>
                        </li>
                        <li className="nav-item">
                            {adminLinks()}
                        </li>
                    </ul>
                    <div className="d-flex align-items-center">
                        {renderAuthLinks()}
                    </div>
                </div>
            </div>
        </nav>
    );
}
