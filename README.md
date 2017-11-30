# dot_net_cor_eapp_service
A dot net core dummy application hosted in azure app service and amazons elastic beanstack and IBMs managed hosting. Nothing is done yet but soon will be implemented.


*   dotnet core version checking

    ```bash
    dotnet --version
    ```

# Project: "vs web mvc"

*   dot net core running in watch mode. [link](https://github.com/aspnet/Docs/blob/master/aspnetcore/tutorials/dotnet-watch.md)

    >> Change the .csproj like

    ```xml
        <ItemGroup>
            <DotNetCliToolReference  Include="Microsoft.DotNet.Watcher.Tools" Version="2.0.0" />
        </ItemGroup> 
    ```  

    >> then run this in cmd/bash

    ```bash
        dotnet watch run //it only compiles automatically on change
    ```

* connection strings are in applicationsettings.json file
    >> localdb
    ```xml
        "ToDoContext": "Server=(localdb)\\mssqllocaldb;Database=ToDoContext-a74b7b17-c6bd-4645-868a-69cb9d1d1320;Trusted_Connection=True;MultipleActiveResultSets=true"
    ```
    >> sqlexpress
    ```xml
        "ToDoContext": "Server=.\\SQLEXPRESS;Database=ToDoContext-a74b7b17-c6bd-4645-868a-69cb9d1d1320;Trusted_Connection=True;MultipleActiveResultSets=true"
    ```

