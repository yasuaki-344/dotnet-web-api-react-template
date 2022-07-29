import { createContext, useContext } from "react";

export const DIContainer = createContext({} as { [key: string]: any });

export const useInjection = () => {
  const context = useContext(DIContainer);

  const inject = (key: string): any => {
    if (key in context) {
      return context[key];
    }
    throw new Error(`${key} is not registered as dependency`);
  };

  return inject;
};

export const constructContainer = () => {
  const container: { [key: string]: any } = {};

  return container;
}
