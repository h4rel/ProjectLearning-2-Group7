import java.io.PrintWriter;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

interface ServerCommand {
    void execute(PrintWriter out, String args);
}

//データベースへの接続を管理する
class DatabaseManager {
    static Connection getConnection() throws SQLException {
        return DriverManager.getConnection(MyVariables.DB_URL, MyVariables.DB_USERNAME, MyVariables.DB_PASSWORD);
    }
}

class FetchRanking1Command implements ServerCommand {
    @Override
    public void execute(PrintWriter out, String args) {
        try (Connection connection = DatabaseManager.getConnection()) {
            System.out.println("MySQLに接続しました。");

            // スコアが高い順に4つのデータを取得
            PreparedStatement statement = connection.prepareStatement(
                "SELECT player_name, GPA, score FROM ranking1 ORDER BY score DESC LIMIT 4"
            );
            ResultSet resultSet = statement.executeQuery();

            StringBuilder response = new StringBuilder("fetchRankingSuccess");
            while (resultSet.next()) {
                response.append(",")
                        .append(resultSet.getString("player_name"))
                        .append(",")
                        .append(resultSet.getFloat("GPA"))
                        .append(",")
                        .append(resultSet.getFloat("score"));
            }

            out.println(response.toString());

            statement.close();
        } catch (SQLException e) {
            out.println("エラー: ランキングデータの取得に失敗しました。");
            System.out.println("MySQLへの接続に失敗しました。");
            e.printStackTrace();
        }
    }
}

class FetchRanking2Command implements ServerCommand {
    @Override
    public void execute(PrintWriter out, String args) {
        try (Connection connection = DatabaseManager.getConnection()) {
            System.out.println("MySQLに接続しました。");

            // スコアが高い順に4つのデータを取得
            PreparedStatement statement = connection.prepareStatement(
                "SELECT team_name, GPA, score FROM ranking2 ORDER BY score DESC LIMIT 4"
            );
            ResultSet resultSet = statement.executeQuery();

            StringBuilder response = new StringBuilder("fetchRankingSuccess");
            while (resultSet.next()) {
                response.append(",")
                        .append(resultSet.getString("team_name"))
                        .append(",")
                        .append(resultSet.getFloat("GPA"))
                        .append(",")
                        .append(resultSet.getFloat("score"));
            }

            out.println(response.toString());

            statement.close();
        } catch (SQLException e) {
            out.println("エラー: ランキングデータの取得に失敗しました。");
            System.out.println("MySQLへの接続に失敗しました。");
            e.printStackTrace();
        }
    }
}

class FetchRanking3Command implements ServerCommand {
    @Override
    public void execute(PrintWriter out, String args) {
        try (Connection connection = DatabaseManager.getConnection()) {
            System.out.println("MySQLに接続しました。");

            // スコアが高い順に4つのデータを取得
            PreparedStatement statement = connection.prepareStatement(
                "SELECT team_name, GPA, score FROM ranking3 ORDER BY score DESC LIMIT 4"
            );
            ResultSet resultSet = statement.executeQuery();

            StringBuilder response = new StringBuilder("fetchRankingSuccess");
            while (resultSet.next()) {
                response.append(",")
                        .append(resultSet.getString("team_name"))
                        .append(",")
                        .append(resultSet.getFloat("GPA"))
                        .append(",")
                        .append(resultSet.getFloat("score"));
            }

            out.println(response.toString());

            statement.close();
        } catch (SQLException e) {
            out.println("エラー: ランキングデータの取得に失敗しました。");
            System.out.println("MySQLへの接続に失敗しました。");
            e.printStackTrace();
        }
    }
}

class FetchRanking4Command implements ServerCommand {
    @Override
    public void execute(PrintWriter out, String args) {
        try (Connection connection = DatabaseManager.getConnection()) {
            System.out.println("MySQLに接続しました。");

            // スコアが高い順に4つのデータを取得
            PreparedStatement statement = connection.prepareStatement(
                "SELECT team_name, GPA, score FROM ranking4 ORDER BY score DESC LIMIT 4"
            );
            ResultSet resultSet = statement.executeQuery();

            StringBuilder response = new StringBuilder("fetchRankingSuccess");
            while (resultSet.next()) {
                response.append(",")
                        .append(resultSet.getString("team_name"))
                        .append(",")
                        .append(resultSet.getFloat("GPA"))
                        .append(",")
                        .append(resultSet.getFloat("score"));
            }

            out.println(response.toString());

            statement.close();
        } catch (SQLException e) {
            out.println("エラー: ランキングデータの取得に失敗しました。");
            System.out.println("MySQLへの接続に失敗しました。");
            e.printStackTrace();
        }
    }
}

class InsertRankingCommand implements ServerCommand {
    private String tableName;
    private String nameColumn;

    public InsertRankingCommand(String tableName, String nameColumn) {
        this.tableName = tableName;
        this.nameColumn = nameColumn;
    }

    @Override
    public void execute(PrintWriter out, String args) {
        String[] parts = args.split(",");
        if (parts.length != 3) {
            out.println("insertRankingError: Invalid number of arguments");
            return;
        }

        String name = parts[0];
        float gpa;
        float score;

        try {
            gpa = Float.parseFloat(parts[1]);
            score = Float.parseFloat(parts[2]);
        } catch (NumberFormatException e) {
            out.println("insertRankingError: Invalid GPA or score format");
            return;
        }

        try (Connection connection = DatabaseManager.getConnection()) {
            // Check for duplicate
            String checkQuery = "SELECT * FROM " + tableName + " WHERE " + nameColumn + " = ? AND GPA = ? AND score = ?";
            PreparedStatement checkStatement = connection.prepareStatement(checkQuery);
            checkStatement.setString(1, name);
            checkStatement.setFloat(2, gpa);
            checkStatement.setFloat(3, score);
            ResultSet resultSet = checkStatement.executeQuery();

            if (resultSet.next()) {
                out.println("insertRankingError: Duplicate entry");
                return;
            }

            // Insert new record
            String insertQuery = "INSERT INTO " + tableName + " (" + nameColumn + ", GPA, score) VALUES (?, ?, ?)";
            PreparedStatement insertStatement = connection.prepareStatement(insertQuery);
            insertStatement.setString(1, name);
            insertStatement.setFloat(2, gpa);
            insertStatement.setFloat(3, score);
            insertStatement.executeUpdate();

            out.println("insertRankingSuccess");
        } catch (SQLException e) {
            e.printStackTrace();
            out.println("insertRankingError: " + e.getMessage());
        }
    }
}