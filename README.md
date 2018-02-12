# Fone Dynamics Client Library for .NET

.NET 4.5 client library for [Fone Dynamics](https://www.fonedynamics.com/) services.  This library currently supports messaging only.

## Installing the Fone Dynamics Client Library for .NET

The easiest way to get started is to use the NuGet Package Manager to install the `FoneDynamics` package.

You can also use the Package Manager Console by running the following command.

```
Install-Package FoneDynamics
```

## Authentication

There are two ways to set up authentication with your Fone Dynamics account.

### Method 1: Use Application Settings

In your App.config or Web.config file, under the `appSettings` element, add the following keys.

```xml
<add key="FoneDynamics.AccountSid" value="YOUR_ACCOUNT_SID" />
<add key="FoneDynamics.Token" value="YOUR_TOKEN" />
<add key="FoneDynamics.DefaultPropertySid" value="YOUR_PROPERTY_SID" />
```

Note that the `FoneDynamics.DefaultPropertySid` is optional. If you have multiple properties you should omit this setting and specify it explicitly when interacting with the client library.

### Method 2: Use FoneDynamicsClient

You can define your authentication credentials on startup of your application by initializing `FoneDynamicsClient` as below. This will statically initialize authentication for the entire application.

```cs
// initialize the Fone Dynamics client library
FoneDynamicsClient.Initialize("YOUR_ACCOUNT_SID", "YOUR_TOKEN", "OPTIONAL_DEFAULT_PROPERTY_SID");
```

Alternatively, if you need to interact with multiple Fone Dynamics accounts, you can construct an instance of `FoneDynamicsClient` for a specific account and explicitly pass this as an argument when interacting with the client library.

## Usage

### Sending a message

To send a message, use `MessageResource.Send()`.  The response will contain details of the message that has been sent.

```cs
// send the message. use from: null to auto-allocate a sender ID
MessageResource msg = MessageResource.Send("+61499999999", from: null, text: "Hello world!");

// log details of sent message to console
Console.WriteLine($"Sent message with MessageSid: {msg.MessageSid} From: {msg.From} To: {msg.To} Text: {msg.Text}");
```

### Getting a message

To get the details of a message that has been sent or received, use `MessageResource.Get()`.

```cs
// get a message by its MessageSid
string messageSid = "MGTBUEHNLFOOHNSIOCSAQRRUKLMEZSLE";
MessageResource msg = MessageResource.Get(messageSid);

// log details of message to console
Console.WriteLine($"Fetched message. MessageSid: {msg.MessageSid} From: {msg.From} To: {msg.To} Text: {msg.Text}");
```

## Documentation

IntelliSense documentation is included for all methods and parameters.

For additional documentation, please see the [Fone Dynamics REST API Documentation](https://www.fonedynamics.com/docs/rest-api).
