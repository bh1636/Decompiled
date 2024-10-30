// Decompiled with JetBrains decompiler
// Type: Fuar.MalzemeFrm
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using Fuar.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class MalzemeFrm : XtraForm
  {
    public string _id = string.Empty;
    public bool _hareket_gormus;
    private IContainer components;
    private GroupBox groupBox1;
    private TextBox txt_alt3;
    private TextBox txt_alt2;
    private TextBox txt_alt1;
    private TextBox txt_ana;
    private TextBox txt_tedarikci;
    private TextBox txt_grup;
    private TextBox txt_marka;
    private TextBox txt_uretici;
    private TextBox txt_ad;
    private TextBox txt_kod;
    private Label label10;
    private Label label9;
    private Label label8;
    private Label label7;
    private Label label6;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label2;
    private Label label1;
    private SimpleButton btn_kaydet;
    private SimpleButton btn_iptal;
    private GridControl dtg_urun;
    private GridView grd_urun;
    private GroupBox groupBox2;
    private PictureBox pb_kresim;
    private RepositoryItemComboBox repositoryItemComboBox1;
    private PictureBox pb_resim1;
    private PictureBox pb_resim2;
    private PictureBox pb_resim3;
    private SimpleButton btn_silk;
    private SimpleButton btn_eklek;
    private SimpleButton btn_sil1;
    private SimpleButton btn_ekle1;
    private SimpleButton btn_sil2;
    private SimpleButton btn_ekle2;
    private SimpleButton btn_sil3;
    private SimpleButton btn_ekle3;
    private ErrorProvider ep1;
    private BarDockControl barDockControlLeft;
    private BarDockControl barDockControlRight;
    private BarDockControl barDockControlBottom;
    private BarDockControl barDockControlTop;
    private PopupMenu pp1;
    private BarButtonItem bb_ekle;
    private BarButtonItem bb_sil;
    private BarManager bm1;
    private OpenFileDialog ofd;
    private XtraTabControl xtab;
    private XtraTabPage t_kucuk;
    private XtraTabPage t1;
    private XtraTabPage t2;
    private XtraTabPage t3;

    public MalzemeFrm() => this.InitializeComponent();

    private void MalzemeFrm_Load(object sender, EventArgs e) => this.xgrid_load();

    private void xgrid_load()
    {
      RepositoryItemComboBox repositoryItemComboBox = new RepositoryItemComboBox();
      repositoryItemComboBox.Items.Add((object) "TRL");
      repositoryItemComboBox.Items.Add((object) "USD");
      repositoryItemComboBox.Items.Add((object) "EUR");
      repositoryItemComboBox.Items.Add((object) "GBP");
      repositoryItemComboBox.TextEditStyle = TextEditStyles.DisableTextEditor;
      RepositoryItemLookUpEdit repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
      repositoryItemLookUpEdit.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM BIRIMLER");
      repositoryItemLookUpEdit.DisplayMember = "BIRIM";
      repositoryItemLookUpEdit.ValueMember = "ID";
      repositoryItemLookUpEdit.AllowNullInput = DefaultBoolean.False;
      repositoryItemLookUpEdit.NullValuePromptShowForEmptyValue = true;
      repositoryItemLookUpEdit.NullText = "Birim Seçiniz...";
      if (this._id != "")
      {
        DataTable dataTable = _main.komutcalistir_dt("SELECT * FROM MALZEMELER WHERE ID = " + this._id);
        if (dataTable.Rows.Count > 0)
        {
          this.txt_kod.Text = dataTable.Rows[0]["KOD"].ToString();
          this.txt_ad.Text = dataTable.Rows[0]["AD"].ToString();
          this.txt_uretici.Text = dataTable.Rows[0]["URETICIKODU"].ToString();
          this.txt_marka.Text = dataTable.Rows[0]["MARKA"].ToString();
          this.txt_grup.Text = dataTable.Rows[0]["GRUPKODU"].ToString();
          this.txt_tedarikci.Text = dataTable.Rows[0]["TEDARIKCI"].ToString();
          this.txt_ana.Text = dataTable.Rows[0]["ANAKATEGORI"].ToString();
          this.txt_alt1.Text = dataTable.Rows[0]["ALTKATEGORI1"].ToString();
          this.txt_alt2.Text = dataTable.Rows[0]["ALTKATEGORI2"].ToString();
          this.txt_alt3.Text = dataTable.Rows[0]["ALTKATEGORI3"].ToString();
          if (!string.IsNullOrEmpty(dataTable.Rows[0]["KRESIM"].ToString()))
            this.pb_kresim.Image = _main.byteArrayToImage((byte[]) dataTable.Rows[0]["KRESIM"]);
          if (!string.IsNullOrEmpty(dataTable.Rows[0]["RESIM1"].ToString()))
            this.pb_resim1.Image = _main.byteArrayToImage((byte[]) dataTable.Rows[0]["RESIM1"]);
          if (!string.IsNullOrEmpty(dataTable.Rows[0]["RESIM2"].ToString()))
            this.pb_resim2.Image = _main.byteArrayToImage((byte[]) dataTable.Rows[0]["RESIM2"]);
          if (!string.IsNullOrEmpty(dataTable.Rows[0]["RESIM3"].ToString()))
            this.pb_resim3.Image = _main.byteArrayToImage((byte[]) dataTable.Rows[0]["RESIM3"]);
          this.dtg_urun.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM MALZEMEDETAY WHERE MALZEMEID = " + this._id);
        }
      }
      else
        this.dtg_urun.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM MALZEMEDETAY").Clone();
      this.grd_urun.Columns["BIRIMID"].ColumnEdit = (RepositoryItem) repositoryItemLookUpEdit;
      this.grd_urun.Columns["BIRIMID"].Caption = "BİRİM";
      this.grd_urun.Columns["ID"].Visible = false;
      this.grd_urun.Columns["MALZEMEID"].Visible = false;
      this.grd_urun.Columns["SATIRNO"].OptionsColumn.AllowFocus = false;
      this.grd_urun.Columns["ANABIRIM"].OptionsColumn.AllowFocus = false;
      this.grd_urun.Columns["PARABIRIMI"].ColumnEdit = (RepositoryItem) repositoryItemComboBox;
      if (!this._hareket_gormus)
        return;
      this.grd_urun.Columns["BIRIMID"].OptionsColumn.AllowFocus = false;
      this.grd_urun.Columns["KATSAYI"].OptionsColumn.AllowFocus = false;
    }

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void btn_kaydet_Click(object sender, EventArgs e)
    {
      if (!this.alan_kontrol())
        return;
      if (this._id == "")
      {
        if (!this.insert_mlz())
          return;
        this.Close();
      }
      else if (this._hareket_gormus)
      {
        if (!this.update_mlz_h())
          return;
        this.Close();
      }
      else
      {
        if (!this.update_mlz())
          return;
        this.Close();
      }
    }

    private bool insert_mlz()
    {
      bool flag = false;
      SqlTransaction sqlTransaction = (SqlTransaction) null;
      string empty = string.Empty;
      string cmdText1 = "INSERT INTO MALZEMELER (KOD,AD,URETICIKODU,MARKA,GRUPKODU,TEDARIKCI,ANAKATEGORI,ALTKATEGORI1,ALTKATEGORI2, " + "ALTKATEGORI3,KRESIM,RESIM1,RESIM2,RESIM3) " + "VALUES ('" + this.txt_kod.Text + "','" + this.txt_ad.Text + "','" + this.txt_uretici.Text + "','" + this.txt_marka.Text + "','" + this.txt_grup.Text + "'," + "'" + this.txt_tedarikci.Text + "','" + this.txt_ana.Text + "','" + this.txt_alt1.Text + "','" + this.txt_alt2.Text + "','" + this.txt_alt3.Text + "'," + "@KRESIM,@RESIM1,@RESIM2,@RESIM3) " + "SELECT @ID = @@IDENTITY";
      string cmdText2 = "INSERT INTO MALZEMEDETAY (MALZEMEID,BIRIMID,SATIRNO,ANABIRIM,KATSAYI,BARKOD1,BARKOD2,BARKOD3,BARKOD4,BARKOD5,SATISFIYATI,PARABIRIMI,KDVORANI,KDVDAHIL) " + "VALUES (@MALZEMEID,@BIRIMID,@SATIRNO,@ANABIRIM,@KATSAYI,@BARKOD1,@BARKOD2,@BARKOD3,@BARKOD4,@BARKOD5,@SATISFIYATI,@PARABIRIMI,@KDVORANI,@KDVDAHIL)";
      try
      {
        byte[] numArray1 = this.pb_kresim.Image != null ? _main.imageToByteArray(this.pb_kresim.Image) : _main.imageToByteArray((Image) new Bitmap(1, 1));
        byte[] numArray2 = this.pb_resim1.Image != null ? _main.imageToByteArray(this.pb_resim1.Image) : _main.imageToByteArray((Image) new Bitmap(1, 1));
        byte[] numArray3 = this.pb_resim2.Image != null ? _main.imageToByteArray(this.pb_resim2.Image) : _main.imageToByteArray((Image) new Bitmap(1, 1));
        byte[] numArray4 = this.pb_resim3.Image != null ? _main.imageToByteArray(this.pb_resim3.Image) : _main.imageToByteArray((Image) new Bitmap(1, 1));
        SqlConnection connection = new SqlConnection(_main.str_connection);
        SqlCommand sqlCommand1 = new SqlCommand(cmdText1, connection);
        sqlCommand1.Parameters.AddWithValue("@KRESIM", (object) numArray1);
        sqlCommand1.Parameters.AddWithValue("@RESIM1", (object) numArray2);
        sqlCommand1.Parameters.AddWithValue("@RESIM2", (object) numArray3);
        sqlCommand1.Parameters.AddWithValue("@RESIM3", (object) numArray4);
        SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.Int);
        sqlParameter.Direction = ParameterDirection.Output;
        sqlCommand1.Parameters.Add(sqlParameter);
        connection.Open();
        sqlTransaction = connection.BeginTransaction();
        sqlCommand1.Transaction = sqlTransaction;
        sqlCommand1.ExecuteNonQuery();
        int result = 0;
        if (int.TryParse(sqlParameter.Value.ToString(), out result))
        {
          SqlCommand sqlCommand2 = new SqlCommand(cmdText2, connection);
          sqlCommand2.Transaction = sqlTransaction;
          DataTable dataSource = (DataTable) this.dtg_urun.DataSource;
          for (int index = 0; index < dataSource.Rows.Count; ++index)
          {
            sqlCommand2.Parameters.Clear();
            sqlCommand2.Parameters.AddWithValue("@MALZEMEID", (object) result);
            sqlCommand2.Parameters.AddWithValue("@BIRIMID", dataSource.Rows[index]["BIRIMID"]);
            sqlCommand2.Parameters.AddWithValue("@SATIRNO", dataSource.Rows[index]["SATIRNO"]);
            sqlCommand2.Parameters.AddWithValue("@ANABIRIM", dataSource.Rows[index]["ANABIRIM"]);
            sqlCommand2.Parameters.AddWithValue("@KATSAYI", dataSource.Rows[index]["KATSAYI"]);
            sqlCommand2.Parameters.AddWithValue("@BARKOD1", dataSource.Rows[index]["BARKOD1"]);
            sqlCommand2.Parameters.AddWithValue("@BARKOD2", dataSource.Rows[index]["BARKOD2"]);
            sqlCommand2.Parameters.AddWithValue("@BARKOD3", dataSource.Rows[index]["BARKOD3"]);
            sqlCommand2.Parameters.AddWithValue("@BARKOD4", dataSource.Rows[index]["BARKOD4"]);
            sqlCommand2.Parameters.AddWithValue("@BARKOD5", dataSource.Rows[index]["BARKOD5"]);
            sqlCommand2.Parameters.AddWithValue("@SATISFIYATI", dataSource.Rows[index]["SATISFIYATI"]);
            sqlCommand2.Parameters.AddWithValue("@PARABIRIMI", dataSource.Rows[index]["PARABIRIMI"]);
            sqlCommand2.Parameters.AddWithValue("@KDVORANI", dataSource.Rows[index]["KDVORANI"]);
            sqlCommand2.Parameters.AddWithValue("@KDVDAHIL", dataSource.Rows[index]["KDVDAHIL"]);
            sqlCommand2.ExecuteNonQuery();
          }
        }
        sqlTransaction.Commit();
        return true;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
        sqlTransaction.Rollback();
        return flag;
      }
    }

    private bool update_mlz_h()
    {
      bool flag = false;
      SqlConnection connection = new SqlConnection(_main.str_connection);
      string empty = string.Empty;
      string cmdText1 = "UPDATE MALZEMELER SET KOD = '" + this.txt_kod.Text + "',AD = '" + this.txt_ad.Text + "',URETICIKODU = '" + this.txt_uretici.Text + "',MARKA = '" + this.txt_marka.Text + "'," + "GRUPKODU = '" + this.txt_grup.Text + "',TEDARIKCI = '" + this.txt_tedarikci.Text + "',ANAKATEGORI = '" + this.txt_ana.Text + "',ALTKATEGORI1 = '" + this.txt_alt1.Text + "'," + "ALTKATEGORI2 = '" + this.txt_alt2.Text + "',ALTKATEGORI3 = '" + this.txt_alt3.Text + "',KRESIM = @KRESIM,RESIM1 = @RESIM1,RESIM2 = @RESIM2,RESIM3 = @RESIM3 " + "WHERE ID = " + this._id;
      string cmdText2 = "UPDATE MALZEMEDETAY SET BARKOD1 = @BARKOD1, BARKOD2 = @BARKOD2, BARKOD3 = @BARKOD3, BARKOD4 = @BARKOD4, BARKOD5 = @BARKOD5, SATISFIYATI = @SATISFIYATI, PARABIRIMI = @PARABIRIMI, KDVORANI = @KDVORANI, KDVDAHIL = @KDVDAHIL " + "WHERE MALZEMEID = @MALZEMEID AND SATIRNO = @SATIRNO";
      try
      {
        byte[] numArray1 = this.pb_kresim.Image != null ? _main.imageToByteArray(this.pb_kresim.Image) : _main.imageToByteArray((Image) new Bitmap(1, 1));
        byte[] numArray2 = this.pb_resim1.Image != null ? _main.imageToByteArray(this.pb_resim1.Image) : _main.imageToByteArray((Image) new Bitmap(1, 1));
        byte[] numArray3 = this.pb_resim2.Image != null ? _main.imageToByteArray(this.pb_resim2.Image) : _main.imageToByteArray((Image) new Bitmap(1, 1));
        byte[] numArray4 = this.pb_resim3.Image != null ? _main.imageToByteArray(this.pb_resim3.Image) : _main.imageToByteArray((Image) new Bitmap(1, 1));
        SqlCommand sqlCommand1 = new SqlCommand(cmdText1, connection);
        sqlCommand1.Parameters.AddWithValue("@KRESIM", (object) numArray1);
        sqlCommand1.Parameters.AddWithValue("@RESIM1", (object) numArray2);
        sqlCommand1.Parameters.AddWithValue("@RESIM2", (object) numArray3);
        sqlCommand1.Parameters.AddWithValue("@RESIM3", (object) numArray4);
        connection.Open();
        sqlCommand1.ExecuteNonQuery();
        connection.Close();
        int int32 = Convert.ToInt32(this._id);
        DataTable dataSource = (DataTable) this.dtg_urun.DataSource;
        for (int index = 0; index < dataSource.Rows.Count; ++index)
        {
          SqlCommand sqlCommand2 = new SqlCommand(cmdText2, connection);
          sqlCommand2.Parameters.AddWithValue("@MALZEMEID", (object) int32);
          sqlCommand2.Parameters.AddWithValue("@SATIRNO", dataSource.Rows[index]["SATIRNO"]);
          sqlCommand2.Parameters.AddWithValue("@BARKOD1", dataSource.Rows[index]["BARKOD1"]);
          sqlCommand2.Parameters.AddWithValue("@BARKOD2", dataSource.Rows[index]["BARKOD2"]);
          sqlCommand2.Parameters.AddWithValue("@BARKOD3", dataSource.Rows[index]["BARKOD3"]);
          sqlCommand2.Parameters.AddWithValue("@BARKOD4", dataSource.Rows[index]["BARKOD4"]);
          sqlCommand2.Parameters.AddWithValue("@BARKOD5", dataSource.Rows[index]["BARKOD5"]);
          sqlCommand2.Parameters.AddWithValue("@SATISFIYATI", dataSource.Rows[index]["SATISFIYATI"]);
          sqlCommand2.Parameters.AddWithValue("@PARABIRIMI", dataSource.Rows[index]["PARABIRIMI"]);
          sqlCommand2.Parameters.AddWithValue("@KDVORANI", dataSource.Rows[index]["KDVORANI"]);
          sqlCommand2.Parameters.AddWithValue("@KDVDAHIL", dataSource.Rows[index]["KDVDAHIL"]);
          connection.Open();
          sqlCommand2.ExecuteNonQuery();
          connection.Close();
          sqlCommand2.Dispose();
        }
        return true;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
        if (connection.State == ConnectionState.Open)
          connection.Close();
        return flag;
      }
    }

    private bool update_mlz()
    {
      _main.komutcalistir("DELETE FROM MALZEMELER WHERE ID = " + this._id + " DELETE FROM MALZEMEDETAY WHERE MALZEMEID = " + this._id);
      return this.insert_mlz();
    }

    private bool alan_kontrol()
    {
      bool flag = true;
      if (this.txt_kod.Text.Length == 0)
      {
        this.ep1.SetError((Control) this.txt_kod, "Alan Boş Olamaz");
        return false;
      }
      this.ep1.Clear();
      if (this.txt_ad.Text.Length == 0)
      {
        this.ep1.SetError((Control) this.txt_ad, "Alan Boş Olamaz");
        return false;
      }
      if (this.grd_urun.RowCount < 1)
      {
        int num = (int) MessageBox.Show("En az bir birim seçmelisiniz.");
        return false;
      }
      if (this.grd_urun.RowCount != 1)
      {
        int rowCount = this.grd_urun.RowCount;
        for (int dataSourceIndex1 = 0; dataSourceIndex1 < rowCount; ++dataSourceIndex1)
        {
          string rowCellDisplayText1 = this.grd_urun.GetRowCellDisplayText(this.grd_urun.GetRowHandle(dataSourceIndex1), "BIRIMID");
          for (int dataSourceIndex2 = 0; dataSourceIndex2 < rowCount; ++dataSourceIndex2)
          {
            string rowCellDisplayText2 = this.grd_urun.GetRowCellDisplayText(this.grd_urun.GetRowHandle(dataSourceIndex2), "BIRIMID");
            if (rowCellDisplayText1 == rowCellDisplayText2 && dataSourceIndex1 != dataSourceIndex2)
            {
              int num = (int) MessageBox.Show("Aynı birim seçilemez");
              return false;
            }
          }
        }
      }
      return flag;
    }

    private void grd_urun_ValidateRow(object sender, ValidateRowEventArgs e)
    {
      if (!e.Valid)
        return;
      this.grd_urun.SetRowCellValue(e.RowHandle, "SATIRNO", (object) (this.grd_urun.GetVisibleIndex(e.RowHandle) + 1));
      if (this.grd_urun.GetVisibleIndex(e.RowHandle) == 0)
        this.grd_urun.SetRowCellValue(e.RowHandle, "ANABIRIM", (object) true);
      else
        this.grd_urun.SetRowCellValue(e.RowHandle, "ANABIRIM", (object) false);
    }

    private void grd_urun_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
    {
    }

    private void bb_ekle_ItemClick(object sender, ItemClickEventArgs e) => this.setnewrow();

    private void bb_sil_ItemClick(object sender, ItemClickEventArgs e)
    {
      this.grd_urun.DeleteSelectedRows();
      this.setsatirno();
    }

    private void setsatirno()
    {
      int rowCount = this.grd_urun.RowCount;
      for (int dataSourceIndex = 0; dataSourceIndex < rowCount; ++dataSourceIndex)
      {
        int rowHandle = this.grd_urun.GetRowHandle(dataSourceIndex);
        this.grd_urun.SetRowCellValue(rowHandle, "SATIRNO", (object) (this.grd_urun.GetVisibleIndex(rowHandle) + 1));
        if (this.grd_urun.GetVisibleIndex(rowHandle) == 0)
          this.grd_urun.SetRowCellValue(rowHandle, "ANABIRIM", (object) true);
        else
          this.grd_urun.SetRowCellValue(rowHandle, "ANABIRIM", (object) false);
      }
    }

    private void dtg_urun_MouseUp(object sender, MouseEventArgs e)
    {
      if (this._hareket_gormus || e.Button != MouseButtons.Right)
        return;
      this.pp1.ShowPopup(Control.MousePosition);
    }

    private void MalzemeFrm_KeyDown(object sender, KeyEventArgs e)
    {
      if (this._hareket_gormus)
        return;
      if (e.Shift && e.KeyCode == Keys.Insert)
        this.setnewrow();
      if (!e.Shift || e.KeyCode != Keys.Delete)
        return;
      this.grd_urun.DeleteSelectedRows();
      this.setsatirno();
    }

    private void setnewrow()
    {
      this.grd_urun.AddNewRow();
      this.grd_urun.SetFocusedRowCellValue("KATSAYI", (object) "1");
      this.grd_urun.SetFocusedRowCellValue("BIRIMID", (object) 1);
      this.grd_urun.SetFocusedRowCellValue("PARABIRIMI", (object) "TRL");
      this.grd_urun.SetFocusedRowCellValue("KDVDAHIL", (object) false);
    }

    private bool mlzkod_check(string _kod)
    {
      bool flag = false;
      if (string.IsNullOrEmpty(_main.komutcalistir_str("SELECT KOD FROM MALZEMELER WHERE KOD = '" + _kod + "'")))
        flag = true;
      return flag;
    }

    private void btn_eklek_Click(object sender, EventArgs e)
    {
      this.ofd.Filter = "Fotoğraf Dosyaları (*.jpg)|*.jpg";
      if (this.ofd.ShowDialog() != DialogResult.OK)
        return;
      this.pb_kresim.Image = Image.FromFile(this.ofd.FileName);
    }

    private void btn_silk_Click(object sender, EventArgs e) => this.pb_kresim.Image = (Image) null;

    private void btn_ekle1_Click(object sender, EventArgs e)
    {
      this.ofd.Filter = "Fotoğraf Dosyaları (*.jpg)|*.jpg";
      if (this.ofd.ShowDialog() != DialogResult.OK)
        return;
      this.pb_resim1.Image = Image.FromFile(this.ofd.FileName);
    }

    private void btn_sil1_Click(object sender, EventArgs e) => this.pb_resim1.Image = (Image) null;

    private void btn_ekle2_Click(object sender, EventArgs e)
    {
      this.ofd.Filter = "Fotoğraf Dosyaları (*.jpg)|*.jpg";
      if (this.ofd.ShowDialog() != DialogResult.OK)
        return;
      this.pb_resim2.Image = Image.FromFile(this.ofd.FileName);
    }

    private void btn_sil2_Click(object sender, EventArgs e) => this.pb_resim2.Image = (Image) null;

    private void btn_ekle3_Click(object sender, EventArgs e)
    {
      this.ofd.Filter = "Fotoğraf Dosyaları (*.jpg)|*.jpg";
      if (this.ofd.ShowDialog() != DialogResult.OK)
        return;
      this.pb_resim3.Image = Image.FromFile(this.ofd.FileName);
    }

    private void btn_sil3_Click(object sender, EventArgs e) => this.pb_resim3.Image = (Image) null;

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
      this.txt_alt3 = new TextBox();
      this.txt_alt2 = new TextBox();
      this.txt_alt1 = new TextBox();
      this.txt_ana = new TextBox();
      this.txt_tedarikci = new TextBox();
      this.txt_grup = new TextBox();
      this.txt_marka = new TextBox();
      this.txt_uretici = new TextBox();
      this.txt_ad = new TextBox();
      this.txt_kod = new TextBox();
      this.label10 = new Label();
      this.label9 = new Label();
      this.label8 = new Label();
      this.label7 = new Label();
      this.label6 = new Label();
      this.label5 = new Label();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.btn_kaydet = new SimpleButton();
      this.btn_iptal = new SimpleButton();
      this.dtg_urun = new GridControl();
      this.grd_urun = new GridView();
      this.bm1 = new BarManager(this.components);
      this.barDockControlTop = new BarDockControl();
      this.barDockControlBottom = new BarDockControl();
      this.barDockControlLeft = new BarDockControl();
      this.barDockControlRight = new BarDockControl();
      this.bb_ekle = new BarButtonItem();
      this.bb_sil = new BarButtonItem();
      this.repositoryItemComboBox1 = new RepositoryItemComboBox();
      this.groupBox2 = new GroupBox();
      this.btn_silk = new SimpleButton();
      this.btn_eklek = new SimpleButton();
      this.pb_kresim = new PictureBox();
      this.btn_sil1 = new SimpleButton();
      this.btn_ekle1 = new SimpleButton();
      this.pb_resim1 = new PictureBox();
      this.btn_sil2 = new SimpleButton();
      this.btn_ekle2 = new SimpleButton();
      this.pb_resim2 = new PictureBox();
      this.btn_sil3 = new SimpleButton();
      this.btn_ekle3 = new SimpleButton();
      this.pb_resim3 = new PictureBox();
      this.ep1 = new ErrorProvider(this.components);
      this.pp1 = new PopupMenu(this.components);
      this.ofd = new OpenFileDialog();
      this.xtab = new XtraTabControl();
      this.t_kucuk = new XtraTabPage();
      this.t1 = new XtraTabPage();
      this.t2 = new XtraTabPage();
      this.t3 = new XtraTabPage();
      this.groupBox1.SuspendLayout();
      this.dtg_urun.BeginInit();
      this.grd_urun.BeginInit();
      this.bm1.BeginInit();
      this.repositoryItemComboBox1.BeginInit();
      this.groupBox2.SuspendLayout();
      ((ISupportInitialize) this.pb_kresim).BeginInit();
      ((ISupportInitialize) this.pb_resim1).BeginInit();
      ((ISupportInitialize) this.pb_resim2).BeginInit();
      ((ISupportInitialize) this.pb_resim3).BeginInit();
      ((ISupportInitialize) this.ep1).BeginInit();
      this.pp1.BeginInit();
      this.xtab.BeginInit();
      this.xtab.SuspendLayout();
      this.t_kucuk.SuspendLayout();
      this.t1.SuspendLayout();
      this.t2.SuspendLayout();
      this.t3.SuspendLayout();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.txt_alt3);
      this.groupBox1.Controls.Add((Control) this.txt_alt2);
      this.groupBox1.Controls.Add((Control) this.txt_alt1);
      this.groupBox1.Controls.Add((Control) this.txt_ana);
      this.groupBox1.Controls.Add((Control) this.txt_tedarikci);
      this.groupBox1.Controls.Add((Control) this.txt_grup);
      this.groupBox1.Controls.Add((Control) this.txt_marka);
      this.groupBox1.Controls.Add((Control) this.txt_uretici);
      this.groupBox1.Controls.Add((Control) this.txt_ad);
      this.groupBox1.Controls.Add((Control) this.txt_kod);
      this.groupBox1.Controls.Add((Control) this.label10);
      this.groupBox1.Controls.Add((Control) this.label9);
      this.groupBox1.Controls.Add((Control) this.label8);
      this.groupBox1.Controls.Add((Control) this.label7);
      this.groupBox1.Controls.Add((Control) this.label6);
      this.groupBox1.Controls.Add((Control) this.label5);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Location = new Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(579, 185);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Ürün Genel Tanımları";
      this.txt_alt3.Location = new Point(392, 140);
      this.txt_alt3.Name = "txt_alt3";
      this.txt_alt3.Size = new Size(172, 21);
      this.txt_alt3.TabIndex = 19;
      this.txt_alt2.Location = new Point(392, 114);
      this.txt_alt2.Name = "txt_alt2";
      this.txt_alt2.Size = new Size(172, 21);
      this.txt_alt2.TabIndex = 18;
      this.txt_alt1.Location = new Point(392, 88);
      this.txt_alt1.Name = "txt_alt1";
      this.txt_alt1.Size = new Size(172, 21);
      this.txt_alt1.TabIndex = 17;
      this.txt_ana.Location = new Point(392, 62);
      this.txt_ana.Name = "txt_ana";
      this.txt_ana.Size = new Size(172, 21);
      this.txt_ana.TabIndex = 16;
      this.txt_tedarikci.Location = new Point(392, 36);
      this.txt_tedarikci.Name = "txt_tedarikci";
      this.txt_tedarikci.Size = new Size(172, 21);
      this.txt_tedarikci.TabIndex = 15;
      this.txt_grup.Location = new Point(91, 140);
      this.txt_grup.Name = "txt_grup";
      this.txt_grup.Size = new Size(172, 21);
      this.txt_grup.TabIndex = 14;
      this.txt_marka.Location = new Point(91, 114);
      this.txt_marka.Name = "txt_marka";
      this.txt_marka.Size = new Size(172, 21);
      this.txt_marka.TabIndex = 13;
      this.txt_uretici.Location = new Point(91, 88);
      this.txt_uretici.Name = "txt_uretici";
      this.txt_uretici.Size = new Size(172, 21);
      this.txt_uretici.TabIndex = 12;
      this.txt_ad.Location = new Point(91, 62);
      this.txt_ad.Name = "txt_ad";
      this.txt_ad.Size = new Size(172, 21);
      this.txt_ad.TabIndex = 11;
      this.txt_kod.Location = new Point(91, 36);
      this.txt_kod.Name = "txt_kod";
      this.txt_kod.Size = new Size(172, 21);
      this.txt_kod.TabIndex = 10;
      this.label10.AutoSize = true;
      this.label10.Location = new Point(312, 143);
      this.label10.Name = "label10";
      this.label10.Size = new Size(69, 13);
      this.label10.TabIndex = 9;
      this.label10.Text = "Alt Kategori3";
      this.label9.AutoSize = true;
      this.label9.Location = new Point(312, 117);
      this.label9.Name = "label9";
      this.label9.Size = new Size(69, 13);
      this.label9.TabIndex = 8;
      this.label9.Text = "Alt Kategori2";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(312, 91);
      this.label8.Name = "label8";
      this.label8.Size = new Size(69, 13);
      this.label8.TabIndex = 7;
      this.label8.Text = "Alt Kategori1";
      this.label7.AutoSize = true;
      this.label7.Location = new Point(312, 65);
      this.label7.Name = "label7";
      this.label7.Size = new Size(69, 13);
      this.label7.TabIndex = 6;
      this.label7.Text = "Ana Kategori";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(312, 39);
      this.label6.Name = "label6";
      this.label6.Size = new Size(49, 13);
      this.label6.TabIndex = 5;
      this.label6.Text = "Tedarikçi";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(18, 143);
      this.label5.Name = "label5";
      this.label5.Size = new Size(57, 13);
      this.label5.TabIndex = 4;
      this.label5.Text = "Grup Kodu";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(18, 117);
      this.label4.Name = "label4";
      this.label4.Size = new Size(36, 13);
      this.label4.TabIndex = 3;
      this.label4.Text = "Marka";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(18, 91);
      this.label3.Name = "label3";
      this.label3.Size = new Size(37, 13);
      this.label3.TabIndex = 2;
      this.label3.Text = "Üretici";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(18, 65);
      this.label2.Name = "label2";
      this.label2.Size = new Size(20, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Ad";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(18, 39);
      this.label1.Name = "label1";
      this.label1.Size = new Size(25, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Kod";
      this.btn_kaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kaydet.Location = new Point(13, 453);
      this.btn_kaydet.Name = "btn_kaydet";
      this.btn_kaydet.Size = new Size(75, 33);
      this.btn_kaydet.TabIndex = 24;
      this.btn_kaydet.Text = "Kaydet";
      this.btn_kaydet.Click += new EventHandler(this.btn_kaydet_Click);
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(99, 453);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 25;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.dtg_urun.Dock = DockStyle.Fill;
      this.dtg_urun.Location = new Point(3, 17);
      this.dtg_urun.MainView = (BaseView) this.grd_urun;
      this.dtg_urun.MenuManager = (IDXMenuManager) this.bm1;
      this.dtg_urun.Name = "dtg_urun";
      this.dtg_urun.RepositoryItems.AddRange(new RepositoryItem[1]
      {
        (RepositoryItem) this.repositoryItemComboBox1
      });
      this.dtg_urun.Size = new Size(965, 216);
      this.dtg_urun.TabIndex = 0;
      this.dtg_urun.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_urun
      });
      this.dtg_urun.MouseUp += new MouseEventHandler(this.dtg_urun_MouseUp);
      this.grd_urun.FocusRectStyle = DrawFocusRectStyle.RowFocus;
      this.grd_urun.GridControl = this.dtg_urun;
      this.grd_urun.Name = "grd_urun";
      this.grd_urun.OptionsBehavior.AllowAddRows = DefaultBoolean.False;
      this.grd_urun.OptionsBehavior.AllowDeleteRows = DefaultBoolean.False;
      this.grd_urun.OptionsBehavior.AllowFixedGroups = DefaultBoolean.False;
      this.grd_urun.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
      this.grd_urun.OptionsLayout.Columns.StoreAllOptions = true;
      this.grd_urun.OptionsLayout.Columns.StoreAppearance = true;
      this.grd_urun.OptionsLayout.StoreAllOptions = true;
      this.grd_urun.OptionsLayout.StoreAppearance = true;
      this.grd_urun.OptionsMenu.EnableGroupPanelMenu = false;
      this.grd_urun.OptionsView.EnableAppearanceEvenRow = true;
      this.grd_urun.OptionsView.ShowGroupPanel = false;
      this.grd_urun.ShowButtonMode = ShowButtonModeEnum.ShowAlways;
      this.grd_urun.InvalidRowException += new InvalidRowExceptionEventHandler(this.grd_urun_InvalidRowException);
      this.grd_urun.ValidateRow += new ValidateRowEventHandler(this.grd_urun_ValidateRow);
      this.bm1.DockControls.Add(this.barDockControlTop);
      this.bm1.DockControls.Add(this.barDockControlBottom);
      this.bm1.DockControls.Add(this.barDockControlLeft);
      this.bm1.DockControls.Add(this.barDockControlRight);
      this.bm1.Form = (Control) this;
      this.bm1.Items.AddRange(new BarItem[2]
      {
        (BarItem) this.bb_ekle,
        (BarItem) this.bb_sil
      });
      this.bm1.MaxItemId = 4;
      this.barDockControlTop.CausesValidation = false;
      this.barDockControlTop.Dock = DockStyle.Top;
      this.barDockControlTop.Location = new Point(0, 0);
      this.barDockControlTop.Size = new Size(999, 0);
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = DockStyle.Bottom;
      this.barDockControlBottom.Location = new Point(0, 498);
      this.barDockControlBottom.Size = new Size(999, 0);
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = DockStyle.Left;
      this.barDockControlLeft.Location = new Point(0, 0);
      this.barDockControlLeft.Size = new Size(0, 498);
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = DockStyle.Right;
      this.barDockControlRight.Location = new Point(999, 0);
      this.barDockControlRight.Size = new Size(0, 498);
      this.bb_ekle.Caption = "Ekle";
      this.bb_ekle.Id = 0;
      this.bb_ekle.Name = "bb_ekle";
      this.bb_ekle.ItemClick += new ItemClickEventHandler(this.bb_ekle_ItemClick);
      this.bb_sil.Caption = "Sil";
      this.bb_sil.Id = 2;
      this.bb_sil.Name = "bb_sil";
      this.bb_sil.ItemClick += new ItemClickEventHandler(this.bb_sil_ItemClick);
      this.repositoryItemComboBox1.AutoHeight = false;
      this.repositoryItemComboBox1.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Combo)
      });
      this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
      this.groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox2.Controls.Add((Control) this.dtg_urun);
      this.groupBox2.Location = new Point(12, 203);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(971, 236);
      this.groupBox2.TabIndex = 26;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Ürün Detay Tanımları";
      this.btn_silk.Cursor = Cursors.Hand;
      this.btn_silk.Image = (Image) Resources.note_delete;
      this.btn_silk.Location = new Point(242, 88);
      this.btn_silk.Name = "btn_silk";
      this.btn_silk.Size = new Size(110, 36);
      this.btn_silk.TabIndex = 6;
      this.btn_silk.Text = "Resim Sil";
      this.btn_silk.Click += new EventHandler(this.btn_silk_Click);
      this.btn_eklek.Cursor = Cursors.Hand;
      this.btn_eklek.Image = (Image) Resources.note_add;
      this.btn_eklek.Location = new Point(242, 26);
      this.btn_eklek.Name = "btn_eklek";
      this.btn_eklek.Size = new Size(110, 36);
      this.btn_eklek.TabIndex = 5;
      this.btn_eklek.Text = "Resim Ekle";
      this.btn_eklek.Click += new EventHandler(this.btn_eklek_Click);
      this.pb_kresim.BorderStyle = BorderStyle.FixedSingle;
      this.pb_kresim.Location = new Point(11, 6);
      this.pb_kresim.Name = "pb_kresim";
      this.pb_kresim.Size = new Size(112, 99);
      this.pb_kresim.SizeMode = PictureBoxSizeMode.Zoom;
      this.pb_kresim.TabIndex = 1;
      this.pb_kresim.TabStop = false;
      this.btn_sil1.Cursor = Cursors.Hand;
      this.btn_sil1.Image = (Image) Resources.note_delete;
      this.btn_sil1.Location = new Point(242, 88);
      this.btn_sil1.Name = "btn_sil1";
      this.btn_sil1.Size = new Size(110, 36);
      this.btn_sil1.TabIndex = 4;
      this.btn_sil1.Text = "Resim Sil";
      this.btn_sil1.Click += new EventHandler(this.btn_sil1_Click);
      this.btn_ekle1.Cursor = Cursors.Hand;
      this.btn_ekle1.Image = (Image) Resources.note_add;
      this.btn_ekle1.Location = new Point(242, 26);
      this.btn_ekle1.Name = "btn_ekle1";
      this.btn_ekle1.Size = new Size(110, 36);
      this.btn_ekle1.TabIndex = 3;
      this.btn_ekle1.Text = "Resim Ekle";
      this.btn_ekle1.Click += new EventHandler(this.btn_ekle1_Click);
      this.pb_resim1.BorderStyle = BorderStyle.FixedSingle;
      this.pb_resim1.Location = new Point(6, 6);
      this.pb_resim1.Name = "pb_resim1";
      this.pb_resim1.Size = new Size(213, 144);
      this.pb_resim1.SizeMode = PictureBoxSizeMode.Zoom;
      this.pb_resim1.TabIndex = 2;
      this.pb_resim1.TabStop = false;
      this.btn_sil2.Cursor = Cursors.Hand;
      this.btn_sil2.Image = (Image) Resources.note_delete;
      this.btn_sil2.Location = new Point(242, 88);
      this.btn_sil2.Name = "btn_sil2";
      this.btn_sil2.Size = new Size(110, 36);
      this.btn_sil2.TabIndex = 6;
      this.btn_sil2.Text = "Resim Sil";
      this.btn_sil2.Click += new EventHandler(this.btn_sil2_Click);
      this.btn_ekle2.Cursor = Cursors.Hand;
      this.btn_ekle2.Image = (Image) Resources.note_add;
      this.btn_ekle2.Location = new Point(242, 26);
      this.btn_ekle2.Name = "btn_ekle2";
      this.btn_ekle2.Size = new Size(110, 36);
      this.btn_ekle2.TabIndex = 5;
      this.btn_ekle2.Text = "Resim Ekle";
      this.btn_ekle2.Click += new EventHandler(this.btn_ekle2_Click);
      this.pb_resim2.BorderStyle = BorderStyle.FixedSingle;
      this.pb_resim2.Location = new Point(6, 6);
      this.pb_resim2.Name = "pb_resim2";
      this.pb_resim2.Size = new Size(213, 144);
      this.pb_resim2.SizeMode = PictureBoxSizeMode.Zoom;
      this.pb_resim2.TabIndex = 3;
      this.pb_resim2.TabStop = false;
      this.btn_sil3.Cursor = Cursors.Hand;
      this.btn_sil3.Image = (Image) Resources.note_delete;
      this.btn_sil3.Location = new Point(242, 88);
      this.btn_sil3.Name = "btn_sil3";
      this.btn_sil3.Size = new Size(110, 36);
      this.btn_sil3.TabIndex = 6;
      this.btn_sil3.Text = "Resim Sil";
      this.btn_sil3.Click += new EventHandler(this.btn_sil3_Click);
      this.btn_ekle3.Cursor = Cursors.Hand;
      this.btn_ekle3.Image = (Image) Resources.note_add;
      this.btn_ekle3.Location = new Point(242, 26);
      this.btn_ekle3.Name = "btn_ekle3";
      this.btn_ekle3.Size = new Size(110, 36);
      this.btn_ekle3.TabIndex = 5;
      this.btn_ekle3.Text = "Resim Ekle";
      this.btn_ekle3.Click += new EventHandler(this.btn_ekle3_Click);
      this.pb_resim3.BorderStyle = BorderStyle.FixedSingle;
      this.pb_resim3.Location = new Point(6, 6);
      this.pb_resim3.Name = "pb_resim3";
      this.pb_resim3.Size = new Size(213, 144);
      this.pb_resim3.SizeMode = PictureBoxSizeMode.Zoom;
      this.pb_resim3.TabIndex = 3;
      this.pb_resim3.TabStop = false;
      this.ep1.ContainerControl = (ContainerControl) this;
      this.pp1.LinksPersistInfo.AddRange(new LinkPersistInfo[2]
      {
        new LinkPersistInfo((BarItem) this.bb_ekle),
        new LinkPersistInfo((BarItem) this.bb_sil)
      });
      this.pp1.Manager = this.bm1;
      this.pp1.Name = "pp1";
      this.xtab.Location = new Point(597, 12);
      this.xtab.Name = "xtab";
      this.xtab.SelectedTabPage = this.t_kucuk;
      this.xtab.Size = new Size(385, 185);
      this.xtab.TabIndex = 32;
      this.xtab.TabPages.AddRange(new XtraTabPage[4]
      {
        this.t_kucuk,
        this.t1,
        this.t2,
        this.t3
      });
      this.t_kucuk.Controls.Add((Control) this.btn_silk);
      this.t_kucuk.Controls.Add((Control) this.btn_eklek);
      this.t_kucuk.Controls.Add((Control) this.pb_kresim);
      this.t_kucuk.Name = "t_kucuk";
      this.t_kucuk.Size = new Size(379, 157);
      this.t_kucuk.Text = "Ürün Resmi (Küçük)";
      this.t1.Controls.Add((Control) this.btn_sil1);
      this.t1.Controls.Add((Control) this.btn_ekle1);
      this.t1.Controls.Add((Control) this.pb_resim1);
      this.t1.Name = "t1";
      this.t1.Size = new Size(379, 157);
      this.t1.Text = "Ürün Resmi 1";
      this.t2.Controls.Add((Control) this.btn_sil2);
      this.t2.Controls.Add((Control) this.btn_ekle2);
      this.t2.Controls.Add((Control) this.pb_resim2);
      this.t2.Name = "t2";
      this.t2.Size = new Size(379, 157);
      this.t2.Text = "Ürün Resmi 2";
      this.t3.Controls.Add((Control) this.btn_sil3);
      this.t3.Controls.Add((Control) this.pb_resim3);
      this.t3.Controls.Add((Control) this.btn_ekle3);
      this.t3.Name = "t3";
      this.t3.Size = new Size(379, 157);
      this.t3.Text = "Ürün Resmi 3";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(999, 498);
      this.Controls.Add((Control) this.xtab);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.btn_kaydet);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.barDockControlLeft);
      this.Controls.Add((Control) this.barDockControlRight);
      this.Controls.Add((Control) this.barDockControlBottom);
      this.Controls.Add((Control) this.barDockControlTop);
      this.KeyPreview = true;
      this.MinimizeBox = false;
      this.Name = nameof (MalzemeFrm);
      this.Text = "Ürün";
      this.Load += new EventHandler(this.MalzemeFrm_Load);
      this.KeyDown += new KeyEventHandler(this.MalzemeFrm_KeyDown);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.dtg_urun.EndInit();
      this.grd_urun.EndInit();
      this.bm1.EndInit();
      this.repositoryItemComboBox1.EndInit();
      this.groupBox2.ResumeLayout(false);
      ((ISupportInitialize) this.pb_kresim).EndInit();
      ((ISupportInitialize) this.pb_resim1).EndInit();
      ((ISupportInitialize) this.pb_resim2).EndInit();
      ((ISupportInitialize) this.pb_resim3).EndInit();
      ((ISupportInitialize) this.ep1).EndInit();
      this.pp1.EndInit();
      this.xtab.EndInit();
      this.xtab.ResumeLayout(false);
      this.t_kucuk.ResumeLayout(false);
      this.t1.ResumeLayout(false);
      this.t2.ResumeLayout(false);
      this.t3.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
