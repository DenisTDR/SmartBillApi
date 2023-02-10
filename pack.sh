#!/bin/bash

buildDir="./publish"
dotnet build -c Release
dotnet pack -c Release -o "$buildDir" ./SmartBillApi/SmartBillApi.csproj