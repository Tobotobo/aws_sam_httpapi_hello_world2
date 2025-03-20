exports.handler = async (event, context) => {
  // Log the event argument for debugging and for use in local development.
  console.log(JSON.stringify(event, undefined, 2));

  // 0 から 9 のランダムな値を生成
  const random0to9 = Math.floor(Math.random() * 10);

  // HTMLのレスポンスボディを作成
  const body = `<!DOCTYPE html>
<html lang="ja">
<head>
    <meta charset="utf-8" />
    <title>Hello NodeJS!</title>
</head>
<body>
    <h1>Hello NodeJS!</h1>
    <p>0 から 9 のランダムな値: ${random0to9}</p>
</body>
</html>`

  // レスポンスを作成
  return {
    statusCode: 200,
    headers: {
      'Content-Type': 'text/html'
    },
    body: body
  };
};
