#!/bin/bash

echo -e "Building mpq-packer..."

if [[ "$OSTYPE" == "linux-gnu"* ]]; then
    build="linux-x64"
elif [[ "$OSTYPE" == "msys" ]]; then
    build="win-x64"
fi

dotnet restore mpq-packer.sln

dotnet publish mpq-packer.csproj -c Release --self-contained -r $build -o Build -f netcoreapp3.1 -p:PublishSingleFile=true

cp libs/StormLib.dll Build/StormLib.dll
cp libs/StormLibSharp.dll Build/StormLibSharp.dll