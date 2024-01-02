import React from 'react';
import Alert from './Alert';
import { Link } from 'react-router-dom';
import { useNavigate } from "react-router-dom"

export default function Login() {

    const navigate = useNavigate();

    let isLoggedIn = window.sessionStorage.getItem("isLoggedIn")

    React.useEffect(() => {
        if (isLoggedIn === null) {

        } else {
            navigate("/")
        }
    }, []);

    const [formData, setFormData] = React.useState({
        email: "",
        password: ""
    })

    function handleChange(event) {
        const { name, value } = event.target
        setFormData(x => ({
            ...x,
            [name]: value
        }))
    }

    const [showAlert, setShowAlert] = React.useState(false);

    const handleLogin = async (event) => {
        event.preventDefault();

        const userLogin = {
            email: formData.email,
            password: formData.password,
        };

        console.log('userLogin:', userLogin);

        try {
            const response = await fetch('/api/users/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(userLogin),
            });

            if (response.ok) {
                // Login successful
                const pass = await response.json();

                console.log("Pass: ",pass)

                if (pass !== false) {
                    fetch(`/api/users/${pass}`)
                        .then(response => { return response.json() })
                        .then(data => {
                            console.log(data);
                            window.sessionStorage.setItem('isLoggedIn', true);
                            window.sessionStorage.setItem('userID', data.userId);
                            window.sessionStorage.setItem('roleID', data.role);
                            navigate(0);
                        })
                        .catch(error => console.error('Error fetching user:', error))
                } else {
                    setShowAlert(true);
                }
            } else {
                // Handle authentication failure
                console.error('Authentication failed:', response.status, response.statusText);
            }
        } catch (error) {
            console.error('Error during API call:', error);
        }
    };

    return (
        <form onSubmit={handleLogin}>

            <div className="form-outline mt-5 mb-5">
                <input type="email" name="email" value={formData.email} onChange={handleChange} id="form2Example1" className="form-control" />
                <label className="form-label" htmlFor="form2Example1">Email address</label>
            </div>


            <div className="form-outline mb-4">
                <input type="password" name="password" value={formData.password} onChange={handleChange} id="form2Example2" className="form-control" />
                <label className="form-label" htmlFor="form2Example2">Password</label>
            </div>

            {showAlert ? < Alert message="Incorrect email or password." type="danger" /> : ""}

            <button className="btn btn-primary btn-block mb-4">Sign in</button>

            <div className="text-center">
                <p>Not a member? <Link to="/register">Register</Link></p>
            </div>
            
        </form>
    );
}
