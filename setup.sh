az login
appId=$(az ad app create --display-name "summarize email console app" --public-client-redirect-uris "http://localhost" --query appId -o tsv)
sed -i '' -e "s/CLIENT_ID/$appId/g" Program.cs