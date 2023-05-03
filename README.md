## How to run the code

### Prerequisites

1. .Net Core 7.0 SDK <a href="https://dotnet.microsoft.com/en-us/download/dotnet/7.0">link</a>
2. nUnit Console <a href="https://github.com/nunit/nunit-console/releases/tag/3.16.0">link</a>
3. Chromium driver <a href="https://chromedriver.chromium.org/downloads">link</a>

### Steps to run

1. Place your chrome driver in /SeleniumTests/Driver folder
2. Run in ./
```
dotnet build SeleniumTests
```
3. Find the path to SeleniumTests.dll (look in /bin/Debug/net7.0)
4. Go to the instalation folder of nUnit Console
5. Run
```
${executable for the console} ${path to SeleniumTests.dll}
```