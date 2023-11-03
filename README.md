# Serialize Property Serializer

[![openupm](https://img.shields.io/npm/v/com.playdarium.serialize-property-serializer?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.playdarium.serialize-property-serializer/)
<img alt="GitHub" src="https://img.shields.io/github/license/playdarium/serialize-property-serializer">

## Installing

Using the native Unity Package Manager introduced in 2017.2, you can add this library as a package by modifying your
`manifest.json` file found at `/ProjectName/Packages/manifest.json` to include it as a dependency. See the example below
on how to reference it.

### Install via OpenUPM

The package is available on the [openupm](https://openupm.com/packages/com.playdarium.serialize-property-serializer/)
registry.

```
{
  "dependencies": {
    ...
    "com.playdarium.serialize-property-serializer": "1.1.2",
    ...
  },
  "scopedRegistries": [
    {
      "name": "Playdarium",
      "url": "https://package.openupm.com",
      "scopes": [
        "com.playdarium"
      ]
    }
  ]
}
```

### Install via GIT URL

```
"com.playdarium.serialize-property-serializer": "https://gitlab.com/pd-packages/serialize-property-serializer.git#upm"
```

# Usage

Example of usage you can find in [ExampleUsageTest.cs](./Assets/Tests/Editor/ExampleUsageTest.cs)