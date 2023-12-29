import React, { useState } from 'react';

export default function Cart({ cartItems }) {
    const [items, setItems] = useState(cartItems);

    const handleRemoveItem = (itemId) => {
        const updatedItems = items.filter((item) => item.id !== itemId);
        setItems(updatedItems);
    };

    const handleUpdateQuantity = (itemId, newQuantity) => {
        const updatedItems = items.map((item) =>
            item.id === itemId ? { ...item, quantity: newQuantity } : item
        );
        setItems(updatedItems);
    };

    return (
        <div>
            <h2>Shopping Cart</h2>
            {items.length === 0 ? (
                <p>Your cart is empty</p>
            ) : (
                <table>
                    <thead>
                        <tr>
                            <th>Item Name</th>
                            <th>Price</th>
                            <th>Quantity</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {items.map((item) => (
                            <tr key={item.id}>
                                <td>{item.name}</td>
                                <td>${item.price}</td>
                                <td>
                                    <button onClick={() => handleUpdateQuantity(item.id, item.quantity - 1)}>-</button>
                                    {item.quantity}
                                    <button onClick={() => handleUpdateQuantity(item.id, item.quantity + 1)}>+</button>
                                </td>
                                <td>
                                    <button onClick={() => handleRemoveItem(item.id)}>Remove</button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            )}
        </div>
    );
}
