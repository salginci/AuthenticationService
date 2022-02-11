#!/bin/sh
echo "Web hook triggered. Pulling from repo"
cd /home/user/AutService/AuthenticationService
git pull origin master 
echo "git pull completed"

dotnet publish -c release -o out
echo "dotnet compile application.! Application is modified as working on port 80"
\cp /home/user/AutService/appsettings.json out/appsettings.json
echo "appsettings.json is copied to out folder"
echo "build docker image"
docker rm $(docker stop $(docker ps -a -q --filter ancestor=authservice --format="{{.ID}}"))
docker rmi -f authservice
echo "remove existing container"
docker build -t authservice .
docker run -d -p 9091:80 --name authservice authservice
echo "Auth service is assigned to port 9091"