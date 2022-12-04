import { WeatherForecast } from "../api-gateways";

export const WeatherForecastUseCase = (
  getWeatherForecast: () => Promise<WeatherForecast[]>
) => ({ getWeatherForecast });
