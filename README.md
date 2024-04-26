# Localization Service

This library provides a localization service for Unity3D. It includes several classes that work together to provide localization features.

## Dependencies

This library depends on the following packages:
- TextMeshPro
  [ LiteNinja Injection](https://github.com/sponticelli/LiteNinja-Injection.git)

## Classes

### ILocalizationService

This is an interface that defines the methods and properties that a localization service should have.
It includes methods for getting localized text, getting and setting the current language, getting the default language, and getting the available languages. It also includes an event that is triggered when the current language is changed.

### LocalizationDictionary

This class represents a localization dictionary for a specific language.
It includes methods for initializing the dictionary and getting the text for a given key. It also includes properties for getting the language that the dictionary is for and the terms in the dictionary.

### Term

This class represents a key-value pair for a localized text.
It includes properties for getting the key and the value of the term.

### LocalizationSettings

This class is a scriptable object that contains the localization settings for the application.
It includes the default language and the dictionaries for each language. It includes methods for getting the dictionary for a specific language and the default dictionary.

### LocalizationService

This class provides localization services for the application.
It implements the ILocalizationService interface. It includes methods for getting localized text, and properties for getting and setting the current language, getting the default language, and getting the available languages.
It also includes an event that is triggered when the current language is changed.

### LocalizeTextMeshProUGUI

This class is responsible for localizing TextMeshProUGUI components.
It listens to language change events from the localization service and updates the text accordingly.

## Usage

To use these classes, you would typically create an instance of the `LocalizationService` class and use it to get localized text. For example:

```csharp
var settings = new LocalizationSettings();
var service = new LocalizationService(settings);
var text = service.GetText("hello");
```

You can also change the current language by setting the `CurrentLanguage` property:

```csharp
service.CurrentLanguage = SystemLanguage.Spanish;
```

And you can listen to the `LanguageChanged` event to know when the current language has been changed:

```csharp
service.LanguageChanged += () =>
{
    // Do something when the language is changed
};
```

The `LocalizeTextMeshProUGUI` class can be used to automatically update the text of a TextMeshProUGUI component when the current language is changed.
To use it, attach it to the same GameObject as the TextMeshProUGUI component, and set the `Key` property to the key of the localized text.