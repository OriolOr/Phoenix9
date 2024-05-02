import React, { useState, useEffect }  from "react";
import YearBalance from "./yearBalance";
import "./main.styles.css"
import Axios, { AxiosResponse } from "axios";

const Main:React.FC = () => {

    const [userBalance , setUserBalance] = useState(0);

    useEffect(()=>{
        const url = "https://localhost:44356/AccountMock/GetCurrentBalance"

        Axios.get(url).then(response => setUserBalance(response.data))
        .catch(function (error) {
        });
    },[])

    return (
    <div className = "mainContainer">

        <p>Current Balance : {userBalance} € </p>
        <YearBalance/>
    </div>
    )
}

export default Main;
