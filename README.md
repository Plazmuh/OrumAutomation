Raymond Dasilva - Orum Opportunity

--------------------------------------------------------------------------------------------------------------------------

This REPO is used for Orum web automation testing using Selenium (web) / Mobile (Appium)

Jenkins Integration - At request


Two methods of running tests (amongst many)
*Simply run 'dotnet test' to run the automation tests.*
*Clone Repo --> Open solution in VS View --> Test Explorer Run desired Tests (Current runs will yield Parallel results. FireFox + Chrome for quicker execution across different browsers)*

--------------------------------------------------------------------------------------------------------------------------

Summary and branching strategy

Current Test Cases (3)

Main Branch will be 'Main'

--------------------------------------------------------------------------------------------------------------------------

Potential issues running dotnet test

Issue: Session not created: This version of ChromDriver only supports Chrome Version Blah.\
Solution: Update your Chrome Version in Settings (AND RELAUNCH Chrome).

Solution Explained: I've taken many steps to let this be plug and play for anyone in Orum cloning the repo, like using a base
Selenium IWebDriver, which takes care of incompatibilities between your environment and Chrome/FireFox. But this error could still come up if you are either too behind, or on an incompatible version that would have needed a direct download.
