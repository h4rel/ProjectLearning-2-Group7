# 情報共有

## 画面遷移
* TitleScene -> タイトル画面
* LoginScene -> ログイン画面
* SelectGameScene -> ゲーム選択画面
* RankingScene -> ランキング画面
* MatchScene -> マッチング画面
* BattleScene -> 対戦画面
* ResultScene -> リザルト画面
* ShopScene -> 売店の画面
* StartScene -> フィールド画面(モニュメント前)
* Field01Scene -> フィールド画面(都市科学部棟)
* Field02Scene -> フィールド画面(教育~図書館)
* Field03Scene -> フィールド画面(学生センター~理工A)
* Field04Scene -> フィールド画面(理工B~C)
* Field05Scene -> フィールド画面(生協)
* Field06Scene -> フィールド画面(研究棟)
* EndingScene -> ゲーム終了時画面

## ソースファイル(アルファベット順)
* Forever_ChaseCamera.cs -> ずっとカメラが追いかける(視点をプレイヤーに固定する)
* Forever_Escape.cs -> ずっと逃げる
* Forever_MoveH.cs -> ずっと水平移動する
* OnCollision_SwitchScene.cs -> 衝突したら画面遷移
* OnKeyPress_ChangeAnime.cs -> 十字キーでアニメーションの方向転換
* OnMouseDown_Hide.cs -> クリックしたらゲームオブジェクトを非表示にする
* OnMouseDown_Login.cs -> クリックしたらInputTextから入力情報をサーバに送信し、受理されたらログイン完了
* OnMouseDown_Show.cs -> クリックしたらゲームオブジェクトを表示する
* OnMouseDown_SwitchScene.cs -> クリックしたら画面遷移
* PlayerController.cs -> 十字キーで移動
* Sometime_Flip.cs -> ときどき反転する
* Sometime_Turn.cs -> ときどき方向転換する

## ゲームオブジェクトのサイズ設定
* Player1 -> Scale{X:0.5,Y:0.5,Z:0.5}