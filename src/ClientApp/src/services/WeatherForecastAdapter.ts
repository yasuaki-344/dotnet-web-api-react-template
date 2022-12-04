import { WeatherForecast, WeatherForecastApi } from "../api-gateways";
import { WeatherForecastService } from "../application";

export const userWeatherForecast = (): WeatherForecastService => {
  const api = new WeatherForecastApi();

  const getWeatherForecast = async (): Promise<WeatherForecast[]> => {
    const res = await api.getWeatherForecast();
    return res;
  };

  return {
    getWeatherForecast,
  };
};
