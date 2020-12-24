# Goblinfactory.PrettyJson

Cross platform .net core Pretty print Json files to console.

- Automatically detects dark or light backgrounds and uses a suitable default light or dark theme.
- No external dependancies, uses System.Text.Json from .net core. Can be overridden to use your own serializer.
- Configurable themes for light or dark backgrounds.
- Configurable serializer.
- Can set the indenting.
- Can set the number of decimals to Round off display numbers to.
- Super light memory footprint. Based on fast forward Utf8JsonReader. Does not load whole file into memory. Can PrettyPrint gigabyte Json files!

## 1 liner Usage

```csharp

using Goblinfactory.PrettyJson;
new PrettyPrinter(PrettyConfig.Default).PrintJson(myData);

```

## Easy Configuration

```csharp

using Goblinfactory.PrettyJson;
using static System.ConsoleColor;

var config = PrettyConfig.Default;

config.LightStyle.Nulls = Red;
config.DarkStyle.Nulls = Red;
config.NumberOfDecimals = 3;
config.IndentWidth = 4;

new PrettyPrinter(config).PrintJson(myData);

```

