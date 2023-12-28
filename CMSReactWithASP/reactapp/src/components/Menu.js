import React from 'react';

export default function Menu() {
    const [items, setItems] = React.useState([]);

    React.useEffect(() => {
        fetch('items')
            .then(response => response.json())
            .then(data => setItems(data))
            .catch(error => console.error('Error fetching items:', error))
    }, []);

    return (
        <div>
            <h2>Menu</h2>
            <ul>
                {items.map(item => (
                    <li key={item.itemId}>
                        <h3>{item.itemName}</h3>
                        <p>{item.itemDescription}</p>
                        <p>Price: {item.price}</p>
                    </li>
                ))}
            </ul>
        </div>
    );
}

