using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json.Serialization;

using Amazon.Lambda.Core;
using Amazon.Lambda.RuntimeSupport;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Serialization.SystemTextJson;

namespace Function;

public class Function
{
    /// <summary>
    /// Lambdaエントリーポイント
    /// </summary>
    private static async Task Main()
    {
        Func<APIGatewayHttpApiV2ProxyRequest, ILambdaContext, Task<APIGatewayHttpApiV2ProxyResponse>> handler = FunctionHandler;
        await LambdaBootstrapBuilder.Create(handler, new SourceGeneratorLambdaJsonSerializer<LambdaFunctionJsonSerializerContext>())
            .Build()
            .RunAsync();
    }

    public static Task<APIGatewayHttpApiV2ProxyResponse> FunctionHandler(APIGatewayHttpApiV2ProxyRequest apigProxyEvent, ILambdaContext context)
    {
        // 0〜9のランダムな整数を生成
        var random = new Random();
        int random0to9 = random.Next(0, 10);

        // HTMLレスポンスを構築
        var html = $@"<!DOCTYPE html>
<html lang=""ja"">
<head>
    <meta charset=""utf-8"" />
    <title>Hello .NET Native AOT!</title>
</head>
<body>
    <h1>Hello .NET Native AOT!</h1>
    <p>0 から 9 のランダムな値: {random0to9}</p>
</body>
</html>";

        var response = new APIGatewayHttpApiV2ProxyResponse
        {
            StatusCode = 200,
            Headers = new Dictionary<string, string> {
                { "Content-Type", "text/html" }
            },
            Body = html
        };

        return Task.FromResult(response);
    }
}

[JsonSerializable(typeof(APIGatewayHttpApiV2ProxyRequest))]
[JsonSerializable(typeof(APIGatewayHttpApiV2ProxyResponse))]
public partial class LambdaFunctionJsonSerializerContext : JsonSerializerContext
{
}
