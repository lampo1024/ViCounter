# ViCounter
A middleware for counting the number of visitors written in .net core 2+.


## Install

```
Install-Package ViCounter -Version 1.0.0
```

or

```
dotnet add package ViCounter --version 1.0.0
```

## Usage

Startup.cs

1. Configure `ConfigureServices`:

```
public void ConfigureServices(IServiceCollection services)
{
    // ... your application config here
    
    // add ViCounter service
    services.AddViCounter();
    // or override default ViCounterOptions with parameter
    //services.AddViCounter(new ViCounterOptions { RefreshInterval = 5, ActivityDuration = 10 });
    
    
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
}
```

2. Use ViCounter in `public void Configure(IApplicationBuilder app, IHostingEnvironment env)` method

```
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    // ...your application config here
    
    // use ViCounter
    app.UseViCounter();

    app.UseMvc();
}
```

## Access data from public api

You can access some interesting data through the api, e.g.:

```
Get the number of current online users: @(CounterProcessor.VisitorNumber)
```

```
Refresh interval:@(ViCounterSettings.RefreshInterval)
```

```
Activity duration:@(ViCounterSettings.ActivityDuration)
```

List the information of each online user:

```
<ul>
    @foreach (var v in CounterProcessor.VisitorList)
    {
        <li>ID:@v.Id,Expired at:@v.ExpiredAt</li>
    }
</ul>
```

> NOTE: This middleware requires browsers to support cookies, or each request will be treated as a separate user.