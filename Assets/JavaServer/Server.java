import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.HashMap;
import java.util.Map;

public class Server {
    private static Map<String, ServerCommand> commandMap = new HashMap<>();

    static {
    	commandMap.put("FETCH_RANKING1", new FetchRanking1Command());
    	commandMap.put("FETCH_RANKING2", new FetchRanking2Command());
    	commandMap.put("FETCH_RANKING3", new FetchRanking3Command());
    	commandMap.put("FETCH_RANKING4", new FetchRanking4Command());
    	commandMap.put("INSERT_RANKING1", new InsertRankingCommand("ranking1", "player_name"));
        commandMap.put("INSERT_RANKING2", new InsertRankingCommand("ranking2", "team_name"));
        commandMap.put("INSERT_RANKING3", new InsertRankingCommand("ranking3", "team_name"));
        commandMap.put("INSERT_RANKING4", new InsertRankingCommand("ranking4", "team_name"));
    }
    
    public static void main(String[] args) throws IOException {
        int port = MyVariables.PORT;//MyVariables.PORTからポート番号を取得して、port変数に設定
        ServerSocket serverSocket = new ServerSocket(port);//指定したポート番号で新しいServerSocketオブジェクトを作成
        System.out.println("Server is running...");

        try {
            while (true) {
                Socket clientSocket = serverSocket.accept();//クライアントからの接続を待つ
                //入出力ストリームの作成
                PrintWriter writer = new PrintWriter(clientSocket.getOutputStream(), true);
                BufferedReader reader = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
                
                new Thread(() -> handleClient(clientSocket, writer, reader)).start();//クライアントからの入力を受け取り、その内容に基づいて適切なアクションを実行
            }
        } finally {
            serverSocket.close();//サーバーソケットをクローズ
        }
    }
    
    private static void handleClient(Socket clientSocket, PrintWriter out, BufferedReader in) {
        try {
        	//クライアントからの入力を行単位で読み取る
            String inputLine;
            while ((inputLine = in.readLine()) != null) {
            	// BOMを取り除く
                if (inputLine.charAt(0) == '\uFEFF') {
                    inputLine = inputLine.substring(1);
                }
            	//クライアントからのメッセージを受け取り、その内容を解析してコマンドと引数に分割
                    System.out.println("Received message: " + inputLine);
                    String[] parts = inputLine.split(":", 2);
                    String command = parts[0];
                    String args = parts.length > 1 ? parts[1] : "";
                    //コマンドの実行
                    ServerCommand cmd = commandMap.get(command);
                    if (cmd != null) {
                        cmd.execute(out, args);
                    } else {
                        out.println("Unknown command: " + command);
                        System.out.println("Unknown command: " + command);
                    }
                }
        } catch (IOException e) {
            System.out.println("Error handling client: " + e.getMessage());
        }
    }
}
