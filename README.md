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

