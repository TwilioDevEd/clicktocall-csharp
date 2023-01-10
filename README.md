<a  href="https://www.twilio.com">
<img  src="https://static0.twilio.com/marketing/bundles/marketing/img/logos/wordmark-red.svg"  alt="Twilio"  width="250"  />
</a>

# Click to Call with ASP.NET MVC and Twilio

> This repository is archived and no longer maintained. Check out the [Twilio Voice](https://www.twilio.com/docs/voice/) docs for links to other tutorials. 

## Set up

### Requirements

- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework/net472)
- A Twilio account - [sign up](https://www.twilio.com/try-twilio)
- [ngrok](https://ngrok.com/)

### Twilio Account Settings

This application should give you a ready-made starting point for writing your
own application. Before we begin, we need to collect
all the config values we need to run the application:

| Config&nbsp;Value | Description                                                                                                                                                  |
| :---------------- | :----------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Account&nbsp;Sid  | Your primary Twilio account identifier - find this [in the Console](https://www.twilio.com/console).                                                         |
| Auth&nbsp;Token   | Used to authenticate - [just like the above, you'll find this here](https://www.twilio.com/console).                                                         |
| Phone&nbsp;number | A Twilio phone number in [E.164 format](https://en.wikipedia.org/wiki/E.164) - you can [get one here](https://www.twilio.com/console/phone-numbers/incoming) |

### Local development

After the above requirements have been met:

1. Clone this repository and `cd` into it

```bash
git clone https://github.com/TwilioDevEd/clicktocall-csharp.git
cd clicktocall-csharp
```

2. Set your configuration variables

```bash
copy ClickToCall.Web/Local.config.example ClickToCall.Web/Local.config
```

See [Twilio Account Settings](#twilio-account-settings) to locate the necessary environment variables.

3. Endpoints like `https://<your-ngrok-subdomain>.ngrok.io/Call/Connect` needs to be publicly accessible. [We recommend using ngrok to solve this problem](https://www.twilio.com/blog/2015/09/6-awesome-reasons-to-use-ngrok-when-testing-webhooks.html). Set up and run ngrok: `ngrok http 1430 host-header="localhost:1430"` (or use the [ngrok Visual Studio extension](https://marketplace.visualstudio.com/items?itemName=DavidProthero.NgrokExtensions))

4. Be sure to update the "PublicUrl" AppSetting in `ClickToCall.Web/Local.config` to match your ngrok URL (without a trailing slash).

5. Build the solution

6. Run the application

7. Navigate to `https://<your-ngrok-subdomain>.ngrok.io`

That's it!

## Resources

- The CodeExchange repository can be found [here](https://github.com/twilio-labs/code-exchange/).

## License

[MIT](http://www.opensource.org/licenses/mit-license.html)

## Disclaimer

No warranty expressed or implied. Software is as is.

[twilio]: https://www.twilio.com
