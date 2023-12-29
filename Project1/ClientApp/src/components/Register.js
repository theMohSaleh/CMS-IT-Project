import React from 'react';
import Alert from './Alert';
import { Link } from 'react-router-dom';
import { useNavigate } from "react-router-dom"


export default function Register() {

    const navigate = useNavigate();

    const [formData, setFormData] = React.useState({
        name: "",
        email: "",
        password: "",
        passwordConfirm: "",
        office: "",
        number: "",
        role: 2
    })

    const [showAlert, setShowAlert] = React.useState(false);

    function handleChange(event) {
        const { name, value } = event.target
        setFormData(x => ({
            ...x,
            [name]: value
        }))
    }

    const handleRegister = async (event) => {
        event.preventDefault();

        const newUser = {
            Name: formData.name,
            Email: formData.email,
            Password: formData.password,
            Office: formData.office,
            Number: formData.number,
            Role: 2,
        };

        console.log('newUser:', newUser);


        try {
            const response = await fetch('/api/users/reg', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(newUser),
            });

            if (response.ok) {
                // register successful
                const pass = await response.json();
                console.log(pass);
                if (pass == true) {
                } else {
                    setShowAlert(true);
                }
            } else {
                console.error('Authentication failed:', response.status, response.statusText);
            }
        } catch (error) {
            console.error('Error during API call:', error);
        }
    };

    return (
        <div>
            <section className="vh-100 bg-image">
                <div className="mask d-flex align-items-center h-100 gradient-custom-3">
                    <div className="container h-100">
                        <div className="row d-flex justify-content-center align-items-center h-100">
                            <div className="col-12 col-md-9 col-lg-7 col-xl-6">
                                <div className="card" styles="border-radius: 15px;">
                                    <div className="card-body p-5">
                                        <h2 className="text-uppercase text-center mb-5">Create an account</h2>

                                        <form onSubmit={handleRegister}>

                                            <div className="form-outline mb-4">
                                                <input type="text" name="name" value={formData.name} onChange={handleChange} id="form3Example1cg" className="form-control form-control-lg" />
                                                <label className="form-label" htmlFor="form3Example1cg">Your Name</label>
                                            </div>

                                            <div className="form-outline mb-4">
                                                <input type="email" name="email" value={formData.email} onChange={handleChange}  id="form3Example3cg" className="form-control form-control-lg" />
                                                <label className="form-label" htmlFor="form3Example3cg">Your Email</label>
                                            </div>

                                            <div className="form-outline mb-4">
                                                <input type="password" name="password" value={formData.password} onChange={handleChange} id="form3Example4cg" className="form-control form-control-lg" />
                                                <label className="form-label" htmlFor="form3Example4cg">Password</label>
                                            </div>

                                            <div className="form-outline mb-4">
                                                <input type="password" name="passwordConfirm" value={formData.passwordConfirm} onChange={handleChange} id="form3Example4cdg" className="form-control form-control-lg" />
                                                <label className="form-label" htmlFor="form3Example4cdg">Repeat your password</label>
                                            </div>

                                            <div className="form-outline mb-4">
                                                <input type="text" name="office" value={formData.office} onChange={handleChange} id="form3Example5cg" className="form-control form-control-lg" />
                                                <label className="form-label" htmlFor="form3Example5cg">Office Location</label>
                                            </div>

                                            <div className="form-outline mb-4">
                                                <input type="text" name="number" value={formData.number} onChange={handleChange} id="form3Example6cg" className="form-control form-control-lg" />
                                                <label className="form-label" htmlFor="form3Example6cg">Phone Number</label>
                                            </div>

                                            <div className="d-flex justify-content-center">
                                                <button
                                                    className="btn btn-success btn-block btn-lg gradient-custom-4 text-body">Register</button>
                                            </div>
                                            {showAlert ? < Alert message="Incorrect email or password." type="danger" /> : ""}
                                            <p className="text-center text-muted mt-5 mb-0">Have already an account?
                                                <Link className="fw-bold text-body" styles="color:blue;" to="/login">Login here</Link></p>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    );
}
