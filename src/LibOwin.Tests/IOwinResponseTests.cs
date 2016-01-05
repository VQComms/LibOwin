namespace LibOwin.Owin 
{
    using System;
    using Shouldly;
    using Xunit;

    public class IOwinResponseTests 
    {
        [Fact]
        public void When_using_strongly_typed_OnSendingHeaders_it_should_be_invoked_at_sending_headers()
        {
            var owinResponse = new OwinResponse();
            owinResponse.Environment["server.OnSendingHeaders"] = new Action<Action<object>, object>((action, obj) => action(obj));
            owinResponse.OnSendingHeaders(str =>
            {
                str.GetType().ShouldBe(typeof(string));
                str.ShouldBe("Strongly typed!");
            },"Strongly typed!");

            
        }
    }
}