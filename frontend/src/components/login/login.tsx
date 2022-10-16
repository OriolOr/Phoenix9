import React, { useState } from "react";
import Axios, { AxiosResponse } from "axios";
import "./login.styles.css"


const Login:React.FC = () => {
  
  const [userName , setUserName] = useState('');
  const [userPassword, setUserPassword] = useState('');
  const [userBalance ,setUserBalance] = useState('');

    return(   
    <div className="loginContainer">
      <input type="text" onChange={(e) => setUserName(e.target.value)}></input>
      <input type="password" onChange={(e)=> setUserPassword(e.target.value)}></input>
      <input type="submit" value="Log In" onClick={HandleLogin}></input>
      <h1>{userBalance}</h1>
    </div>)

    function HandleLogin () {

      const url = ["https://localhost:7171/Account/GetCurrentBalance?user=" + userName +"&password="+ userPassword].join();

      Axios.get(url).catch().then(function (response) {
        CheckResponseStatus(response);
      })
      .catch(function (error) {
        console.log(error);
      });
    };

    function CheckResponseStatus(response:AxiosResponse){
      
      if (response.status == 200){
        console.log("OK")
        setUserBalance(response.data +' €');
      }
      else if (response.status == 401)
        setUserBalance("Login error");
    }
};

export default Login;