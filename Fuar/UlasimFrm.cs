// Decompiled with JetBrains decompiler
// Type: Fuar.UlasimFrm
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
  public class UlasimFrm : XtraForm
  {
    public string _id = string.Empty;
    private IContainer components;
    private SimpleButton btn_iptal;
    private SimpleButton btn_kaydet;
    private GroupBox groupBox1;
    private TextBox txt_guz;
    private Label label3;
    private Label label1;
    private TextBox txt_ulstip;
    private Label label2;
    private System.Windows.Forms.ComboBox cmb_ulasim;

    public UlasimFrm() => this.InitializeComponent();

    private void UlasimFrm_Load(object sender, EventArgs e)
    {
      this.cmb_ulasim.Items.Add((object) "Karayolu");
      this.cmb_ulasim.Items.Add((object) "Havayolu");
      this.cmb_ulasim.Items.Add((object) "Denizyolu");
      this.cmb_ulasim.SelectedIndex = 0;
      if (!(this._id != ""))
        return;
      DataTable dataTable = _main.komutcalistir_dt("SELECT * FROM ULASIM WHERE ID = " + this._id);
      if (dataTable.Rows.Count <= 0)
        return;
      this.cmb_ulasim.SelectedItem = (object) dataTable.Rows[0]["ULASIMSEKLI"].ToString();
      this.txt_ulstip.Text = dataTable.Rows[0]["ULASIMTIPI"].ToString();
      this.txt_guz.Text = dataTable.Rows[0]["GUZERGAH"].ToString();
    }

    private void btn_iptal_Click(object sender, EventArgs e) => this.Close();

    private void btn_kaydet_Click(object sender, EventArgs e)
    {
      if (this._id == "")
        this.insert_uls();
      else
        this.update_uls();
      this.Close();
    }

    private void insert_uls()
    {
      _main.komutcalistir("INSERT INTO ULASIM (ULASIMSEKLI,ULASIMTIPI,GUZERGAH) " + "VALUES ('" + this.cmb_ulasim.SelectedItem.ToString() + "','" + this.txt_ulstip.Text + "','" + this.txt_guz.Text + "')");
    }

    private void update_uls()
    {
      _main.komutcalistir("UPDATE ULASIM SET ULASIMSEKLI = '" + this.cmb_ulasim.SelectedItem.ToString() + "',ULASIMTIPI = '" + this.txt_ulstip.Text + "',GUZERGAH = '" + this.txt_guz.Text + "'" + " WHERE ID = " + this._id);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.btn_iptal = new SimpleButton();
      this.btn_kaydet = new SimpleButton();
      this.groupBox1 = new GroupBox();
      this.txt_guz = new TextBox();
      this.label3 = new Label();
      this.label1 = new Label();
      this.txt_ulstip = new TextBox();
      this.label2 = new Label();
      this.cmb_ulasim = new System.Windows.Forms.ComboBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.btn_iptal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_iptal.Location = new Point(100, 245);
      this.btn_iptal.Name = "btn_iptal";
      this.btn_iptal.Size = new Size(75, 33);
      this.btn_iptal.TabIndex = 3;
      this.btn_iptal.Text = "İptal";
      this.btn_iptal.Click += new EventHandler(this.btn_iptal_Click);
      this.btn_kaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.btn_kaydet.Location = new Point(12, 245);
      this.btn_kaydet.Name = "btn_kaydet";
      this.btn_kaydet.Size = new Size(75, 33);
      this.btn_kaydet.TabIndex = 2;
      this.btn_kaydet.Text = "Kaydet";
      this.btn_kaydet.Click += new EventHandler(this.btn_kaydet_Click);
      this.groupBox1.Controls.Add((Control) this.cmb_ulasim);
      this.groupBox1.Controls.Add((Control) this.txt_guz);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.txt_ulstip);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Location = new Point(12, 22);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(349, 177);
      this.groupBox1.TabIndex = 10;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Ulaşım Şekli Tanımları";
      this.txt_guz.Location = new Point(111, 116);
      this.txt_guz.Name = "txt_guz";
      this.txt_guz.Size = new Size(196, 21);
      this.txt_guz.TabIndex = 10;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(20, 119);
      this.label3.Name = "label3";
      this.label3.Size = new Size(53, 13);
      this.label3.TabIndex = 9;
      this.label3.Text = "Güzergah";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(20, 51);
      this.label1.Name = "label1";
      this.label1.Size = new Size(61, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Ulaşım Şekli";
      this.txt_ulstip.Location = new Point(111, 81);
      this.txt_ulstip.Name = "txt_ulstip";
      this.txt_ulstip.Size = new Size(196, 21);
      this.txt_ulstip.TabIndex = 8;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(20, 84);
      this.label2.Name = "label2";
      this.label2.Size = new Size(56, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Ulaşım Tipi";
      this.cmb_ulasim.DropDownStyle = ComboBoxStyle.DropDownList;
      this.cmb_ulasim.FormattingEnabled = true;
      this.cmb_ulasim.Location = new Point(111, 48);
      this.cmb_ulasim.Name = "cmb_ulasim";
      this.cmb_ulasim.Size = new Size(196, 21);
      this.cmb_ulasim.TabIndex = 11;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(392, 290);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.btn_iptal);
      this.Controls.Add((Control) this.btn_kaydet);
      this.MinimizeBox = false;
      this.Name = nameof (UlasimFrm);
      this.Text = "Ulaşım Şekli";
      this.Load += new EventHandler(this.UlasimFrm_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
