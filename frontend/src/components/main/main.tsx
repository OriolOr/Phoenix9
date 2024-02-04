import React  from "react";
import YearBalance from "./yearBalance";
import "./main.styles.css"

const Main:React.FC = () => {

    return (
    <div className = "mainContainer">
        2024
        <p>Current Balance : 0 € </p>
        <YearBalance/>
    </div>

    )
}


export default Main;