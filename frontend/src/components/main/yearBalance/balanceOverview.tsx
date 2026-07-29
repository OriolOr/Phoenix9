import React, { useState } from 'react';


const BalanceOverview: React.FC = () => {

    const [userBalance , _setUserBalance] = useState(1400);
    const [n26Balance , _setN26Balance] = useState(1479);
    const [tradeBalance , _setTradeBalance] = useState(2700);
    
  return (
    <div className="balance-overview">
      {
        <>
        <span>N26 Balance: {n26Balance} € </span>
        <span>Trade Balance : {tradeBalance} € </span>
        <span>Current Balance : {userBalance + tradeBalance} € </span>
        </>
     }
    </div>
  );
};

export default BalanceOverview;
