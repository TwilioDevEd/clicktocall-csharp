﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml.Linq;
using TestStack.FluentMVCTesting;
using Twilio.AspNet.Mvc;

namespace ClickToCall.Web.Tests.Extensions
{
    public static class ControllerResultTestExtensions
    {
        public static TwiMLResult ShouldReturnTwiMLResult<T>(
            this ControllerResultTest<T> controllerResultTest) where T : Controller
        {
            controllerResultTest.ValidateActionReturnType<TwiMLResult>();
            return (TwiMLResult)controllerResultTest.ActionResult;
        }

        public static TwiMLResult ShouldReturnTwiMLResult<T>(
            this ControllerResultTest<T> controllerResultTest,
            Action<XDocument> assertion) where T : Controller
        {
            controllerResultTest.ValidateActionReturnType<ActionResult>();

            var twiMLResult = (TwiMLResult)controllerResultTest.ActionResult;
            var xdocument = twiMLResult.Data as XDocument;

            assertion(xdocument);

            return (TwiMLResult)controllerResultTest.ActionResult;
        }
    }
}
