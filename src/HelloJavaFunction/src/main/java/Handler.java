// package 追加
// ※テンプレは無名パッケージだが sam local invoke で java.lang.ClassNotFoundException になる。
// 　template.yaml には Handler: awslambda.javagradle.Handler::handler と記述する。
package awslambda.javagradle;

import java.util.HashMap;
import java.util.Map;
import java.util.Random;

public class Handler {
    public Map<String, Object> handler(Object event) {
        Random random = new Random();
        int random0to9 = random.nextInt(10); // 0から9のランダムな値

        // HTMLのレスポンスボディを作成
        String body = "<!DOCTYPE html>\n" +
                "<html lang=\"ja\">\n" +
                "<head>\n" +
                "    <meta charset=\"utf-8\" />\n" +
                "    <title>Hello Java!</title>\n" +
                "</head>\n" +
                "<body>\n" +
                "    <h1>Hello Java!</h1>\n" +
                "    <p>0 から 9 のランダムな値: " + random0to9 + "</p>\n" +
                "</body>\n" +
                "</html>";

        // レスポンスをマップで作成
        Map<String, Object> response = new HashMap<>();
        response.put("statusCode", 200);

        Map<String, String> headers = new HashMap<>();
        headers.put("Content-Type", "text/html");
        response.put("headers", headers);

        response.put("body", body);

        return response;
    }
}
