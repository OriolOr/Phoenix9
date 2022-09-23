import React, { useState } from "react";
import "./login.styles.css"


const Login:React.FC = () => {
  

  const [userName , setUserName] = useState('');
  const [userPassword, setUserPassword] = useState('');
  const url = "http://localhost:5050";

    return(   
    <div className="loginContainer">
      <input type="text" onChange={(e) => setUserName(e.target.value)}></input>
      <input type="password" onChange={(e)=> setUserPassword(e.target.value)}></input>
      <input type="submit" value="Log In" onClick={HandleLogin}></input>
    </div>)
  
    function HandleLogin () {
      console.log (userName);
      console.log(userPassword);
    };

};

export default Login;