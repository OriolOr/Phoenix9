import React, { useEffect, useState }  from "react";
import Axios from "axios";
import * as Constants from "../../common/constants"
import "./main.styles.css"
import "./yearBalance.styles.css"

interface Month {
    Name: string;
    StartBalance: number; 
    EndBalance: number
}

const YearBalance:React.FC = () => {

    const [yearData, setYearData] = useState<Month[]>([]);
    const [year, setYear] = useState<number>(null);

    useEffect(()=> {

        const url = Constants.BaseUrl + "/AccountMock/GetCurrentYearData";
        Axios.get(url).then(response => {
            
            const fetchYearData = response.data.MonthBalances;
            setYear(response.data.Year);

            const monthList: Month[] = fetchYearData.map((jsonData:any)=> {
                return{
                    Name: jsonData.Month,
                    StartBalance: jsonData.InitialBalance,
                    EndBalance: jsonData.FinalBalance
                };
            });
            setYearData(monthList);
        })
        .catch(function (error) {});

    },[]);

    return (
        <div>
            {year}
        <table>
            <thead>
                <tr>
                    <th>Month</th>
                    <th>Start</th>
                    <th>End</th>
                </tr>
            </thead>
            <tbody>
            {yearData.map (month => (
            <tr>
                <td>{month.Name}</td>
                <td><input type="text" value={month.StartBalance} />€</td>
                <td><input type="text" value={month.EndBalance}/>€</td>
                <button onClick={handleStartBalance}>Save</button>
            </tr>                    
                ))}
            </tbody>
        </table>
        </div>
    )
}

const handleStartBalance = () => {  
    const url = "https://localhost:7171/AccountMock/UpdateCurrentYearData";
    console.log("Update Start Balance");
    Axios.post(url).then(response => console.log(response)).catch(function (error) {});
}

export default YearBalance;