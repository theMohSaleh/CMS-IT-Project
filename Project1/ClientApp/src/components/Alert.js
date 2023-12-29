import React from 'react';

export default function Alert(props) {
    return (
        (
            <div className={`alert alert-${props.type} alert-dismissible`} role="alert">
                <div>{props.message}</div>
            </div>
        )
    );
}
