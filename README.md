# HarbardSDK

.NET Software Development Kit for integrating your HARBARD API compatible traffic monitoring device into your application.<br/>
Provides high level classes and functions indentical to the ones defined in [Harbard API documentation](Docs/HarbardAPI.pdf).
## Compatible devices
- **Einar-5 from** v2.3.0
- **Einar Gen 2** from v1.3.0
- **Carmen Box/Nano** from v1.4.0
- **Enforce Box/Nano** from v1.4.0
- **MicroCAM** Gen 2 from v1.0.0

## Using SDK
In order to use api functions one must aquire a device session through one of the following classes depending on the level of abstraction required.
> [!NOTE] 
> *The available methods are grouped into categories. Each category has a set of methods that can perform an action on the device or query the device for information.*

| Class | Description |
|-----:|-----------|
| ApiSession | Provides high level api functions |
| Session | Providies low level functions for communication |


| Session | Functions | Description |
|-----:|-----------|-----------|
|  | executeCommand(category, method, data?) |  |
|  | executeCommandAsync(category, method, callback, data?) | send blabla |
### High level classes

## Compiling SDK
...

...
### Adding HarbardSDK to a solution
...

## Examples
