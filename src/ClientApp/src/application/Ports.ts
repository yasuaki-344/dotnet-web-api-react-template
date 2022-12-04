import { WeatherForecast } from "../api-gateways";

export interface CountStorageService {
  count: number;
  updateCount(count: number): void;
}

export interface WeatherForecastService {
  getWeatherForecast(): Promise<WeatherForecast[]>;
}

export interface CountService {
  increaseCount(): void;
}
