/* tslint:disable */
/* eslint-disable */
/**
 * Weather forecast API
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


import * as runtime from '../runtime';
import type {
  ProblemDetails,
  WeatherForecast,
} from '../models';
import {
    ProblemDetailsFromJSON,
    ProblemDetailsToJSON,
    WeatherForecastFromJSON,
    WeatherForecastToJSON,
} from '../models';

/**
 * WeatherForecastApi - interface
 * 
 * @export
 * @interface WeatherForecastApiInterface
 */
export interface WeatherForecastApiInterface {
    /**
     * 
     * @summary Gets whether forecast list.
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof WeatherForecastApiInterface
     */
    getWeatherForecastRaw(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Array<WeatherForecast>>>;

    /**
     * Gets whether forecast list.
     */
    getWeatherForecast(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Array<WeatherForecast>>;

}

/**
 * 
 */
export class WeatherForecastApi extends runtime.BaseAPI implements WeatherForecastApiInterface {

    /**
     * Gets whether forecast list.
     */
    async getWeatherForecastRaw(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Array<WeatherForecast>>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        const response = await this.request({
            path: `/api/v1/weatherforecast`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => jsonValue.map(WeatherForecastFromJSON));
    }

    /**
     * Gets whether forecast list.
     */
    async getWeatherForecast(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Array<WeatherForecast>> {
        const response = await this.getWeatherForecastRaw(initOverrides);
        return await response.value();
    }

}