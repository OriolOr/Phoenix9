import React, { useState } from "react";
import Axios, { AxiosResponse } from "axios";
import "./login.styles.css"
import { Link } from "react-router-dom";

const Login:React.FC = () => {
  
  const [userName , setUserName] = useState('');
  const [userPassword, setUserPassword] = useState('');

    return(   
    <div className="loginContainer">
      <input type="text" className ="loginInput" onChange={(e) => setUserName(e.target.value)}></input>
      <input type="password" className ="loginInput" onChange={(e)=> setUserPassword(e.target.value)}></input>
      <input type="submit" className ="login-btn" value="Log In" onClick={HandleLogin}></input>

      <Link to ="app">
      <button className="login-exit">Exit</button>
      </Link>
    </div>)

    function HandleLogin () {

      const url = ["http://localhost:5000/Account/GetCurrentBalance?user=" + userName +"&password="+ userPassword].join();

      //to update get -> post
      Axios.get(url).then(response => CheckResponseStatus(response))
      .catch(function (error) {
        console.log(error);
      });
    };

    function CheckResponseStatus(response:AxiosResponse){
      if (response.status == 200){
        console.log("OK")
      }
    }
};

export default Login;