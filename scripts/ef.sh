#!/bin/zsh

echo "Choose an action:"
echo "1. Migrations"
echo "2. Database"

read -r choice

if [ "$choice" = "1" ]; then
  echo "What do you want to do?"
  echo "1. Add"
  echo "2. Remove"
  
  read -r action
  
  if [ "$action" = "1" ]; then
    echo "What name?"
    read -r name
    dotnet ef migrations add $name -s ../src/Prohelika.API -p ../src/Prohelika.Infrastructure
  else
    echo "What name?"
    read -r name
    dotnet ef migrations remove $name -s ../src/Prohelika.API -p ../src/Prohelika.Infrastructure
  fi
else
  echo "What do you want to do?"
  echo "1. Update"
  echo "2. Drop"
  
  read -r action
  
  if [ "$action" = "1" ]; then
    dotnet ef database update -s ../src/Prohelika.API -p ../src/Prohelika.Infrastructure
  else
    dotnet ef database drop -s ../src/Prohelika.API -p ../src/Prohelika.Infrastructure
  fi
fi
