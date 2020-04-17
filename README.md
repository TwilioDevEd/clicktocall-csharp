<a href="https://www.twilio.com">
  <img src="https://static0.twilio.com/marketing/bundles/marketing/img/logos/wordmark-red.svg" alt="Twilio" width="250" />
</a>

# Click to Call with ASP.NET MVC and Twilio

[![Build status](https://ci.appveyor.com/api/projects/status/vs9wpc0k3b6c9ixw?svg=true)](https://ci.appveyor.com/project/TwilioDevEd/clicktocall-csharp)

> We are currently in the process of updating this sample template. If you are encountering any issues with the sample, please open an issue at [github.com/twilio-labs/code-exchange/issues](https://github.com/twilio-labs/code-exchange/issues) and we'll try to help you.

Click-to-call enables your company to convert web traffic into phone calls with the click of a button. Learn how to implement it in minutes.

[Read the full tutorial here](https://www.twilio.com/docs/tutorials/walkthrough/click-to-call/csharp/mvc)!

### Local development

1. First clone this repository and `cd` into it.

   ```shell
   $ git clone https://github.com/TwilioDevEd/clicktocall-csharp.git
   $ cd clicktocall-csharp
   ```

2. Copy the `ClickToCall.Web/Local.config.example` file to `ClickToCall.Web/Local.config`, and edit it including your credentials for the Twilio API (found at https://www.twilio.com/console/account/settings). You will also need a [Twilio Number](https://www.twilio.com/console/phone-numbers/incoming).

3. Build the solution.

4. If testing locally, set up and run [ngrok][twilio-ngrok]: `ngrok http 1430 host-header="localhost:1430"` (or use the [ngrok Visual Studio extension][ngrok-vs])

5. Be sure to update the "PublicUrl" AppSetting in `ClickToCall.Web/Local.config` to match your ngrok URL (without a trailing slash).

6. Run the application.

7. Check it out at your ngrok address: https://<your-ngrok-subdomain>.ngrok.io

### Using ngrok

Endpoints like `https://<your-ngrok-subdomain>.ngrok.io/Call/Connect` needs to be publicly accessible. [We recommend using ngrok to solve this problem][twilio-ngrok].

[twilio-ngrok]: https://www.twilio.com/blog/2015/09/6-awesome-reasons-to-use-ngrok-when-testing-webhooks.html
[ngrok-vs]: https://marketplace.visualstudio.com/items?itemName=DavidProthero.NgrokExtensions

## Meta

* No warranty expressed or implied. Software is as is. Diggity.
* The CodeExchange repository can be found [here](https://github.com/twilio-labs/code-exchange/).
* [MIT License](http://www.opensource.org/licenses/mit-license.html)
* Lovingly crafted by Twilio Developer Education.
