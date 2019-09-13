# Overview

This repository contains the sample ```ASP.Net``` Core 2.2 Web API and bash scripts that are used in the blog entry [How to Locally Debug a ASP.Net Core Web API that Receives Messages from Azure EventGrid](https://blog.michaeldeongreen.com/how-to-locally-debug-a-asp-net-core-webapi-that-receives-messages-from-azure-eventgrid).

## Demo.WebApi ```ASP.Net``` Core 2.2 Web API

Sample application created in Visual Studio Code that is used to demonstrate how to locally debug a ```ASP.Net``` Core Web API that receives messages from Azure EventGrid.

## create-az-storage-account Bash Script

Bash script used to create an Azure Blob Storage Account and a container called *demo* so a user can create a new Azure EventGrid Blob Created Subscription and upload a file.

To run the script, execute the following command:

```bash
    chmod +x create-az-storage-account.sh &&
    ./create-az-storage-account.sh -r {name_of_resource_group} -l {location} -a {name_of_blob_storage_account}
```

## delete-az-storage-account Bash Script

Bash script used to delete the Azure Resource Group and Azure Blob Storage Account.

To run the script, execute the following command:

```bash
    chmod +x delete-az-storage-account.sh &&
    ./delete-az-storage-account.sh -r {name_of_resource_group}
```