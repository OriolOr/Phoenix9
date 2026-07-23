import React, { useState, useEffect }  from "react";
import Axios from "axios";
import YearBalance from "./yearBalance/yearBalance";
import { BaseUrl } from "../../common/constants"
import "./main.styles.css"


const Main:React.FC = () => {

    const [userBalance , setUserBalance] = useState(1400);
    const [n26Balance , setN26Balance] = useState(1479);
    const [tradeBalance , setTradeBalance] = useState(2700);

    useEffect(()=>{
        const url = BaseUrl + "/AccountMock/GetCurrentBalance"

        Axios.get(url).then(response => setUserBalance(response.data))
        .catch(function (error) {
        });
    },[])

    return (
    <div className = "mainContainer">

        <span>N26 Balance: {userBalance} € </span>
        <span>Trade Balance : {tradeBalance} € </span>
        <span>Current Balance : {userBalance + tradeBalance} € </span>
        <YearBalance/>
    </div>
    )
}

export default Main;
