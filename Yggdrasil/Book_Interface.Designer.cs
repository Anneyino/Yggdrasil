﻿namespace Yggdrasil
{
    partial class Book_Interface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Book_Interface));
            this.BookNameLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ChapterBox = new System.Windows.Forms.ComboBox();
            this.ChapterLabel = new System.Windows.Forms.Label();
            this.Summary = new System.Windows.Forms.TextBox();
            this.BeginReadButton = new System.Windows.Forms.Button();
            this.ContinueReadButton = new System.Windows.Forms.Button();
            this.CommentsBox = new System.Windows.Forms.RichTextBox();
            this.WriteCommentBox = new System.Windows.Forms.RichTextBox();
            this.CommentButton = new System.Windows.Forms.Button();
            this.CommentLabel = new System.Windows.Forms.Label();
            this.LeaveCommentLabel = new System.Windows.Forms.Label();
            this.CollectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BookNameLabel
            // 
            this.BookNameLabel.AutoSize = true;
            this.BookNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.BookNameLabel.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BookNameLabel.Location = new System.Drawing.Point(42, 20);
            this.BookNameLabel.Name = "BookNameLabel";
            this.BookNameLabel.Size = new System.Drawing.Size(124, 25);
            this.BookNameLabel.TabIndex = 0;
            this.BookNameLabel.Text = "BookName";
            
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(46, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(269, 227);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            
            // 
            // ChapterBox
            // 
            this.ChapterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChapterBox.FormattingEnabled = true;
            this.ChapterBox.Location = new System.Drawing.Point(46, 343);
            this.ChapterBox.Name = "ChapterBox";
            this.ChapterBox.Size = new System.Drawing.Size(121, 23);
            this.ChapterBox.TabIndex = 2;
            this.ChapterBox.SelectedIndexChanged += new System.EventHandler(this.ChapterBox_SelectedIndexChanged);
            // 
            // ChapterLabel
            // 
            this.ChapterLabel.AutoSize = true;
            this.ChapterLabel.BackColor = System.Drawing.Color.Transparent;
            this.ChapterLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChapterLabel.Location = new System.Drawing.Point(43, 320);
            this.ChapterLabel.Name = "ChapterLabel";
            this.ChapterLabel.Size = new System.Drawing.Size(86, 20);
            this.ChapterLabel.TabIndex = 3;
            this.ChapterLabel.Text = "Chapter";
            // 
            // Summary
            // 
            this.Summary.BackColor = System.Drawing.SystemColors.MenuBar;
            this.Summary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Summary.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Summary.Location = new System.Drawing.Point(347, 47);
            this.Summary.Multiline = true;
            this.Summary.Name = "Summary";
            this.Summary.ReadOnly = true;
            this.Summary.Size = new System.Drawing.Size(425, 227);
            this.Summary.TabIndex = 4;
            
            // 
            // BeginReadButton
            // 
            this.BeginReadButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.BeginReadButton.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BeginReadButton.Location = new System.Drawing.Point(347, 353);
            this.BeginReadButton.Name = "BeginReadButton";
            this.BeginReadButton.Size = new System.Drawing.Size(200, 63);
            this.BeginReadButton.TabIndex = 5;
            this.BeginReadButton.Text = "Begin to Read";
            this.BeginReadButton.UseVisualStyleBackColor = false;
            this.BeginReadButton.Click += new System.EventHandler(this.BeginReadButton_Click);
            // 
            // ContinueReadButton
            // 
            this.ContinueReadButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.ContinueReadButton.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ContinueReadButton.Location = new System.Drawing.Point(574, 353);
            this.ContinueReadButton.Name = "ContinueReadButton";
            this.ContinueReadButton.Size = new System.Drawing.Size(198, 63);
            this.ContinueReadButton.TabIndex = 6;
            this.ContinueReadButton.Text = "Continue to Read";
            this.ContinueReadButton.UseVisualStyleBackColor = false;
            this.ContinueReadButton.Click += new System.EventHandler(this.ContinueReadButton_Click);
            // 
            // CommentsBox
            // 
            this.CommentsBox.BackColor = System.Drawing.Color.AntiqueWhite;
            this.CommentsBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CommentsBox.Location = new System.Drawing.Point(3, 422);
            this.CommentsBox.Name = "CommentsBox";
            this.CommentsBox.ReadOnly = true;
            this.CommentsBox.Size = new System.Drawing.Size(792, 298);
            this.CommentsBox.TabIndex = 7;
            this.CommentsBox.Text = "";
            // 
            // WriteCommentBox
            // 
            this.WriteCommentBox.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.WriteCommentBox.Location = new System.Drawing.Point(11, 797);
            this.WriteCommentBox.Name = "WriteCommentBox";
            this.WriteCommentBox.Size = new System.Drawing.Size(784, 96);
            this.WriteCommentBox.TabIndex = 8;
            this.WriteCommentBox.Text = "";
            // 
            // CommentButton
            // 
            this.CommentButton.BackColor = System.Drawing.Color.LightSalmon;
            this.CommentButton.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CommentButton.Location = new System.Drawing.Point(347, 932);
            this.CommentButton.Name = "CommentButton";
            this.CommentButton.Size = new System.Drawing.Size(106, 36);
            this.CommentButton.TabIndex = 9;
            this.CommentButton.Text = "Submit";
            this.CommentButton.UseVisualStyleBackColor = false;
            this.CommentButton.Click += new System.EventHandler(this.CommentButton_Click);
            // 
            // CommentLabel
            // 
            this.CommentLabel.AutoSize = true;
            this.CommentLabel.BackColor = System.Drawing.Color.Transparent;
            this.CommentLabel.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CommentLabel.Location = new System.Drawing.Point(9, 385);
            this.CommentLabel.Name = "CommentLabel";
            this.CommentLabel.Size = new System.Drawing.Size(138, 31);
            this.CommentLabel.TabIndex = 10;
            this.CommentLabel.Text = "Comments";
            // 
            // LeaveCommentLabel
            // 
            this.LeaveCommentLabel.AutoSize = true;
            this.LeaveCommentLabel.BackColor = System.Drawing.Color.Transparent;
            this.LeaveCommentLabel.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LeaveCommentLabel.Location = new System.Drawing.Point(9, 763);
            this.LeaveCommentLabel.Name = "LeaveCommentLabel";
            this.LeaveCommentLabel.Size = new System.Drawing.Size(325, 31);
            this.LeaveCommentLabel.TabIndex = 11;
            this.LeaveCommentLabel.Text = "Leave your comments here";
            // 
            // CollectButton
            // 
            this.CollectButton.BackColor = System.Drawing.Color.LightCoral;
            this.CollectButton.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CollectButton.Location = new System.Drawing.Point(46, 276);
            this.CollectButton.Name = "CollectButton";
            this.CollectButton.Size = new System.Drawing.Size(269, 32);
            this.CollectButton.TabIndex = 12;
            this.CollectButton.Text = "Add to My Collection";
            this.CollectButton.UseVisualStyleBackColor = false;
            this.CollectButton.Click += new System.EventHandler(this.CollectButton_Click);
            // 
            // Book_Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::Yggdrasil.Properties.Resources._5_120601095934;
            this.ClientSize = new System.Drawing.Size(798, 980);
            this.Controls.Add(this.CollectButton);
            this.Controls.Add(this.LeaveCommentLabel);
            this.Controls.Add(this.CommentLabel);
            this.Controls.Add(this.CommentButton);
            this.Controls.Add(this.WriteCommentBox);
            this.Controls.Add(this.CommentsBox);
            this.Controls.Add(this.ContinueReadButton);
            this.Controls.Add(this.BeginReadButton);
            this.Controls.Add(this.Summary);
            this.Controls.Add(this.ChapterLabel);
            this.Controls.Add(this.ChapterBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BookNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Book_Interface";
            this.Text = "书籍界面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Book_Interface_FormClosing);
            this.Load += new System.EventHandler(this.Book_Interface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BookNameLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox ChapterBox;
        private System.Windows.Forms.Label ChapterLabel;
        private System.Windows.Forms.TextBox Summary;
        private System.Windows.Forms.Button BeginReadButton;
        private System.Windows.Forms.Button ContinueReadButton;
        private System.Windows.Forms.RichTextBox CommentsBox;
        private System.Windows.Forms.RichTextBox WriteCommentBox;
        private System.Windows.Forms.Button CommentButton;
        private System.Windows.Forms.Label CommentLabel;
        private System.Windows.Forms.Label LeaveCommentLabel;
        private System.Windows.Forms.Button CollectButton;
    }
}