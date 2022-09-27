import React, { useState } from "react";
import Axios, { AxiosResponse } from "axios";
import "./login.styles.css"


const Login:React.FC = () => {
  
  const [userName , setUserName] = useState('');
  const [userPassword, setUserPassword] = useState('');

    return(   
    <div className="loginContainer">
      <input type="text" onChange={(e) => setUserName(e.target.value)}></input>
      <input type="password" onChange={(e)=> setUserPassword(e.target.value)}></input>
      <input type="submit" value="Log In" onClick={HandleLogin}></input>
    </div>)
  
    function HandleLogin () {

      const url = ["https://localhost:7171/Account/GetCurrentBalance?user=" + userName +"&password="+ userPassword].join();
      console.log(url);
      Axios.get(url).catch().then(function (response) {
         
        CheckResponseStatus(response);
      })
      .catch(function (error) {
        console.log(error);
      });;
    };

    function CheckResponseStatus(response:AxiosResponse){
      
      if (response.status == 200){
        console.log("OK")
        console.log(response.data);
      }
    }
};

export default Login;