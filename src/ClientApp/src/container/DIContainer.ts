import { createContext, useContext } from "react";
import {
  WeatherForecastApi,
  WeatherForecastApiInterface,
} from "../api-gateways";
import { WeatherForecastInteractor } from "../use-cases";

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

  const inject = <T>(key: string): T => {
    if (key in container) {
      return container[key] as T;
    }
    throw new Error(`${key} is not registered as dependency`);
  };

  // Register objects to DI container.
  register("WeatherForecastApi", new WeatherForecastApi());
  register(
    "WeatherForecastInteractor",
    new WeatherForecastInteractor(
      inject<WeatherForecastApiInterface>("WeatherForecastApi")
    )
  );

  return container;
};
