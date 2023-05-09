import React  from "react";
import { Link } from "react-router-dom";
import "./main.styles.css"

export const Main:React.FC = () => {

    return (
    <div className = "mainContainer">
        <p> Maneko </p>
        <Link to ="login">
        <button> LogIn </button>
        </Link>
    </div>
    )
}


export default Main;