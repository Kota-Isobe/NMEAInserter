using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace NMEAInserter
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
    {
    }
        public static int driverID = 0, carID = 0, sensorID = 0;
        public static bool nullAllowance;

        // SENSOR_ID
        //public static readonly int SENSOR_ID = 17;  //29=Nexus7(2012)-1
        // カラムの末尾
        public static int END_OF_COLUMN;
        // 作業用変数
        public static String a, b, DataType;
        // インサート用SQL文用変数
        public static String insertQuery;
        // ファイルパス
        private String filePath;
        private List<String> filePathList = new List<String>();

        private void startInsertingButton_Click(object sender, EventArgs e)
        {
            // DRIVER_IDが設定されているかをチェック
            if (driverIDComboBox.SelectedIndex == -1)
            {
                errorCodeLabel.ForeColor = Color.Red;
                errorCodeLabel.Text = "Select Driver ID";
                return;
            }
            // CAR_IDが設定されているかをチェック
            if (carIDComboBox.SelectedIndex == -1)
            {
                errorCodeLabel.ForeColor = Color.Red;
                errorCodeLabel.Text = "Select Car ID";
                return;
            }

            // SENSOR_IDが設定されているかをチェック
            if (sensorIDcomboBox.SelectedIndex == -1)
            {
                errorCodeLabel.ForeColor = Color.Red;
                errorCodeLabel.Text = "Select Sensor ID";
                return;
            }
            // ファイルパスが設定されているかをチェック
            if (filePath == null)
            {
                errorCodeLabel.ForeColor = Color.Red;
                errorCodeLabel.Text = "Select inserting file";
                return;
            }
            
            errorCodeLabel.ForeColor = Color.Blue;
            errorCodeLabel.Text = "Inserting start ...";

            

            /*** Driver ID の決定 ***/
            switch (driverIDComboBox.SelectedIndex)
            {
                #region GUIで選択した名前とdriverIDの対応付け
                // 富井先生
                case 0:
                    driverID = 1;
                    break;
                // 森先生
                case 1:
                    driverID = 4;
                    break;
                // 植村さん
                case 2:
                    driverID = 17;
                    break;
                // 茨城さん
                case 3:
                    driverID = 20;
                    break;
                // 濱崎さん
                case 4:
                    driverID = 21;
                    break;
                // 小池さん
                case 5:
                    driverID = 24;
                    break;
                // 磯部さん
                case 6:
                    driverID = 26;
                    break;
                // 吉瀬
                case 7:
                    driverID = 28;
                    break;
                // 猪谷
                case 8:
                    driverID = 29;
                    break;
                // 勝村
                case 9:
                    driverID = 30;
                    break;
                // 渡辺
                case 10:
                    driverID = 31;
                    break;
                // 石田さん
                case 11:
                    driverID = 32;
                    break;
                // 深野さん
                case 12:
                    driverID = 33;
                    break;
#endregion
            }

            /*** Car ID の決定 ***/
            switch (carIDComboBox.SelectedIndex)
            {
                #region GUIで選択した車と、carIDの対応付け
                // 富井先生のleaf
                case 0:
                    carID = 3;
                    break;
                // leaf?
                case 1:
                    carID = 8;
                    break;
                // 2018春leaf-ZE1
                case 2:
                    carID = 13;
                    break;
                // 2018春DAYZ
                case 3:
                    carID = 12;
                    break;
                #endregion
            }

            /*** sensorIDの決定 ***/
            switch (sensorIDcomboBox.SelectedIndex)
            {
                #region GUIで選択した端末とsensorIDの対応付け
                case 0:
                    sensorID = 1;
                    break;
                case 1:
                    sensorID = 3;
                    break;
                case 2:
                    sensorID = 4;
                    break;
                case 3:
                    sensorID = 6;
                    break;
                case 4:
                    sensorID = 7;
                    break;
                case 5:
                    sensorID = 8;
                    break;
                case 6:
                    sensorID = 9;
                    break;
                case 7:
                    sensorID = 10;
                    break;
                case 8:
                    sensorID = 11;
                    break;
                case 9:
                    sensorID = 12;
                    break;
                case 10:
                    sensorID = 13;
                    break;
                case 11:
                    sensorID = 14;
                    break;
                case 12:
                    sensorID = 15;
                    break;
                case 13:
                    sensorID = 16;
                    break;
                case 14:
                    sensorID = 17;
                    break;
                case 15:
                    sensorID = 18;
                    break;
                case 16:
                    sensorID = 19;
                    break;
                case 17:
                    sensorID = 20;
                    break;
                case 18:
                    sensorID = 21;
                    break;
                case 19:
                    sensorID = 22;
                    break;
                case 20:
                    sensorID = 23;
                    break;
                case 21:
                    sensorID = 24;
                    break;
                case 22:
                    sensorID = 25;
                    break;
                case 23:
                    sensorID = 26;
                    break;
                case 24:
                    sensorID = 27;
                    break;
                case 25:
                    sensorID = 28;
                    break;
                case 26:
                    sensorID = 98;
                    break;
                case 27:
                    sensorID = 99;
                    break;
                #endregion
            }

            /**** Trip ID のNullの許容の確認 ****/
            nullAllowance = this.nullAllowanceCheckBox.Checked;

            Console.WriteLine("Driver ID : " + driverID + ", Car ID : " + carID + ", sensorID : " + sensorID + ", NullAllowance : " + nullAllowance);

            // インサート本処理の呼び出し
            foreach (var filePath in filePathList)
            {
                insertData(filePath, driverID, carID, sensorID, nullAllowance);
            }

            // インサート処理は切り分けるので、コメントアウト
            MessageBox.Show("インサート終了",
            "インサート終了",
             MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else {
                e.Effect = DragDropEffects.None;
            }
        }

        

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            // ファイルが渡されていなければ、何もしない
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            // ファイルが渡されていた場合には、そのファイルパスを変数に格納する。
            foreach (var filePath in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                fileNameLabel.Text = filePath;
                this.filePathList.Add(filePath);
            }
            //string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            // 渡されたファイルに対して処理を行う
            //for (int i = 0; i < files.Length; i++)
            ////Parallel.For(0, files.Length, i =>
            //{
            //    filePath = files[i];
            //    /*foreach (var filePath in (string[])e.Data.GetData(DataFormats.FileDrop))
            //    {
            //        fileNameLabel.Text = filePath;
            //        this.filePath = filePath;*/
            //    insertData(filePath, 1, 3);
            //    //Console.WriteLine("Success : " + filePath + System.Environment.NewLine);

            //}
    //});

            // インサート処理は切り分けるので、コメントアウト
            //MessageBox.Show("インサート終了",
            //"インサート終了",
            // MessageBoxButtons.OK,
            //    MessageBoxIcon.Asterisk);
        }

        private static TextFieldParser GetParser(string filePath)
        {
            TextFieldParser parser = new TextFieldParser(filePath, Encoding.GetEncoding(932))
            {
                TextFieldType = FieldType.Delimited,
                Delimiters = new string[] { "," },
                HasFieldsEnclosedInQuotes = true,
                TrimWhiteSpace = true
            };

            return parser;
        }
        private void insertData(String filePath, int driverID, int carID, int sensorID, bool nullAllowance)
        {
            
            DataTable TRIPS_TABLE = new DataTable();

            /***** NMEAファイルの読み込み Start *****/
            var parser = GetParser(filePath);
            //Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            ////エクセルを非表示
            //ExcelApp.Visible = false;
            ////エクセルファイルのオープン
            //Microsoft.Office.Interop.Excel.Workbooks WorkBooks = ExcelApp.Workbooks;
            //Microsoft.Office.Interop.Excel.Workbook WorkBook = WorkBooks.Open(filePath);

            ////1シート目の選択
            //Microsoft.Office.Interop.Excel.Worksheet sheet = WorkBook.Sheets[1];
            //sheet.Select();
            /***** NMEAファイルの読み込み End *****/

            /***** DBにアクセス *****/

            String connectionString = "Data Source=ECOLOGDB2016;Initial Catalog=ECOLOGDBver3;Integrated Security=True;Connection Timeout=3600";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                /***** TRIPS_TABLE生成 Start *****/
                string query = "SELECT TRIP_ID, START_TIME, END_TIME FROM [ECOLOGDBver2].[dbo].[TRIPS] WHERE DRIVER_ID = " + driverID + " AND CAR_ID = " + carID + "AND SENSOR_ID = " + sensorID;
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(TRIPS_TABLE);
                /***** TRIPS_TABLE生成 End *****/

                // データ挿入
                try
                {
                    int count = 0;
                    // NMEAデータの読み込み
                    while (!parser.EndOfData)//Used～は、行数
                    {
                        count++;
                        string[] fields = parser.ReadFields();
                        //Console.WriteLine(count);
                        indexLabel.Text = Convert.ToString(count);
                        NMEADatum datum = new NMEADatum();
                        //Microsoft.Office.Interop.Excel.Range range = sheet.Cells[i, 2];
                        if (fields[1] != null) DataType = Convert.ToString(fields[1]);

                        //各データタイプごとに、返すDataType値と列の最後を変更
                        if (DataType == "$QZGSV")
                        {
                            String insertQuery = null;
                            String insertQuery2 = null;
                            int len1 = 0;
                            int len2 = 0;
                            String c = null;
                            String d = null;

                            if (fields.Length > 8)
                            {
                                c = Convert.ToString(fields[8]);
                                len1 = c.Length;
                            }
                            
                            if (fields.Length > 12)
                            {
                                d = Convert.ToString(fields[12]);
                                len2 = d.Length;
                            }

                            if (len1 == 3)
                            {
                                DataType = "$QZGSV";  //センテンス数1,センテンスのSN比null
                                END_OF_COLUMN = 9;
                                c = c.Substring(len1 - 2, 2);
                                for (int j = 0; j < END_OF_COLUMN - 1; j++)
                                {
                                    
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt = Convert.ToDateTime(datum.androidTime);
                                    insertQuery = "INSERT INTO QZGSV_RAW VALUES('" + dt + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                   datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                   "','" + datum.elevation + "','" + datum.azimuth + "'," + "NULL" + ",'" + c + "')";
                                }
                            }

                            if (len1 == 5)
                            {
                                DataType = "$QZGSV";  //センテンス数1,センテンスのSN比null
                                END_OF_COLUMN = 9;
                                String g = null;
                                String h = null;
                                if (c != null)
                                {
                                    g = c.Substring(0, 2);
                                    h = c.Substring(len1 - 2, 2);
                                }
                                for (int j = 0; j < END_OF_COLUMN - 1; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt = Convert.ToDateTime(datum.androidTime);
                                    insertQuery = "INSERT INTO QZGSV_RAW VALUES('" + dt + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                   datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                   "','" + datum.elevation + "','" + datum.azimuth + "','" + g + "','" + h + "')";
                                }
                            }

                            if (len1 == 0)
                            {
                                END_OF_COLUMN = 12;//センテンス数2,1センテンス目のSN比null
                                DataType = "$QZGSV-2";
                                for (int j = 0; j < 7; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                String g = null;
                                String h = null;
                                if (d != null && len2!= 0)
                                {
                                    g = d.Substring(0, 2);
                                    h = d.Substring(len2 - 2, 2);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt = Convert.ToDateTime(datum.androidTime);
                                    insertQuery = "INSERT INTO QZGSV_RAW VALUES('" + dt + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                   datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                   "','" + datum.elevation + "','" + datum.azimuth + "'," + "NULL" + ",'" + h + "')";
                                }
                                if (len2 == 3)//センテンス数2,2センテンス目のSN比もnull
                                {
                                    for (int j = 0; j < 4; j++)
                                    {
                                        //range = sheet.Cells[i, j];
                                        datum.setDatumByIndex(j, fields[j], DataType);
                                    }
                                    for (int j = 9; j < END_OF_COLUMN - 1; j++)
                                    {
                                        //range = sheet.Cells[i, j];
                                        datum.setDatumByIndex(j, fields[j], DataType);
                                    }
                                    if (datum.androidTime != null)
                                    {
                                        DateTime dt2 = Convert.ToDateTime(datum.androidTime);
                                        insertQuery2 = "INSERT INTO QZGSV_RAW VALUES('" + dt2 + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                       datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                       "','" + datum.elevation + "','" + datum.azimuth + "'," + "NULL" + ",'" + h + "')";
                                    }
                                }
                                if (len2 == 5)//センテンス数2
                                {
                                    for (int j = 0; j < 4; j++)
                                    {
                                        //range = sheet.Cells[i, j];
                                        datum.setDatumByIndex(j, fields[j], DataType);
                                    }
                                    for (int j = 9; j < END_OF_COLUMN - 1; j++)
                                    {
                                        //range = sheet.Cells[i, j];
                                        datum.setDatumByIndex(j, fields[j], DataType);
                                    }
                                    if (datum.androidTime != null)
                                    {
                                        DateTime dt2 = Convert.ToDateTime(datum.androidTime);
                                        insertQuery2 = "INSERT INTO QZGSV_RAW VALUES('" + dt2 + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                       datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                       "','" + datum.elevation + "','" + datum.azimuth + "','" + g + "','" + h + "')";
                                    }
                                }
                            }

                            if (len1 == 2)//センテンス数2
                            {
                                END_OF_COLUMN = 12;
                                DataType = "$QZGSV-2";
                                for (int j = 0; j < 8; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                String g = null;
                                String h = null;
                                if (d != null && len2 > 2)
                                {
                                    g = d.Substring(0, 2);
                                    h = d.Substring(len2 - 2, 2);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt = Convert.ToDateTime(datum.androidTime);
                                    insertQuery = "INSERT INTO QZGSV_RAW VALUES('" + dt + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                   datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                   "','" + datum.elevation + "','" + datum.azimuth + "','" + datum.SNRatio + "','" + h + "')";
                                }
                                if (len2 == 3)//センテンス数2,2センテンス目のSN比null
                                {
                                    for (int j = 0; j < 4; j++)
                                    {
                                        //range = sheet.Cells[i, j];
                                        datum.setDatumByIndex(j, fields[j], DataType);
                                    }
                                    for (int j = 9; j < END_OF_COLUMN - 1; j++)
                                    {
                                        //range = sheet.Cells[i, j];
                                        datum.setDatumByIndex(j, fields[j], DataType);
                                    }
                                    if (datum.androidTime != null)
                                    {
                                        DateTime dt2 = Convert.ToDateTime(datum.androidTime);
                                        insertQuery2 = "INSERT INTO QZGSV_RAW VALUES('" + dt2 + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                       datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                       "','" + datum.elevation + "','" + datum.azimuth + "'," + "NULL" + ",'" + h + "')";
                                    }
                                }
                                if (len2 == 5)//センテンス数2
                                {
                                    for (int j = 0; j < 4; j++)
                                    {
                                        //range = sheet.Cells[i, j];
                                        datum.setDatumByIndex(j, fields[j], DataType);
                                    }
                                    for (int j = 9; j < END_OF_COLUMN - 1; j++)
                                    {
                                        //range = sheet.Cells[i, j];
                                        datum.setDatumByIndex(j, fields[j], DataType);
                                    }
                                    if (datum.androidTime != null)
                                    {
                                        DateTime dt2 = Convert.ToDateTime(datum.androidTime);
                                        insertQuery2 = "INSERT INTO QZGSV_RAW VALUES('" + dt2 + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                       datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                       "','" + datum.elevation + "','" + datum.azimuth + "','" + g + "','" + h + "')";
                                    }
                                }
                            }
                            //Task.Run(() =>
                            //{


                                if (insertQuery != null)
                                {
                                    //SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                                    //SqlCommand sqlCommand = sqlConnection.CreateCommand();
                                    //sqlCommand.Transaction = sqlTransaction;
                                    try
                                    {
                                        // 新規にInsert文を発行
                                        String sqlIns = insertQuery;
                                        SqlCommand sqlCommand = new SqlCommand(sqlIns, sqlConnection);
                                        // 指定した SQL コマンドを実行してデータを挿入する

                                        sqlCommand.ExecuteNonQuery();
                                    this.successInsertingTextBox.AppendText("Success : " + insertQuery + System.Environment.NewLine);

                                    // 旨くいったらコミット
                                    //sqlTransaction.Commit();


                                }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    this.failedInsertingTextBox.AppendText("Failed : " + insertQuery + System.Environment.NewLine);
                                    // 失敗すると例外となるので，ロールバック
                                    //sqlTransaction.Rollback();
                                }
                                }

                                if (insertQuery2 != null)
                                {
                                    //SqlTransaction sqlTransaction2 = sqlConnection.BeginTransaction();
                                    //SqlCommand sqlCommand2 = sqlConnection.CreateCommand();
                                    //sqlCommand2.Transaction = sqlTransaction2;
                                    try
                                    {
                                        // 新規にInsert文を発行
                                        String sqlIns2 = insertQuery2;
                                        SqlCommand sqlCommand2 = new SqlCommand(sqlIns2, sqlConnection);
                                        // 指定した SQL コマンドを実行してデータを挿入する
                                        sqlCommand2.ExecuteNonQuery();
                                    // 旨くいったらコミット
                                    //sqlTransaction2.Commit();

                                    this.successInsertingTextBox.AppendText("Success : " + insertQuery2 + System.Environment.NewLine);
                                }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    this.failedInsertingTextBox.AppendText("Failed : " + insertQuery2 + System.Environment.NewLine);
                                    // 失敗すると例外となるので，ロールバック
                                    //sqlTransaction2.Rollback();
                                }
                                }
                            //});
                        }

                        if (DataType == "$GPGGA")
                        {
                            String insertQuery = null;
                            END_OF_COLUMN = 16;                            
                            for (int j = 0; j < END_OF_COLUMN - 1; j++)
                            {
                                //range = sheet.Cells[i, j];
                                datum.setDatumByIndex(j, fields[j], DataType);
                            }
                            b = Convert.ToString(fields[15]);
                            if (b != null && b.Length > 1)
                            {
                                int len = b.Length;
                                b = b.Substring(len- 2, 2);
                            }
                            else b = "NULL";
                            if (datum.androidTime != null)
                            {
                                DateTime dt = Convert.ToDateTime(datum.androidTime);
                                insertQuery = "INSERT INTO GPGGA_RAW VALUES('" + dt + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                datum.UTCTime + "','" + datum.latitude + "','" + datum.NorS + "','" + datum.longitude + "','" + datum.EorW + "','"
                                + datum.positionIdentificationQuality + "','" + datum.numberOfUsingSatellites + "','" + datum.HDOP + "','" + datum.heightOfAntenna + "','" +
                                datum.unitOfAntenna + "','" + datum.heightOfGeoid + "','" + datum.unitOfGeoid + "','" + datum.DGPSTime + "'," + "NULL" + ",'" + b + "')";
                            }
                            if (insertQuery != null)
                            {
                                //SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                                //SqlCommand sqlCommand = sqlConnection.CreateCommand();
                                //sqlCommand.Transaction = sqlTransaction;
                                try
                                {
                                    // 新規にInsert文を発行
                                    String sqlIns = insertQuery;
                                    SqlCommand sqlCommand = new SqlCommand(sqlIns, sqlConnection);
                                    // 指定した SQL コマンドを実行してデータを挿入する
                                    sqlCommand.ExecuteNonQuery();
                                    // 旨くいったらコミット
                                    //sqlTransaction.Commit();

                                    this.successInsertingTextBox.AppendText("Success : " + insertQuery + System.Environment.NewLine);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                    this.failedInsertingTextBox.AppendText("Failed : " + insertQuery + System.Environment.NewLine);
                                    // 失敗すると例外となるので，ロールバック
                                    //sqlTransaction.Rollback();
                                }
                            }
                        }

                        if (DataType == "$GPRMC")
                        {
                            String insertQuery = null;
                            END_OF_COLUMN = 14;
                            for (int j = 0; j < END_OF_COLUMN - 1; j++)
                            {
                                //range = sheet.Cells[i, j];
                                datum.setDatumByIndex(j, fields[j], DataType);
                            }
                            b = Convert.ToString(fields[13]);
                            if (datum.UTCTime.ToString() != "")
                            {
                                //if (b != null)
                                //{
                                //    a = b.Substring(0, 1);
                                //    int len = b.Length;
                                //    b = b.Substring(len - 2, 2);
                                //}
                                //else
                                //{
                                    a = "NULL";
                                    b = "NULL";
                                //}
                                double utctime2;
                                utctime2 = Convert.ToDouble(datum.UTCTime);
                                double utctime3 = Math.Floor(utctime2);
                                String UTCTime = utctime3.ToString();
                                String UTCDate = Convert.ToString(datum.UTCDate);
                                int lenTime = UTCTime.Length;
                                int lenDate = UTCDate.Length;
                                //UTCTime = Convert.ToString(datum.UTCTime);
                                for (int k = 5; k > 0; k--)
                                {
                                    if (lenDate <= k) UTCDate = "0" + UTCDate;
                                    if (lenTime <= k) UTCTime = "0" + UTCTime;
                                }
                                if (UTCDate != "00000")
                                {
                                    String UTC = UTCDate + "," + UTCTime;
                                    DateTime utc;
                                    if (DateTime.TryParseExact(UTC, "ddMMyy,HHmmss", System.Globalization.DateTimeFormatInfo.InvariantInfo,
                                        System.Globalization.DateTimeStyles.None, out utc))
                                    {
                                        //utc = System.DateTime.ParseExact(UTC, "ddMMyy,HHmmss", System.Globalization.DateTimeFormatInfo.InvariantInfo,
                                        //    System.Globalization.DateTimeStyles.None);  //ParseExactでUTCに
                                        TimeZoneInfo jstZoneInfo = System.TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");   //JSTのTimeZoneInfoを取得
                                        DateTime jst = System.TimeZoneInfo.ConvertTimeFromUtc(utc, jstZoneInfo);    //TimeZoneInfoを元に、UTCをJSTに変換
                                        if (datum.androidTime != null)
                                        {
                                            DateTime dt = Convert.ToDateTime(datum.androidTime);
                                            insertQuery = "INSERT INTO GPRMC_RAW VALUES('" + dt + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                            datum.UTCTime + "','" + datum.status + "','" + datum.latitude + "','" + datum.NorS + "','" + datum.longitude + "','"
                                            + datum.EorW + "','" + datum.movingSpeed + "','" + datum.movingAzimuth + "','" + datum.UTCDate + "','" + datum.magneticVariation +
                                            "','" + datum.magneticVariationDeclination + "'," + a + "," + b + ",'" + jst + "')";
                                        }
                                        //Task.Run(() =>
                                        //{


                                        if (insertQuery != null)
                                        {
                                            //SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                                            //SqlCommand sqlCommand = sqlConnection.CreateCommand();
                                            //sqlCommand.Transaction = sqlTransaction;
                                            try
                                            {
                                                // 新規にInsert文を発行
                                                String sqlIns = insertQuery;
                                                SqlCommand sqlCommand = new SqlCommand(sqlIns, sqlConnection);
                                                // 指定した SQL コマンドを実行してデータを挿入する
                                                sqlCommand.ExecuteNonQuery();
                                                // 旨くいったらコミット
                                                //sqlTransaction.Commit();

                                                this.successInsertingTextBox.AppendText("Success : " + insertQuery + System.Environment.NewLine);
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine(e.Message);
                                                this.failedInsertingTextBox.AppendText("Failed : " + insertQuery + System.Environment.NewLine);
                                                // 失敗すると例外となるので，ロールバック
                                                //sqlTransaction.Rollback();
                                            }
                                        }
                                        //});
                                    }
                                }
                            }
                        }

                        if (DataType == "$GNGSA")   //GNGSA,GPGSA,QZGSAは5~16にnullがあればreject
                        {
                            String insertQuery = null;
                            END_OF_COLUMN = 19;
                            if (fields[4] == null)
                            {
                                for (int j = 0; j <= 3; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                for (int j = 16; j < END_OF_COLUMN - 1; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                a = Convert.ToString(fields[18]);
                                b = a;
                                if (b != null)
                                {
                                    int len = b.Length;
                                    if (len > 1) b = b.Substring(len - 2, 2);
                                    else b = "NULL";
                                }
                                if (a != null)a = a.Substring(0, 3);
                                if (datum.androidTime != null)
                                {
                                    DateTime dt = Convert.ToDateTime(datum.androidTime);
                                    insertQuery = "INSERT INTO GNGSA_RAW VALUES('" + dt + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                    datum.mode + "','" + datum.identificationType + "'," + "0" + ",'" + datum.PDOP + "','" + datum.HDOP + "','" + datum.VDOP + "','"
                                    + b + "')";
                                }
                                //Task.Run(() =>
                                //{


                                    if (insertQuery != null)
                                    {
                                        //SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                                        //SqlCommand sqlCommand = sqlConnection.CreateCommand();
                                        //sqlCommand.Transaction = sqlTransaction;
                                        try
                                        {
                                            // 新規にInsert文を発行
                                            String sqlIns = insertQuery;
                                            SqlCommand sqlCommand = new SqlCommand(sqlIns, sqlConnection);
                                            // 指定した SQL コマンドを実行してデータを挿入する
                                            sqlCommand.ExecuteNonQuery();
                                        // 旨くいったらコミット
                                        //sqlTransaction.Commit();

                                        this.successInsertingTextBox.AppendText("Success : " + insertQuery + System.Environment.NewLine);
                                    }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        this.failedInsertingTextBox.AppendText("Failed : " + insertQuery + System.Environment.NewLine);
                                        // 失敗すると例外となるので，ロールバック
                                        //sqlTransaction.Rollback();
                                    }
                                    }
                                //});
                            }

                            if (fields[4] != null)
                            {
                                for (int j = 0; j <= 3; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }

                                for (int k = 4; fields[k-1] != null; k++)
                                {
                                    if (k > 15) break;
                                    else
                                    {
                                        //range = sheet.Cells[i, k];
                                        datum.setDatumByIndex(k, fields[k], DataType);
                                    }
                                    for (int j = 16; j < END_OF_COLUMN -1; j++)
                                    {
                                        //range = sheet.Cells[i, j];
                                        datum.setDatumByIndex(j, fields[k], DataType);
                                    }
                                    a = Convert.ToString(fields[18]);
                                    b = a;
                                    if (b != null)
                                    {
                                        int len = b.Length;
                                        if (len > 1) b = b.Substring(len - 2, 2);
                                        else b = "NULL";
                                    }
                                    if (a != null) a = a.Substring(0, 3);
                                    if (datum.androidTime != null)
                                    {
                                        DateTime dt = Convert.ToDateTime(datum.androidTime);
                                        insertQuery = "INSERT INTO GNGSA_RAW VALUES('" + dt + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                          datum.mode + "','" + datum.identificationType + "','" + datum.satelliteNumber + "','" + datum.PDOP + "','" + datum.HDOP +
                                          "','" + datum.VDOP + "','" + b + "')";
                                    }
                                    //Task.Run(() =>
                                    //{


                                        if (insertQuery != null)
                                        {
                                            //SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                                            //SqlCommand sqlCommand = sqlConnection.CreateCommand();
                                            //sqlCommand.Transaction = sqlTransaction;
                                            try
                                            {
                                                // 新規にInsert文を発行
                                                String sqlIns = insertQuery;
                                                SqlCommand sqlCommand = new SqlCommand(sqlIns, sqlConnection);
                                                // 指定した SQL コマンドを実行してデータを挿入する
                                                sqlCommand.ExecuteNonQuery();
                                            // 旨くいったらコミット
                                            //sqlTransaction.Commit();

                                            this.successInsertingTextBox.AppendText("Success : " + insertQuery + System.Environment.NewLine);
                                        }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine(e.Message);
                                            this.failedInsertingTextBox.AppendText("Failed : " + insertQuery + System.Environment.NewLine);
                                            // 失敗すると例外となるので，ロールバック
                                            //sqlTransaction.Rollback();
                                        }
                                        }
                                    //});
                                }
                            }
                        }

                        if (DataType == "$GPGSA" && fields.Length > 16)   //GNGSA,GPGSA,QZGSAは5~16にnullがあればreject
                        {
                            String insertQuery = null;
                            END_OF_COLUMN = 19;
                            a = Convert.ToString(fields[18]);
                            b = a;
                            if (fields[4] == null)
                            {
                                for (int j = 0; j <= 3; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                for (int j = 16; j < END_OF_COLUMN - 1; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                a = Convert.ToString(fields[18]);
                                b = a;
                                if (b != null)
                                {
                                    int len = b.Length;
                                    if (len > 1) b = b.Substring(len - 2, 2);
                                    else b = "NULL";
                                }
                                if (a != null) a = a.Substring(0, 3);
                                if (datum.androidTime != null)
                                {
                                    DateTime dt = Convert.ToDateTime(datum.androidTime);
                                    insertQuery = "INSERT INTO GPGSA_RAW VALUES('";
                                    insertQuery += dt + "','";
                                    insertQuery += sensorID + "','";
                                    insertQuery += driverID + "','" + carID + "','" +
                                    datum.mode + "','" + datum.identificationType + "',";
                                    insertQuery += "0" + ",'" + datum.PDOP + "','" + datum.HDOP + "','";
                                    insertQuery += datum.VDOP + "','";
                                    insertQuery += b + "')";
                                }
                                //Task.Run(() =>
                                //{


                                    if (insertQuery != null)
                                    {
                                        //SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                                        //SqlCommand sqlCommand = sqlConnection.CreateCommand();
                                        //sqlCommand.Transaction = sqlTransaction;
                                        try
                                        {
                                            // 新規にInsert文を発行
                                            String sqlIns = insertQuery;
                                            SqlCommand sqlCommand = new SqlCommand(sqlIns, sqlConnection);
                                            // 指定した SQL コマンドを実行してデータを挿入する
                                            sqlCommand.ExecuteNonQuery();
                                        // 旨くいったらコミット
                                        //sqlTransaction.Commit();

                                        this.successInsertingTextBox.AppendText("Success : " + insertQuery + System.Environment.NewLine);
                                    }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        this.failedInsertingTextBox.AppendText("Failed : " + insertQuery + System.Environment.NewLine);
                                        // 失敗すると例外となるので，ロールバック
                                        //sqlTransaction.Rollback();
                                    }
                                    }
                                //});
                            }

                            if (fields[4] != null)
                            {
                                for (int j = 0; j <= 3; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }

                                for (int k = 4; fields[k-1] != null; k++)
                                {
                                    if (k > 15) break;
                                    else
                                    {
                                        //range = sheet.Cells[i, k];
                                        datum.setDatumByIndex(k, fields[k], DataType);
                                    }
                                    for (int j = 16; j < END_OF_COLUMN - 1; j++)
                                    {
                                        //range = sheet.Cells[i, j];
                                        datum.setDatumByIndex(j, fields[j], DataType);
                                    }
                                    a = Convert.ToString(fields[18]);
                                    b = a;
                                    if (b != null)
                                    {
                                        int len = b.Length;
                                        if (len > 1) b = b.Substring(len - 2, 2);
                                        else b = "NULL";
                                    }
                                    if (a != null) a = a.Substring(0, 3);
                                    if (datum.androidTime != null)
                                    {
                                        DateTime dt = Convert.ToDateTime(datum.androidTime);
                                        if (datum.satelliteNumber != null) insertQuery = "INSERT INTO GPGSA_RAW VALUES('" + dt + "','" + sensorID + "','" + driverID
                                                + "','" + carID + "','" + datum.mode + "','" + datum.identificationType + "','" + datum.satelliteNumber + "','" + datum.PDOP + "','"
                                                + datum.HDOP + "','" + a + "','" + b + "')";
                                    }
                                    //Task.Run(() =>
                                    //{


                                        if (insertQuery != null)
                                        {
                                            //SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                                            //SqlCommand sqlCommand = sqlConnection.CreateCommand();
                                            //sqlCommand.Transaction = sqlTransaction;
                                            try
                                            {
                                                // 新規にInsert文を発行
                                                String sqlIns = insertQuery;
                                                SqlCommand sqlCommand = new SqlCommand(sqlIns, sqlConnection);
                                                // 指定した SQL コマンドを実行してデータを挿入する
                                                sqlCommand.ExecuteNonQuery();
                                            // 旨くいったらコミット
                                            //sqlTransaction.Commit();

                                            this.successInsertingTextBox.AppendText("Success : " + insertQuery + System.Environment.NewLine);
                                        }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine(e.Message);
                                            this.failedInsertingTextBox.AppendText("Failed : " + insertQuery + System.Environment.NewLine);
                                            // 失敗すると例外となるので，ロールバック
                                            //sqlTransaction.Rollback();
                                        }
                                        }
                                    //});
                                }
                            }
                        }

                        if (DataType == "$QZGSA")   //GNGSA,GPGSA,QZGSAは5~16にnullがあればreject
                        {
                            String insertQuery = null;
                            END_OF_COLUMN = 19;
                            if (fields[4] == null)
                            {
                                for (int j = 0; j <= 3; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                for (int j = 16; j < END_OF_COLUMN - 1; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                a = Convert.ToString(fields[18]);
                                b = a;
                                if (b != null)
                                {
                                    int len = b.Length;
                                    if (len > 1) b = b.Substring(len - 2, 2);
                                    else b = "NULL";
                                }
                                if (a != null) a = a.Substring(0, 3);
                                if (datum.androidTime != null)
                                {
                                    DateTime dt = Convert.ToDateTime(datum.androidTime);
                                    insertQuery = "INSERT INTO QZGSA_RAW VALUES('" + dt + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                    datum.mode + "','" + datum.identificationType + "'," + "0" + ",'" + datum.PDOP + "','" + datum.HDOP + "','" + Convert.ToSingle(a) 
                                    + "','" + b + "')";
                                }
                                //Task.Run(() =>
                                //{
                                    if (insertQuery != null)
                                    {
                                        //SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                                        //SqlCommand sqlCommand = sqlConnection.CreateCommand();
                                        //sqlCommand.Transaction = sqlTransaction;
                                        try
                                        {
                                            // 新規にInsert文を発行
                                            String sqlIns = insertQuery;
                                            SqlCommand sqlCommand = new SqlCommand(sqlIns, sqlConnection);
                                            // 指定した SQL コマンドを実行してデータを挿入する
                                            sqlCommand.ExecuteNonQuery();
                                        // 旨くいったらコミット
                                        //sqlTransaction.Commit();

                                        this.successInsertingTextBox.AppendText("Success : " + insertQuery + System.Environment.NewLine);
                                    }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        this.failedInsertingTextBox.AppendText("Failed : " + insertQuery + System.Environment.NewLine);
                                        // 失敗すると例外となるので，ロールバック
                                        //sqlTransaction.Rollback();
                                    }
                                    }
                                //});
                            }

                            if (fields[4] != null)
                            {
                                for (int j = 0; j <= 3; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }

                                for (int k = 4; fields[k-1] != null; k++)
                                {
                                    if (k > 15) break;
                                    else
                                    {
                                       // range = sheet.Cells[i, k];
                                        datum.setDatumByIndex(k, fields[k], DataType);
                                    }
                                    for (int j = 16; j < END_OF_COLUMN - 1; j++)
                                    {
                                        //range = sheet.Cells[i, j];
                                        datum.setDatumByIndex(j, fields[j], DataType);
                                    }
                                    a = Convert.ToString(fields[18]);
                                    b = a;
                                    if (b != null)
                                    {
                                        int len = b.Length;
                                        if (len > 1) b = b.Substring(len - 2, 2);
                                        else b = "NULL";
                                    }
                                    if (a != null) a = a.Substring(0, 3);
                                    if (datum.androidTime != null)
                                    {
                                        DateTime dt = Convert.ToDateTime(datum.androidTime);
                                        if (datum.satelliteNumber != null) insertQuery = "INSERT INTO QZGSA_RAW VALUES('" + dt + "','" + sensorID + "','" + driverID
                                                + "','" + carID + "','" + datum.mode + "','" + datum.identificationType + "','" + datum.satelliteNumber + "','" + datum.PDOP 
                                                + "','" + datum.HDOP + "','" + Convert.ToSingle(a) + "','" + b + "')";
                                    }
                                    //Task.Run(() =>
                                    //{
                                        if (insertQuery != null)
                                        {
                                            //SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                                            //SqlCommand sqlCommand = sqlConnection.CreateCommand();
                                            //sqlCommand.Transaction = sqlTransaction;
                                            try
                                            {
                                                // 新規にInsert文を発行
                                                String sqlIns = insertQuery;
                                                SqlCommand sqlCommand = new SqlCommand(sqlIns, sqlConnection);
                                                // 指定した SQL コマンドを実行してデータを挿入する
                                                sqlCommand.ExecuteNonQuery();
                                            // 旨くいったらコミット
                                            //sqlTransaction.Commit();

                                            this.successInsertingTextBox.AppendText("Success : " + insertQuery + System.Environment.NewLine);
                                        }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine(e.Message);
                                            this.failedInsertingTextBox.AppendText("Failed : " + insertQuery + System.Environment.NewLine);
                                            // 失敗すると例外となるので，ロールバック
                                            //sqlTransaction.Rollback();
                                        }
                                        }
                                    //});
                                }
                            }
                        }

                        if (DataType == "$GPGSV")
                        {
                            String insertQuery = null;
                            String insertQuery2 = null;
                            String insertQuery3 = null;
                            String insertQuery4 = null;
                            String f = null;
                            String g = null;
                            int len1 = 0;
                            int len2 = 0;
                            int len3 = 0;
                            int len4 = 0;
                            if (fields.Length < 8)
                            {
                                a = Convert.ToString(fields[8]);
                                b = Convert.ToString(fields[12]);
                                f = Convert.ToString(fields[16]);
                                g = Convert.ToString(fields[20]);
                            }
                            if (a != null) len1 = a.Length;
                            if (b != null) len2 = b.Length;
                            if (f != null) len3 = f.Length;
                            if (g != null) len4 = g.Length;
                            if (a != null && a.Length != 0 && a.Substring(0, 1) == "*")//I(9)カラム(SN比orSN比*チェックサム）が*で始まっていれば、*チェックサムの形の最終カラム
                            {
                                DataType = "$GPGSV-1";
                                END_OF_COLUMN = 9;
                                for (int j = 0; j < END_OF_COLUMN - 1; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt = Convert.ToDateTime(datum.androidTime);
                                    insertQuery = "INSERT INTO GPGSV_RAW VALUES('" + dt + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "'," + "NULL" + ",'" + "NULL" + "')";
                                }
                            }

                            if (a != null && len1 == 5) //Iカラム(SN比orSN比*チェックサム）が5文字ならば、SN比*チェックサムの形の最終カラム
                            {
                                DataType = "$GPGSV-1";
                                END_OF_COLUMN = 9;
                                for (int j = 0; j < END_OF_COLUMN - 1; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt = Convert.ToDateTime(datum.androidTime);
                                    insertQuery = "INSERT INTO GPGSV_RAW VALUES('" + dt + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "','" + "Null" + "','" + "Null" + "')";
                                }
                            }


                            if (b != null && b.Length != 0 && b.Substring(0, 1) == "*")//M(13)カラム(SN比orSN比*チェックサム)が*で始まれば、*チェックサムの形の最終カラム
                            {
                                DataType = "$GPGSV-2";
                                END_OF_COLUMN = 13;
                                for (int j = 0; j < 8; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt = Convert.ToDateTime(datum.androidTime);
                                    insertQuery = "INSERT INTO GPGSV_RAW VALUES('" + dt + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "','" + datum.SNRatio + "','" + "NULL" + "')";
                                }
                                for (int j = 0; j < 4; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                for (int j = 9; j < END_OF_COLUMN - 1; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null && datum.azimuth != null)
                                {
                                    DateTime dt2 = Convert.ToDateTime(datum.androidTime);
                                    insertQuery2 = "INSERT INTO GPGSV_RAW VALUES('" + dt2 + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "'," + "NULL" + ",'" + "NULL" + "')";
                                }
                            }

                            if (b != null && len2 == 5)//M(13)カラム(SN比orSN比*チェックサム）が5文字ならば、SN比*チェックサムの形の最終カラム
                            {
                                DataType = "$GPGSV-2";
                                END_OF_COLUMN = 13;
                                for (int j = 0; j < 8; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt = Convert.ToDateTime(datum.androidTime);
                                    insertQuery = "INSERT INTO GPGSV_RAW VALUES('" + dt + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "','" + datum.SNRatio + "','" + "Null" + "')";
                                }
                                for (int j = 0; j < 4; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                for (int j = 9; j < END_OF_COLUMN - 1; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt2 = Convert.ToDateTime(datum.androidTime);
                                    insertQuery2 = "INSERT INTO GPGSV_RAW VALUES('" + dt2 + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "','" + "NULL" + "','" + "NULL" + "')";
                                }
                            }

                            if (f != null && f.Length != 0 && f.Substring(0, 1) == "*")//Q(17)カラム(SN比orSN比*チェックサム)が*で始まれば、*チェックサムの形の最終カラム
                            {
                                DataType = "$GPGSV-3";
                                END_OF_COLUMN = 17;
                                for (int j = 0; j < 8; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt = Convert.ToDateTime(datum.androidTime);
                                    insertQuery = "INSERT INTO GPGSV_RAW VALUES('" + dt + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "','" + datum.SNRatio + "','" + "NULL" + "')";
                                }
                                for (int j = 0; j < 4; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                for (int j = 9; j < 12; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt2 = Convert.ToDateTime(datum.androidTime);
                                    insertQuery2 = "INSERT INTO GPGSV_RAW VALUES('" + dt2 + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "','" + datum.SNRatio + "','" + "NULL" + "')";
                                }
                                for (int j = 0; j < 4; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                for (int j = 13; j < END_OF_COLUMN - 1; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt3 = Convert.ToDateTime(datum.androidTime);
                                    insertQuery3 = "INSERT INTO GPGSV_RAW VALUES('" + dt3 + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "'," + "NULL" + ",'" + "NULL" + "')";
                                }
                            }

                            if (f != null && len3 == 5)//Q(17)カラム(SN比orSN比*チェックサム）が5文字ならば、SN比*チェックサムの形の最終カラム
                            {
                                len3 = f.Length;
                                DataType = "$GPGSV-3";
                                END_OF_COLUMN = 17;
                                for (int j = 0; j < 8; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt = Convert.ToDateTime(datum.androidTime);
                                    insertQuery = "INSERT INTO GPGSV_RAW VALUES('" + dt + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "','" + datum.SNRatio + "','" + "NULL" + "')";
                                }
                                for (int j = 0; j < 4; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                for (int j = 9; j < 12; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt2 = Convert.ToDateTime(datum.androidTime);
                                    insertQuery2 = "INSERT INTO GPGSV_RAW VALUES('" + dt2 + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "','" + datum.SNRatio + "','" + "NULL" + "')";
                                }
                                for (int j = 0; j < 4; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                for (int j = 13; j < END_OF_COLUMN - 1; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt3 = Convert.ToDateTime(datum.androidTime);
                                    insertQuery3 = "INSERT INTO GPGSV_RAW VALUES('" + dt3 + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "','" + f.Substring(0, 2) + "','" + "NULL" + "')";
                                }
                            }

                            if (g != null && g.Substring(0, 1) == "*")//U(21)カラム(SN比orSN比*チェックサム)が*で始まれば、*チェックサムの形の最終カラム
                            {
                                DataType = "$GPGSV-4";
                                END_OF_COLUMN = 21;
                                for (int j = 0; j < 8; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt = Convert.ToDateTime(datum.androidTime);
                                    insertQuery = "INSERT INTO GPGSV_RAW VALUES('" + dt + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "','" + datum.SNRatio + "','" + "NULL" + "')";
                                }
                                for (int j = 0; j < 4; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                for (int j = 9; j < 12; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt2 = Convert.ToDateTime(datum.androidTime);
                                    insertQuery2 = "INSERT INTO GPGSV_RAW VALUES('" + dt2 + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "','" + datum.SNRatio + "','" + "NULL" + "')";
                                }
                                for (int j = 0; j < 4; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                for (int j = 13; j < 16; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt3 = Convert.ToDateTime(datum.androidTime);
                                    insertQuery3 = "INSERT INTO GPGSV_RAW VALUES('" + dt3 + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "','" + datum.SNRatio + "','" + "NULL" + "')";
                                }
                                for (int j = 0; j < 4; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                for (int j = 17; j < END_OF_COLUMN - 1; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt4 = Convert.ToDateTime(datum.androidTime);
                                    insertQuery4 = "INSERT INTO GPGSV_RAW VALUES('" + dt4 + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "'," + "NULL" + ",'" + "NULL" + "')";
                                }
                            }

                            if (g != null && len4 == 5)//U(21)カラム(SN比orSN比*チェックサム）が5文字ならば、SN比*チェックサムの形の最終カラム
                            {
                                DataType = "$GPGSV-4";
                                END_OF_COLUMN = 21;
                                for (int j = 0; j < 8; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt = Convert.ToDateTime(datum.androidTime);
                                    insertQuery = "INSERT INTO GPGSV_RAW VALUES('" + dt + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "','" + datum.SNRatio + "','" + "NULL" + "')";
                                }
                                for (int j = 0; j < 4; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                for (int j = 9; j < 12; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt2 = Convert.ToDateTime(datum.androidTime);
                                    insertQuery2 = "INSERT INTO GPGSV_RAW VALUES('" + dt2 + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "','" + datum.SNRatio + "','" + "NULL" + "')";
                                }
                                for (int j = 0; j < 4; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                for (int j = 13; j < 16; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt3 = Convert.ToDateTime(datum.androidTime);
                                    insertQuery3 = "INSERT INTO GPGSV_RAW VALUES('" + dt3 + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "','" + datum.SNRatio + "','" + "NULL" + "')";
                                }
                                for (int j = 0; j < 4; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                for (int j = 17; j < END_OF_COLUMN - 1; j++)
                                {
                                    //range = sheet.Cells[i, j];
                                    datum.setDatumByIndex(j, fields[j], DataType);
                                }
                                if (datum.androidTime != null)
                                {
                                    DateTime dt4 = Convert.ToDateTime(datum.androidTime);
                                    insertQuery4 = "INSERT INTO GPGSV_RAW VALUES('" + dt4 + "','" + sensorID + "','" + driverID + "','" + carID + "','" +
                                        datum.numberOfAllSentences + "','" + datum.sentenceNumber + "','" + datum.numberOfAllSatellites + "','" + datum.satelliteNumber +
                                        "','" + datum.elevation + "','" + datum.azimuth + "','" + "NULL" + "','" + "NULL" + "')";
                                }
                            }
                            //Task.Run(() =>
                            //{
                                if (insertQuery != null)
                                {
                                    //SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                                    //SqlCommand sqlCommand = sqlConnection.CreateCommand();
                                    //sqlCommand.Transaction = sqlTransaction;
                                    try
                                    {
                                        // 新規にInsert文を発行
                                        String sqlIns = insertQuery;
                                        SqlCommand sqlCommand = new SqlCommand(sqlIns, sqlConnection);
                                        // 指定した SQL コマンドを実行してデータを挿入する
                                        sqlCommand.ExecuteNonQuery();
                                    // 旨くいったらコミット
                                    //sqlTransaction.Commit();

                                    this.successInsertingTextBox.AppendText("Success : " + insertQuery + System.Environment.NewLine);
                                }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    this.failedInsertingTextBox.AppendText("Failed : " + insertQuery + System.Environment.NewLine);
                                    // 失敗すると例外となるので，ロールバック
                                    //sqlTransaction.Rollback();
                                }
                                }

                                if (insertQuery2 != null)
                                {
                                    //SqlTransaction sqlTransaction2 = sqlConnection.BeginTransaction();
                                    //SqlCommand sqlCommand2 = sqlConnection.CreateCommand();
                                    //sqlCommand2.Transaction = sqlTransaction2;
                                    try
                                    {
                                        // 新規にInsert文を発行
                                        String sqlIns2 = insertQuery2;
                                        SqlCommand sqlCommand2 = new SqlCommand(sqlIns2, sqlConnection);
                                        // 指定した SQL コマンドを実行してデータを挿入する
                                        sqlCommand2.ExecuteNonQuery();
                                    // 旨くいったらコミット
                                    //sqlTransaction2.Commit();

                                    this.successInsertingTextBox.AppendText("Success : " + insertQuery2 + System.Environment.NewLine);
                                }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    this.failedInsertingTextBox.AppendText("Failed : " + insertQuery2 + System.Environment.NewLine);
                                    // 失敗すると例外となるので，ロールバック
                                    //sqlTransaction2.Rollback();
                                }
                                }

                                if (insertQuery3 != null)
                                {
                                    //SqlTransaction sqlTransaction3 = sqlConnection.BeginTransaction();
                                    //SqlCommand sqlCommand3 = sqlConnection.CreateCommand();
                                    //sqlCommand3.Transaction = sqlTransaction3;
                                    try
                                    {
                                        // 新規にInsert文を発行
                                        String sqlIns3 = insertQuery3;
                                        SqlCommand sqlCommand3 = new SqlCommand(sqlIns3, sqlConnection);
                                        // 指定した SQL コマンドを実行してデータを挿入する
                                        sqlCommand3.ExecuteNonQuery();
                                    // 旨くいったらコミット
                                    //sqlTransaction3.Commit();

                                    this.successInsertingTextBox.AppendText("Success : " + insertQuery3 + System.Environment.NewLine);
                                }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    this.failedInsertingTextBox.AppendText("Failed : " + insertQuery3 + System.Environment.NewLine);
                                    // 失敗すると例外となるので，ロールバック
                                    //sqlTransaction3.Rollback();
                                }
                                }
                                if (insertQuery4 != null)
                                {
                                    //SqlTransaction sqlTransaction4 = sqlConnection.BeginTransaction();
                                    //SqlCommand sqlCommand4 = sqlConnection.CreateCommand();
                                    //sqlCommand4.Transaction = sqlTransaction4;
                                    try
                                    {
                                        // 新規にInsert文を発行
                                        String sqlIns4 = insertQuery4;
                                        SqlCommand sqlCommand4 = new SqlCommand(sqlIns4, sqlConnection);
                                        // 指定した SQL コマンドを実行してデータを挿入する
                                        sqlCommand4.ExecuteNonQuery();
                                    // 旨くいったらコミット
                                    //sqlTransaction4.Commit();

                                    this.successInsertingTextBox.AppendText("Success : " + insertQuery4 + System.Environment.NewLine);
                                }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    this.failedInsertingTextBox.AppendText("Failed : " + insertQuery4 + System.Environment.NewLine);
                                    // 失敗すると例外となるので，ロールバック
                                    //sqlTransaction4.Rollback();
                                }
                                }
                            //});
                        }
                        else DoNothing();
                    }
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            //workbookを閉じる
            //WorkBook.Close();
            //WorkBook = null;
            //WorkBooks.Close();
            //WorkBooks = null;
            ////エクセルを閉じる
            //ExcelApp.Quit();
            //ExcelApp = null;
            parser.Close();
            //errorCodeLabel.Text = "All inserting complete";

        }

        private void driverIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DoNothing() { }
    }
}
