Raymond Dasilva - Orum Opportunity

--------------------------------------------------------------------------------------------------------------------------

This REPO is used for Orum web automation testing using Selenium (web) / Mobile (Appium)

Jenkins Integration - At request


Three methods of running tests (amongst many)
*Simply run 'dotnet test' to run the automation tests.*
*Any commit to the repo will also trigger a ci build that runs and ensures all tests pass in order to merge into Main.*
*Clone Repo --> Open solution in VS View --> Test Explorer Run desired Tests (Current runs will yield Parallel results. FireFox + Chrome for quicker execution across different browsers)*

--------------------------------------------------------------------------------------------------------------------------

CI and DOCKER Container

*workflow added*
* Included is a workflow yml that will ensure all tests are passing for every PR submitted. This should happen for any commit, but the individual
tests can be rerun manually if necessary.

*Dockerfile Added for Containerization*
* Included a Dockerfile (which is not in .gitignore) in order to Test and Debug locally before sending into GitHub. This should reduce surprises 
if any commits fail the actions.
* docker build -t orum-tests .
* docker run --rm orum-tests

--------------------------------------------------------------------------------------------------------------------------

Summary and branching strategy

Current Test Cases (3)

Main Branch will be 'Main'

--------------------------------------------------------------------------------------------------------------------------

Potential issues running dotnet test

Issue: Session not created: This version of ChromDriver only supports Chrome Version Blah.\
Solution TLDR: Update your Chrome Version in Settings (AND RELAUNCH Chrome).

Solution Explained: I've taken many steps to let this be plug and play for anyone in Orum cloning the repo, like using a base
Selenium IWebDriver, which takes care of incompatibilities between your environment and Chrome/FireFox. But this error could still come up if you are either too behind, or on an incompatible version that would have needed a direct download.

--------------------------------------------------------------------------------------------------------------------------