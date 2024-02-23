import React, { useEffect, useState }  from "react";
import Axios from "axios";
import { Link } from "react-router-dom";
import "./main.styles.css"


interface Month {
    Name: string;
    StartBalance: number; 
    EndBalance: number
}

const YearBalance:React.FC = () => {

    const [yearData, setYearData] = useState<Month[]>([]);
    const [yearData, setYear] = useState(0);

    useEffect(()=> {

        const url = "https://localhost:44356/AccountMock/GetCurrentYearData"
        Axios.get(url).then(response => {
            
            const fetchYearData = response.data.MonthBalances;

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
                <td>{month.StartBalance}€</td>
                <td>{month.EndBalance}€</td>
            </tr>                    
                ))}
            </tbody>
        </table>
    )
}


export default YearBalance;