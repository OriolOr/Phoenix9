import React, { useEffect, useState }  from "react";
import Axios from "axios";
import { BaseUrl } from "../../common/constants"
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

        const url = BaseUrl + "/AccountMock/GetCurrentYearData";

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
            <tr >
                <td>{month.Name}</td>
                <td><input type="text" value={month.StartBalance} onChange={(event) =>
                    handleStartBalance(event,index)
                  }/>€</td>
                <td><input type="text" value={month.EndBalance}/>€</td>
                <button>Save</button>
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