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
* FieldScene -> フィールド画面

## ソースファイル(アルファベット順)
* Forever_ChaseCamera.cs -> ずっとカメラが追いかける(視点をプレイヤーに固定する)
* Forever_Escape.cs -> ずっと逃げる
* OnCollision_SwitchScene.cs -> 衝突したら画面遷移
* OnKeyPress_ChangeAnime.cs -> 十字キーでアニメーションの方向転換
* OnMouseDown_Hide.cs -> クリックしたらゲームオブジェクトを非表示にする
* OnMouseDown_Show.cs -> クリックしたらゲームオブジェクトを表示する
* OnMouseDown_SwitchScene.cs -> クリックしたら画面遷移
* PlayerController.cs -> 十字キーで移動
* Sometime_Flip.cs -> ときどき反転する
* Sometime_Turn.cs -> ときどき方向転換する