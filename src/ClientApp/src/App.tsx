import { Main } from "./components";
import { constructContainer, DIContainer } from "./container";
import "./index.css";

export const App = () => {
  const container = constructContainer();

  return (
    <DIContainer.Provider value={container}>
      <Main />
    </DIContainer.Provider>
  );
};
