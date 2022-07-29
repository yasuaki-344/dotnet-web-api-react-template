import { describe, expect, it } from "vitest";
import { WeatherForecastApiInterface } from "../../api-gateways";
import { WeatherForecastInteractor } from "../WeatherForecastInteractor";

describe("WeatherForecastInteractorTest", () => {
  it("constructor", () => {
    const repository = {} as WeatherForecastApiInterface;
    const target = new WeatherForecastInteractor(repository);
    expect(target).not.toBeNull();
  });
});
