// Decompiled with JetBrains decompiler
// Type: Fuar.Hakkinda
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraEditors;
using Fuar.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class Hakkinda : XtraForm
  {
    private IContainer components;
    private Label label6;
    private Label label5;
    private Label label4;
    private Label label3;
    private Label label2;
    private PictureBox pictureBox2;
    private Label label1;
    private SimpleButton btn_kapat;

    public Hakkinda() => this.InitializeComponent();

    private void btn_kapat_Click(object sender, EventArgs e) => this.Close();

    private void pictureBox2_Click(object sender, EventArgs e)
    {
      Process.Start("http://www.dmsbilgisayar.com");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label6 = new Label();
      this.label5 = new Label();
      this.label4 = new Label();
      this.label3 = new Label();
      this.label2 = new Label();
      this.label1 = new Label();
      this.pictureBox2 = new PictureBox();
      this.btn_kapat = new SimpleButton();
      ((ISupportInitialize) this.pictureBox2).BeginInit();
      this.SuspendLayout();
      this.label6.AutoSize = true;
      this.label6.Location = new Point(54, 207);
      this.label6.Name = "label6";
      this.label6.Size = new Size(194, 13);
      this.label6.TabIndex = 26;
      this.label6.Text = "e-posta : software@dmsbilgisayar.com";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(54, 185);
      this.label5.Name = "label5";
      this.label5.Size = new Size(154, 13);
      this.label5.TabIndex = 25;
      this.label5.Text = "Web : www.dmsbilgisayar.com";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(54, 163);
      this.label4.Name = "label4";
      this.label4.Size = new Size(404, 13);
      this.label4.TabIndex = 24;
      this.label4.Text = "Yeni Mah. Pamukkale Sk. KentPlus C.Blok Kat.17 Daire.104 Soğanlık/Kartal/İstanbul";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(54, 141);
      this.label3.Name = "label3";
      this.label3.Size = new Size(110, 13);
      this.label3.TabIndex = 23;
      this.label3.Text = "Fax : 0216 623 10 94";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(54, 119);
      this.label2.Name = "label2";
      this.label2.Size = new Size(128, 13);
      this.label2.TabIndex = 22;
      this.label2.Text = "Tel : 0216 623 10 12 - 14";
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
      this.label1.Location = new Point(54, 96);
      this.label1.Name = "label1";
      this.label1.Size = new Size(368, 13);
      this.label1.TabIndex = 19;
      this.label1.Text = "Copyright 2011 Dms Bilgisayar Yazılım ve İlt.Sis.San.Tic.Ltd.Şti.";
      this.pictureBox2.BorderStyle = BorderStyle.FixedSingle;
      this.pictureBox2.Cursor = Cursors.Hand;
      this.pictureBox2.Image = (Image) Resources.dms_logo;
      this.pictureBox2.Location = new Point(205, 19);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new Size(120, 68);
      this.pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
      this.pictureBox2.TabIndex = 21;
      this.pictureBox2.TabStop = false;
      this.pictureBox2.Click += new EventHandler(this.pictureBox2_Click);
      this.btn_kapat.Location = new Point(155, 241);
      this.btn_kapat.Name = "btn_kapat";
      this.btn_kapat.Size = new Size(228, 34);
      this.btn_kapat.TabIndex = 27;
      this.btn_kapat.Text = "Kapat";
      this.btn_kapat.Click += new EventHandler(this.btn_kapat_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(538, 287);
      this.Controls.Add((Control) this.btn_kapat);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.pictureBox2);
      this.Controls.Add((Control) this.label1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (Hakkinda);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Hakkımızda";
      ((ISupportInitialize) this.pictureBox2).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
