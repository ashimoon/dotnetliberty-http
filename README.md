# Description

Extensions and utilities for `System.Net.Http.HttpClient` on .NET and .NET Core.

## Contents
1. Typed extensions for `HttpClient`
2. Synchronous extensions for `HttpClient`
3. `JsonContent<TEntity>` for easy JSON serialization

## 1. Typed extensions for `HttpClient`

`GET`/`POST`/`PUT`/`DELETE` of standard .NET objects using `DataContractJsonSerializer`. (Optional: Supports data contract annotations.)

#### Setup
Declare a model:
```csharp
[DataContract]
public class Thing
{
    [DataMember]
    public int Id { get; set; }

    [DataMember]
    public string SomeProperty { get; set; }
}
```
Import extensions:
```csharp
using DotNetLiberty.Http;
```

Create client:
```csharp
var client = new HttpClient()
    .WithBaseUri(new Uri("http://localhost:5000/api/things/"))
    .AcceptJson();
```
#### GET /api/things/
```csharp
IEnumerable<Thing> things = await client.GetManyAsync<Thing>();
```
#### GET /api/things/1
```csharp
Thing thing = await client.GetSingleAsync<Thing>(1);
```
#### POST /api/things/
```csharp
Thing created = await client.PostAsync(new Thing {
    SomeProperty = "Some value"
});
```
#### PUT /api/things/1
```csharp
Thing updated = await client.PutAsync(1, new Thing {
    Id = 1,
    SomeProperty = "Some value"
});
```
#### DELETE /api/things/1
```csharp
await client.DeleteAsync(1);
```

## 2. Synchronous extensions for `HttpClient`

`System.Net.Http.HttpClient` only supports asynchronous variants of operations out of the box. Rather than handle `Wait`ing and unpacking exceptions we can use synchronous extension methods.

### Setup

Import extensions:
```csharp
using DotNetLiberty.Http.Sync;
```
Create client:
```csharp
var client = new HttpClient()
    .WithBaseUri(new Uri("http://localhost:5000/"));
```

### Samples
```csharp
HttpResponseMessage response = client.Get("");
HttpResponseMessage response = client.Post("", new StringContent(""));
HttpResponseMessage response = client.Put("", new StringContent(""));
HttpResponseMessage response = client.Delete("");
var request = new HttpRequestMessage();
HttpResponseMessage response = client.Send(request);
```

## 3. `JsonContent<TEntity>` for easy JSON serialization

Rather than having to serialize and encode your entities into a `StringContent` instance manually, you can use a `JsonContent<TEntity>(TEntity)` instead.

### Sample

```csharp
Thing thing = new Thing {
    Id = 1,
    SomeProperty = "Some value"
};
StringContent content = new JsonContent<Thing>(thing); 
HttpResponseMessage response = await client.PostAsync("", content);
```


## Website

.NET Liberty - http://dotnetliberty.com

