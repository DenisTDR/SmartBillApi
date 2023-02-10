#!/bin/bash

if [ $# -eq 0 ]; then
  echo "No api key argument supplied. Usage: $0 <api key>"
  exit 1
fi

dotnet nuget push "./publish/*.nupkg" "./publish/*.snupkg" --api-key "$1" --source https://api.nuget.org/v3/index.json --skip-duplicate