FROM mcr.microsoft.com/dotnet/sdk:8.0

# RD: NOTE -- I am creating a Dockerfile and adding it to this REPO so that we can simulate, and test changes to 
# CICD and test them locally, before committing to GitHub. This helps tremendously with testing, and reduces the amount
# of times we would need to create new commits in case of issues.

# RD: Not putting into .gitignore so that we can have it accessible for others to follow behind and test.

# Install essential dependencies including those required for Chrome headless mode on Linux
RUN apt-get update && apt-get install -y wget gnupg libnss3 libxss1 libappindicator3-1

# Install Chrome
RUN wget -q -O - https://dl.google.com/linux/linux_signing_key.pub | apt-key add -
RUN echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" \
    >> /etc/apt/sources.list.d/google-chrome.list
RUN apt-get update && apt-get install -y google-chrome-stable

# Create and switch to /app directory
WORKDIR /app

# Copy everything from your repo into /app in the container
COPY . ./

# Restore dependencies
RUN dotnet restore

# Build in Release mode
RUN dotnet build --configuration Release --no-restore

# Default command: run the tests
CMD ["dotnet", "test", "--configuration", "Release", "--no-build", "--logger:console;verbosity=detailed"]