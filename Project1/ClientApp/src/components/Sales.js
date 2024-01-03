import React from 'react';

export default function Sales() {
    const [items, setItems] = React.useState([]);
    const [itemImages, setItemImages] = React.useState({});
    const [summary, setSummary] = React.useState(null);

    React.useEffect(() => {
        fetch('/api/OrderItems/summary')
            .then((response) => response.json())
            .then((data) => {
                setSummary(data);
            })
            .catch((error) => console.error('Error fetching sales summary:', error));
    }, []);

    React.useEffect(() => {
        fetch('/api/items/')
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

    return (
        <div>
            {summary && (
                <div>
                    <div className="card mt-5 mb-3" styles="width: 18rem;">
                        <h4 className="card-title">Most Sold Item:</h4>
                        <img src={itemImages[summary.itemId]} className="card-img-top" alt="..." />
                        <div className="card-body">
                            <p className="card-text">   </p>
                            </div>
                    </div>
                    <h3 className="mb-5">Total Restaurant Revenue: {summary.totalRevenue.toFixed(2)} BD</h3>
                </div>
            )}
        </div>
    );
}

