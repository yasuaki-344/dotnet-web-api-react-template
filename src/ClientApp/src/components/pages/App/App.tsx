import { useState } from "react";
import reactLogo from "../../../assets/react.svg";
import { ImageLink } from "../../ui-parts";
import "./App.css";

export const App = () => {
  const [count, setCount] = useState(0);

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
        <button onClick={() => setCount((o) => o + 1)} type="button">
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
