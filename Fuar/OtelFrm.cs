// Decompiled with JetBrains decompiler
// Type: Fuar.OtelFrm
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class OtelFrm : XtraForm
  {
    public string _id = string.Empty;
    private IContainer components;
    private Label label1;
    private TextBox txt_ad;
    private TextBox txt_sehir;
    private Label label2;
    private TextBox txt_yetkili;
    private Label label3;
    private Label label4;
    private TextBox txt_eposta;
    private Label label5;
    private Label label6;
    private Label label7;
    private MaskedTextBox txt_telefon;
    private TextBox txt_sinif;
    private TextBox txt_tip;
    private GroupBox groupBox1;
    private SimpleButton btn_kaydet;
    private SimpleButton btn_iptal;
    private GridControl dtg_oda;
    private GridView grd_oda;
    private RepositoryItemComboBox cmb1;
    private ErrorProvider ep1;
    private GroupBox groupBox2;

    public OtelFrm() => this.InitializeComponent();

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void btn_kaydet_Click(object sender, EventArgs e)
    {
      if (!this.alan_kontrol())
        return;
      if (this._id == "")
        this.insert_otel();
      else
        this.update_otel();
      this.Close();
    }

    private void OtelFrm_Load(object sender, EventArgs e)
    {
      if (this._id != "")
      {
        DataTable dataTable = _main.komutcalistir_dt("SELECT * FROM OTELLER WHERE ID = " + this._id);
        if (dataTable.Rows.Count > 0)
        {
          this.txt_ad.Text = dataTable.Rows[0]["OTELADI"].ToString();
          this.txt_sehir.Text = dataTable.Rows[0]["SEHIR"].ToString();
          this.txt_yetkili.Text = dataTable.Rows[0]["YETKILI"].ToString();
          this.txt_telefon.Text = dataTable.Rows[0]["TELEFON"].ToString();
          this.txt_eposta.Text = dataTable.Rows[0]["EPOSTA"].ToString();
          this.txt_sinif.Text = dataTable.Rows[0]["SINIF"].ToString();
          this.txt_tip.Text = dataTable.Rows[0]["TIP"].ToString();
          this.dtg_oda.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM ODALAR WHERE OTELID = " + this._id);
          this.grd_oda.Columns["ID"].Visible = false;
          this.grd_oda.Columns["OTELID"].Visible = false;
        }
      }
      else
      {
        this.dtg_oda.DataSource = (object) _main.komutcalistir_dt("SELECT * FROM ODALAR").Clone();
        this.grd_oda.Columns["ID"].Visible = false;
        this.grd_oda.Columns["OTELID"].Visible = false;
      }
      DataTable dataTable1 = _main.komutcalistir_dt("SELECT * FROM ODATIP");
      this.cmb1.Items.Clear();
      for (int index = 0; index < dataTable1.Rows.Count; ++index)
        this.cmb1.Items.Add((object) dataTable1.Rows[index]["ODATIPI"].ToString());
      this.grd_oda.Columns["ODATIP"].ColumnEdit = (RepositoryItem) this.cmb1;
    }

    private void insert_otel()
    {
      string str = _main.komutcalistir_str("INSERT INTO OTELLER (OTELADI,SEHIR,YETKILI,TELEFON,EPOSTA,SINIF,TIP) " + "VALUES ('" + this.txt_ad.Text + "','" + this.txt_sehir.Text + "','" + this.txt_yetkili.Text + "','" + this.txt_telefon.Text + "','" + this.txt_eposta.Text + "','" + this.txt_sinif.Text + "','" + this.txt_tip.Text + "') " + "SELECT @@IDENTITY AS OTELID ");
      if (string.IsNullOrEmpty(str))
        return;
      DataTable dataSource = (DataTable) this.dtg_oda.DataSource;
      string empty = string.Empty;
      for (int index = 0; index < dataSource.Rows.Count; ++index)
      {
        if (dataSource.Rows[index]["ODATIP"].ToString() != "")
          _main.komutcalistir("INSERT INTO ODALAR (OTELID,ODATIP,KISISAYISI,ODAUCRETI,EXTRA,OZEL) " + " VALUES (" + str + ",'" + dataSource.Rows[index]["ODATIP"].ToString() + "'," + this.set_is_null(dataSource.Rows[index]["KISISAYISI"].ToString()) + "," + this.set_is_null(dataSource.Rows[index]["ODAUCRETI"].ToString()) + "," + this.set_is_null(dataSource.Rows[index]["EXTRA"].ToString()) + "," + this.set_is_null(dataSource.Rows[index]["OZEL"].ToString()) + ")");
      }
    }

    private void update_otel()
    {
      bool flag = true;
      _main.komutcalistir("UPDATE OTELLER SET OTELADI = '" + this.txt_ad.Text + "',SEHIR = '" + this.txt_sehir.Text + "',YETKILI = '" + this.txt_yetkili.Text + "',TELEFON = '" + this.txt_telefon.Text + "',EPOSTA = '" + this.txt_eposta.Text + "',SINIF = '" + this.txt_sinif.Text + "',TIP = '" + this.txt_tip.Text + "'" + " WHERE ID = " + this._id);
      DataTable dataSource = (DataTable) this.dtg_oda.DataSource;
      for (int index = 0; index < dataSource.Rows.Count; ++index)
      {
        if (dataSource.Rows[index]["ID"].ToString() != "" && this.hareket_kontrol(dataSource.Rows[index]["ID"].ToString()))
        {
          flag = false;
          int num = (int) MessageBox.Show("Hareket görmüş Oda kayıtları değiştirilemez.");
          break;
        }
      }
      if (!flag)
        return;
      string empty1 = string.Empty;
      for (int index = 0; index < dataSource.Rows.Count; ++index)
      {
        if (dataSource.Rows[index]["ID"].ToString() != "")
          _main.komutcalistir("DELETE FROM ODALAR WHERE ID = " + dataSource.Rows[index]["ID"].ToString());
      }
      string empty2 = string.Empty;
      for (int index = 0; index < dataSource.Rows.Count; ++index)
      {
        if (dataSource.Rows[index]["ODATIP"].ToString() != "")
          _main.komutcalistir("INSERT INTO ODALAR (OTELID,ODATIP,KISISAYISI,ODAUCRETI,EXTRA,OZEL) " + " VALUES (" + this._id + ",'" + dataSource.Rows[index]["ODATIP"].ToString() + "'," + this.set_is_null(dataSource.Rows[index]["KISISAYISI"].ToString()) + "," + this.set_is_null(dataSource.Rows[index]["ODAUCRETI"].ToString()) + "," + this.set_is_null(dataSource.Rows[index]["EXTRA"].ToString()) + "," + this.set_is_null(dataSource.Rows[index]["OZEL"].ToString()) + ")");
      }
    }

    private bool hareket_kontrol(string str_oda_id)
    {
      return _main.komutcalistir_dt("SELECT * FROM OTELHAR WHERE ODAID = " + str_oda_id).Rows.Count > 0;
    }

    private bool alan_kontrol()
    {
      bool flag = true;
      if (this.txt_ad.Text.Length == 0)
      {
        this.ep1.SetError((Control) this.txt_ad, "Alan Boş Olamaz");
        return false;
      }
      this.ep1.Clear();
      if (this.grd_oda.RowCount != 1 || !(this.cmb1.GetDisplayText((object) this.cmb1) == ""))
        return flag;
      int num = (int) MessageBox.Show("Oda tiplerini belirtiniz.");
      return false;
    }

    private void dtg_oda_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Delete || string.IsNullOrEmpty(this.grd_oda.GetFocusedRowCellDisplayText("ID")) || MessageBox.Show("Seçili Oda bilgisini silmek istediğinize eminmisiniz ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
        return;
      this.grd_oda.DeleteSelectedRows();
    }

    private string set_is_null(string deger)
    {
      string str;
      try
      {
        str = !string.IsNullOrEmpty(deger) ? (!string.IsNullOrWhiteSpace(deger) ? deger : "0") : "0";
      }
      catch
      {
        return "0";
      }
      return str;
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
      this.label1 = new Label();
      this.txt_ad = new TextBox();
      this.txt_sehir = new TextBox();
      this.label2 = new Label();
      this.txt_yetkili = new TextBox();
      this.label3 = new Label();
      this.label4 = new Label();
      this.txt_eposta = new TextBox();
      this.label5 = new Label();
      this.label6 = new Label();
      this.label7 = new Label();
      this.txt_telefon = new MaskedTextBox();
      this.txt_sinif = new TextBox();
      this.txt_tip = new TextBox();
      this.groupBox1 = new GroupBox();
      this.dtg_oda = new GridControl();
      this.grd_oda = new GridView();
      this.cmb1 = new RepositoryItemComboBox();
      this.btn_kaydet = new SimpleButton();
      this.btn_iptal = new SimpleButton();
      this.ep1 = new ErrorProvider(this.components);
      this.groupBox2 = new GroupBox();
      this.groupBox1.SuspendLayout();
      this.dtg_oda.BeginInit();
      this.grd_oda.BeginInit();
      this.cmb1.BeginInit();
      ((ISupportInitialize) this.ep1).BeginInit();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(18, 26);
      this.label1.Name = "label1";
      this.label1.Size = new Size(45, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Otel Adı";
      this.txt_ad.Location = new Point(68, 23);
      this.txt_ad.Name = "txt_ad";
      this.txt_ad.Size = new Size(428, 21);
      this.txt_ad.TabIndex = 1;
      this.txt_sehir.Location = new Point(68, 56);
      this.txt_sehir.Name = "txt_sehir";
      this.txt_sehir.Size = new Size(118, 21);
      this.txt_sehir.TabIndex = 2;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(18, 59);
      this.label2.Name = "label2";
      this.label2.Size = new Size(31, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Şehir";
      this.txt_yetkili.Location = new Point(68, 89);
      this.txt_yetkili.Name = "txt_yetkili";
      this.txt_yetkili.Size = new Size(118, 21);
      this.txt_yetkili.TabIndex = 3;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(18, 92);
      this.label3.Name = "label3";
      this.label3.Size = new Size(34, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Yetkili";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(18, 125);
      this.label4.Name = "label4";
      this.label4.Size = new Size(43, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "Telefon";
      this.txt_eposta.Location = new Point(302, 56);
      this.txt_eposta.Name = "txt_eposta";
      this.txt_eposta.Size = new Size(194, 21);
      this.txt_eposta.TabIndex = 5;
      this.label5.AutoSize = true;
      this.label5.Location = new Point(253, 59);
      this.label5.Name = "label5";
      this.label5.Size = new Size(44, 13);
      this.label5.TabIndex = 8;
      this.label5.Text = "E-posta";
      this.label6.AutoSize = true;
      this.label6.Location = new Point(253, 92);
      this.label6.Name = "label6";
      this.label6.Size = new Size(27, 13);
      this.label6.TabIndex = 10;
      this.label6.Text = "Sınıf";
      this.label7.AutoSize = true;
      this.label7.Location = new Point(253, 125);
      this.label7.Name = "label7";
      this.label7.Size = new Size(21, 13);
      this.label7.TabIndex = 11;
      this.label7.Text = "Tip";
      this.txt_telefon.Location = new Point(68, 122);
      this.txt_telefon.Mask = "(0000) 000 00 00";
      this.txt_telefon.Name = "txt_telefon";
      this.txt_telefon.Size = new Size(118, 21);
      this.txt_telefon.TabIndex = 4;
      this.txt_sinif.Location = new Point(302, 89);
      this.txt_sinif.Name = "txt_sinif";
      this.txt_sinif.Size = new Size(194, 21);
      this.txt_sinif.TabIndex = 6;
      this.txt_tip.Location = new Point(302, 122);
      this.txt_tip.Name = "txt_tip";
      this.txt_tip.Size = new Size(194, 21);
      this.txt_tip.TabIndex = 7;
      this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.groupBox1.Controls.Add((Control) this.dtg_oda);
      this.groupBox1.Location = new Point(17, 184);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(519, 281);
      this.groupBox1.TabIndex = 12;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Oda Tanımları";
      this.dtg_oda.Dock = DockStyle.Fill;
      this.dtg_oda.Location = new Point(3, 16);
      this.dtg_oda.MainView = (BaseView) this.grd_oda;
      this.dtg_oda.Name = "dtg_oda";
      this.dtg_oda.RepositoryItems.AddRange(new RepositoryItem[1]
      {
        (RepositoryItem) this.cmb1
      });
      this.dtg_oda.Size = new Size(513, 262);
      this.dtg_oda.TabIndex = 0;
      this.dtg_oda.ViewCollection.AddRange(new BaseView[1]
      {
        (BaseView) this.grd_oda
      });
      this.dtg_oda.KeyDown += new KeyEventHandler(this.dtg_oda_KeyDown);
      this.grd_oda.GridControl = this.dtg_oda;
      this.grd_oda.Name = "grd_oda";
      this.grd_oda.OptionsMenu.EnableGroupPanelMenu = false;
      this.grd_oda.OptionsView.EnableAppearanceEvenRow = true;
      this.grd_oda.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
      this.grd_oda.OptionsView.ShowGroupPanel = false;
      this.cmb1.AllowNullInput = DefaultBoolean.False;
      this.cmb1.AutoHeight = false;
      this.cmb1.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Combo)
      });
      this.cmb1.ImmediatePopup = true;
      this.cmb1.Name = "cmb1";
      this.cmb1.NullText = "Oda tipi seçiniz...";
      this.cmb1.NullValuePrompt = "Oda tipi seçiniz...";
      this.cmb1.NullValuePromptShowForEmptyValue = true;
      this.cmb1.TextEditStyle = TextEditStyles.DisableTextEditor;
      this.btn_kaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kaydet.Location = new Point(17, 487);
      this.btn_kaydet.Name = "btn_kaydet";
      this.btn_kaydet.Size = new Size(75, 33);
      this.btn_kaydet.TabIndex = 13;
      this.btn_kaydet.Text = "Kaydet";
      this.btn_kaydet.Click += new EventHandler(this.btn_kaydet_Click);
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(103, 487);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 14;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.ep1.ContainerControl = (ContainerControl) this;
      this.groupBox2.Controls.Add((Control) this.label1);
      this.groupBox2.Controls.Add((Control) this.txt_ad);
      this.groupBox2.Controls.Add((Control) this.label2);
      this.groupBox2.Controls.Add((Control) this.txt_sehir);
      this.groupBox2.Controls.Add((Control) this.txt_tip);
      this.groupBox2.Controls.Add((Control) this.label3);
      this.groupBox2.Controls.Add((Control) this.txt_sinif);
      this.groupBox2.Controls.Add((Control) this.txt_yetkili);
      this.groupBox2.Controls.Add((Control) this.txt_telefon);
      this.groupBox2.Controls.Add((Control) this.label4);
      this.groupBox2.Controls.Add((Control) this.label7);
      this.groupBox2.Controls.Add((Control) this.label5);
      this.groupBox2.Controls.Add((Control) this.label6);
      this.groupBox2.Controls.Add((Control) this.txt_eposta);
      this.groupBox2.Location = new Point(17, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(518, 161);
      this.groupBox2.TabIndex = 15;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Otel Tanımları";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(554, 532);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.btn_kaydet);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.groupBox1);
      this.KeyPreview = true;
      this.MinimizeBox = false;
      this.Name = nameof (OtelFrm);
      this.Text = "Otel Bilgileri";
      this.Load += new EventHandler(this.OtelFrm_Load);
      this.groupBox1.ResumeLayout(false);
      this.dtg_oda.EndInit();
      this.grd_oda.EndInit();
      this.cmb1.EndInit();
      ((ISupportInitialize) this.ep1).EndInit();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
