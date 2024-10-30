// Decompiled with JetBrains decompiler
// Type: Fuar.AktFrmStok
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class AktFrmStok : XtraForm
  {
    private string t_conn;
    private string t_firmano;
    private string t_donemno = string.Empty;
    private DataTable dt_birimler;
    private IContainer components;
    private GroupBox groupBox1;
    private SimpleButton btn_kapat;
    private SimpleButton btn_aktar;
    private BackgroundWorker bw;
    private ProgressBarControl pb2;
    private Timer timer1;
    private TimeEdit t_time;

    public AktFrmStok() => this.InitializeComponent();

    private void btn_kapat_Click(object sender, EventArgs e) => this.Close();

    private void btn_aktar_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Aktarıma başlanacaktır. Onaylıyormusunuz?", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
        return;
      try
      {
        if (!this.ayaroku_degiskene())
          return;
        this.timer1.Enabled = true;
        this.timer1.Start();
        this.btn_kapat.Enabled = false;
        this.btn_aktar.Enabled = false;
        this.bw.RunWorkerAsync();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void AktFrmStok_Load(object sender, EventArgs e)
    {
      this.t_time.Properties.AllowFocused = false;
    }

    private void bw_DoWork(object sender, DoWorkEventArgs e) => this.aktar_stok();

    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      this.btn_kapat.Enabled = true;
      this.btn_aktar.Enabled = true;
      this.pb2.EditValue = (object) 100;
      this.timer1.Stop();
      int num = (int) MessageBox.Show("Aktarım tamamlandı");
    }

    private void aktar_stok()
    {
      string empty = string.Empty;
      DataTable dataTable1 = new DataTable();
      DataTable dataTable2 = new DataTable();
      DataTable dataTable3 = new DataTable();
      DataTable dataTable4 = new DataTable();
      SqlConnection connection = new SqlConnection(_main.str_connection);
      DataTable dataTable5 = this.t_komutcalistir_dt("SELECT CODE FROM LG_" + this.t_firmano + "_ITEMS WHERE ACTIVE = 0");
      DataTable dataTable6 = this.t_komutcalistir_dt("SELECT NAME AS BIRIM FROM LG_" + this.t_firmano + "_UNITSETL WHERE UNITSETREF > 4 GROUP BY NAME");
      for (int index = 0; index < dataTable6.Rows.Count; ++index)
        _main.komutcalistir("IF NOT EXISTS (SELECT BIRIM FROM BIRIMLER WHERE BIRIM = '" + dataTable6.Rows[index]["BIRIM"].ToString() + "') " + "INSERT INTO BIRIMLER (BIRIM) VALUES ('" + dataTable6.Rows[index]["BIRIM"].ToString() + "')");
      this.dt_birimler = _main.komutcalistir_dt("SELECT * FROM BIRIMLER");
      for (int index1 = 0; index1 < dataTable5.Rows.Count; ++index1)
      {
        DataView dataView = new DataView(this.t_komutcalistir_dt("SELECT I.CODE AS KOD, I.NAME AS AD, ISNULL(B.BARCODE, '') AS BARCODE, U.NAME AS BIRIM, U.MAINUNIT AS ANABIRIM, U.CONVFACT1 AS KATSAYI, I.STGRPCODE AS GRUPKODU, I.EXPCTGNO AS URETICIKODU, I.VAT AS KDVORANI, I.PRODCOUNTRY AS TEDARIKCI, I.SPECODE AS ANA, I.SPECODE2 AS ALT, I.SPECODE3 AS ALT2," + "ISNULL(M.CODE, '') AS MARKA, ISNULL(P.PRICE, 0) AS FIYAT, ISNULL(P.INCVAT, 0) AS KDVDAHIL, CASE ISNULL(P.CURRENCY, 160) WHEN 160 THEN 'TRL' WHEN 1 THEN 'USD' WHEN 20 THEN 'EUR' WHEN 17 THEN 'GBP' END AS PARABIRIMI " + "FROM LG_" + this.t_firmano + "_PRCLIST AS P RIGHT OUTER JOIN LG_" + this.t_firmano + "_ITMUNITA AS IA INNER JOIN LG_" + this.t_firmano + "_UNITSETL AS U ON IA.UNITLINEREF = U.LOGICALREF RIGHT OUTER JOIN LG_" + this.t_firmano + "_ITEMS AS I ON IA.ITEMREF = I.LOGICALREF AND U.UNITSETREF = I.UNITSETREF ON P.UOMREF = IA.UNITLINEREF AND " + "P.CARDREF = I.LOGICALREF LEFT OUTER JOIN LG_" + this.t_firmano + "_UNITBARCODE AS B ON IA.LOGICALREF = B.ITMUNITAREF LEFT OUTER JOIN LG_" + this.t_firmano + "_MARK AS M ON I.MARKREF = M.LOGICALREF " + "WHERE (P.PTYPE = 2 OR P.PTYPE IS NULL) AND (I.ACTIVE = 0) AND (I.CARDTYPE = 1) AND (I.CODE = '" + dataTable5.Rows[index1]["CODE"].ToString() + "')"));
        DataTable table1 = dataView.ToTable(true, "KOD", "AD", "URETICIKODU", "MARKA", "TEDARIKCI", "ANA", "ALT", "ALT2", "GRUPKODU");
        for (int index2 = 0; index2 < table1.Rows.Count; ++index2)
        {
          try
          {
            string str1 = table1.Rows[index2]["AD"].ToString().Replace("'", " ").Replace('"', ' ').Replace(";", " ").Replace("\\", " ");
            SqlCommand sqlCommand1 = new SqlCommand("IF NOT EXISTS (SELECT KOD FROM MALZEMELER WHERE KOD = '" + table1.Rows[index2]["KOD"].ToString() + "') " + "BEGIN INSERT INTO MALZEMELER (KOD, AD, URETICIKODU, MARKA, TEDARIKCI, ANAKATEGORI, ALTKATEGORI1, ALTKATEGORI2, GRUPKODU) " + "VALUES ('" + table1.Rows[index2]["KOD"].ToString() + "','" + str1 + "','" + table1.Rows[index2]["URETICIKODU"].ToString() + "','" + table1.Rows[index2]["MARKA"].ToString() + "','" + table1.Rows[index2]["TEDARIKCI"].ToString() + "','" + table1.Rows[index2]["ANA"].ToString() + "','" + table1.Rows[index2]["ALT"].ToString() + "','" + table1.Rows[index2]["ALT2"].ToString() + "','" + table1.Rows[index2]["GRUPKODU"].ToString() + "') " + "SELECT @@IDENTITY END " + "ELSE BEGIN SELECT '' END", connection);
            connection.Open();
            string str2 = sqlCommand1.ExecuteScalar().ToString();
            connection.Close();
            dataView.RowFilter = "KOD = '" + table1.Rows[index2]["KOD"].ToString() + "'";
            dataView.Sort = "ANABIRIM DESC";
            DataTable dataTable7 = this.Distinct(dataView.ToTable(), "BIRIM");
            DataTable table2 = dataView.ToTable();
            for (int index3 = 0; index3 < dataTable7.Rows.Count; ++index3)
            {
              if (str2 != "")
              {
                string[] barcodes = this.get_barcodes(table2, table1.Rows[index2]["KOD"].ToString(), dataTable7.Rows[index3]["BIRIM"].ToString());
                SqlCommand sqlCommand2 = new SqlCommand("INSERT INTO MALZEMEDETAY (MALZEMEID, BIRIMID, SATIRNO, ANABIRIM, KATSAYI, BARKOD1, BARKOD2, BARKOD3, BARKOD4, BARKOD5, SATISFIYATI, PARABIRIMI, KDVORANI, KDVDAHIL) " + "VALUES (" + str2 + "," + this.get_birim_id(dataTable7.Rows[index3]["BIRIM"].ToString()) + "," + (index3 + 1).ToString() + "," + dataTable7.Rows[index3]["ANABIRIM"].ToString() + "," + dataTable7.Rows[index3]["KATSAYI"].ToString() + ", " + "'" + barcodes[0] + "','" + barcodes[1] + "','" + barcodes[2] + "','" + barcodes[3] + "','" + barcodes[4] + "'," + dataTable7.Rows[index3]["FIYAT"].ToString().Replace(",", ".") + ",'" + dataTable7.Rows[index3]["PARABIRIMI"].ToString() + "'," + dataTable7.Rows[index3]["KDVORANI"].ToString() + "," + dataTable7.Rows[index3]["KDVDAHIL"].ToString() + ")", connection);
                connection.Open();
                sqlCommand2.ExecuteNonQuery();
                connection.Close();
              }
            }
          }
          catch (Exception ex)
          {
            if (connection.State == ConnectionState.Open)
              connection.Close();
          }
        }
        this.t_komutcalistir("UPDATE LG_" + this.t_firmano + "_ITEMS SET RECSTATUS = 0 WHERE CODE = '" + dataTable5.Rows[index1]["CODE"].ToString() + "'");
        this.bw.ReportProgress(index1 * 100 / dataTable5.Rows.Count);
      }
    }

    private bool ayaroku_degiskene()
    {
      try
      {
        if (new FileInfo("transfer.ini").Exists)
        {
          StreamReader streamReader = new StreamReader("transfer.ini");
          string end = streamReader.ReadToEnd();
          streamReader.Close();
          streamReader.Dispose();
          string[] strArray1 = new string[end.Replace("\r", "").Split('\n').Length];
          string[] strArray2 = end.Replace("\r", "").Split('\n');
          string str1 = strArray2[1];
          string str2 = _main.Decrypt(strArray2[2], "951623");
          string str3 = strArray2[3];
          string str4 = strArray2[4];
          this.t_firmano = strArray2[5];
          this.t_donemno = strArray2[6];
          this.t_conn = "Data Source=" + str3 + ";Initial Catalog=" + str4 + ";User Id=" + str1 + ";Password=" + str2;
          return true;
        }
        int num = (int) MessageBox.Show("Aktarım ayarları yapılmamış.Ayarlar menüsünden aktarım ayarlarınızı yapıp kaydedin.");
        return false;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
        return false;
      }
    }

    private string get_birim_id(string birimadi)
    {
      string birimId = "1";
      for (int index = 0; index < this.dt_birimler.Rows.Count; ++index)
      {
        if (this.dt_birimler.Rows[index]["BIRIM"].ToString() == birimadi.ToUpper())
        {
          birimId = this.dt_birimler.Rows[index]["ID"].ToString();
          break;
        }
      }
      return birimId;
    }

    private string[] get_barcodes(DataTable _dt, string s_mkod, string s_birim)
    {
      string[] barcodes = new string[5];
      DataTable table = new DataView(_dt)
      {
        RowFilter = ("KOD = '" + s_mkod + "' AND BIRIM = '" + s_birim + "'")
      }.ToTable();
      for (int index = 0; index < table.Rows.Count; ++index)
        barcodes[index] = table.Rows[index]["BARCODE"].ToString();
      for (int index = 0; index < barcodes.Length; ++index)
      {
        if (barcodes[index] == null)
          barcodes[index] = "";
      }
      return barcodes;
    }

    public DataTable Distinct(DataTable dataSource, string distinctColumn)
    {
      DataTable dataTable = new DataTable();
      foreach (DataColumn column in (InternalDataCollectionBase) dataSource.Columns)
        dataTable.Columns.Add(column.ColumnName, column.DataType);
      bool flag = false;
      foreach (DataRow row1 in (InternalDataCollectionBase) dataSource.Rows)
      {
        foreach (DataRow row2 in (InternalDataCollectionBase) dataTable.Rows)
        {
          if (row2[distinctColumn].ToString() == row1[distinctColumn].ToString())
          {
            flag = true;
            break;
          }
        }
        if (!flag)
          dataTable.Rows.Add(row1.ItemArray);
        flag = false;
      }
      return dataTable;
    }

    public DataTable t_komutcalistir_dt(string str_query)
    {
      DataTable dataTable = new DataTable();
      SqlConnection connection = new SqlConnection(this.t_conn);
      SqlCommand sqlCommand = new SqlCommand(str_query, connection);
      connection.Open();
      SqlDataReader reader = sqlCommand.ExecuteReader();
      dataTable.Load((IDataReader) reader);
      connection.Close();
      return dataTable;
    }

    public void t_komutcalistir(string str_query)
    {
      SqlConnection connection = new SqlConnection(this.t_conn);
      SqlCommand sqlCommand = new SqlCommand(str_query, connection);
      connection.Open();
      sqlCommand.ExecuteNonQuery();
      connection.Close();
    }

    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      this.pb2.EditValue = (object) e.ProgressPercentage;
      this.pb2.Text = e.ProgressPercentage.ToString();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      this.t_time.Time = this.t_time.Time.AddSeconds(1.0);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      this.groupBox1 = new GroupBox();
      this.pb2 = new ProgressBarControl();
      this.btn_kapat = new SimpleButton();
      this.btn_aktar = new SimpleButton();
      this.bw = new BackgroundWorker();
      this.timer1 = new Timer(this.components);
      this.t_time = new TimeEdit();
      this.groupBox1.SuspendLayout();
      this.pb2.Properties.BeginInit();
      this.t_time.Properties.BeginInit();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.t_time);
      this.groupBox1.Controls.Add((Control) this.pb2);
      this.groupBox1.Controls.Add((Control) this.btn_kapat);
      this.groupBox1.Controls.Add((Control) this.btn_aktar);
      this.groupBox1.Location = new Point(12, 14);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(487, 98);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Malzemeler Aktarımı";
      this.pb2.Location = new Point(23, 20);
      this.pb2.Name = "pb2";
      this.pb2.Properties.ShowTitle = true;
      this.pb2.Size = new Size(440, 26);
      this.pb2.TabIndex = 6;
      this.btn_kapat.Location = new Point(257, 55);
      this.btn_kapat.Name = "btn_kapat";
      this.btn_kapat.Size = new Size(107, 23);
      this.btn_kapat.TabIndex = 2;
      this.btn_kapat.Text = "Kapat";
      this.btn_kapat.Click += new EventHandler(this.btn_kapat_Click);
      this.btn_aktar.Location = new Point(122, 55);
      this.btn_aktar.Name = "btn_aktar";
      this.btn_aktar.Size = new Size(107, 23);
      this.btn_aktar.TabIndex = 1;
      this.btn_aktar.Text = "Aktarımı Başlat";
      this.btn_aktar.Click += new EventHandler(this.btn_aktar_Click);
      this.bw.WorkerReportsProgress = true;
      this.bw.DoWork += new DoWorkEventHandler(this.bw_DoWork);
      this.bw.ProgressChanged += new ProgressChangedEventHandler(this.bw_ProgressChanged);
      this.bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
      this.timer1.Interval = 1000;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.t_time.EditValue = (object) new DateTime(2012, 4, 14, 0, 0, 0, 0);
      this.t_time.Enabled = false;
      this.t_time.Location = new Point(23, 58);
      this.t_time.Name = "t_time";
      this.t_time.Properties.AllowMouseWheel = false;
      this.t_time.Properties.ReadOnly = true;
      this.t_time.Size = new Size(60, 20);
      this.t_time.TabIndex = 8;
      this.t_time.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(511, 122);
      this.Controls.Add((Control) this.groupBox1);
      this.MinimizeBox = false;
      this.Name = nameof (AktFrmStok);
      this.Text = "Malzemeler Aktarımı";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.AktFrmStok_Load);
      this.groupBox1.ResumeLayout(false);
      this.pb2.Properties.EndInit();
      this.t_time.Properties.EndInit();
      this.ResumeLayout(false);
    }
  }
}
