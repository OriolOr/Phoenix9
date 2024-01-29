import React  from "react";
import { Link } from "react-router-dom";
import "./main.styles.css"

const Main:React.FC = () => {

    return (
    <div className = "mainContainer">
        <p>Current Balance : 0 € </p>
        <p>Starting Balance : 0 €</p>
        
        
        <Link to ="login">
        <button> LogIn </button>
        </Link>


        <button> Balance </button>

        <Link to ="stock">
        <button> Stock </button>
        </Link>


    </div>
    )
}


export default Main;