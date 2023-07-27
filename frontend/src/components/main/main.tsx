import React  from "react";
import { Link } from "react-router-dom";
import "./main.styles.css"

export const Main:React.FC = () => {

    return (
    <div className = "mainContainer">
        <h1> Maneko </h1>
        <Link to ="login">
        <button> LogIn </button>
        </Link>
    </div>
    )
}


export default Main;