import React from 'react';
import Alert from './Alert';
import { useNavigate } from "react-router-dom"
import { Route } from 'react-router-dom';
import EditItem from './EditItem';
import { Link } from 'react-router-dom';

export default function EditMenu() {
    const [items, setItems] = React.useState([]);
    const [itemImages, setItemImages] = React.useState({});
    const [showAlert, setShowAlert] = React.useState(false);
    const navigate = useNavigate();
    const [showEdit, setShowEdit] = React.useState(false);
    const [editItemVisible, setEditItemVisible] = React.useState(false);
    const [selectedItemId, setSelectedItemId] = React.useState(null);

    const handleEditClick = (itemId) => {
        setSelectedItemId(itemId);
        setEditItemVisible(true);
    };

    let roleID = window.sessionStorage.getItem("roleID")

    React.useEffect(() => {
        if (roleID === "1") {

        } else {
            navigate("/")
        }
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

    const handleSubmit = async (event, itemId) => {
        event.preventDefault();

        setShowEdit(true)
        //if (roleID === "1") {

        //    const newCart = {
        //        userId: window.sessionStorage.getItem("userID"),
        //        ItemId: itemId.toString()
        //    };

        //    console.log("cart", newCart)

        //    try {
        //        const response = await fetch('/api/orderCart/cart', {
        //            method: 'POST',
        //            headers: {
        //                'Content-Type': 'application/json',
        //            },
        //            body: JSON.stringify(newCart),
        //        });

        //        if (response.ok) {
        //            // add successful
        //            //window.alert('Item added to cart!');
        //            setShowAlert(true)
        //        } else {
        //            console.error('Adding cart failed:', response.status, response.statusText);
        //        }
        //    } catch (error) {
        //        console.error('Error during API call:', error);
        //    }
        //} else {
        //    window.alert('Not an admin!');
        //}
    }

    return (
        <div>
            {editItemVisible && <EditItem itemId={selectedItemId} />}
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
                                <button className="btn btn-info" onClick={() => handleEditClick(item.id)} data-mdb-ripple-init>Edit Item</button>
                                {/*<button className="btn btn-info" onClick={(e) => handleSubmit(e, item.itemId)} data-mdb-ripple-init>Edit Item</button>*/}
                                {/*<Link className="btn btn-info" to="/editItem">Edit Item</Link>*/}
                            </div>
                        </div>
                    ))}
                </div>
            </form>
        </div>
    );
}

