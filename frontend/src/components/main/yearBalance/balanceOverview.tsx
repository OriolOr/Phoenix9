import React from 'react';


const BalanceOverview: React.FC = () => {

    const [userBalance , setUserBalance] = useState(1400);
    const [n26Balance , setN26Balance] = useState(1479);
    const [tradeBalance , setTradeBalance] = useState(2700);
    
  return (
    <div className="balance-overview">
      {
        <span>N26 Balance: {userBalance} € </span>
        <span>Trade Balance : {tradeBalance} € </span>
        <span>Current Balance : {userBalance + tradeBalance} € </span>
     }
    </div>
  );
};

export default BalanceOverview;
