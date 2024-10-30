// Decompiled with JetBrains decompiler
// Type: Yönetim.frmYeniStokKart
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Yönetim.Properties;

#nullable disable
namespace Yönetim
{
  public class frmYeniStokKart : Form
  {
    private IContainer components = (IContainer) null;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Button button1;
    private TextBox txtkod;
    private TextBox txtad;
    private TextBox txtfiyat;
    private TextBox txtbirim;
    private TextBox txtbarkod;
    private Label label6;
    private TextBox TXTKDV;

    public frmYeniStokKart() => this.InitializeComponent();

    private void button1_Click(object sender, EventArgs e)
    {
      SqlCommand mCommand1 = new SqlCommand("INSERT INTO STOKLAR (sto_Recno,sto_kod,sto_isim,sto_perakende_vergi,sto_Bakiye) values (@sto_Recno,@sto_kod,@sto_isim,@sto_perakende_vergi,@sto_Bakiye)");
      mCommand1.Parameters.AddWithValue("@sto_Recno", (object) 0);
      mCommand1.Parameters.AddWithValue("@sto_kod", (object) this.txtkod.Text);
      mCommand1.Parameters.AddWithValue("@sto_isim", (object) this.txtad.Text);
      mCommand1.Parameters.AddWithValue("@sto_perakende_vergi", (object) this.TXTKDV.Text);
      mCommand1.Parameters.AddWithValue("@sto_Bakiye", (object) 0);
      DBManager.sqlRunCommand(mCommand1);
      SqlCommand mCommand2 = new SqlCommand("INSERT INTO BARKOD_TANIMLARI (bar_Recno,bar_stokkod,bar_kodu,bar_birim) values (@bar_Recno,@bar_stokkod,@bar_kodu,@bar_birim)");
      mCommand2.Parameters.AddWithValue("@bar_Recno", (object) 0);
      mCommand2.Parameters.AddWithValue("@bar_stokkod", (object) this.txtkod.Text);
      mCommand2.Parameters.AddWithValue("@bar_kodu", (object) this.txtbarkod.Text);
      mCommand2.Parameters.AddWithValue("@bar_birim", (object) this.txtbirim.Text);
      DBManager.sqlRunCommand(mCommand2);
      SqlCommand mCommand3 = new SqlCommand("INSERT INTO FIYAT_LISTESI (sfiyat_cariKod,sfyt_Recno,sfyt_no,sfyt_stokkod,sfyt_iskonto1,sfyt_iskonto2,sfyt_fiyat) values (@sfiyat_cariKod,@sfyt_Recno,@sfyt_no,@sfyt_stokkod,@sfyt_iskonto1,@sfyt_iskonto2,@sfyt_fiyat)");
      mCommand3.Parameters.AddWithValue("@sfyt_Recno", (object) 0);
      mCommand3.Parameters.AddWithValue("@sfyt_no", (object) 0);
      mCommand3.Parameters.AddWithValue("@sfyt_stokkod", (object) this.txtkod.Text);
      mCommand3.Parameters.AddWithValue("@sfyt_iskonto1", (object) 0);
      mCommand3.Parameters.AddWithValue("@sfyt_iskonto2", (object) 0);
      mCommand3.Parameters.AddWithValue("@sfyt_fiyat", (object) Convert.ToDouble(this.txtfiyat.Text));
      mCommand3.Parameters.AddWithValue("@sfiyat_cariKod", (object) "");
      DBManager.sqlRunCommand(mCommand3);
      this.Close();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmYeniStokKart));
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.button1 = new Button();
      this.txtkod = new TextBox();
      this.txtad = new TextBox();
      this.txtfiyat = new TextBox();
      this.txtbirim = new TextBox();
      this.txtbarkod = new TextBox();
      this.label6 = new Label();
      this.TXTKDV = new TextBox();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label1.Location = new Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new Size(68, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "STOK KOD :";
      this.label2.AutoSize = true;
      this.label2.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label2.Location = new Point(12, 36);
      this.label2.Name = "label2";
      this.label2.Size = new Size(66, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "STOK ADI :";
      this.label3.AutoSize = true;
      this.label3.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label3.Location = new Point(12, 59);
      this.label3.Name = "label3";
      this.label3.Size = new Size(46, 13);
      this.label3.TabIndex = 0;
      this.label3.Text = "FIYAT :";
      this.label4.AutoSize = true;
      this.label4.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label4.Location = new Point(12, 135);
      this.label4.Name = "label4";
      this.label4.Size = new Size(75, 13);
      this.label4.TabIndex = 0;
      this.label4.Text = "BIRIM  ADI :";
      this.label5.AutoSize = true;
      this.label5.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label5.Location = new Point(13, 110);
      this.label5.Name = "label5";
      this.label5.Size = new Size(59, 13);
      this.label5.TabIndex = 0;
      this.label5.Text = "BARKOD :";
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.button1.ForeColor = Color.Red;
      this.button1.Image = (Image) Resources.Actions_list_add;
      this.button1.ImageAlign = ContentAlignment.BottomLeft;
      this.button1.Location = new Point(12, 157);
      this.button1.Name = "button1";
      this.button1.Size = new Size(445, 40);
      this.button1.TabIndex = 1;
      this.button1.Text = "Kaydet";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.txtkod.BorderStyle = BorderStyle.FixedSingle;
      this.txtkod.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txtkod.Location = new Point(114, 2);
      this.txtkod.Name = "txtkod";
      this.txtkod.Size = new Size(177, 21);
      this.txtkod.TabIndex = 1;
      this.txtad.BorderStyle = BorderStyle.FixedSingle;
      this.txtad.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txtad.Location = new Point(114, 28);
      this.txtad.Name = "txtad";
      this.txtad.Size = new Size(343, 21);
      this.txtad.TabIndex = 2;
      this.txtfiyat.BorderStyle = BorderStyle.FixedSingle;
      this.txtfiyat.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txtfiyat.Location = new Point(114, 52);
      this.txtfiyat.Name = "txtfiyat";
      this.txtfiyat.Size = new Size(76, 21);
      this.txtfiyat.TabIndex = 3;
      this.txtbirim.BorderStyle = BorderStyle.FixedSingle;
      this.txtbirim.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txtbirim.Location = new Point(114, 128);
      this.txtbirim.Name = "txtbirim";
      this.txtbirim.Size = new Size(76, 21);
      this.txtbirim.TabIndex = 5;
      this.txtbarkod.BorderStyle = BorderStyle.FixedSingle;
      this.txtbarkod.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.txtbarkod.Location = new Point(114, 103);
      this.txtbarkod.Name = "txtbarkod";
      this.txtbarkod.Size = new Size(236, 21);
      this.txtbarkod.TabIndex = 6;
      this.label6.AutoSize = true;
      this.label6.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label6.Location = new Point(12, 85);
      this.label6.Name = "label6";
      this.label6.Size = new Size(74, 13);
      this.label6.TabIndex = 0;
      this.label6.Text = "KDV ORANI :";
      this.TXTKDV.BorderStyle = BorderStyle.FixedSingle;
      this.TXTKDV.Font = new Font("Tahoma", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.TXTKDV.Location = new Point(114, 78);
      this.TXTKDV.Name = "TXTKDV";
      this.TXTKDV.Size = new Size(76, 21);
      this.TXTKDV.TabIndex = 4;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(469, 204);
      this.Controls.Add((Control) this.TXTKDV);
      this.Controls.Add((Control) this.txtfiyat);
      this.Controls.Add((Control) this.txtbarkod);
      this.Controls.Add((Control) this.txtbirim);
      this.Controls.Add((Control) this.txtad);
      this.Controls.Add((Control) this.txtkod);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmYeniStokKart);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Yeni Stok Kartı";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
