// Decompiled with JetBrains decompiler
// Type: Fuar.ParametreFrm
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class ParametreFrm : XtraForm
  {
    public string rapor_id = string.Empty;
    public string parameter_id = string.Empty;
    private IContainer components;
    private SimpleButton btn_iptal;
    private SimpleButton btn_kaydet;
    private PanelControl panelControl1;
    private LabelControl labelControl1;
    private TextEdit t_value;
    private TextEdit t_sql_ad;
    private TextEdit t_ad;
    private LabelControl labelControl4;
    private LabelControl labelControl3;
    private LabelControl labelControl2;
    private LookUpEdit cmb_tip;
    private ErrorProvider ep1;

    public ParametreFrm() => this.InitializeComponent();

    private void ParametreFrm_Load(object sender, EventArgs e)
    {
      this.set_type();
      if (!(this.parameter_id != string.Empty))
        return;
      this.get_param(this.parameter_id);
    }

    private void get_param(string _pid)
    {
      DataTable dataTable = _main.komutcalistir_dt("SELECT * FROM RAPORPARAMS WHERE ID = " + _pid);
      if (dataTable.Rows.Count <= 0)
        return;
      this.cmb_tip.EditValue = (object) dataTable.Rows[0]["PARAMTYPE"].ToString();
      this.t_ad.Text = dataTable.Rows[0]["PARAMCAPTION"].ToString();
      this.t_sql_ad.Text = dataTable.Rows[0]["PARAMNAME"].ToString();
      this.t_value.Text = dataTable.Rows[0]["DEFAULTVALUE"].ToString();
    }

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void btn_kaydet_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.alankontrol())
          return;
        if (this.rapor_id != string.Empty)
          this.save_param();
        this.Close();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void set_type()
    {
      DataTable dataTable = new DataTable();
      DataColumn column1 = new DataColumn("Value");
      DataColumn column2 = new DataColumn("Tip");
      dataTable.Columns.Add(column1);
      dataTable.Columns.Add(column2);
      dataTable.Rows.Add((object) "String", (object) "Text");
      dataTable.Rows.Add((object) "Int", (object) "TamSayı");
      dataTable.Rows.Add((object) "Double", (object) "OndalıkSayı");
      dataTable.Rows.Add((object) "Date", (object) "Tarih");
      dataTable.Rows.Add((object) "Boolean", (object) "Mantıksal");
      this.cmb_tip.Properties.DataSource = (object) dataTable;
      this.cmb_tip.Properties.ValueMember = "Value";
      this.cmb_tip.Properties.DisplayMember = "Tip";
      this.cmb_tip.Properties.PopulateColumns();
      this.cmb_tip.Properties.Columns["Value"].Visible = false;
      this.cmb_tip.EditValue = (object) "String";
    }

    private void save_param()
    {
      string str = this.cmb_tip.EditValue.ToString();
      string text1 = this.t_ad.Text;
      string text2 = this.t_sql_ad.Text;
      string text3 = this.t_value.Text;
      if (this.parameter_id == string.Empty)
        _main.komutcalistir("INSERT INTO RAPORPARAMS (REPORTID, PARAMNAME, PARAMCAPTION, PARAMTYPE, DEFAULTVALUE) " + " VALUES (" + this.rapor_id + ",'" + text2 + "','" + text1 + "','" + str + "','" + text3 + "')");
      else
        _main.komutcalistir("UPDATE RAPORPARAMS SET PARAMNAME ='" + text2 + "', PARAMCAPTION ='" + text1 + "', PARAMTYPE ='" + str + "', " + " DEFAULTVALUE ='" + text3 + "' WHERE ID = " + this.parameter_id);
    }

    private bool alankontrol()
    {
      bool flag = true;
      if (this.cmb_tip.EditValue == null)
      {
        this.ep1.SetError((Control) this.cmb_tip, "Alan Boş Olamaz");
        return false;
      }
      this.ep1.Clear();
      if (this.t_ad.Text.Length == 0)
      {
        this.ep1.SetError((Control) this.t_ad, "Alan Boş Olamaz");
        return false;
      }
      this.ep1.Clear();
      if (this.t_sql_ad.Text.Length == 0)
      {
        this.ep1.SetError((Control) this.t_sql_ad, "Alan Boş Olamaz");
        return false;
      }
      this.ep1.Clear();
      return flag;
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
      this.btn_iptal = new SimpleButton();
      this.btn_kaydet = new SimpleButton();
      this.panelControl1 = new PanelControl();
      this.cmb_tip = new LookUpEdit();
      this.t_value = new TextEdit();
      this.t_sql_ad = new TextEdit();
      this.t_ad = new TextEdit();
      this.labelControl4 = new LabelControl();
      this.labelControl3 = new LabelControl();
      this.labelControl2 = new LabelControl();
      this.labelControl1 = new LabelControl();
      this.ep1 = new ErrorProvider(this.components);
      this.panelControl1.BeginInit();
      this.panelControl1.SuspendLayout();
      this.cmb_tip.Properties.BeginInit();
      this.t_value.Properties.BeginInit();
      this.t_sql_ad.Properties.BeginInit();
      this.t_ad.Properties.BeginInit();
      ((ISupportInitialize) this.ep1).BeginInit();
      this.SuspendLayout();
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(106, 210);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 8;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.btn_kaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kaydet.Location = new Point(12, 210);
      this.btn_kaydet.Name = "btn_kaydet";
      this.btn_kaydet.Size = new Size(75, 33);
      this.btn_kaydet.TabIndex = 7;
      this.btn_kaydet.Text = "Kaydet";
      this.btn_kaydet.Click += new EventHandler(this.btn_kaydet_Click);
      this.panelControl1.Controls.Add((Control) this.cmb_tip);
      this.panelControl1.Controls.Add((Control) this.t_value);
      this.panelControl1.Controls.Add((Control) this.t_sql_ad);
      this.panelControl1.Controls.Add((Control) this.t_ad);
      this.panelControl1.Controls.Add((Control) this.labelControl4);
      this.panelControl1.Controls.Add((Control) this.labelControl3);
      this.panelControl1.Controls.Add((Control) this.labelControl2);
      this.panelControl1.Controls.Add((Control) this.labelControl1);
      this.panelControl1.Location = new Point(12, 12);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new Size(359, 179);
      this.panelControl1.TabIndex = 9;
      this.cmb_tip.Location = new Point(140, 24);
      this.cmb_tip.Name = "cmb_tip";
      this.cmb_tip.Properties.AllowNullInput = DefaultBoolean.False;
      this.cmb_tip.Properties.Buttons.AddRange(new EditorButton[1]
      {
        new EditorButton(ButtonPredefines.Combo)
      });
      this.cmb_tip.Properties.ExportMode = ExportMode.Value;
      this.cmb_tip.Properties.NullText = "Seçiniz....";
      this.cmb_tip.Size = new Size(166, 20);
      this.cmb_tip.TabIndex = 9;
      this.t_value.Location = new Point(140, 132);
      this.t_value.Name = "t_value";
      this.t_value.Size = new Size(166, 20);
      this.t_value.TabIndex = 7;
      this.t_sql_ad.Location = new Point(140, 96);
      this.t_sql_ad.Name = "t_sql_ad";
      this.t_sql_ad.Size = new Size(166, 20);
      this.t_sql_ad.TabIndex = 6;
      this.t_ad.Location = new Point(140, 60);
      this.t_ad.Name = "t_ad";
      this.t_ad.Size = new Size(166, 20);
      this.t_ad.TabIndex = 5;
      this.labelControl4.Location = new Point(32, 135);
      this.labelControl4.Name = "labelControl4";
      this.labelControl4.Size = new Size(88, 13);
      this.labelControl4.TabIndex = 4;
      this.labelControl4.Text = "Varsayılan Değer :";
      this.labelControl3.Location = new Point(32, 99);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new Size(39, 13);
      this.labelControl3.TabIndex = 3;
      this.labelControl3.Text = "Sql Adı :";
      this.labelControl2.Location = new Point(32, 63);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new Size(75, 13);
      this.labelControl2.TabIndex = 2;
      this.labelControl2.Text = "Parametre Adı :";
      this.labelControl1.Location = new Point(32, 27);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new Size(76, 13);
      this.labelControl1.TabIndex = 1;
      this.labelControl1.Text = "Parametre Tipi :";
      this.ep1.ContainerControl = (ContainerControl) this;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(389, (int) byte.MaxValue);
      this.Controls.Add((Control) this.panelControl1);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.btn_kaydet);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (ParametreFrm);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "Parametre Tanımı";
      this.Load += new EventHandler(this.ParametreFrm_Load);
      this.panelControl1.EndInit();
      this.panelControl1.ResumeLayout(false);
      this.panelControl1.PerformLayout();
      this.cmb_tip.Properties.EndInit();
      this.t_value.Properties.EndInit();
      this.t_sql_ad.Properties.EndInit();
      this.t_ad.Properties.EndInit();
      ((ISupportInitialize) this.ep1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
