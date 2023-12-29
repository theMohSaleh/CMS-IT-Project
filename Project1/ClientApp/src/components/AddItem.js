import React from 'react';

export default function AddItem() {

    const [formData, setFormData] = React.useState({
        CategoryId: "2",
        ItemName: "",
        ItemDescription: "",
        Price: "",
        ImageData: []
    })

    const handleFileChange = (event) => {
        const file = event.target.files[0];

        const reader = new FileReader();
        reader.onload = (e) => {
            const imageData = arrayBufferToBase64(e.target.result);
            setFormData((prevData) => ({
                ...prevData,
                ImageData: imageData,
            }));
        };

        reader.readAsArrayBuffer(file);
    };

    function arrayBufferToBase64(buffer) {
        let binary = '';
        const bytes = new Uint8Array(buffer);
        const len = bytes.byteLength;

        for (let i = 0; i < len; i++) {
            binary += String.fromCharCode(bytes[i]);
        }

        return window.btoa(binary);
    }

    //const handleFileChange = (event) => {
    //    const file = event.target.files[0];

    //    const reader = new FileReader();
    //    reader.onload = (e) => {
    //        const imageData = new Uint8Array(e.target.result);
    //        setFormData((prevData) => ({
    //            ...prevData,
    //            ImageData: imageData,
    //        }));
    //    };

    //    reader.readAsArrayBuffer(file);
    //};

    const handleUpload = async (event) => {
        event.preventDefault();
        console.log("formData: ",formData)
        const result = await fetch('/api/items/addItem', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData)
        })

        const resultInJson = await result.json();
        console.log(resultInJson)

        //try {
        //    const response = await fetch('/api/items/addItem', {
        //        method: 'POST',
        //        headers: {
        //            'Content-Type': 'application/json',
        //        },
        //        body: JSON.stringify(formData),
        //    });

        //    if (response.ok) {
        //        console.log('Item added successfully!');
        //    } else {
        //        console.error('Failed to add item');
        //    }
        //} catch (error) {
        //    console.error('Error during item addition:', error);
        //}
    };

    function handleChange(event) {
        const { name, value} = event.target
        setFormData(x => {
            return {
                ...x,
                [name]: value
            }
        })
        console.log(name, ": ", value)
        console.log("img binary: ", formData.ImageData)
    }

    return (
        <div className="container">
            <div className="row mx-0 justify-content-center">
                <div className="col-md-7 col-lg-5 px-lg-2 col-xl-4 px-xl-0 px-xxl-3">
                    <form
                        onSubmit={handleUpload}
                        className="w-100 rounded-1 p-4 border bg-white">
                        <div className="form-outline mb-4">
                            <label className="form-label" htmlFor="form3Example3cg">Name</label>
                            <input name="ItemName" value={formData.ItemName} onChange={handleChange} placeholder="name" id="form3Example3cg" className="form-control form-control-lg" />
                        </div>
                        <div className="form-outline mb-4">
                            <label className="form-label" htmlFor="form3Example3cg">Description</label>
                            <input name="ItemDescription" value={formData.ItemDescription} onChange={handleChange} placeholder="ex. tomato, pickles etc..." id="form3Example3cg" className="form-control form-control-lg" />
                        </div>
                        <div className="form-outline mb-4">
                            <label className="form-label" htmlFor="form3Example3cg">Price</label>
                            <input name="Price" value={formData.Price} onChange={handleChange} placeholder="0.000 BD" id="form3Example3cg" className="form-control form-control-lg" />
                        </div>
                        <label className="d-block mb-4">
                            <span className="form-label d-block">Your photo</span>
                            <input name="ImageData" type="file" onChange={handleFileChange} className="form-control" />
                        </label>

                        <div className="mb-3">
                            <button type="submit" className="btn btn-primary px-3 rounded-3">
                                Add Item
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
}

