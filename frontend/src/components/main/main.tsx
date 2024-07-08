import React, { useState, useEffect }  from "react";
import Axios, { AxiosResponse } from "axios";
import YearBalance from "./yearBalance/yearBalance";
import { BaseUrl } from "../../common/constants"
import "./main.styles.css"


const Main:React.FC = () => {

    const [userBalance , setUserBalance] = useState(0);

    useEffect(()=>{
        const url = BaseUrl + "/AccountMock/GetCurrentBalance"

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
