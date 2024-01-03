import React from 'react';
import Alert from './Alert';
import { useNavigate } from "react-router-dom"
import { Added } from "./Added"

export default function Menu() {
    const [items, setItems] = React.useState([]);
    const [itemImages, setItemImages] = React.useState({});
    const [showAlert, setShowAlert] = React.useState(false);
    const [openEdit, setOpenEdit] = React.useState(false);
    const navigate = useNavigate();

    let isLoggedIn = window.sessionStorage.getItem("isLoggedIn")

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
                    setOpenEdit(true)
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

    return (
        <div>
            <form onSubmit={handleSubmit}>
                {showAlert ? < Alert message="Item added successfully!." type="success" /> : ""}
                <div className="row row-cols-1 row-cols-md-3 g-4 mt-5 mb-5">
                    {items.map(item => (
                        <div key={item.itemId} className="col">
                            <div className="card">
                                <img src={itemImages[item.itemId]} className="card-img-top"
                                    alt="Loading..." />
                                <div className="card-body">
                                    <h5 className="card-title">{item.itemName}</h5>
                                    <p className="card-text">
                                        Price:&nbsp;{item.price}&nbsp;BD
                                    </p>
                                    <p className="card-text">
                                        Description:<br />
                                        {item.itemDescription}
                                    </p>
                                </div>
                                <button className="btn btn-primary" onClick={(e) => handleSubmit(e, item.itemId)} data-mdb-ripple-init>Add to Cart</button>
                            </div>
                        </div>
                    ))}
                </div>
            </form>
            {openEdit ? <Added closeEdit={() =>
                setOpenEdit(false)
                }
                /> : ""}
        </div>
    );
}

