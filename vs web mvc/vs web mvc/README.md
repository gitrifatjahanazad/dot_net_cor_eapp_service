
//packages to install use nuget PMC(Package Manager Console)

Install-Package Microsoft.EntityFrameworkCore.Tools
Add-Migration Initial
Update-Database

//in .csproj file under item group tag add
<DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.0" />


//then run from CLI
dotnet ef migrations add InitialCreate
dotnet ef database update

// warnign to drop databases 
dotnet ef database drop