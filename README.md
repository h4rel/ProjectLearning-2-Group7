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
* Button_HideImages.cs -> クリックしたら画像を表示
* Button_ResumeGame.cs -> クリックしたらゲームを再開する(UI->Buttonにアタッチ)
* Button_ShoImages.cs -> クリックしたら画像を非表示
* Button_StopGame.cs -> クリックしたらゲームを一時停止する(UI->Buttonにアタッチ)
* Button_Switch.cs -> クリックしたらボタンを置き換え
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

## バトルーーコマンドパラメータ
武器とアイテムをそれぞれ「Accuracy（精確）」、「Knowledgeable（知識豊富）」、「Logical（論理的）」、「Punctual（時間厳守）」の4つの特性に基づいて一対一での案
### 武器
* Accuracy -> 狙撃スコープ: 攻撃の精度を高め、敵の弱点を正確に狙うことができる。
* Knowledgeble -> 戦略マニュアル: 戦術的なアドバイスを提供し、敵の弱点や戦略を理解する手助けをする。
* Logical -> 推理グローブ: 分析力を強化し、パズルの解決や敵の弱点の見つけ出しに役立つ。
* Punctual -> タイムマシン: 時間の流れを操作し、特定のミッションや戦闘の時間を延長することができる。
### アイテム
* Accuracy -> 精密タイマー: 正確な時間計測を提供し、時間内に効率的にタスクを遂行するのに役立つ。
* Knowledgeble -> 知識の書: 追加の知識やスキルを提供し、複雑な学問や挑戦に対処する手助けをする。
* Logical -> 論理パズルソルバー: 謎解きや推理のヒントを提供し、知力を試す挑戦を支援する。
* Punctual -> 時間の補給剤: 消耗した時間を回復し、ミッションや挑戦の期限を守るのに役立つ。
