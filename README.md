# SSLEngine
[![Build Status](https://dev.azure.com/matthewhope396/SSLEngine/_apis/build/status/Master?branchName=master)](https://dev.azure.com/matthewhope396/SSLEngine/_build/latest?definitionId=1&branchName=master)
[![Build status](https://ci.appveyor.com/api/projects/status/he6ndae88rbxhl9l?svg=true)](https://ci.appveyor.com/project/AtLeastITry/sslengine)

## Getting started
### Referencing the packages
There are two packages you'll need to reference:

- [SSLEngine.Abstraction](https://www.nuget.org/packages/SSLEngine.Abstraction/)
- [SSLEngine.Core](https://www.nuget.org/packages/SSLEngine.Core/)

### Setting up DI
To set up DI all you need to do is call the `AddSSL()` method on the service collection:

#### Example
```c#
public void ConfigureServices(IServiceCollection services)  
{  
	services.AddSSL();
} 
```

### Using the Engine
- To use the engine you'll first need to either Inject the `ISSLEngine` interface or create an instance using the `SSLEngineFactory` class.
- Once you have an instance of the engine you are then able to call the available commands. i.e. Pkcs12 or Req 

### Example
```c#
await sslEngine.Pkcs12Async(
    options: new Pkcs12Options
    {
    	Export = true,
    	In = "example\\test.cer",
    	InKey = "example\\test.key",
    	Out = "example\\test.pfx",
    	PassOut = "pass:1234"
    }
);
```

## Commands implemented so far
- Pkcs12
- Req

## Acknowledgement
 - This product includes software developed by the OpenSSL Project for use in the OpenSSL Toolkit (http://www.openssl.org/)
 - This product includes software written by Tim Hudson (tjh@cryptsoft.com)
