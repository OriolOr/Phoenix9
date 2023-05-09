import React from "react";
import {Routes, Route} from "react-router-dom"
import Footer  from "./components/footer/footer";
import Header from "./components/header/header";
import Login  from "./components/login/login";
import Main from "./components/main/main";


export const App:React.FC = () => {
  
  return(
    <div className = "appContainer">
      <Header/>
      <Routes>
        <Route path="/" element={<Main/>}/>
        <Route path="login" element={<Login/>}/>
      </Routes>
      <Footer/>
    </div>
)
};

export default App;