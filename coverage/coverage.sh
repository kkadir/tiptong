#!/bin/bash

cd ..
dotnet clean
dotnet restore
dotnet build /p:DebugType=Full

cd -
dotnet minicover instrument --workdir ../ --assemblies test/**/bin/**/*.dll --sources src/**/*.cs
dotnet minicover reset --workdir ../
dotnet test --no-build ../test/Tiptong.Framework.Domain.Tests/Tiptong.Framework.Domain.Tests.csproj
dotnet minicover uninstrument --workdir ../
dotnet minicover report --workdir ../ --threshold 60