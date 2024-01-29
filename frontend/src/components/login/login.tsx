import React, { useState } from "react";
import Axios, { AxiosResponse } from "axios";
import "./login.styles.css"
import { Link } from "react-router-dom";


const Login:React.FC = () => {
  
  const [userName , setUserName] = useState('');
  const [userPassword, setUserPassword] = useState('');
  const [userBalance ,setUserBalance] = useState('');

    return(   
    <div className="loginContainer">
      <input type="text" className ="loginInput" onChange={(e) => setUserName(e.target.value)}></input>
      <input type="password" className ="loginInput" onChange={(e)=> setUserPassword(e.target.value)}></input>
      <input type="submit" className ="login-btn" value="Log In" onClick={HandleLogin}></input>
      <h1>{userBalance}</h1>

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
        setUserBalance("Login error");
      });
    };

    function CheckResponseStatus(response:AxiosResponse){
      console.log("entro en el estatus");
      if (response.status == 200){
        console.log("OK")
        //it should link to main page view, then it should charge all info related with user
        setUserBalance(response.data +' €');

      }
      else if (response.status == 401)
        setUserBalance("Login error");
    }
};

export default Login;