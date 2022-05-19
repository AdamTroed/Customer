#Multi stage docker file - multiple FROM
#Reason - only ship what we need to run

#Base image, underlying image that our eventual container image is built on - putting it in base
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#Restores the dependencies and tools of a project. - putting it in build
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Customer.csproj", ""]
RUN dotnet restore "./Customer.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Customer.csproj" -c Release -o /app/build

#Building a release version of the app - putting it in publish
FROM build AS publish
RUN dotnet publish "Customer.csproj" -c Release -o /app/publish

#Put it all together
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customer.dll"] #Dockerfile directive specifying the executable to run in docker container