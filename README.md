<a href="https://www.twilio.com">
  <img src="https://static0.twilio.com/marketing/bundles/marketing/img/logos/wordmark-red.svg" alt="Twilio" width="250" />
</a>

# Click to Call with ASP.NET MVC and Twilio

[![Build status](https://ci.appveyor.com/api/projects/status/vs9wpc0k3b6c9ixw?svg=true)](https://ci.appveyor.com/project/TwilioDevEd/clicktocall-csharp)

Click-to-call enables your company to convert web traffic into phone calls with the click of a button. Learn how to implement it in minutes.

[Read the full tutorial here](https://www.twilio.com/docs/tutorials/walkthrough/click-to-call/csharp/mvc)!

### Local development

1. First clone this repository and `cd` into it.

   ```shell
   $ git clone git@github.com:TwilioDevEd/clicktocall-csharp.git
   $ cd clicktocall-csharp
   ```

2. Copy the `ClickToCall.Web/Local.config.example` file to `ClickToCall.Web/Local.config`, and edit it including your credentials for the Twilio API (found at https://www.twilio.com/console/account/settings). You will also need a [Twilio Number](https://www.twilio.com/console/phone-numbers/incoming).

3. Build the solution.

4. Run the application.

5. Check it out at [http://localhost:1430](http://localhost:1430)

### Using ngrok

Endpoints like `/Call/Connect` needs to be publicly accessible. [We recommend using ngrok to solve this problem][twilio-ngrok].

[twilio-ngrok]: https://www.twilio.com/blog/2015/09/6-awesome-reasons-to-use-ngrok-when-testing-webhooks.html

```shell
$ ngrok http 1430 -host-header="localhost:1430"
```

## Meta

* No warranty expressed or implied. Software is as is. Diggity.
* [MIT License](http://www.opensource.org/licenses/mit-license.html)
* Lovingly crafted by Twilio Developer Education.
