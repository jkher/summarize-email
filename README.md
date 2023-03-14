# Email Summarization Tool 📧 - A .NET v7.0 console app connected to Microsoft Graph
[![Hack Together: Microsoft Graph and .NET](https://img.shields.io/badge/Microsoft%20-Hack--Together-orange?style=for-the-badge&logo=microsoft)](https://github.com/microsoft/hack-together)
[![dotnet 7.0](https://img.shields.io/badge/Microsoft-.NET%207.0-blueviolet?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![Microsoft Graph](https://img.shields.io/badge/Microsoft-%20Graph-orangered?style=for-the-badge&logo=Microsoft%20Office)](https://graph.microsoft.com)
[![Microsoft Graph](https://img.shields.io/badge/Azure-%20Cognitive%20Service%20for%20Language-blue?style=for-the-badge&logo=Microsoft%20Azure)](https://azure.microsoft.com/en-us/products/cognitive-services/language-service/)
[![Repo License](https://img.shields.io/github/license/jkher/summarize-email?style=for-the-badge)](https://github.com/jkher/summarize-email/blob/master/LICENSE)
[![Demonstration Video](https://img.shields.io/badge/Video%20Demonstration-b900b4?style=for-the-badge&logo=clyp&logoColor=white)](https://clipchamp.com/watch/HsFW4Nm4xkn)

 - With this console app, you can select any email message from latest 10 messages in your inbox and generate extractive summary of its contents using ***Azure Cognitive Service for Language***. 
 - You can send the generated extractive summary to your inbox for later use.
 - Or you can publish the summary instantly to any of your team channel on Teams. The app provides you the menu options to select a Team you joined and then a Channel under selected team.

---
## Minimal Path to Awesome 🚀

Follow the instructions to successfully run your Email Summarization Tool with Microsoft Graph.

### 1. Register an Azure Active Directory app

Every app that uses Azure AD for authentication must be registered with Azure AD. You can register app through Azure Portal or by using Azure CLI. Please follow one of the options to register your app:

<details open>
  <summary>Option 1: Register an app by using Azure CLI</summary>

* [Install Azure CLI](https://learn.microsoft.com/cli/azure/install-azure-cli?view=azure-cli-latest) if you haven't already.
* Register your app on Microsoft Azure, by creating a new Azure AD app registration:
  * <details>
      <summary>On macOS/Linux/in Bash</summary>

    * Open terminal and change the working directory to the root of this project
    * To make the setup script executable, run `chmod +x ./setup.sh`
    * To register the app, run `./setup.sh`
    * When prompted, sign in with your **Microsoft 365 developer sandbox account**

    </details>
  * <details>
      <summary>On Windows/in PowerShell</summary>

    * Open PowerShell and change the working directory to the root of this project
    * To register the app, run `.\setup.ps1`
    * When prompted, sign in with your **Microsoft 365 developer sandbox account**

    </details>

</details>

<details open>

  <summary>Option 2: Register an app through Azure Portal</summary>

* Go to [Azure Portal](https://portal.azure.com) and login with your testing account that has Application developer or administrator permissions.
* Select **Azure Active Directory**, and select **App Registrations** from the left side bar. Then select **+ New registration**.
* Give any name to your app. For **Supported account types**, select **Accounts in any organizational directory (Any Azure AD directory - Multitenant)**.
* Set the **Redirect URI** drop down to **Public client/native (mobile & desktop)** and enter `http://localhost`. Then, select **Register**.
* Navigate to **Overview** tab and make a note of the **Application (client) ID**. 
* Replace the `CLIENT_ID` in `appsettings.json` file with **Application (client) ID** noted above.

</details>

### 2. Register **Azure Cognitive Service for Language** resource

* Azure subscription - [Create one for free](https://azure.microsoft.com/free/cognitive-services)
* Once you have your Azure subscription, create a Language resource in the Azure portal to get your key and endpoint. 
* You can use the free pricing tier (Free F0) to try the service, and upgrade later to a paid tier for production.
* After it deploys, select Go to resource.
* You will need the key and endpoint from the resource you create to connect your application to the API.
* Replace the `AZURE_LANGUAGE_ENDPOINT` in `appsettings.json` file with **language endpoint** noted above.
* Also, replace the `AZURE_LANGUAGE_ENDPOINT_KEY` in `appsettings.json` file with **language endpoint key** noted above.

### 3. Run your Console app

* Clone the [summerize-email](https://github.com/jkher/summarize-email) repository to your local workspace or directly download the source code.
* Open the project folder `summarize-email` with the editor of your choice. (Visual Studio Code is recommended.)
* Open terminal in project folder and run the tool using `dotnet run` command. 🚀

---
## Video Demonstration 🚀

Click badge below to watch video demonstration.

[![Demonstration Video](https://img.shields.io/badge/Video%20Demonstration-b900b4?style=for-the-badge&logo=clyp&logoColor=white)](https://clipchamp.com/watch/HsFW4Nm4xkn)
