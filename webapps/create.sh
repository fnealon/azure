# Show the resource group details
az group show --name navpack
az appservice plan create --name appServicePlan -g navpack --sku F1
# [] flattens the array returning all names only
az appservice plan list --query '[].name' 
# to filter base on a value az appservice plan list --query "[?filter=='value'].properties"
az appservice plan list --query "[?name=='appServicePlan'].name"
# to query am object { and children .}


# Create webapp. default is .net framework . 
az webapp create -g navpack --plan appServicePlan --name alpineSkiHouses
az webapp show  --query 'siteConfig.scmType'
#
# Deploy Options zip, local-git, github 
#1. Compress-Archive file.in out.zip and Expand-Archive out.zip
az webapp deployment source config-zip --src .\out.zip --name alpineSkiHouses -g navpack
# git remote -v #  https://github.com/fnealon/azure.git
# git remote add <url>  | git remote set-url --add origin "https://slottyme@alpineskihouses.scm.azurewebsites.net/alpineSkiHouses.git"

az webapp deployment source config-local-git # returns .git url - git remote set-url add origin https://slottyme@webapp.scm.azurewebsites.net/webapp 
# set a deployment username and password or get the app credentials
$username = "fnealon" # in cli export username="fnealon"
$password = "0penSays8e"
az webapp deployment user set --user-name $username  --password $password 
# app credentials - returns url for publishing. i did not have success with this. 
az webapp deployment list-publishing-credentials --name alpineSkiHouses --resource-group navpack --query scmUri --output tsv
# Configure local Git and get deployment URL... url=$(az webapp deployment source config-local-git --name $webappname --resource-group myResourceGroup --query url --output tsv)
# conflict deployment settings with local-git. set PropertyName="siteConfig.scmType")
az webapp deployment source config --repository-type git -u https://github.com/fnealon/azure.git -g navpack --name alpineSkiHouses


# stream logs
az webapp log tail -g navpack -n alpineSkiHouses