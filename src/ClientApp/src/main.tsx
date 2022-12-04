import React from "react";
import ReactDOM from "react-dom/client";
import { App } from "./App";
import { Provider } from "./services";

ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <Provider>
    <React.StrictMode>
      <App />
    </React.StrictMode>
  </Provider>
);
