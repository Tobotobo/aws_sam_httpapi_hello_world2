require 'json'
require 'logger'

def handler(event:, context:)
  logger = Logger.new($stdout)
  logger.info(JSON.pretty_generate(event))  # JSONを見やすく整形してログ出力

  random0to9 = rand(10)  # 0から9のランダムな整数を生成

  body = <<~HTML
    <!DOCTYPE html>
    <html lang="ja">
    <head>
        <meta charset="utf-8" />
        <title>Hello Ruby!</title>
    </head>
    <body>
        <h1>Hello Ruby!</h1>
        <p>0 から 9 のランダムな値: #{random0to9}</p>
    </body>
    </html>
  HTML

  {
    statusCode: 200,
    headers: {
      'Content-Type' => 'text/html'
    },
    body: body
  }
end
