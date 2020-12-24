# Goblinfactory.PrettyJson

Cross platform .net core Pretty print Json files to console.

## 1 liner Usage

```csharp

using Goblinfactory.PrettyJson;

new PrettyPrinter(PrettyConfig.CreateDefault()).PrintJson(myData);

```

- Automatically detects dark or light backgrounds. Uses a suitable theme based on current Console background color.
- No external dependancies, uses System.Text.Json from .net core. Can be overridden to use your own serializer.
- Configurable themes for light or dark backgrounds.
- Configurable serializer.
- Can set the indenting.
- Can set the number of decimals to Round off display numbers to.
- Super light memory footprint. Based on fast forward Utf8JsonReader. Does not load whole file into memory. Can PrettyPrint gigabyte Json files!
- Configuration is `per printer`, and not global.
- Useful `.Dump()` extensions for objects and strings that will dump the object or json to console.
- Configurable styling based on property name.

## Great for dumping anonymous types

```csharp

var player = new 


```

## Easy Configuration

```csharp

using Goblinfactory.PrettyJson;
using static System.ConsoleColor;

var config = PrettyConfig.CreateDefault();

config.LightStyle.Nulls = Red;
config.DarkStyle.Nulls = Red;
config.NumberOfDecimals = 3;
config.IndentWidth = 4;

new PrettyPrinter(config).PrintJson(myData);

```

## Super useful `.Dump()` extentions

```


```


## Limitations and final thoughts

- Does not do any encoding other than replace \ with \\, and " with \"
- See `StringExtensions.cs` for the string encoding.
- If you need additional encodings, please submit a PR for me to review and if it makes sense, or extend the configuration to configure diffrerent types of encoding if needed.
- This is a very small project, feel free to fork it and make your own variant. It could easily be entirely encapsulated in a single file.
