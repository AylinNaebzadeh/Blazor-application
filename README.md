# Blazor-application
In the second semester we have been learning a bit c# and our final project was to build a simple CRUD project using [BlazorWebAssembly](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor). Our main ide was vscode but it was better to use visual studio to debug the code. Also we used Postman to check our APIs.Finally we deployed our projects on Heroku and get a free domain which I think won't have an expiration date(despit pythonanywhere) and also we used PostgreSQL to save our data.

Here is my [live Demo](https://blazordb.herokuapp.com/).


More details :

We have runned the below command in cmd to create a project:

```
dotnet new blazorwasm --no-https --hosted

```
It consists of 3 parts, first we want to create a blazorwebassembly not a blazorserver , second we use --no-https to create port 127.0.0.1:5000 and third we used --hosted which create us 3 repos :
```c#
 1- Client
 2- Server
 3- Shared
```
Client is our view part which we can put our HTML and CSS(but it is much better to put your css codes in wwwroot and then reference them in razor pages) codes in Razor files also create a correlation between our models and APIs using c# codes. 

Server is where we code our Controller and Provider also use Http to create APIs.

Shared is where you put your Models why?! when you wanna use something both in Server and Client so it's better to put it in Shared than overwrite it in 2 other sides.

We also add some packages to our project to make it more usefull(Hint : run all this commands in Server side):

```
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 5.0.6
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 5.0.6
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Swashbuckle.AspNetCore --version 5.6.3
```
The last command was to create Swagger and next we had to add some codes to Startup.cs. At the end of ConfigureServices :

```c#
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("a1",new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "API Title Is",
            Version = "a1"
        });
    });
```
At the end of Configure :

```c#
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapRazorPages();
        endpoints.MapControllers();
        endpoints.MapFallbackToFile("index.html");
    });

    app.UseSwagger();
    app.UseSwaggerUI( c => {
        c.SwaggerEndpoint("/swagger/a1/swagger.json","a1 api test");
    });
```

And finally do not forget to use [CorsPolicy](https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api).
In ConfigureServices:

```c#
    services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy",builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    });
```
In Configure:

```c#
    app.UseCors("CorsPolicy");
```

Eventually I am really grateful for my TAs especially our Head-TA who taught  us blazor and helped us in this way.
