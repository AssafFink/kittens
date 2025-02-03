# Inherit existing Microsoft image from Microsoft hub (MCR = Microsoft Container Registry):
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Create directory inside the image for containing our app and setting it as the current-directory:
WORKDIR /src

# Copy only project file (Kittens REST API.csproj) containing NuGet installations: 
COPY ["Kittens REST API.csproj", "/src"]

# Restore NuGet packages from the .csproj inside the image (RUN = running cmd commands inside the image):
RUN dotnet restore "Kittens REST API.csproj"

# Copy our project from local folder (.) into /app insdie the image: 
COPY . /src

# Build project output without publishing it: 
RUN dotnet build "/src/Kittens REST API.csproj" --configuration Release --output /src/build

# Build and publish project output files + all needed .NET dependencies without the .exe file which called AppHost:
RUN dotnet publish "/src/Kittens REST API.csproj" --configuration Release --output /src/publish /p:UseAppHost=false

# --------------------------------------------------

# Inherit light-weight Microsoft image from Microsoft hub:
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Create regular Linux user with regular privileges (--create-home = create a folder for that user in the home folder, --shell = use bash as your terminal):
#RUN useradd --create-home --shell /bin/bash JohnBryce

# Switch from root user to JohnBryce user: 
#USER JohnBryce

# Create directory inside the image for containing our app and setting it as the current-directory:
WORKDIR /app

COPY --from=build /src/publish /app

# --------------------------------------------------

# Run application when container starts: 
ENTRYPOINT ["dotnet", "/app/Kittens REST API.dll"]

# --------------------------------------------------
