# Company Software Store Demo
Demo searching a company store's list of software by semnatic version number.

This demonstration is implemented using ASP.NET Core 2.2 and Vue 2. ASP.NET provides the website and hosts both the restful API this exmaple uses and also the Vue single page application (SPA) that provides the user interface for this example.

## Running the demonstration
1. Clone this solution
2. Navigate into the project folder, "./CompanySoftwareStore/CompanySoftwareStore"
3. Execute the website using the command "dotnet run"
4. Open your web browser and navigate to https://localhost:5001/

## Docker
This project does not include any SSL cert. For now, it supports only HTTP when deployed through docker. If HTTPS is desired, configuring a reverse proxy service to serve this website can provide HTTPS.

1. docker build -f Dockerfile.manual -t company_store:latest .

2. docker run -it -p 5000:80 company_store:latest

You can also specify to run the container in detached mode, of course.


## Troubleshooting
If the user interface renders, but no results are returned despite having provided a valid semantic version number the "Search" button was pressed, you will want to make sure the URL specified in the Vue client application is correct for your hosted server environment. Please review either .env.development or .env.production.

## Known Issues
1. There is a Vue middleware error that presents when this application is run in a docker container by Visual Studio.
2. The project's Dockerfile is not configured with any type of SSL cert to enable HTTPS by Kestrel in a container.
