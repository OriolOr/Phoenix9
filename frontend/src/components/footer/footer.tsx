import React, { useState } from "react";
import Axios from "axios"
import "./footer.styles.css"

export const Footer:React.FC = () => {
   
    const [connectionStatus, setConnectionStatus] = useState ('')
    ManageconnectionStatus();
    function ManageconnectionStatus(){

    const url = "https://localhost:7171/AccountMock/GetCurrentBalance" ;
    Axios.get(url).then(response => setConnectionStatus('Connected'))
    .catch(function (error) {
      setConnectionStatus('Not Connected')
    });

   }
   
    return (
        <div className = "footerContainer">
            <p>Development Version</p>
            <p> {connectionStatus}</p>
        </div>
    )
};

export default Footer;