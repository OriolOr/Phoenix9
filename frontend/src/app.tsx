import Stock from './components/Stock/stock'
import {Routes, Route} from "react-router-dom"
import './App.css'
import { Header } from './components/header/header'
import { Footer } from './components/footer/footer'
import Main from './components/main/main'
import Login from './components/login/login'
import HomeMortage from './components/homeMortage/homeMortage'

function App() {

  return (
    <div className= "appContainer">
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
}

export default App
