import React from 'react';
import "./Added.css";


export const Added = ({ closeEdit }) => {

    const handleSubmit = async (e) => {
        e.preventDefault();
        closeEdit(`Item added successfully`);
    }

    return (
        <div className="add-container" onClick={(e) => {
            if (e.target.className === "add-container") {
                closeEdit();
            }
        }} >
            <div className="addModal">
                <form onSubmit={handleSubmit}>
                    <div className="modal-content">
                        <h2>Item added to cart!</h2>
                    </div>
                    <div className="modal-footer mt-3 mb-0">
                        <button className="btn btn-primary" type="submit">OK</button>
                    </div>
                </form>
            </div>
        </div>
    )
}
