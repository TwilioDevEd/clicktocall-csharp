# Click-To-Call - ASP.NET MVC: Converting web traffic into phone calls with Twilio.

[![Build status](https://ci.appveyor.com/api/projects/status/vs9wpc0k3b6c9ixw?svg=true)](https://ci.appveyor.com/project/TwilioDevEd/clicktocall-csharp)

Click-to-call enables your company to convert web traffic into phone calls with the click of a button. Learn how to implement it in minutes.

[Read the full tutorial here](https://www.twilio.com/docs/tutorials/walkthrough/click-to-call/csharp/mvc)!

### Local development

1. First clone this repository and `cd` into its directory:
   ```
   git clone git@github.com:TwilioDevEd/clicktocall-csharp.git

   cd clicktocall-csharp
   ```

2. Create a new file ClickToCall.Web/Local.config and update the content with:

   ```
   <appSettings>
        <add key="TwilioAccountSID" value="your_account_SID" />
	    <add key="TwilioAuthToken" value="your_twilio_auth_token" />
	    <add key="TwilioNumber" value="your_twilio_number" />
	    <add key="TestDomain" value="[your-ngrok-subdomain].ngrok.io"/>
   </appSettings>
   ```
  
    Scare about ```[your-ngrok-subdomain]```?. Don't!, see [Using ngrok](#ngrok) section

3. Build the solution.

4. Run the application.

5. Check it out at [http://localhost:1430](http://localhost:1430)

That's it

#### Using ngrok<a name="ngrok">

Endpoints like `/Call/Connect` needs to be publicly accessible. [We recommend using ngrok to solve this problem](https://www.twilio.com/blog/2015/09/6-awesome-reasons-to-use-ngrok-when-testing-webhooks.html).

```
ngrok http 1430 -host-header="localhost:1430"
```

## Meta

* No warranty expressed or implied. Software is as is. Diggity.
* [MIT License](http://www.opensource.org/licenses/mit-license.html)
* Lovingly crafted by Twilio Developer Education.
