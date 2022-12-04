import { useEffect } from "react";
import { WeatherForecast } from "../../../api-gateways";
import reactLogo from "../../../assets/react.svg";
import {
  useCounter,
  useCountStorage,
  userWeatherForecast,
} from "../../../services";
import { ImageLink } from "../../ui-parts";
import "./App.css";

export const Main = () => {
  const { count } = useCountStorage();
  const { increaseCount } = useCounter();
  const { getWeatherForecast } = userWeatherForecast();

  useEffect(() => {
    getWeatherForecast()
      .then((response: WeatherForecast[]) => {
        console.log(response);
      })
      .catch(console.error);
  }, []);

  return (
    <div className="App">
      <div>
        <ImageLink
          href="https://vitejs.dev"
          src="/vite.svg"
          className="logo"
          alt="Vite logo"
        />
        <ImageLink
          href="https://reactjs.org"
          src={reactLogo}
          className="logo react"
          alt="React logo"
        />
      </div>
      <h1>Vite + React</h1>
      <div className="card">
        <button onClick={() => increaseCount()} type="button">
          count is {count}
        </button>
        <p>
          Edit <code>src/App.tsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
    </div>
  );
};
