# NMEAInserter
GPSから受信できるデータに含まれるNMEAフォーマットのデータをDBに挿入するためのインサータ

# 仕様・使い方
現状、Driver ID と Car ID の設定は特に意味なし。 Driver ID:1, Car ID:3, Sensor ID:18 で固定。
これらID の変更はForm1.csを直接いじる必要アリ（←要変更）
NMEAファイル（○○UnsentNmea.csv）をドラッグ＆ドロップでインサート開始。

# その他
work⇒ECOLOG内のNMEAフォーマットも参考のこと
