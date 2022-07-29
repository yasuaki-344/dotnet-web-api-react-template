import { WeatherForecast } from "../api-gateways";

export interface WeatherForecastInteractorInterface {
  /**
   * Gets weather forecast list
   */
  getWeatherForecast(): Promise<WeatherForecast[]>;
}
