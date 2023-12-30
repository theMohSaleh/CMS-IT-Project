import React from 'react';

export default function Alert(props) {
    return (
        <div>

            <div className={`alert alert-${props.type} alert-dismissible`} role="alert">
                <div>{props.message}</div>
                <button
                    type="button"
                    className="btn-close"
                    data-bs-dismiss="alert"
                    aria-label="Close"
                ></button>
            </div>

        </div>
    );
}
