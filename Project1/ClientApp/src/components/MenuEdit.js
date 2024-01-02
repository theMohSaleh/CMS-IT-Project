import React from 'react';
import "./MenuEdit.css";


export const MenuEdit = ({ closeEdit, itemID }) => {
    //const [item, setItem] = React.useState(null);
    const [formData, setFormData] = React.useState({
        itemID: "",
        itemName: "",
        itemDescription: "",
        price: "",
    })

    React.useEffect(() => {
        fetch(`/api/items/${itemID}`)
            .then(response => { return response.json() })
            .then(data => setFormData(data))
            .catch(error => console.error('Error fetching items:', error))
    }, []);

    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value
        })

        console.log("Form: ", formData) 
    }

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {

            const editData = {
                itemID: itemID,
                itemName: formData.itemName,
                itemDescription: formData.itemDescription,
                price: formData.price,
            }

            console.log("editData:", editData)

            const response = await fetch(`/api/items/updateItem`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(editData),
            });

            if (response.ok) {
                console.log(`Item ${itemID} edited successfully`);
                
                closeEdit(); 
            } else {
                const errorMessage = await response.text();
                console.error(`Error editing item: ${errorMessage}`);
            }
        } catch (error) {
            console.error('Error:', error.message);
        }
    }

    return (
        <div className="edit-container" onClick={(e) => {
            if (e.target.className === "edit-container") {
                closeEdit();
            }
        }} >
            <div className="editModal">
                <form onSubmit={handleSubmit}>
                    <div className="modal-content">
                        <label htmlFor="itemName">Name</label>
                        <input name="itemName" value={formData.itemName} onChange={handleChange} />
                    </div>
                    <div className="modal-content">
                        <label htmlFor="itemDescription">Description</label>
                        <textarea name="itemDescription" value={formData.itemDescription} onChange={handleChange} />
                    </div>
                    <div className="modal-content">
                        <label htmlFor="price">Price</label>
                        <input name="price" value={formData.price} onChange={handleChange} />
                    </div>
                    <div className="modal-footer mt-3 mb-0">
                        <button className="btn btn-primary" type="submit">Submit</button>
                    </div>
                </form>
            </div>
        </div>
    )
}
