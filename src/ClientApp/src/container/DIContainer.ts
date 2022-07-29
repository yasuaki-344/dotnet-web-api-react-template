import { createContext, useContext } from "react";
import { WeatherForecastApi } from "../api-gateways";

export const DIContainer = createContext({} as { [key: string]: any });

export const useInjection = () => {
  const context = useContext(DIContainer);

  const inject = <T>(key: string): T => {
    if (key in context) {
      return context[key] as T;
    }
    throw new Error(`${key} is not registered as dependency`);
  };

  return inject;
};

export const constructContainer = () => {
  const container: { [key: string]: any } = {};

  const register = (key: string, object: any) => {
    container[key] = object;
  };

  // Register objects to DI container.
  register("WeatherForecastApi", new WeatherForecastApi());

  return container;
};
