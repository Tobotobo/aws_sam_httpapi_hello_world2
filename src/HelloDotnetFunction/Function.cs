using System;
using System.Collections.Generic;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Function
{
    public class Function
    {
        public Dictionary<string, object> FunctionHandler(dynamic eventTrigger)
        {
            Console.WriteLine(eventTrigger);

            // 0 から 9 のランダムな値を生成
            Random random = new Random();
            int random0to9 = random.Next(0, 10);

            // HTMLのレスポンスボディを作成
            string body = $@"<!DOCTYPE html>
<html lang=""ja"">
<head>
    <meta charset=""utf-8"" />
    <title>Hello .NET!</title>
</head>
<body>
    <h1>Hello .NET!</h1>
    <p>0 から 9 のランダムな値: {random0to9}</p>
</body>
</html>";

            // レスポンスをディクショナリで作成
            return new Dictionary<string, object>
            {
                { "statusCode", 200 },
                { "headers", new Dictionary<string, string> { { "Content-Type", "text/html" } } },
                { "body", body }
            };
        }
    }
}
