~~現状、Driver ID と Car ID の設定は特に意味なし。 Driver ID:1, Car ID:3, Sensor ID:18 で固定 ~~  
~~これらID の変更はForm1.csを直接いじる必要アリ（←要変更）~~  
リストの変更のみForm1.csの変更をすれば良い。  
ComboBoxにより、IDの変更ができる。    
~~NMEAファイル（○○UnsentNmea.csv）をドラッグ＆ドロップでインサート開始。~~  
NMEAファイルのD&D後に`Start inserting`ボタンでインサート開始できる。  

work⇒ECOLOG内のNMEAフォーマットも参考のこと

# NMEAInserter
NMEAデータをECOLOGDBにインサートするためのプログラム。  

## 使い方
**使う前に、Exception Setting から　Managed Debugging Assistants を切っておくことを推奨。  

1. 各種IDの設定
  - ドロップダウン形式で選択することができる。  
  - リストを追加する場合には、DBとForm1.csの変更が必要
2.  画面上にNMEAファイルをD&Dで配置
  - NMEAファイルのフォーマットはdfs->work->ECOLOG以下を参照  
3. `Start inserting ボタンをクリック`

## 改修2018春
(ほんとはCHANGELOG.mdとか作るべきかもしれない)  
(というか、ここに書く必要ないかもしれない)  

### 変更内容
- DriverID,CarID,SensorIDが固定となっていたのを変更
- SensorIDを選択するためのComboBoxを追加  
- D&Dで処理開始していたのを、ボタンクリックで処理開始に変更  

### TODO
- **DBからリスト取得して、選択できるようにする**  
  DBの更新頻度が少ないので現状のハードコーディングでもそこまで工数多くない  
  優先度はかなり低い  
- **insertData()のリファクタ**
  処理自体に問題はないが、1メソッドが長くて様々な処理を行っている  
  構造の変更と、コードの変更を進める  
  優先度はかなり低い

- Exception Settingを変更しなくても途中停止されなくて済むようにしたい
  クリックイベントからUIに処理が帰ってくるまでが長すぎるのが問題。  
  async awaitなどを使って、処理をUI側に返しておく必要がある。  
  (UIスレッドをバックグラウンド処理が使ってるのが問題?)  
  SensorLogInserterReなどはそこの問題を解決していると推察されるので、それをパクるのが速そう。

