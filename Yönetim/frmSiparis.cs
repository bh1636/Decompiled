// Decompiled with JetBrains decompiler
// Type: Yönetim.frmSiparis
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Yönetim.Properties;

#nullable disable
namespace Yönetim
{
  public class frmSiparis : Form
  {
    private int Yukseklik = 0;
    private int Genislik = 0;
    private DataTable dtListe = (DataTable) null;
    public string Seri = "";
    public int Sira = 0;
    public string CariKod = "";
    public string CariUnvan = "";
    public string plasiyer = "";
    public string musteritipi = "";
    private IContainer components = (IContainer) null;
    private GroupControl groupControl1;
    private GroupControl groupControl2;
    private GridControl gridControl1;
    private GridView gridView1;
    private GridColumn gridColumn1;
    private GridColumn gridColumn2;
    private GridColumn gridColumn3;
    private GridColumn gridColumn4;
    private GridColumn gridColumn5;
    private GridColumn gridColumn6;
    private GridColumn gridColumn7;
    private GridColumn gridColumn8;
    private GridColumn gridColumn9;
    private GroupControl groupControl3;
    private Label label6;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label2;
    private Label label1;
    private Label lblgeneltoplam;
    private Label lblkdv;
    private Label lblaratoplam2;
    private Label lbliskonto2;
    private Label lblisktono1;
    private Label lblaratoplam;
    private Label label15;
    private Label label14;
    private Label label13;
    private DateTimePicker dateTimePicker1;
    private ButtonEdit btnCariAdi;
    private ButtonEdit btnCariKod;
    private TextBox txtEvrakNo;
    private Label label16;
    private GridColumn gridColumn10;
    private ToolStrip toolStrip1;
    private ToolStripButton toolStripButton1;
    private ToolStripButton toolStripButton2;
    private ToolStripSeparator toolStripSeparator1;
    private RepositoryItemTextEdit btnmiktar;
    private RepositoryItemTextEdit btfiyat;
    private RepositoryItemTextEdit btnisk1;
    private RepositoryItemTextEdit btnisk2;
    private RepositoryItemButtonEdit repositoryItemButtonEdit1;
    private RepositoryItemButtonEdit repositoryItemButtonEdit2;
    private GridColumn gridColumn11;
    private GridColumn gridColumn12;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripButton toolStripButton3;
    public TextBox textBox1;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripButton toolStripButton4;
    private ToolStripSeparator toolStripSeparator6;
    private ToolStripButton toolStripButton7;
    private ToolStripSeparator toolStripSeparator7;
    private Label label31;
    private System.Windows.Forms.ComboBox cmbPlasiyer;
    private ButtonEdit txtPrkAdi;
    private ButtonEdit txtPrkKod;
    private Label label7;
    private Label label8;
    private TextBox txtAraBayiiAdi;
    private Label label9;
    private Label lblpromosyontopla;
    private Label label11;

    public frmSiparis() => this.InitializeComponent();

    private void label15_Click(object sender, EventArgs e)
    {
    }

    private void label14_Click(object sender, EventArgs e)
    {
    }

    private void plsiyerYukle()
    {
      this.cmbPlasiyer.DataSource = (object) DBManager.sqlGetDataTable(new SqlCommand("select * from PLASIYERLER"));
      this.cmbPlasiyer.DisplayMember = "ISIM";
      this.cmbPlasiyer.ValueMember = "LOGICALREF";
    }

    private void frmSiparis_Load(object sender, EventArgs e)
    {
      this.plsiyerYukle();
      this.txtEvrakNo.Text = this.Seri;
      this.textBox1.Text = this.Sira.ToString();
      this.btnCariAdi.Text = this.CariUnvan;
      this.btnCariKod.Text = this.CariKod;
      SqlCommand mCommand = new SqlCommand("ex_SiparisDetay");
      mCommand.CommandType = CommandType.StoredProcedure;
      mCommand.Parameters.AddWithValue("@SERI", (object) this.Seri);
      mCommand.Parameters.AddWithValue("@SIRA", (object) this.Sira);
      this.dtListe = DBManager.sqlGetDataTable(mCommand);
      this.gridControl1.DataSource = (object) this.dtListe;
      this.AltToplamAL();
      for (int index = 0; index < this.gridView1.Columns.Count; ++index)
      {
        if (this.gridView1.Columns[index].ColumnType.FullName != "System.String" && this.gridView1.Columns[index].ColumnType.FullName != "System.Int32" && this.gridView1.Columns[index].FieldName != "sip_miktar" && this.gridView1.Columns[index].FieldName != "sip_iskonto_1" && this.gridView1.Columns[index].FieldName != "sip_iskonto_2")
        {
          this.gridView1.Columns[index].DisplayFormat.FormatType = FormatType.Numeric;
          this.gridView1.Columns[index].DisplayFormat.FormatString = "C";
        }
      }
      if (Convert.ToInt32(this.Sira) > 0)
      {
        this.plasiyer = this.dtListe.Rows[0]["PLASIYER"].ToString();
        this.txtPrkKod.Text = this.dtListe.Rows[0]["PRKOD"].ToString();
        this.txtPrkAdi.Text = this.dtListe.Rows[0]["PRUNVAN"].ToString();
        this.txtAraBayiiAdi.Text = this.dtListe.Rows[0]["ARABAYIADI"].ToString();
        try
        {
          this.cmbPlasiyer.SelectedValue = (object) this.plasiyer;
        }
        catch (Exception ex)
        {
        }
      }
      this.gridView1.BestFitColumns();
    }

    private void frmSiparis_LocationChanged(object sender, EventArgs e)
    {
    }

    private void toolStripButton2_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Yazdırmak İstermisiniz.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) != DialogResult.Yes)
        return;
      SqlCommand mCommand = new SqlCommand("INSERT INTO RMZ_EVRAKLISTESI(EVRAKSERI,EVRAKSIRA,PRINTER,YAZDIRILDIMI) VALUES (@EVRAKSERI,@EVRAKSIRA,@PRINTER,@YAZDIRILDIMI)");
      mCommand.Parameters.AddWithValue("@EVRAKSERI", (object) this.txtEvrakNo.Text);
      mCommand.Parameters.AddWithValue("@EVRAKSIRA", (object) this.textBox1.Text);
      mCommand.Parameters.AddWithValue("@PRINTER", (object) "");
      mCommand.Parameters.AddWithValue("@YAZDIRILDIMI", (object) "");
      DBManager.sqlRunCommand(mCommand);
      this.Close();
    }

    private int SatirNo()
    {
      return this.gridView1.SelectedRowsCount > 0 ? this.gridView1.GetSelectedRows()[0] : -100;
    }

    private void rehber()
    {
      frmStokRehber frmStokRehber = new frmStokRehber();
      int num = (int) frmStokRehber.ShowDialog();
      int index = this.SatirNo();
      try
      {
        if (index == 0 || index < 0)
        {
          DataRow row = this.dtListe.NewRow();
          row["sip_stok_kod"] = (object) frmStokRehber.kod;
          row["sto_isim"] = (object) frmStokRehber.isim;
          row["sip_miktar"] = (object) "0";
          row["KdvOrani"] = (object) frmStokRehber.kdv;
          row["sip_aciklama2"] = (object) frmStokRehber.birimAdi;
          row["KdvMat"] = (object) "0";
          row["Birim"] = (object) frmStokRehber.fiyat;
          row["sip_iskonto_1"] = (object) frmStokRehber.isk1;
          row["sip_iskonto_2"] = (object) frmStokRehber.isk2;
          row["isk1"] = (object) 0;
          row["isk2"] = (object) 0;
          row["Toplam"] = (object) "0";
          this.dtListe.Rows.Add(row);
        }
        else
        {
          this.dtListe.Rows[index]["sip_stok_kod"] = (object) frmStokRehber.kod;
          this.dtListe.Rows[index]["sto_isim"] = (object) frmStokRehber.isim;
          this.dtListe.Rows[index]["sip_miktar"] = (object) frmStokRehber.kdv;
          this.dtListe.Rows[index]["sip_aciklama2"] = (object) frmStokRehber.birimAdi;
        }
      }
      catch (Exception ex)
      {
      }
    }

    private void AltToplamAL()
    {
      Decimal num1 = 0M;
      Decimal num2 = 0M;
      Decimal num3 = 0M;
      Decimal num4 = 0M;
      Decimal num5 = 0M;
      Decimal num6 = 0M;
      foreach (DataRow dataRow in this.dtListe.Select("", "", DataViewRowState.CurrentRows))
      {
        if (dataRow["sip_miktar"].ToString().Length > 0)
        {
          Decimal num7 = Convert.ToDecimal(dataRow["sip_miktar"].ToString());
          Decimal num8 = Convert.ToDecimal(dataRow["Birim"].ToString());
          Decimal num9 = Convert.ToDecimal(dataRow["KdvMat"].ToString());
          Decimal num10 = Convert.ToDecimal(dataRow["isk1"].ToString());
          Decimal num11 = Convert.ToDecimal(dataRow["isk2"].ToString());
          Decimal num12 = Convert.ToDecimal(dataRow["Toplam"].ToString());
          if (dataRow["sip_aciklama2"].ToString() == "Prom.")
            num6 += Convert.ToDecimal(dataRow["PROTUTAR"].ToString());
          Decimal num13 = num7 * num8;
          num1 += num13;
          num2 += num9;
          num3 += num10;
          num4 += num11;
          num5 += num12;
        }
      }
      this.lblpromosyontopla.Text = num6.ToString("c");
      this.lblaratoplam.Text = num1.ToString("c");
      this.lbliskonto2.Text = num4.ToString("c");
      this.lblisktono1.Text = num3.ToString("c");
      this.lblaratoplam2.Text = (num1 - (num3 + num4)).ToString("c");
      this.lblkdv.Text = num2.ToString("c");
      this.lblgeneltoplam.Text = num5.ToString("c");
    }

    private void Hesap()
    {
      try
      {
        this.gridView1.UpdateCurrentRow();
        Decimal num1 = Convert.ToDecimal(this.gridView1.GetRowCellValue(this.SatirNo(), "sip_miktar"));
        Decimal num2 = Convert.ToDecimal(this.gridView1.GetRowCellValue(this.SatirNo(), "Birim"));
        Decimal num3 = Convert.ToDecimal(this.gridView1.GetRowCellValue(this.SatirNo(), "KdvOrani"));
        Decimal num4 = Convert.ToDecimal(this.gridView1.GetRowCellValue(this.SatirNo(), "sip_iskonto_1"));
        Decimal num5 = Convert.ToDecimal(this.gridView1.GetRowCellValue(this.SatirNo(), "sip_iskonto_2"));
        Decimal num6 = num1 * num2;
        if (num4 != 0M)
        {
          this.dtListe.Rows[this.SatirNo()]["isk1"] = (object) (num6 * num4 / 100M);
          num6 -= num6 * num4 / 100M;
        }
        else
          this.gridView1.SetRowCellValue(this.SatirNo(), "isk1", (object) 0);
        if (num5 != 0M)
        {
          this.dtListe.Rows[this.SatirNo()]["isk2"] = (object) (num6 * num5 / 100M);
          num6 -= num6 * num5 / 100M;
        }
        else
          this.gridView1.SetRowCellValue(this.SatirNo(), "isk2", (object) 0);
        Decimal num7 = num6 * num3 / 100M;
        this.gridView1.SetRowCellValue(this.SatirNo(), "KdvMat", (object) num7);
        this.gridView1.SetRowCellValue(this.SatirNo(), "Toplam", (object) (num6 + num7));
        this.AltToplamAL();
      }
      catch (Exception ex)
      {
      }
    }

    private void btnisim_KeyDown(object sender, KeyEventArgs e) => this.rehber();

    private void btnisim_Leave(object sender, EventArgs e) => this.rehber();

    private void btnkod_Leave(object sender, EventArgs e) => this.rehber();

    private void hesap(object sender, EventArgs e) => this.Hesap();

    private void repositoryItemButtonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
    {
      this.rehber();
    }

    private void repositoryItemButtonEdit2_ButtonClick(object sender, ButtonPressedEventArgs e)
    {
      this.rehber();
    }

    private void toolStripButton1_Click(object sender, EventArgs e) => this.Close();

    private void toolStripButton3_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Bu Evrağı Kayıt  İstediğinizden Eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
        return;
      this.dtListe.WriteXml(Application.StartupPath + "\\" + this.txtEvrakNo.Text + "-" + this.textBox1.Text + ".XML", XmlWriteMode.WriteSchema);
      DBManager.sqlRunCommand(new SqlCommand("DELETE FROM SIPARISLER WHERE sip_evrakno_seri='" + this.txtEvrakNo.Text + "' and sip_evrakno_sira=" + this.textBox1.Text));
      foreach (DataRow dataRow in this.dtListe.Select("", "", DataViewRowState.CurrentRows))
      {
        try
        {
          if (dataRow["sip_miktar"].ToString().Length > 0)
          {
            SqlCommand mCommand = new SqlCommand();
            mCommand.CommandType = CommandType.StoredProcedure;
            mCommand.CommandText = "sp_SIPARIS";
            mCommand.Parameters.AddWithValue("@SERI", (object) this.txtEvrakNo.Text);
            mCommand.Parameters.AddWithValue("@SIRA", (object) this.textBox1.Text);
            mCommand.Parameters.AddWithValue("@STOKKODU", (object) dataRow["sip_stok_kod"].ToString());
            mCommand.Parameters.AddWithValue("@MUSTERIKODU", (object) this.btnCariKod.Text);
            mCommand.Parameters.AddWithValue("@MIKTAR", (object) Convert.ToDecimal(dataRow["sip_miktar"]));
            mCommand.Parameters.AddWithValue("@BFIYAT", (object) Convert.ToDecimal(dataRow["Birim"]));
            mCommand.Parameters.AddWithValue("@TUTAR", (object) Convert.ToDecimal(dataRow["Toplam"]));
            mCommand.Parameters.AddWithValue("@ISKONTO1", (object) Convert.ToDecimal(dataRow["isk1"]));
            mCommand.Parameters.AddWithValue("@ISKONTO2", (object) Convert.ToDecimal(dataRow["isk2"]));
            mCommand.Parameters.AddWithValue("@BIRIM", (object) "1");
            mCommand.Parameters.AddWithValue("@VERGIPNTR", (object) 4);
            mCommand.Parameters.AddWithValue("@VERGI", (object) Convert.ToDecimal(dataRow["KdvMat"]));
            mCommand.Parameters.AddWithValue("@ACIKLAMA", (object) dataRow["BirimAd"].ToString());
            mCommand.Parameters.AddWithValue("@ARABAYI", (object) this.txtAraBayiiAdi.Text);
            mCommand.Parameters.AddWithValue("@ALTBAYI", (object) this.txtPrkKod.Text);
            try
            {
              mCommand.Parameters.AddWithValue("@PLASIYER", (object) this.cmbPlasiyer.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
              mCommand.Parameters.AddWithValue("@PLASIYER", (object) "");
            }
            DBManager.sqlRunCommand(mCommand);
          }
        }
        catch (SqlException ex)
        {
          int num = (int) MessageBox.Show(ex.Message);
        }
      }
      this.toolStripButton2_Click(sender, e);
      this.Close();
    }

    private void toolStripButton4_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Bu Evrağı Silmek İstediğinizden Eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
        return;
      DBManager.sqlRunCommand(new SqlCommand("DELETE FROM SIPARISLER WHERE sip_evrakno_seri='" + this.Seri + "' and sip_evrakno_sira=" + (object) this.Sira));
      this.Close();
    }

    private void repositoryItemButtonEdit1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.F10)
        return;
      this.rehber();
    }

    private void repositoryItemButtonEdit2_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.F10)
        return;
      this.rehber();
    }

    private void repositoryItemButtonEdit1_KeyPress(object sender, KeyPressEventArgs e)
    {
    }

    private void toolStripButton5_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "Siparis Yedek Dosyası |*.xml";
      if (saveFileDialog.ShowDialog() != DialogResult.Yes)
        return;
      int num = (int) this.dtListe.ReadXml(saveFileDialog.FileName);
    }

    private void toolStripButton6_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "Siparis Yedek Dosyası |*.xml";
      if (saveFileDialog.ShowDialog() != DialogResult.Yes)
        return;
      this.dtListe.WriteXml(saveFileDialog.FileName + "\\" + this.txtEvrakNo.Text + "-" + this.textBox1.Text + ".XML", XmlWriteMode.WriteSchema);
    }

    private void btnCariKod_ButtonClick(object sender, ButtonPressedEventArgs e)
    {
      frmCariRehber frmCariRehber = new frmCariRehber();
      int num = (int) frmCariRehber.ShowDialog();
      if (frmCariRehber.CariKod.Length <= 0)
        return;
      this.btnCariAdi.Text = frmCariRehber.CariIsim;
      this.btnCariKod.Text = frmCariRehber.CariKod;
    }

    private void btnCariAdi_ButtonClick(object sender, ButtonPressedEventArgs e)
    {
      frmCariRehber frmCariRehber = new frmCariRehber();
      int num = (int) frmCariRehber.ShowDialog();
      if (frmCariRehber.CariKod.Length <= 0)
        return;
      this.btnCariAdi.Text = frmCariRehber.CariIsim;
      this.btnCariKod.Text = frmCariRehber.CariKod;
    }

    private void button1_Click(object sender, EventArgs e)
    {
    }

    private void toolStripButton7_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Kopya Kayıt Edilecek.", "Uyari", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
        return;
      SqlCommand mCommand = new SqlCommand();
      mCommand.CommandText = "SELECT ISNULL(MAX(sip_evrakno_sira),0)+2 FROM SIPARISLER WHERE sip_evrakno_seri=@Seri";
      mCommand.Parameters.AddWithValue("@Seri", (object) this.txtEvrakNo.Text);
      this.textBox1.Text = DBManager.sqlGetScalarValue(mCommand).ToString();
      this.toolStripButton3_Click(sender, e);
    }

    private void toolStripButton8_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "Excell Dosyası | *.xls";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      this.gridView1.ExportToXls(saveFileDialog.FileName);
    }

    private void txtArabayi_ilce_TextChanged(object sender, EventArgs e)
    {
    }

    private void txtPrkAdi_Click(object sender, EventArgs e)
    {
      frmCariRehber frmCariRehber = new frmCariRehber();
      int num = (int) frmCariRehber.ShowDialog();
      if (frmCariRehber.CariKod.Length <= 0)
        return;
      this.txtPrkKod.Text = frmCariRehber.CariKod;
      this.txtPrkAdi.Text = frmCariRehber.CariIsim;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmSiparis));
      this.groupControl1 = new GroupControl();
      this.txtAraBayiiAdi = new TextBox();
      this.label9 = new Label();
      this.txtPrkAdi = new ButtonEdit();
      this.txtPrkKod = new ButtonEdit();
      this.label7 = new Label();
      this.label8 = new Label();
      this.cmbPlasiyer = new System.Windows.Forms.ComboBox();
      this.label31 = new Label();
      this.textBox1 = new TextBox();
      this.txtEvrakNo = new TextBox();
      this.label16 = new Label();
      this.dateTimePicker1 = new DateTimePicker();
      this.btnCariAdi = new ButtonEdit();
      this.btnCariKod = new ButtonEdit();
      this.label15 = new Label();
      this.label14 = new Label();
      this.label13 = new Label();
      this.groupControl2 = new GroupControl();
      this.gridControl1 = new GridControl();
      this.gridView1 = new GridView();
      this.gridColumn1 = new GridColumn();
      this.repositoryItemButtonEdit1 = new RepositoryItemButtonEdit();
      this.gridColumn2 = new GridColumn();
      this.repositoryItemButtonEdit2 = new RepositoryItemButtonEdit();
      this.gridColumn3 = new GridColumn();
      this.btnmiktar = new RepositoryItemTextEdit();
      this.gridColumn4 = new GridColumn();
      this.gridColumn5 = new GridColumn();
      this.btfiyat = new RepositoryItemTextEdit();
      this.gridColumn6 = new GridColumn();
      this.btnisk1 = new RepositoryItemTextEdit();
      this.gridColumn7 = new GridColumn();
      this.btnisk2 = new RepositoryItemTextEdit();
      this.gridColumn8 = new GridColumn();
      this.gridColumn9 = new GridColumn();
      this.gridColumn10 = new GridColumn();
      this.gridColumn11 = new GridColumn();
      this.gridColumn12 = new GridColumn();
      this.groupControl3 = new GroupControl();
      this.lblgeneltoplam = new Label();
      this.label6 = new Label();
      this.lblkdv = new Label();
      this.label5 = new Label();
      this.lblaratoplam2 = new Label();
      this.label4 = new Label();
      this.lbliskonto2 = new Label();
      this.lblisktono1 = new Label();
      this.label3 = new Label();
      this.lblaratoplam = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.toolStrip1 = new ToolStrip();
      this.toolStripButton1 = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolStripButton2 = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.toolStripButton7 = new ToolStripButton();
      this.toolStripSeparator6 = new ToolStripSeparator();
      this.toolStripButton3 = new ToolStripButton();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.toolStripButton4 = new ToolStripButton();
      this.toolStripSeparator7 = new ToolStripSeparator();
      this.label11 = new Label();
      this.lblpromosyontopla = new Label();
      this.groupControl1.BeginInit();
      this.groupControl1.SuspendLayout();
      this.txtPrkAdi.Properties.BeginInit();
      this.txtPrkKod.Properties.BeginInit();
      this.btnCariAdi.Properties.BeginInit();
      this.btnCariKod.Properties.BeginInit();
      this.groupControl2.BeginInit();
      this.groupControl2.SuspendLayout();
      this.gridControl1.BeginInit();
      this.gridView1.BeginInit();
      this.repositoryItemButtonEdit1.BeginInit();
      this.repositoryItemButtonEdit2.BeginInit();
      this.btnmiktar.BeginInit();
      this.btfiyat.BeginInit();
      this.btnisk1.BeginInit();
      this.btnisk2.BeginInit();
      this.groupControl3.BeginInit();
      this.groupControl3.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      this.groupControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.groupControl1.Controls.Add((Control) this.txtAraBayiiAdi);
      this.groupControl1.Controls.Add((Control) this.label9);
      this.groupControl1.Controls.Add((Control) this.txtPrkAdi);
      this.groupControl1.Controls.Add((Control) this.txtPrkKod);
      this.groupControl1.Controls.Add((Control) this.label7);
      this.groupControl1.Controls.Add((Control) this.label8);
      this.groupControl1.Controls.Add((Control) this.cmbPlasiyer);
      this.groupControl1.Controls.Add((Control) this.label31);
      this.groupControl1.Controls.Add((Control) this.textBox1);
      this.groupControl1.Controls.Add((Control) this.txtEvrakNo);
      this.groupControl1.Controls.Add((Control) this.label16);
      this.groupControl1.Controls.Add((Control) this.dateTimePicker1);
      this.groupControl1.Controls.Add((Control) this.btnCariAdi);
      this.groupControl1.Controls.Add((Control) this.btnCariKod);
      this.groupControl1.Controls.Add((Control) this.label15);
      this.groupControl1.Controls.Add((Control) this.label14);
      this.groupControl1.Controls.Add((Control) this.label13);
      this.groupControl1.Location = new Point(2, 33);
      this.groupControl1.LookAndFeel.SkinName = "iMaginary";
      this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
      this.groupControl1.Name = "groupControl1";
      this.groupControl1.Size = new Size(1090, 115);
      this.groupControl1.TabIndex = 0;
      this.groupControl1.Text = "Üst Bilgiler";
      this.txtAraBayiiAdi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtAraBayiiAdi.Location = new Point(611, 91);
      this.txtAraBayiiAdi.Name = "txtAraBayiiAdi";
      this.txtAraBayiiAdi.Size = new Size(474, 21);
      this.txtAraBayiiAdi.TabIndex = 24;
      this.label9.Location = new Point(499, 99);
      this.label9.Name = "label9";
      this.label9.Size = new Size(128, 13);
      this.label9.TabIndex = 25;
      this.label9.Text = "Ara Bayi Adi :";
      this.txtPrkAdi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPrkAdi.Location = new Point(611, 70);
      this.txtPrkAdi.Name = "txtPrkAdi";
      this.txtPrkAdi.Properties.Appearance.BackColor = Color.White;
      this.txtPrkAdi.Properties.Appearance.Options.UseBackColor = true;
      this.txtPrkAdi.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.txtPrkAdi.Size = new Size(474, 20);
      this.txtPrkAdi.TabIndex = 22;
      this.txtPrkAdi.Click += new EventHandler(this.txtPrkAdi_Click);
      this.txtPrkKod.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.txtPrkKod.Location = new Point(611, 48);
      this.txtPrkKod.Name = "txtPrkKod";
      this.txtPrkKod.Properties.Appearance.BackColor = Color.White;
      this.txtPrkKod.Properties.Appearance.Options.UseBackColor = true;
      this.txtPrkKod.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.txtPrkKod.Size = new Size(474, 20);
      this.txtPrkKod.TabIndex = 23;
      this.txtPrkKod.Click += new EventHandler(this.txtPrkAdi_Click);
      this.label7.Location = new Point(499, 77);
      this.label7.Name = "label7";
      this.label7.Size = new Size(128, 13);
      this.label7.TabIndex = 20;
      this.label7.Text = "Perakende Firma  Adi:";
      this.label8.Location = new Point(499, 55);
      this.label8.Name = "label8";
      this.label8.Size = new Size(128, 13);
      this.label8.TabIndex = 21;
      this.label8.Text = "Perakende Firma :";
      this.cmbPlasiyer.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cmbPlasiyer.FormattingEnabled = true;
      this.cmbPlasiyer.Location = new Point(611, 24);
      this.cmbPlasiyer.Name = "cmbPlasiyer";
      this.cmbPlasiyer.Size = new Size(156, 21);
      this.cmbPlasiyer.TabIndex = 19;
      this.label31.AutoSize = true;
      this.label31.Location = new Point(499, 32);
      this.label31.Name = "label31";
      this.label31.Size = new Size(60, 13);
      this.label31.TabIndex = 18;
      this.label31.Text = "Plasiyer    :";
      this.textBox1.BackColor = Color.White;
      this.textBox1.BorderStyle = BorderStyle.FixedSingle;
      this.textBox1.Location = new Point(126, 46);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(116, 21);
      this.textBox1.TabIndex = 4;
      this.txtEvrakNo.BackColor = Color.White;
      this.txtEvrakNo.BorderStyle = BorderStyle.FixedSingle;
      this.txtEvrakNo.Location = new Point(72, 46);
      this.txtEvrakNo.Name = "txtEvrakNo";
      this.txtEvrakNo.Size = new Size(53, 21);
      this.txtEvrakNo.TabIndex = 4;
      this.label16.AutoSize = true;
      this.label16.Location = new Point(2, 54);
      this.label16.Name = "label16";
      this.label16.Size = new Size(69, 13);
      this.label16.TabIndex = 3;
      this.label16.Text = "Evrak     No :";
      this.dateTimePicker1.Format = DateTimePickerFormat.Short;
      this.dateTimePicker1.Location = new Point(72, 24);
      this.dateTimePicker1.Name = "dateTimePicker1";
      this.dateTimePicker1.Size = new Size(141, 21);
      this.dateTimePicker1.TabIndex = 2;
      this.btnCariAdi.Location = new Point(72, 91);
      this.btnCariAdi.Name = "btnCariAdi";
      this.btnCariAdi.Properties.Appearance.BackColor = Color.White;
      this.btnCariAdi.Properties.Appearance.Options.UseBackColor = true;
      this.btnCariAdi.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.btnCariAdi.Size = new Size(421, 20);
      this.btnCariAdi.TabIndex = 1;
      this.btnCariAdi.ButtonClick += new ButtonPressedEventHandler(this.btnCariAdi_ButtonClick);
      this.btnCariKod.Location = new Point(72, 69);
      this.btnCariKod.Name = "btnCariKod";
      this.btnCariKod.Properties.Appearance.BackColor = Color.White;
      this.btnCariKod.Properties.Appearance.Options.UseBackColor = true;
      this.btnCariKod.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.btnCariKod.Size = new Size(421, 20);
      this.btnCariKod.TabIndex = 1;
      this.btnCariKod.ButtonClick += new ButtonPressedEventHandler(this.btnCariKod_ButtonClick);
      this.label15.Location = new Point(2, 32);
      this.label15.Name = "label15";
      this.label15.Size = new Size(69, 13);
      this.label15.TabIndex = 0;
      this.label15.Text = "Teslim Tarihi :";
      this.label15.Click += new EventHandler(this.label15_Click);
      this.label14.Location = new Point(2, 98);
      this.label14.Name = "label14";
      this.label14.Size = new Size(69, 13);
      this.label14.TabIndex = 0;
      this.label14.Text = "Cari Adi        :";
      this.label14.Click += new EventHandler(this.label14_Click);
      this.label13.Location = new Point(2, 74);
      this.label13.Name = "label13";
      this.label13.Size = new Size(69, 13);
      this.label13.TabIndex = 0;
      this.label13.Text = "Cari Kod       :";
      this.groupControl2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.groupControl2.Controls.Add((Control) this.gridControl1);
      this.groupControl2.Location = new Point(2, 151);
      this.groupControl2.LookAndFeel.SkinName = "iMaginary";
      this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
      this.groupControl2.Name = "groupControl2";
      this.groupControl2.Size = new Size(1090, 386);
      this.groupControl2.TabIndex = 2;
      this.groupControl2.Text = "Kalem Bilgileri";
      this.gridControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.gridControl1.Location = new Point(2, 22);
      this.gridControl1.LookAndFeel.SkinName = "Liquid Sky";
      this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
      this.gridControl1.MainView = (BaseView) this.gridView1;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.RepositoryItems.AddRange(new RepositoryItem[6]
      {
        (RepositoryItem) this.btnmiktar,
        (RepositoryItem) this.btfiyat,
        (RepositoryItem) this.btnisk1,
        (RepositoryItem) this.btnisk2,
        (RepositoryItem) this.repositoryItemButtonEdit1,
        (RepositoryItem) this.repositoryItemButtonEdit2
      });
      this.gridControl1.Size = new Size(1086, 361);
      this.gridControl1.TabIndex = 0;
      this.gridControl1.UseEmbeddedNavigator = true;
      this.gridControl1.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.gridView1
      });
      this.gridView1.Columns.AddRange(new GridColumn[12]
      {
        this.gridColumn1,
        this.gridColumn2,
        this.gridColumn3,
        this.gridColumn4,
        this.gridColumn5,
        this.gridColumn6,
        this.gridColumn7,
        this.gridColumn8,
        this.gridColumn9,
        this.gridColumn10,
        this.gridColumn11,
        this.gridColumn12
      });
      this.gridView1.CustomizationFormBounds = new Rectangle(1006, 473, 216, 164);
      this.gridView1.GridControl = this.gridControl1;
      this.gridView1.Name = "gridView1";
      this.gridView1.OptionsCustomization.AllowFilter = false;
      this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
      this.gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
      this.gridView1.OptionsView.ShowAutoFilterRow = true;
      this.gridView1.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
      this.gridView1.OptionsView.ShowGroupPanel = false;
      this.gridView1.PaintStyleName = "Skin";
      this.gridColumn1.Caption = "Stok Kod";
      this.gridColumn1.ColumnEdit = (RepositoryItem) this.repositoryItemButtonEdit1;
      this.gridColumn1.FieldName = "sip_stok_kod";
      this.gridColumn1.Name = "gridColumn1";
      this.gridColumn1.Visible = true;
      this.gridColumn1.VisibleIndex = 0;
      this.gridColumn1.Width = 131;
      this.repositoryItemButtonEdit1.AutoHeight = false;
      this.repositoryItemButtonEdit1.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
      this.repositoryItemButtonEdit1.ButtonClick += new ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
      this.repositoryItemButtonEdit1.KeyDown += new KeyEventHandler(this.repositoryItemButtonEdit1_KeyDown);
      this.repositoryItemButtonEdit1.KeyPress += new KeyPressEventHandler(this.repositoryItemButtonEdit1_KeyPress);
      this.gridColumn2.Caption = "Stok Adi";
      this.gridColumn2.ColumnEdit = (RepositoryItem) this.repositoryItemButtonEdit2;
      this.gridColumn2.FieldName = "sto_isim";
      this.gridColumn2.Name = "gridColumn2";
      this.gridColumn2.Visible = true;
      this.gridColumn2.VisibleIndex = 1;
      this.gridColumn2.Width = 444;
      this.repositoryItemButtonEdit2.AutoHeight = false;
      this.repositoryItemButtonEdit2.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton()
      });
      this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
      this.repositoryItemButtonEdit2.ButtonClick += new ButtonPressedEventHandler(this.repositoryItemButtonEdit2_ButtonClick);
      this.repositoryItemButtonEdit2.KeyDown += new KeyEventHandler(this.repositoryItemButtonEdit2_KeyDown);
      this.gridColumn3.Caption = "Miktar";
      this.gridColumn3.ColumnEdit = (RepositoryItem) this.btnmiktar;
      this.gridColumn3.DisplayFormat.FormatString = "f";
      this.gridColumn3.DisplayFormat.FormatType = FormatType.Numeric;
      this.gridColumn3.FieldName = "sip_miktar";
      this.gridColumn3.Name = "gridColumn3";
      this.gridColumn3.Visible = true;
      this.gridColumn3.VisibleIndex = 2;
      this.gridColumn3.Width = 88;
      this.btnmiktar.AutoHeight = false;
      this.btnmiktar.Name = "btnmiktar";
      this.btnmiktar.Leave += new EventHandler(this.hesap);
      this.gridColumn4.Caption = "Aciklama";
      this.gridColumn4.FieldName = "sip_aciklama2";
      this.gridColumn4.Name = "gridColumn4";
      this.gridColumn4.OptionsColumn.AllowEdit = false;
      this.gridColumn4.Visible = true;
      this.gridColumn4.VisibleIndex = 7;
      this.gridColumn4.Width = 58;
      this.gridColumn5.Caption = "B.Fiyat";
      this.gridColumn5.ColumnEdit = (RepositoryItem) this.btfiyat;
      this.gridColumn5.DisplayFormat.FormatString = "f";
      this.gridColumn5.DisplayFormat.FormatType = FormatType.Numeric;
      this.gridColumn5.FieldName = "Birim";
      this.gridColumn5.Name = "gridColumn5";
      this.gridColumn5.Visible = true;
      this.gridColumn5.VisibleIndex = 3;
      this.gridColumn5.Width = 97;
      this.btfiyat.AutoHeight = false;
      this.btfiyat.Name = "btfiyat";
      this.btfiyat.Leave += new EventHandler(this.hesap);
      this.gridColumn6.Caption = "İsk.1.Oran";
      this.gridColumn6.ColumnEdit = (RepositoryItem) this.btnisk1;
      this.gridColumn6.FieldName = "sip_iskonto_1";
      this.gridColumn6.Name = "gridColumn6";
      this.gridColumn6.Visible = true;
      this.gridColumn6.VisibleIndex = 4;
      this.gridColumn6.Width = 81;
      this.btnisk1.AutoHeight = false;
      this.btnisk1.Name = "btnisk1";
      this.btnisk1.Leave += new EventHandler(this.hesap);
      this.gridColumn7.Caption = "İsk.2.Oran";
      this.gridColumn7.ColumnEdit = (RepositoryItem) this.btnisk2;
      this.gridColumn7.FieldName = "sip_iskonto_2";
      this.gridColumn7.Name = "gridColumn7";
      this.gridColumn7.Visible = true;
      this.gridColumn7.VisibleIndex = 5;
      this.gridColumn7.Width = 74;
      this.btnisk2.AutoHeight = false;
      this.btnisk2.Name = "btnisk2";
      this.btnisk2.Leave += new EventHandler(this.hesap);
      this.gridColumn8.Caption = "Toplam";
      this.gridColumn8.DisplayFormat.FormatString = "f";
      this.gridColumn8.DisplayFormat.FormatType = FormatType.Numeric;
      this.gridColumn8.FieldName = "Toplam";
      this.gridColumn8.Name = "gridColumn8";
      this.gridColumn8.OptionsColumn.AllowEdit = false;
      this.gridColumn8.Visible = true;
      this.gridColumn8.VisibleIndex = 8;
      this.gridColumn8.Width = 44;
      this.gridColumn9.Caption = "Kdv Orani";
      this.gridColumn9.DisplayFormat.FormatString = "f";
      this.gridColumn9.DisplayFormat.FormatType = FormatType.Numeric;
      this.gridColumn9.FieldName = "KdvOrani";
      this.gridColumn9.Name = "gridColumn9";
      this.gridColumn9.OptionsColumn.AllowEdit = false;
      this.gridColumn9.Visible = true;
      this.gridColumn9.VisibleIndex = 6;
      this.gridColumn9.Width = 74;
      this.gridColumn10.Caption = "Kdv Matrahı";
      this.gridColumn10.DisplayFormat.FormatString = "f";
      this.gridColumn10.DisplayFormat.FormatType = FormatType.Numeric;
      this.gridColumn10.FieldName = "KdvMat";
      this.gridColumn10.Name = "gridColumn10";
      this.gridColumn10.OptionsColumn.AllowEdit = false;
      this.gridColumn10.Width = 140;
      this.gridColumn11.Caption = "İskonto 1 Tutar";
      this.gridColumn11.DisplayFormat.FormatString = "f";
      this.gridColumn11.DisplayFormat.FormatType = FormatType.Numeric;
      this.gridColumn11.FieldName = "isk1";
      this.gridColumn11.Name = "gridColumn11";
      this.gridColumn11.OptionsColumn.AllowEdit = false;
      this.gridColumn11.Width = 83;
      this.gridColumn12.Caption = "İskonto 2 Tutar";
      this.gridColumn12.DisplayFormat.FormatString = "f";
      this.gridColumn12.DisplayFormat.FormatType = FormatType.Numeric;
      this.gridColumn12.FieldName = "isk2";
      this.gridColumn12.Name = "gridColumn12";
      this.gridColumn12.OptionsColumn.AllowEdit = false;
      this.gridColumn12.Width = 83;
      this.groupControl3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.groupControl3.Controls.Add((Control) this.lblpromosyontopla);
      this.groupControl3.Controls.Add((Control) this.label11);
      this.groupControl3.Controls.Add((Control) this.lblgeneltoplam);
      this.groupControl3.Controls.Add((Control) this.label6);
      this.groupControl3.Controls.Add((Control) this.lblkdv);
      this.groupControl3.Controls.Add((Control) this.label5);
      this.groupControl3.Controls.Add((Control) this.lblaratoplam2);
      this.groupControl3.Controls.Add((Control) this.label4);
      this.groupControl3.Controls.Add((Control) this.lbliskonto2);
      this.groupControl3.Controls.Add((Control) this.lblisktono1);
      this.groupControl3.Controls.Add((Control) this.label3);
      this.groupControl3.Controls.Add((Control) this.lblaratoplam);
      this.groupControl3.Controls.Add((Control) this.label2);
      this.groupControl3.Controls.Add((Control) this.label1);
      this.groupControl3.Location = new Point(2, 539);
      this.groupControl3.LookAndFeel.SkinName = "iMaginary";
      this.groupControl3.LookAndFeel.UseDefaultLookAndFeel = false;
      this.groupControl3.Name = "groupControl3";
      this.groupControl3.Size = new Size(1090, 87);
      this.groupControl3.TabIndex = 4;
      this.groupControl3.Text = "Alt Toplam Bilgileri";
      this.lblgeneltoplam.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblgeneltoplam.BackColor = Color.Transparent;
      this.lblgeneltoplam.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.lblgeneltoplam.Location = new Point(962, 64);
      this.lblgeneltoplam.Name = "lblgeneltoplam";
      this.lblgeneltoplam.Size = new Size(98, 20);
      this.lblgeneltoplam.TabIndex = 0;
      this.lblgeneltoplam.Text = "0.00";
      this.lblgeneltoplam.TextAlign = ContentAlignment.MiddleRight;
      this.label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label6.BackColor = Color.Transparent;
      this.label6.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.label6.ForeColor = Color.FromArgb(192, 0, 0);
      this.label6.Location = new Point(858, 64);
      this.label6.Name = "label6";
      this.label6.Size = new Size(98, 20);
      this.label6.TabIndex = 0;
      this.label6.Text = "Genel Toplam   :";
      this.label6.TextAlign = ContentAlignment.MiddleLeft;
      this.lblkdv.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblkdv.BackColor = Color.Transparent;
      this.lblkdv.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.lblkdv.Location = new Point(962, 44);
      this.lblkdv.Name = "lblkdv";
      this.lblkdv.Size = new Size(98, 20);
      this.lblkdv.TabIndex = 0;
      this.lblkdv.Text = "0.00";
      this.lblkdv.TextAlign = ContentAlignment.MiddleRight;
      this.label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.label5.ForeColor = Color.FromArgb(192, 0, 0);
      this.label5.Location = new Point(858, 44);
      this.label5.Name = "label5";
      this.label5.Size = new Size(98, 20);
      this.label5.TabIndex = 0;
      this.label5.Text = "Kdv                  :";
      this.label5.TextAlign = ContentAlignment.MiddleLeft;
      this.lblaratoplam2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblaratoplam2.BackColor = Color.Transparent;
      this.lblaratoplam2.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.lblaratoplam2.Location = new Point(962, 26);
      this.lblaratoplam2.Name = "lblaratoplam2";
      this.lblaratoplam2.Size = new Size(98, 23);
      this.lblaratoplam2.TabIndex = 0;
      this.lblaratoplam2.Text = "0.00";
      this.lblaratoplam2.TextAlign = ContentAlignment.MiddleRight;
      this.label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label4.BackColor = Color.Transparent;
      this.label4.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.label4.ForeColor = Color.FromArgb(192, 0, 0);
      this.label4.Location = new Point(858, 26);
      this.label4.Name = "label4";
      this.label4.Size = new Size(98, 23);
      this.label4.TabIndex = 0;
      this.label4.Text = "Ara Toplam 2   :";
      this.label4.TextAlign = ContentAlignment.MiddleLeft;
      this.lbliskonto2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lbliskonto2.BackColor = Color.Transparent;
      this.lbliskonto2.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.lbliskonto2.Location = new Point(736, 64);
      this.lbliskonto2.Name = "lbliskonto2";
      this.lbliskonto2.Size = new Size(98, 20);
      this.lbliskonto2.TabIndex = 0;
      this.lbliskonto2.Text = "0.00";
      this.lbliskonto2.TextAlign = ContentAlignment.MiddleRight;
      this.lblisktono1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblisktono1.BackColor = Color.Transparent;
      this.lblisktono1.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.lblisktono1.Location = new Point(736, 44);
      this.lblisktono1.Name = "lblisktono1";
      this.lblisktono1.Size = new Size(98, 20);
      this.lblisktono1.TabIndex = 0;
      this.lblisktono1.Text = "0.00";
      this.lblisktono1.TextAlign = ContentAlignment.MiddleRight;
      this.label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.label3.ForeColor = Color.FromArgb(192, 0, 0);
      this.label3.Location = new Point(632, 64);
      this.label3.Name = "label3";
      this.label3.Size = new Size(98, 20);
      this.label3.TabIndex = 0;
      this.label3.Text = "İskonto 2         :";
      this.lblaratoplam.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblaratoplam.BackColor = Color.Transparent;
      this.lblaratoplam.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.lblaratoplam.Location = new Point(736, 26);
      this.lblaratoplam.Name = "lblaratoplam";
      this.lblaratoplam.Size = new Size(98, 23);
      this.lblaratoplam.TabIndex = 0;
      this.lblaratoplam.Text = "0.00";
      this.lblaratoplam.TextAlign = ContentAlignment.MiddleRight;
      this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label2.BackColor = Color.Transparent;
      this.label2.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.label2.ForeColor = Color.FromArgb(192, 0, 0);
      this.label2.Location = new Point(632, 44);
      this.label2.Name = "label2";
      this.label2.Size = new Size(98, 20);
      this.label2.TabIndex = 0;
      this.label2.Text = "İskonto 1         :";
      this.label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.label1.ForeColor = Color.FromArgb(192, 0, 0);
      this.label1.Location = new Point(632, 26);
      this.label1.Name = "label1";
      this.label1.Size = new Size(98, 23);
      this.label1.TabIndex = 0;
      this.label1.Text = "Ara Toplam      :";
      this.toolStrip1.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.toolStrip1.ImageScalingSize = new Size(25, 25);
      this.toolStrip1.Items.AddRange(new ToolStripItem[10]
      {
        (ToolStripItem) this.toolStripButton1,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.toolStripButton2,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.toolStripButton7,
        (ToolStripItem) this.toolStripSeparator6,
        (ToolStripItem) this.toolStripButton3,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.toolStripButton4,
        (ToolStripItem) this.toolStripSeparator7
      });
      this.toolStrip1.Location = new Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(1094, 32);
      this.toolStrip1.TabIndex = 5;
      this.toolStrip1.Text = "toolStrip1";
      this.toolStripButton1.Image = (Image) componentResourceManager.GetObject("toolStripButton1.Image");
      this.toolStripButton1.ImageTransparentColor = Color.Magenta;
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Size = new Size(71, 29);
      this.toolStripButton1.Text = "KAPAT";
      this.toolStripButton1.Click += new EventHandler(this.toolStripButton1_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 32);
      this.toolStripButton2.Image = (Image) componentResourceManager.GetObject("toolStripButton2.Image");
      this.toolStripButton2.ImageTransparentColor = Color.Magenta;
      this.toolStripButton2.Name = "toolStripButton2";
      this.toolStripButton2.Size = new Size(77, 29);
      this.toolStripButton2.Text = "YAZDIR";
      this.toolStripButton2.Click += new EventHandler(this.toolStripButton2_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 32);
      this.toolStripButton7.Image = (Image) Resources.pda;
      this.toolStripButton7.ImageTransparentColor = Color.Magenta;
      this.toolStripButton7.Name = "toolStripButton7";
      this.toolStripButton7.Size = new Size(108, 29);
      this.toolStripButton7.Text = "KOPYA KAYIT";
      this.toolStripButton7.Click += new EventHandler(this.toolStripButton7_Click);
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new Size(6, 32);
      this.toolStripButton3.Image = (Image) componentResourceManager.GetObject("toolStripButton3.Image");
      this.toolStripButton3.ImageTransparentColor = Color.Magenta;
      this.toolStripButton3.Name = "toolStripButton3";
      this.toolStripButton3.Size = new Size(79, 29);
      this.toolStripButton3.Text = "KAYDET";
      this.toolStripButton3.Click += new EventHandler(this.toolStripButton3_Click);
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(6, 32);
      this.toolStripButton4.Image = (Image) componentResourceManager.GetObject("toolStripButton4.Image");
      this.toolStripButton4.ImageTransparentColor = Color.Magenta;
      this.toolStripButton4.Name = "toolStripButton4";
      this.toolStripButton4.Size = new Size(97, 29);
      this.toolStripButton4.Text = "EVRAĞI SİL";
      this.toolStripButton4.Click += new EventHandler(this.toolStripButton4_Click);
      this.toolStripSeparator7.Name = "toolStripSeparator7";
      this.toolStripSeparator7.Size = new Size(6, 32);
      this.label11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label11.BackColor = Color.Transparent;
      this.label11.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.label11.ForeColor = Color.FromArgb(192, 0, 0);
      this.label11.Location = new Point(358, 29);
      this.label11.Name = "label11";
      this.label11.Size = new Size(135, 15);
      this.label11.TabIndex = 2;
      this.label11.Text = "Promosyon Toplamı : ";
      this.lblpromosyontopla.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.lblpromosyontopla.BackColor = Color.Transparent;
      this.lblpromosyontopla.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.lblpromosyontopla.ForeColor = Color.FromArgb(192, 0, 0);
      this.lblpromosyontopla.Location = new Point(491, 29);
      this.lblpromosyontopla.Name = "lblpromosyontopla";
      this.lblpromosyontopla.Size = new Size(135, 15);
      this.lblpromosyontopla.TabIndex = 4;
      this.lblpromosyontopla.Text = "0.00 TL";
      this.lblpromosyontopla.TextAlign = ContentAlignment.TopRight;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(1094, 628);
      this.Controls.Add((Control) this.toolStrip1);
      this.Controls.Add((Control) this.groupControl3);
      this.Controls.Add((Control) this.groupControl2);
      this.Controls.Add((Control) this.groupControl1);
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmSiparis);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Sipariş Evrağı";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.frmSiparis_Load);
      this.LocationChanged += new EventHandler(this.frmSiparis_LocationChanged);
      this.groupControl1.EndInit();
      this.groupControl1.ResumeLayout(false);
      this.groupControl1.PerformLayout();
      this.txtPrkAdi.Properties.EndInit();
      this.txtPrkKod.Properties.EndInit();
      this.btnCariAdi.Properties.EndInit();
      this.btnCariKod.Properties.EndInit();
      this.groupControl2.EndInit();
      this.groupControl2.ResumeLayout(false);
      this.gridControl1.EndInit();
      this.gridView1.EndInit();
      this.repositoryItemButtonEdit1.EndInit();
      this.repositoryItemButtonEdit2.EndInit();
      this.btnmiktar.EndInit();
      this.btfiyat.EndInit();
      this.btnisk1.EndInit();
      this.btnisk2.EndInit();
      this.groupControl3.EndInit();
      this.groupControl3.ResumeLayout(false);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
