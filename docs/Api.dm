# Weather api

- [Weather API](#weather-api)
  - [Weather](#weather)
   - [GET Weather](#getweather)
     - [Weather Request](#getweather-request)
     - [Weather Response](#getweather-response)


## GET Weather

```js
GET {{host}}/Weather/Forecast
```

### Weather Request
```js
{
 "city": "Brisbane",
 "statecode": "QLD",
 "postcode": "4000",
 "countrycode": "AU"
}
```


### Weather Response

to get geo information, we should use http://api.openweathermap.org/geo/1.0/zip?zip=E14,GB&appid={API key}

to get the weather information, we should use https://api.openweathermap.org/data/2.5/weather?lat=44.34&lon=10.99&appid={API key}