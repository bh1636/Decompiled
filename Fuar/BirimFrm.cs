// Decompiled with JetBrains decompiler
// Type: Fuar.BirimFrm
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class BirimFrm : XtraForm
  {
    public string _id = string.Empty;
    private IContainer components;
    private Label label1;
    private TextBox txt_birim;
    private SimpleButton btn_kaydet;
    private SimpleButton btn_iptal;
    private GroupBox groupBox1;

    public BirimFrm() => this.InitializeComponent();

    private void BirimFrm_Load(object sender, EventArgs e)
    {
      if (!(this._id != ""))
        return;
      DataTable dataTable = _main.komutcalistir_dt("SELECT * FROM BIRIMLER WHERE ID = " + this._id);
      if (dataTable.Rows.Count <= 0)
        return;
      this.txt_birim.Text = dataTable.Rows[0]["BIRIM"].ToString();
    }

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void btn_kaydet_Click(object sender, EventArgs e)
    {
      if (this._id == "")
        this.insert_birim();
      else
        this.update_birim();
      this.Close();
    }

    private void insert_birim()
    {
      _main.komutcalistir("INSERT INTO BIRIMLER (BIRIM) VALUES ('" + this.txt_birim.Text + "')");
    }

    private void update_birim()
    {
      _main.komutcalistir("UPDATE BIRIMLER SET BIRIM = '" + this.txt_birim.Text + "' WHERE ID = " + this._id);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label1 = new Label();
      this.txt_birim = new TextBox();
      this.btn_kaydet = new SimpleButton();
      this.btn_iptal = new SimpleButton();
      this.groupBox1 = new GroupBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(18, 38);
      this.label1.Name = "label1";
      this.label1.Size = new Size(29, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Birim";
      this.txt_birim.Location = new Point(53, 35);
      this.txt_birim.Name = "txt_birim";
      this.txt_birim.Size = new Size(125, 20);
      this.txt_birim.TabIndex = 1;
      this.btn_kaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kaydet.Location = new Point(14, 174);
      this.btn_kaydet.Name = "btn_kaydet";
      this.btn_kaydet.Size = new Size(75, 33);
      this.btn_kaydet.TabIndex = 24;
      this.btn_kaydet.Text = "Kaydet";
      this.btn_kaydet.Click += new EventHandler(this.btn_kaydet_Click);
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(100, 174);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 25;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.groupBox1.Controls.Add((Control) this.txt_birim);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Location = new Point(14, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(200, 75);
      this.groupBox1.TabIndex = 26;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Birim Tanımı";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(279, 219);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.btn_kaydet);
      this.Controls.Add((Control) this.btn_iptal);
      this.Name = nameof (BirimFrm);
      this.Text = "Birim";
      this.Load += new EventHandler(this.BirimFrm_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
