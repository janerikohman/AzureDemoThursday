# AzureDemoThursday
Azure Demos, learning by doing

Base for a Demo at Cybercom.

Move a local application to different Cloud options
1. On prem version
2. Reading from Blob Storage using SAS and Shared Access Policy instead of local disk
3. Creating a VM in Azure, run app from VM
4. Dockerize it, create Azure Container Registry (ACR), push to ACR, run manually on VM
5. Create Azure Container Instance (on-demand docker host), run Dockerized version from ACI manually
6. Run Dockerized version from ACI by starting it from a Logic App that reacts to events blob storage
7. Add code to Logic App to add information to email when ACI starts
8. Add Code in program to send data to a message queue, update Docker image on ACR
9. Write an Azure Function that are triggered from the queue and stores the data in Table Storage

