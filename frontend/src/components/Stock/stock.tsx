import React, { useState } from 'react';
import logo from "../../assets/logo.png"

const Stock: React.FC = () => {

   const [stockValue, setStockValue] = useState(0);

    return (
        
        <div>
           <img src={logo} alt="logo" width="64" height="64"></img>
            WORK IN PROGRESS
        </div>
    );


    function getStockValue() {}
};

export default Stock;

