import React, { useEffect, useState }  from "react";
import Axios from "axios";
import { BaseUrl } from "../../../common/constants"
import "../main.styles.css"
import "./yearBalance.styles.css"
import Balance from "./balance";
import ContentEditable from "react-contenteditable";

interface Month {
    Name: string
    StartBalance: number
    EndBalance: number
    Delta: number
}

const YearBalance:React.FC = () => {

    const [yearData, setYearData] = useState<Month[]>([]);
    const [year, setYear] = useState<number>(null);

    useEffect(()=> {

        const url = BaseUrl + "/AccountMock/GetCurrentYearData";

        Axios.get(url).then(response => {
            
            const fetchYearData = response.data.MonthBalances;
            setYear(response.data.Year);

            const monthList: Month[] = fetchYearData.map((jsonData:any)=> {
                return{
                    Name: jsonData.Month,
                    StartBalance: jsonData.InitialBalance,
                    EndBalance: jsonData.FinalBalance,
                    Delta: jsonData.FinalBalance - jsonData.InitialBalance
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
                    <th>Delta</th>
                    <th>Edit</th>

                </tr>
            </thead> 
            <tbody>
            {yearData.map (month => (
            <tr>
                <td>{month.Name}</td>
                <td><div contentEditable ='true'>{month.StartBalance} €</div></td>
                <td><div contentEditable ='true'>{month.EndBalance} €</div></td>
                <td><Balance value={month.Delta}/></td>
                <td><button>Edit</button><button>Delete</button></td>
            </tr>                    
                ))}
            </tbody>
        </table>
        </div>
    )
}

const handleStartBalance = (event:React.ChangeEvent<HTMLInputElement>, value:number) => {  
    //const url = BaseUrl + "/AccountMock/UpdateCurrentYearData";
    console.log(value);
    //Axios.post(url).then(response => console.log(response)).catch(function (error) {});
}

export default YearBalance;