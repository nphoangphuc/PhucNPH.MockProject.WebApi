#!/usr/bin/env bash


cd PhucNPH.MockProject.Repository

echo "Please enter migration name:"
read migrationName

dotnet ef migrations add "${migrationName}" -c AppDbContext