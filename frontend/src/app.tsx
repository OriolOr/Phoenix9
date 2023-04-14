import React from "react";
import {BrowserRouter, Link} from "react-router-dom"
import Footer  from "./components/footer/footer";
import Header from "./components/header/header";
import Login  from "./components/login/login";


export const App:React.FC = () => {
  
  return(
    <div className = "appContainer">
      <Header/>
      <BrowserRouter>
        <Link>
          <Login/>
        </Link>
      </BrowserRouter>
      <Footer/>
    </div>
)
};

export default App;