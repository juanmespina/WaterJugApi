# WaterJug Game Api
This is a asp .net api for the Chicks Gold test.

## Steps to test
1. Go to root folder.
2. Use command line and run dotnet restore
3. Then run dotnet watch.
4. Go to postman and make a post request to the endpoint https://localhost:7003/WaterJugGame and sending parameters through body using raw option. An example below:

```
{
    "x":3,
    "y":50,
    "z":21
}
\\Being x the first jug, y the second jug and z the desired qty of water.
```

4. Wait for the result. It will be in json format.

## Explanation

The api tries to solve the water jug problem detecting the smaller jug and then
runs the following validations:
* Check if at least one of the jugs is bigger than the desired filling amount.
* Checks if x, y and z are bigger than zero.
* Checks if the smaller jug and the desired quantity have least common divisor.

If one of the options are not met, the api will return not solution.


### Done by Juan Espina for Chicks gold.