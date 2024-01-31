import React, { useState } from 'react';

const Stock: React.FC = () => {

   const [stockValue, setStockValue] = useState(0);

    return (
        <div>
           Stock
           Current stock price: {stockValue}
        </div>
    );


    function getStockValue() {}
};

export default Stock;

