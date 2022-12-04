import { WeatherForecastApi } from "../api-gateways";
import { WeatherForecastService, WeatherForecastUseCase } from "../application";

export const useWeatherForecast = (): WeatherForecastService => {
  const api = new WeatherForecastApi();
  api.getWeatherForecast();

  const { getWeatherForecast } = WeatherForecastUseCase(() =>
    api.getWeatherForecast()
  );

  return { getWeatherForecast };
};
