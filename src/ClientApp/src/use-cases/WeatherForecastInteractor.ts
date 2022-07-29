import { WeatherForecast, WeatherForecastApiInterface } from "../api-gateways";
import { WeatherForecastInteractorInterface } from "../interfaces";

export class WeatherForecastInteractor
  implements WeatherForecastInteractorInterface
{
  private readonly repository: WeatherForecastApiInterface;

  /**
   * Initializes a new instance of WeatherForecastInteractor class.
   */
  constructor(repository: WeatherForecastApiInterface) {
    this.repository = repository;
  }

  /** @inheritdoc */
  async getWeatherForecast(): Promise<WeatherForecast[]> {
    return this.repository.getWeatherForecast();
  }
}
