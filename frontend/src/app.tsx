import React from "react";
import {Routes, Route} from "react-router-dom"
import Footer  from "./components/footer/footer";
import Header from "./components/header/header";
import Login  from "./components/login/login";
import Main from "./components/main/main";
import Stock from "./components/Stock/stock";
import HomeMortage from "./components/homeMortage/homeMortage";



export const App:React.FC = () => {
  
  return(
    <div className = "appContainer">
      <Header/>
      <Routes>
        <Route path="/" element={<Main/>}/>
        <Route path="login" element={<Login/>}/>
        <Route path= "main" element={<Main/>}/>
        <Route path= "homeMortage" element={<HomeMortage/>}/>
        <Route path= "stock" element={<Stock/>}/>
      </Routes>
      <Footer/>
    </div>
)
};

export default App;