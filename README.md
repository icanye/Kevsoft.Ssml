# Fluent-ish SSML Generator

SSML allows you to build XML easily by using a fluent-ish SSML.

[![install from nuget](http://img.shields.io/nuget/v/SSML.svg?style=flat-square)](https://www.nuget.org/packages/SSML)
[![downloads](http://img.shields.io/nuget/dt/SSML.svg?style=flat-square)](https://www.nuget.org/packages/SSML)
[![Build status](https://ci.appveyor.com/api/projects/status/7ewxi76h3ifbuu6p/branch/master?svg=true)](https://ci.appveyor.com/project/kevbite/kevsoft-ssml/branch/master)


## Getting Started

`SSML` can be installed via the package manager console by executing the following commandlet:

```powershell

PM> Install-Package SSML

```

or by using the dotnet CLI:
```bash

$ dotnet add package SSML

```

## Usage

### Plain text

```csharp

var xml = await new Ssml().Say("Hello")
                .Say("World")
                .ToStringAsync();
```
```xml

<?xml version="1.0" encoding="UTF-8"?>
<speak>Hello World</speak>

```

### Text with Alias

```csharp

 var xml = await new Ssml().Say("Hello")
                .Say("World")
                .AsAlias("Bob")
                .ToStringAsync();
```
```xml

<?xml version="1.0" encoding="UTF-8"?>
<speak>
   Hello
   <sub alias="Bob">World</sub>
</speak>

```

### Emphasise word or phrase

```csharp

var xml = await new Ssml().Say("Hello")
                .Say("World")
                .Emphasised()
                .ToStringAsync();
```
```xml

<?xml version="1.0" encoding="UTF-8"?>
<speak>
   Hello
   <emphasis>World</emphasis>
</speak>

```

### Break

```csharp

var xml = await new Ssml().Say("Take a deep breath")
                .Break()
                .Say("then continue.")
                .ToStringAsync();
```
```xml

<?xml version="1.0" encoding="UTF-8"?>
<speak>
   Take a deep breath
   <break />
   then continue.
</speak>

```


### Say-as Date

```csharp
var date = new DateTime(2017, 09, 15);

var xml = await new Ssml()
                .Say("This code was written on")
                .Say(date).As(DateFormat.YearMonth)
                .ToStringAsync();
```
```xml

<?xml version="1.0" encoding="UTF-8"?>
<speak>
   This code was written on
   <say-as interpret-as="date" format="ym">201709</say-as>
</speak>

```

### Say-as Time

```csharp
var time = new TimeSpan(20, 05, 33);

var xml = await new Ssml().Say("Bedtime is")
                .Say(time).In(TimeFormat.TwentyFourHour)
                .ToStringAsync();
```
```xml

<?xml version="1.0" encoding="UTF-8"?>
<speak>
   Bedtime is
   <say-as interpret-as="time" format="hms24">20:05:33</say-as>
</speak>

```


### Say-as Telephone

```csharp
var xml = await new Ssml()
                .Say("If you require a new job, please phone")
                .Say("+44 (0)114 273 0281").AsTelephone()
                .ToStringAsync();
```
```xml

<?xml version="1.0" encoding="UTF-8"?>
<speak>
   If you require a new job, please phone
   <say-as interpret-as="telephone">+44 (0)114 273 0281</say-as>
</speak>

```

### More usages

For full set of usages checkout the unit tests within the `Kevsoft.Ssml.Tests` project.

## Contributing

1. Fork
1. Hack!
1. Pull Request
