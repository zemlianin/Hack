import React, {Component} from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
// import { YMaps, Map, Placemark } from 'react-yandex-maps'
// import { useRef } from 'react'
import './Styles/App.css';
import './Styles/enter_page.css';
import './Styles/style.css';


// var array = [
    
// ]

// function GetDataBase(){

// }

export default class Customer extends Component {
    // static displayName = App.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    static renderForecastsTable(forecasts) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    {forecasts.map(forecast =>
                        <tr key={forecast.date}>
                            <td>{forecast.date}</td>
                            <td>{forecast.temperatureC}</td>
                            <td>{forecast.temperatureF}</td>
                            <td>{forecast.summary}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        // let contents = this.state.loading
        //     ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        //     : App.renderForecastsTable(this.state.forecasts);

        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {/* {contents} */}
            </div>
        );
    }

    async populateWeatherData() {
        console.log("+++");
        const response = await fetch("https://localhost:7090/Transport/get");
        console.log(response);
        const data = await response.json();
        console.log(data);
      //  this.setState({ forecasts: data, loading: false });
    }
}