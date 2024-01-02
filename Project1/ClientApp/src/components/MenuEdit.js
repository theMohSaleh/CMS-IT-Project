import React from 'react';
import "./MenuEdit.css";


export const MenuEdit = ({ closeEdit }) => {
    return (
        <div className="edit-container" onClick={(e) => {
            if (e.target.className === "edit-container") {
                closeEdit();
            }
        }} >
            <div className="editModal">
                <form>
                    <div className="modal-content">
                        <label htmlFor="name">Name</label>
                        <input name="name" />
                    </div>
                    <div className="modal-content">
                        <label htmlFor="description">Description</label>
                        <textarea name="description" />
                    </div>
                    <div className="modal-content">
                        <label htmlFor="price">Price</label>
                        <input name="price" />
                    </div>
                    <div className="modal-footer mt-3 mb-0">
                        <button className="btn btn-primary" type="submit">Submit</button>
                    </div>
                </form>
            </div>
        </div>
    )
}
