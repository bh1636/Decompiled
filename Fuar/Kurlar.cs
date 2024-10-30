// Decompiled with JetBrains decompiler
// Type: Fuar.Kurlar
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class Kurlar : Form
  {
    private IContainer components;
    private GroupBox groupBox1;
    private LabelControl labelControl4;
    private LabelControl labelControl3;
    private LabelControl labelControl2;
    private LabelControl labelControl1;
    private TextEdit t_euro;
    private TextEdit t_usd;
    private SimpleButton btn_iptal;
    private SimpleButton btn_kaydet;

    public Kurlar() => this.InitializeComponent();

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void btn_kaydet_Click(object sender, EventArgs e)
    {
      try
      {
        if (!this.alankontrol())
          return;
        string cmdText = "DELETE FROM KURLAR " + "INSERT INTO KURLAR (USD,EURO) VALUES (@USD,@EURO)";
        SqlConnection connection = new SqlConnection(_main.str_connection);
        SqlCommand sqlCommand = new SqlCommand(cmdText, connection);
        sqlCommand.Parameters.AddWithValue("@USD", (object) Convert.ToDouble(this.t_usd.Text));
        sqlCommand.Parameters.AddWithValue("@EURO", (object) Convert.ToDouble(this.t_euro.Text));
        connection.Open();
        sqlCommand.ExecuteNonQuery();
        connection.Close();
        this.Close();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    private void Kurlar_Load(object sender, EventArgs e)
    {
      DataTable dataTable = _main.komutcalistir_dt("SELECT * FROM KURLAR");
      if (dataTable.Rows.Count <= 0)
        return;
      this.t_usd.Text = dataTable.Rows[0]["USD"].ToString();
      this.t_euro.Text = dataTable.Rows[0]["EURO"].ToString();
    }

    private bool alankontrol()
    {
      bool flag = true;
      if (this.t_euro.EditValue == null)
      {
        int num = (int) MessageBox.Show("Euro kuru giriniz");
        flag = false;
      }
      if (this.t_usd.EditValue == null)
      {
        int num = (int) MessageBox.Show("Usd kuru giriniz");
        flag = false;
      }
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
      this.groupBox1 = new GroupBox();
      this.labelControl4 = new LabelControl();
      this.labelControl3 = new LabelControl();
      this.labelControl2 = new LabelControl();
      this.labelControl1 = new LabelControl();
      this.t_euro = new TextEdit();
      this.t_usd = new TextEdit();
      this.btn_iptal = new SimpleButton();
      this.btn_kaydet = new SimpleButton();
      this.groupBox1.SuspendLayout();
      this.t_euro.Properties.BeginInit();
      this.t_usd.Properties.BeginInit();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.labelControl4);
      this.groupBox1.Controls.Add((Control) this.labelControl3);
      this.groupBox1.Controls.Add((Control) this.labelControl2);
      this.groupBox1.Controls.Add((Control) this.labelControl1);
      this.groupBox1.Controls.Add((Control) this.t_euro);
      this.groupBox1.Controls.Add((Control) this.t_usd);
      this.groupBox1.Location = new Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(220, 155);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = nameof (Kurlar);
      this.labelControl4.Location = new Point(74, 46);
      this.labelControl4.Name = "labelControl4";
      this.labelControl4.Size = new Size(4, 13);
      this.labelControl4.TabIndex = 3;
      this.labelControl4.Text = ":";
      this.labelControl3.Location = new Point(74, 99);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new Size(4, 13);
      this.labelControl3.TabIndex = 2;
      this.labelControl3.Text = ":";
      this.labelControl2.Location = new Point(45, 99);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new Size(22, 13);
      this.labelControl2.TabIndex = 1;
      this.labelControl2.Text = "Euro";
      this.labelControl1.Location = new Point(45, 46);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new Size(18, 13);
      this.labelControl1.TabIndex = 1;
      this.labelControl1.Text = "Usd";
      this.t_euro.Location = new Point(84, 96);
      this.t_euro.Name = "t_euro";
      this.t_euro.Properties.Mask.EditMask = "n4";
      this.t_euro.Properties.Mask.MaskType = MaskType.Numeric;
      this.t_euro.Properties.Mask.UseMaskAsDisplayFormat = true;
      this.t_euro.Size = new Size(100, 20);
      this.t_euro.TabIndex = 0;
      this.t_usd.Location = new Point(84, 43);
      this.t_usd.Name = "t_usd";
      this.t_usd.Properties.AllowNullInput = DefaultBoolean.False;
      this.t_usd.Properties.Mask.EditMask = "n4";
      this.t_usd.Properties.Mask.MaskType = MaskType.Numeric;
      this.t_usd.Properties.Mask.SaveLiteral = false;
      this.t_usd.Properties.Mask.UseMaskAsDisplayFormat = true;
      this.t_usd.Size = new Size(100, 20);
      this.t_usd.TabIndex = 0;
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(100, 187);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 3;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.btn_kaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kaydet.Location = new Point(12, 187);
      this.btn_kaydet.Name = "btn_kaydet";
      this.btn_kaydet.Size = new Size(75, 33);
      this.btn_kaydet.TabIndex = 2;
      this.btn_kaydet.Text = "Kaydet";
      this.btn_kaydet.Click += new EventHandler(this.btn_kaydet_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(246, 232);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.btn_kaydet);
      this.Controls.Add((Control) this.groupBox1);
      this.MaximizeBox = false;
      this.Name = nameof (Kurlar);
      this.ShowIcon = false;
      this.Text = nameof (Kurlar);
      this.Load += new EventHandler(this.Kurlar_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.t_euro.Properties.EndInit();
      this.t_usd.Properties.EndInit();
      this.ResumeLayout(false);
    }
  }
}
