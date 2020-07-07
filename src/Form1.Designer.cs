namespace InternetReady
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.label1 = new System.Windows.Forms.Label();
      this.addressBox = new System.Windows.Forms.TextBox();
      this.attemptLabel = new System.Windows.Forms.Label();
      this.monitorTimer = new System.Windows.Forms.Timer(this.components);
      this.monitorWorker = new System.ComponentModel.BackgroundWorker();
      this.logButton = new System.Windows.Forms.Button();
      this.alertMeCheckbox = new System.Windows.Forms.CheckBox();
      this.checkNowButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(48, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Address:";
      // 
      // addressBox
      // 
      this.addressBox.Location = new System.Drawing.Point(66, 10);
      this.addressBox.Name = "addressBox";
      this.addressBox.Size = new System.Drawing.Size(267, 20);
      this.addressBox.TabIndex = 1;
      this.addressBox.Text = "wildermuth.com";
      // 
      // attemptLabel
      // 
      this.attemptLabel.AutoSize = true;
      this.attemptLabel.Location = new System.Drawing.Point(13, 45);
      this.attemptLabel.Name = "attemptLabel";
      this.attemptLabel.Size = new System.Drawing.Size(0, 13);
      this.attemptLabel.TabIndex = 3;
      // 
      // monitorTimer
      // 
      this.monitorTimer.Enabled = true;
      this.monitorTimer.Interval = 1000;
      this.monitorTimer.Tick += new System.EventHandler(this.monitorTimer_Tick);
      // 
      // monitorWorker
      // 
      this.monitorWorker.WorkerReportsProgress = true;
      this.monitorWorker.WorkerSupportsCancellation = true;
      this.monitorWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.monitorWorker_DoWork);
      this.monitorWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.monitorWorker_RunWorkerCompleted);
      // 
      // logButton
      // 
      this.logButton.Location = new System.Drawing.Point(317, 36);
      this.logButton.Name = "logButton";
      this.logButton.Size = new System.Drawing.Size(75, 23);
      this.logButton.TabIndex = 4;
      this.logButton.Text = "View Log";
      this.logButton.UseVisualStyleBackColor = true;
      this.logButton.Click += new System.EventHandler(this.logButton_Click);
      // 
      // alertMeCheckbox
      // 
      this.alertMeCheckbox.AutoSize = true;
      this.alertMeCheckbox.Location = new System.Drawing.Point(339, 13);
      this.alertMeCheckbox.Name = "alertMeCheckbox";
      this.alertMeCheckbox.Size = new System.Drawing.Size(53, 17);
      this.alertMeCheckbox.TabIndex = 5;
      this.alertMeCheckbox.Text = "Alert?";
      this.alertMeCheckbox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.alertMeCheckbox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.alertMeCheckbox.UseVisualStyleBackColor = true;
      // 
      // checkNowButton
      // 
      this.checkNowButton.Location = new System.Drawing.Point(236, 36);
      this.checkNowButton.Name = "checkNowButton";
      this.checkNowButton.Size = new System.Drawing.Size(75, 23);
      this.checkNowButton.TabIndex = 6;
      this.checkNowButton.Text = "Check Now";
      this.checkNowButton.UseVisualStyleBackColor = true;
      this.checkNowButton.Click += new System.EventHandler(this.checkNowButton_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(395, 66);
      this.Controls.Add(this.checkNowButton);
      this.Controls.Add(this.alertMeCheckbox);
      this.Controls.Add(this.logButton);
      this.Controls.Add(this.attemptLabel);
      this.Controls.Add(this.addressBox);
      this.Controls.Add(this.label1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Internet Tester";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox addressBox;
    private System.Windows.Forms.Label attemptLabel;
    private System.Windows.Forms.Timer monitorTimer;
    private System.ComponentModel.BackgroundWorker monitorWorker;
    private System.Windows.Forms.Button logButton;
    private System.Windows.Forms.CheckBox alertMeCheckbox;
    private System.Windows.Forms.Button checkNowButton;
  }
}

