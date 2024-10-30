// Decompiled with JetBrains decompiler
// Type: Yönetim.frmTopluDegistiklik
// Assembly: Yönetim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 828BB732-6E82-4E07-8165-2512296A2922
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\NRS FUAR\SIPARIS YONETIM\Yönetim.exe

using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Yönetim
{
  public class frmTopluDegistiklik : Form
  {
    private IContainer components = (IContainer) null;
    private Label label1;
    private Label label2;
    private TextBox textBox1;
    private TextBox textBox2;
    private Button button1;

    public frmTopluDegistiklik() => this.InitializeComponent();

    private void button1_Click(object sender, EventArgs e)
    {
      if (this.textBox1.Text == "")
        this.textBox1.Text = "0";
      if (this.textBox2.Text == "")
        this.textBox2.Text = "0";
      DBManager.sqlRunCommand(new SqlCommand("UPDATE FIYAT_LISTESI SET sfyt_iskonto1=" + this.textBox1.Text + ",sfyt_iskonto2=" + this.textBox2.Text));
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
      this.label1 = new Label();
      this.label2 = new Label();
      this.textBox1 = new TextBox();
      this.textBox2 = new TextBox();
      this.button1 = new Button();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(11, 10);
      this.label1.Name = "label1";
      this.label1.Size = new Size(57, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "İskonto 1 :";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(11, 36);
      this.label2.Name = "label2";
      this.label2.Size = new Size(54, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "İskonto 2:";
      this.textBox1.Location = new Point(73, 2);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(100, 20);
      this.textBox1.TabIndex = 2;
      this.textBox2.Location = new Point(73, 29);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(100, 20);
      this.textBox2.TabIndex = 2;
      this.button1.Location = new Point(73, 55);
      this.button1.Name = "button1";
      this.button1.Size = new Size(100, 23);
      this.button1.TabIndex = 3;
      this.button1.Text = "Kayıt";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(190, 87);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.textBox2);
      this.Controls.Add((Control) this.textBox1);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmTopluDegistiklik);
      this.Text = "Toplu Değişiklik";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
