﻿#!/bin/bash

cd PlayGround

nvm install 8.0.0

nvm use 8.0.0

npm install

dotnet build

dotnet test
