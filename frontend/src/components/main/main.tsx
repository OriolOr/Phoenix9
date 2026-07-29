import React from "react";
import YearBalance from "./yearBalance/yearBalance";
import "./main.styles.css"


const Main:React.FC = () => {

    // useEffect(()=>{
    //     const url = BaseUrl + "/AccountMock/GetCurrentBalance"

    //     Axios.get(url).then(response => setUserBalance(response.data))
    //     .catch(function () {
    //     });
    // },[])

    return (
    <div className = "mainContainer">

        <YearBalance/>
    </div>
    )
}

export default Main;
