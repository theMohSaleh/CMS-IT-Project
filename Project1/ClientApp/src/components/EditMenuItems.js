import React from 'react';
import Alert from './Alert';
import { useNavigate } from "react-router-dom"
import { MenuEdit } from "./MenuEdit"

export default function Menu() {
    const [items, setItems] = React.useState([]);
    const [itemImages, setItemImages] = React.useState({});
    const [showAlert, setShowAlert] = React.useState(false);
    const navigate = useNavigate();
    const [openEdit, setOpenEdit] = React.useState(false);
    const [itemToEdit, setItemToEdit] = React.useState(null);

    let isLoggedIn = window.sessionStorage.getItem("isLoggedIn")

    //React.useEffect(() => {
    //    if (isLoggedIn === "true") {

    //    } else {
    //        navigate("/")
    //    }
    //}, []);

    const fetchItems = async () => {
        try {
            const response = await fetch('/api/items');
            const data = await response.json();
            setItems(data);
        } catch (error) {
            console.error('Error fetching items:', error);
        }
    };

    React.useEffect(() => {
        //fetch('/api/items')
        //    .then(response => { return response.json() })
        //    .then(data => setItems(data))
        //    .catch(error => console.error('Error fetching items:', error))

        fetchItems();
    }, []);

    React.useEffect(() => {
        const fetchItemImages = async () => {
            const imagePromises = items.map(async item => {
                const imageId = item.imageId;

                try {
                    const response = await fetch(`/api/images/${imageId}`);

                    if (!response.ok) {
                        throw new Error('Error fetching image');
                    }

                    const blob = await response.blob();
                    const imageUrl = URL.createObjectURL(blob);

                    return {
                        itemId: item.itemId,
                        imageUrl: imageUrl
                    };
                } catch (error) {
                    console.error(`Error fetching image for item ${item.itemId}:`, error);
                    return null;
                }
            });

            const imageResults = await Promise.all(imagePromises);
            const filteredImageResults = imageResults.filter(result => result !== null);

            const imageMap = filteredImageResults.reduce((acc, result) => {
                acc[result.itemId] = result.imageUrl;
                return acc;
            }, {});

            setItemImages(imageMap);
        };

        fetchItemImages();
    }, [items]);

    const handleSubmit = async (event, itemId) => {
        event.preventDefault();

        if (isLoggedIn === "true") {

            const newCart = {
                userId: window.sessionStorage.getItem("userID"),
                ItemId: itemId.toString()
            };

            console.log("cart", newCart)

            try {
                const response = await fetch('/api/orderCart/cart', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(newCart),
                });

                if (response.ok) {
                    // add successful
                    //window.alert('Item added to cart!');
                    setShowAlert(true)
                } else {
                    console.error('Adding cart failed:', response.status, response.statusText);
                }
            } catch (error) {
                console.error('Error during API call:', error);
            }
        } else {
            window.alert('Please login first!');
        }
    }

    const handleEditItem = async (id) => {
        setItemToEdit(id);

        setOpenEdit(true);
    }

    const handleDeleteRow = async (id) => {
        try {
            const response = await fetch(`/api/items/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                    // Include any additional headers if needed
                },
                // You can include a request body if necessary
                // body: JSON.stringify({}),
            });

            if (response.ok) {
                // Successful deletion
                console.log('Item deleted successfully');
                fetchItems();
            } else {
                // Handle error response
                console.error('Error deleting item:', response.statusText);
            }
        } catch (error) {
            // Handle network or other errors
            console.error('Error:', error);
        }
    }

    return (
        <div>
            <table className="table table-striped mt-3 mb-3">
                <thead>
                    <tr>
                        <th scope="col">item ID</th>
                        <th scope="col">Image</th>
                        <th scope="col">Item Name</th>
                        <th scope="col">Item Description</th>
                        <th scope="col">Price</th>
                        <th scope="col">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {items.map(item => (
                        <tr key={item.itemId}>
                            <th scope="row">{item.itemId}</th>
                            <td><img src={itemImages[item.itemId]} width={150} height={100} className="rounded" /></td>
                            <td>{item.itemName}</td>
                            <td>{item.itemDescription}</td>
                            <td>{item.price} BD</td>
                            <td><span>
                                <button type="button" onClick={() => handleEditItem(item.itemId)} className="btn btn-info">Edit</button>
                                <button type="button" onClick={() => handleDeleteRow(item.itemId)} className="btn btn-danger">Delete</button>
                            </span></td>

                        </tr>
                    ))}
                </tbody>
            </table>
            {openEdit ? <MenuEdit closeEdit={() =>
                setOpenEdit(false)
            }
                itemID={itemToEdit}
            /> : ""}
        </div>
    );
}

