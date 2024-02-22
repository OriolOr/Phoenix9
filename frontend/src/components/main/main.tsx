import React, { useState }  from "react";
import YearBalance from "./yearBalance";
import "./main.styles.css"

const Main:React.FC = () => {

    const [userBalance , setUserBalance] = useState(0);
    
    function HandleCurrentBalance(){
        const url = "localhost:5000"; 
        setUserBalance(9001)
        return 9011;
    }

    return (
    <div className = "mainContainer">
        2024
        <p>Current Balance : {userBalance} € </p>
        <YearBalance/>
    </div>
    )
}

export default Main;