import json
import random

def handler(event, context):
    # Log the event argument for debugging and for use in local development.
    print(json.dumps(event, indent=2))

    # 0 から 9 のランダムな値を生成
    random0to9 = random.randint(0, 9)

    # HTMLのレスポンスボディを作成
    body = f"""<!DOCTYPE html>
<html lang="ja">
<head>
    <meta charset="utf-8" />
    <title>Hello Python!</title>
</head>
<body>
    <h1>Hello Python!</h1>
    <p>0 から 9 のランダムな値: {random0to9}</p>
</body>
</html>"""

    # レスポンスを作成
    return {
        "statusCode": 200,
        "headers": {
            "Content-Type": "text/html"
        },
        "body": body
    }
