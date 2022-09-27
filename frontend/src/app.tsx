import React from "react";
import Footer  from "./components/footer/footer";
import Header from "./components/header/header";
import Login  from "./components/login/login";

export const App:React.FC = () => {
  
  return(
    <div className = "appContainer">
    <Header/>
    <Login/>
    <Footer/>
    </div>
)
};

export default App;