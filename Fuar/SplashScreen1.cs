// Decompiled with JetBrains decompiler
// Type: Fuar.SplashScreen1
// Assembly: Fuar, Version=1.1.39.0, Culture=neutral, PublicKeyToken=null
// MVID: B382E810-8DBA-41A1-B0E2-A0674A32F1BB
// Assembly location: C:\Users\DELL\OneDrive\Ramazan\FUARD\Fuar.exe

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using Fuar.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Fuar
{
  public class SplashScreen1 : SplashScreen
  {
    private IContainer components;
    private MarqueeProgressBarControl marqueeProgressBarControl1;
    private LabelControl labelControl1;
    private LabelControl labelControl2;
    private PictureEdit pictureEdit1;
    private PictureEdit pictureEdit2;

    public SplashScreen1() => this.InitializeComponent();

    public override void ProcessCommand(Enum cmd, object arg) => base.ProcessCommand(cmd, arg);

    private void SplashScreen1_FormClosed(object sender, FormClosedEventArgs e) => this.Show();

    private void pictureEdit2_Click(object sender, EventArgs e) => this.Close();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (SplashScreen1));
      this.marqueeProgressBarControl1 = new MarqueeProgressBarControl();
      this.labelControl1 = new LabelControl();
      this.labelControl2 = new LabelControl();
      this.pictureEdit2 = new PictureEdit();
      this.pictureEdit1 = new PictureEdit();
      this.marqueeProgressBarControl1.Properties.BeginInit();
      this.pictureEdit2.Properties.BeginInit();
      this.pictureEdit1.Properties.BeginInit();
      this.SuspendLayout();
      this.marqueeProgressBarControl1.EditValue = (object) 0;
      this.marqueeProgressBarControl1.Location = new Point(23, 321);
      this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
      this.marqueeProgressBarControl1.Size = new Size(404, 12);
      this.marqueeProgressBarControl1.TabIndex = 5;
      this.labelControl1.BorderStyle = BorderStyles.NoBorder;
      this.labelControl1.Location = new Point(23, 366);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new Size(108, 13);
      this.labelControl1.TabIndex = 6;
      this.labelControl1.Text = "Dms Bilgisayar © 2012";
      this.labelControl2.Location = new Point(23, 296);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new Size(61, 13);
      this.labelControl2.TabIndex = 7;
      this.labelControl2.Text = "Yükleniyor...";
      this.pictureEdit2.EditValue = (object) Resources.shopping_cart_icon_copy;
      this.pictureEdit2.Location = new Point(12, 12);
      this.pictureEdit2.Name = "pictureEdit2";
      this.pictureEdit2.Properties.AllowFocused = false;
      this.pictureEdit2.Properties.Appearance.BackColor = Color.Transparent;
      this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
      this.pictureEdit2.Properties.BorderStyle = BorderStyles.NoBorder;
      this.pictureEdit2.Properties.ShowMenu = false;
      this.pictureEdit2.Size = new Size(426, 278);
      this.pictureEdit2.TabIndex = 9;
      this.pictureEdit2.Click += new EventHandler(this.pictureEdit2_Click);
      this.pictureEdit1.EditValue = componentResourceManager.GetObject("pictureEdit1.EditValue");
      this.pictureEdit1.Location = new Point(311, 342);
      this.pictureEdit1.Name = "pictureEdit1";
      this.pictureEdit1.Properties.AllowFocused = false;
      this.pictureEdit1.Properties.Appearance.BackColor = Color.Transparent;
      this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
      this.pictureEdit1.Properties.BorderStyle = BorderStyles.NoBorder;
      this.pictureEdit1.Properties.ShowMenu = false;
      this.pictureEdit1.Size = new Size(100, 57);
      this.pictureEdit1.TabIndex = 8;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(452, 415);
      this.Controls.Add((Control) this.pictureEdit2);
      this.Controls.Add((Control) this.pictureEdit1);
      this.Controls.Add((Control) this.labelControl2);
      this.Controls.Add((Control) this.labelControl1);
      this.Controls.Add((Control) this.marqueeProgressBarControl1);
      this.Name = nameof (SplashScreen1);
      this.Text = "Form1";
      this.TopMost = true;
      this.FormClosed += new FormClosedEventHandler(this.SplashScreen1_FormClosed);
      this.marqueeProgressBarControl1.Properties.EndInit();
      this.pictureEdit2.Properties.EndInit();
      this.pictureEdit1.Properties.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public enum SplashScreenCommand
    {
    }
  }
}
