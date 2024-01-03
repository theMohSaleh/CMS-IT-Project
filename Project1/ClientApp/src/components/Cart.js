import React from 'react';
import { useNavigate } from "react-router-dom"
import { Checkbox } from '../../../../node_modules/@mui/material/index';

export default function Cart() {
    const [items, setItems] = React.useState([]);
    const [isChecked, setIsChecked] = React.useState(false);
    const [itemImages, setItemImages] = React.useState({});
    const [cart, setCart] = React.useState([]);
    let isLoggedIn = window.sessionStorage.getItem("isLoggedIn")
    const navigate = useNavigate();
    const userId = window.sessionStorage.getItem("userID")

    React.useEffect(() => {
        if (isLoggedIn === "true") {

        } else {
            navigate("/")
        }
    }, []);

    React.useEffect(() => {
        fetch(`/api/orderCart/${userId}`)
            .then(response => { return response.json() })
            .then(data => setCart(data))
            .catch(error => console.error('Error fetching items:', error))
    }, []);

    React.useEffect(() => {
        fetch('/api/items')
            .then(response => { return response.json() })
            .then(data => setItems(data))
            .catch(error => console.error('Error fetching items:', error))
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

    const getItemDetails = (itemId) => {
        // Find the item in the items state based on itemId
        const item = items.find((item) => item.itemId === itemId);

        // Return the details
        return item || { imageId: "", itemName: "", itemDescription: "", price: 0 };
    };

    const deleteItem = async (id) => {
        try {
            const response = await fetch(`/api/orderCart/${id}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json',
                },
            });

            if (!response.ok) {
                throw new Error('Failed to delete item');
            }

            const updatedCart = cart.filter((cartItem) => cartItem.orderCartID !== id);
            setCart(updatedCart);
            console.log('Item deleted successfully');
        } catch (error) {
            console.error('Error deleting item:', error);
        }
    };

    const handleCheckboxChange = () => {
        setIsChecked(!isChecked);
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            let dataToSend =
                {
                    userId: "",
                    didCheck: ""
            }

            if (isChecked) {
                dataToSend = {
                    userId: userId.toString(),
                    didCheck: (0).toString()
                };
            } else {
                dataToSend = {
                    userId: userId.toString(),
                    didCheck: (1).toString()
                };
            }

            const response = await fetch('/api/orders/place', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(dataToSend),
            });

            if (!response.ok) {
                throw new Error('Failed to place order');
            }

            window.alert("Order placed successfully!");
            console.log('Order placed successfully');
            navigate("/")
        } catch (error) {
            console.error('Error placing order:', error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <section className="h-100" styles="background-color: #eee;">
                <div className="container h-100 py-5">
                    <div className="row d-flex justify-content-center align-items-center h-100">
                        <div className="col-10">
                            <div className="d-flex justify-content-between align-items-center mb-4">
                                <h3 className="fw-normal mb-0 text-black">Shopping Cart</h3>
                            </div>
                            {cart.map(cartItem => {
                                const { itemId, quantity } = cartItem;
                                const { imageId, itemName, itemDescription, price } = getItemDetails(itemId);
                                const totalItemPrice = price * quantity;
                                return (
                                    <div key={cartItem.orderCartID} className="card rounded-3 mb-4">
                                        <div className="card-body p-4">
                                            <div className="row d-flex justify-content-between align-items-center">
                                                <div className="col-md-2 col-lg-2 col-xl-2">
                                                    <img
                                                        src={itemImages[itemId]}
                                                        className="img-fluid rounded-3" alt="Cotton T-shirt" />
                                                </div>
                                                <div className="col-md-3 col-lg-3 col-xl-3">
                                                    <p className="lead fw-normal mb-2">{itemName}</p>
                                                    <p><span className="text-muted">Quantity: </span>{quantity}</p>
                                                </div>
                                                <div className="col-md-3 col-lg-2 col-xl-2 offset-lg-1">
                                                    <h5 className="mb-0">{totalItemPrice} BD</h5>
                                                </div>
                                                <div className="col-md-3 col-lg-3 col-xl-2 d-flex ms-auto">
                                                    <button type="button" onClick={() => deleteItem(cartItem.orderCartID)} className="btn btn-outline-danger ms-auto" > Delete</button>
                                                </div>
                                                <div className="col-md-1 col-lg-1 col-xl-1 text-end">
                                                    <a href="#!" className="text-danger"><i className="fas fa-trash fa-lg"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                );
                            })}
                            <div className="card">
                                <input type="checkbox" className="btn-check" id="btncheck1" autoComplete="off"
                                    checked={isChecked}
                                    onChange={handleCheckboxChange} />
                                <label className="btn btn-outline-primary" htmlFor="btncheck1">Pick up order?</label>
                                <div className="card-body">
                                    <button className="btn btn-warning btn-block btn-lg w-100">Place Order</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </form>
    );
}
