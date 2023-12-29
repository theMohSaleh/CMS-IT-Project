import React from 'react';

export default function Menu() {
    const [items, setItems] = React.useState([]);
    const [itemImages, setItemImages] = React.useState({});

    React.useEffect(() => {
        fetch('/api/items')
            .then(response => { return response.json() })
            .then(data => setItems(data))
            .catch(error => console.error('Error fetching items:', error))
    }, []);

    React.useEffect(() => {
        // Fetch images for each item
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

    return (
        <div>
            <div className="row row-cols-1 row-cols-md-3 g-4">
                {items.map(item => (
                    <div key={item.itemId} className="col">
                        <div className="card">
                            <img src={itemImages[item.itemId]} className="card-img-top"
                                alt="Hollywood Sign on The Hill" />
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
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
}

