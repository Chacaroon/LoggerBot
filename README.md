# Telegram Logging Service

TelegramLoggingService is a simple cover which provides logging in Telegram.

## Installation

...

## Creation & setting

### 1. The creation of a logger in Telegram.
Ask [@loggariobot](https://t.me/loggariobot) to tune the logger. Click the button "Добавить логгер" in the menu and follow instructions. As the result you'll get Private Token which is important for the next step.

### 2. Adding the logger into the app.
```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    ...

    loggerFactory.AddTelegram("Your Private Token");

    // or

    loggerFactory.AddTelegram("Your Private Token", options => ...);
    
    ...
}
```

## Usage

The logger will automatically send error reports to Telegram. The creator of the logger and all subscribers will be able to get reports. 


## License
...
