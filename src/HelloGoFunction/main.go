package main

import (
	"fmt"
	"math/rand"
	"time"

	"github.com/aws/aws-lambda-go/events"
	"github.com/aws/aws-lambda-go/lambda"
)

func handler(request events.APIGatewayProxyRequest) (events.APIGatewayProxyResponse, error) {
	// 乱数のシードを設定
	rand.Seed(time.Now().UnixNano())

	// 0から9のランダムな数値を生成
	random0to9 := rand.Intn(10)

	// HTMLのレスポンスボディを作成
	body := fmt.Sprintf(`<!DOCTYPE html>
<html lang="ja">
<head>
    <meta charset="utf-8" />
    <title>Hello Go!</title>
</head>
<body>
    <h1>Hello Go!</h1>
    <p>0 から 9 のランダムな値: %d</p>
</body>
</html>`, random0to9)

	// レスポンスを返す
	return events.APIGatewayProxyResponse{
		StatusCode: 200,
		Headers: map[string]string{
			"Content-Type": "text/html",
		},
		Body: body,
	}, nil
}

func main() {
	lambda.Start(handler)
}
