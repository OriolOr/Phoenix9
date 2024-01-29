import React from "react";
import "./header.styles.css"
import { Link } from "react-router-dom";

export const Header:React.FC = () => {
    return (
        <div className = "headerContainer">
        <p>Maneko</p>
        <Link to= "/stock">Stock</Link>
        <Link to= "/login">Login</Link>
        <Link to= "/main">Balance</Link>
        </div>
    )
};

export default Header;

