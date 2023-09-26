# Use the official .NET 6 Core SDK image as a build image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the project files into the container
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code into the container
COPY . ./

# Build the application
RUN dotnet publish -c Release -o out

# Use a smaller base image for the runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory inside the container
WORKDIR /app

# Copy the published application from the build image
COPY --from=build /app/out ./

# Specify the command to run when the container starts
ENTRYPOINT ["dotnet", "Web_Api_Learnings.API.dll"]