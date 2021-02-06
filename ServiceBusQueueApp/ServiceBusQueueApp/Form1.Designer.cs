namespace QueueForm
{
    partial class Form1
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
            this.queueNameTxt = new System.Windows.Forms.TextBox();
            this.createQ = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.TextBox();
            this.sendQueue = new System.Windows.Forms.Button();
            this.sendQueueTxt = new System.Windows.Forms.TextBox();
            this.readQueue = new System.Windows.Forms.Button();
            this.sndTopic = new System.Windows.Forms.Button();
            this.topicTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // queueNameTxt
            // 
            this.queueNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queueNameTxt.Location = new System.Drawing.Point(235, 50);
            this.queueNameTxt.Name = "queueNameTxt";
            this.queueNameTxt.Size = new System.Drawing.Size(493, 34);
            this.queueNameTxt.TabIndex = 1;
            // 
            // createQ
            // 
            this.createQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createQ.Location = new System.Drawing.Point(12, 34);
            this.createQ.Name = "createQ";
            this.createQ.Size = new System.Drawing.Size(203, 50);
            this.createQ.TabIndex = 2;
            this.createQ.Text = "Make Queue";
            this.createQ.UseVisualStyleBackColor = true;
            this.createQ.Click += new System.EventHandler(this.createQ_Click);
            // 
            // status
            // 
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.Location = new System.Drawing.Point(235, 192);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(493, 34);
            this.status.TabIndex = 3;
            // 
            // sendQueue
            // 
            this.sendQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendQueue.Location = new System.Drawing.Point(12, 106);
            this.sendQueue.Name = "sendQueue";
            this.sendQueue.Size = new System.Drawing.Size(203, 51);
            this.sendQueue.TabIndex = 4;
            this.sendQueue.Text = "Send Queue";
            this.sendQueue.UseVisualStyleBackColor = true;
            this.sendQueue.Click += new System.EventHandler(this.sendQueue_Click);
            // 
            // sendQueueTxt
            // 
            this.sendQueueTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendQueueTxt.Location = new System.Drawing.Point(235, 114);
            this.sendQueueTxt.Name = "sendQueueTxt";
            this.sendQueueTxt.Size = new System.Drawing.Size(493, 34);
            this.sendQueueTxt.TabIndex = 5;
            // 
            // readQueue
            // 
            this.readQueue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readQueue.Location = new System.Drawing.Point(12, 182);
            this.readQueue.Name = "readQueue";
            this.readQueue.Size = new System.Drawing.Size(203, 54);
            this.readQueue.TabIndex = 6;
            this.readQueue.Text = "Read Queue";
            this.readQueue.UseVisualStyleBackColor = true;
            this.readQueue.Click += new System.EventHandler(this.readQueue_Click);
            // 
            // sndTopic
            // 
            this.sndTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sndTopic.Location = new System.Drawing.Point(12, 256);
            this.sndTopic.Name = "sndTopic";
            this.sndTopic.Size = new System.Drawing.Size(203, 51);
            this.sndTopic.TabIndex = 7;
            this.sndTopic.Text = "Send Topic";
            this.sndTopic.UseVisualStyleBackColor = true;
            this.sndTopic.Click += new System.EventHandler(this.sndTopic_Click);
            // 
            // topicTB
            // 
            this.topicTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topicTB.Location = new System.Drawing.Point(235, 264);
            this.topicTB.Name = "topicTB";
            this.topicTB.Size = new System.Drawing.Size(493, 34);
            this.topicTB.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 331);
            this.Controls.Add(this.topicTB);
            this.Controls.Add(this.sndTopic);
            this.Controls.Add(this.readQueue);
            this.Controls.Add(this.sendQueueTxt);
            this.Controls.Add(this.sendQueue);
            this.Controls.Add(this.status);
            this.Controls.Add(this.createQ);
            this.Controls.Add(this.queueNameTxt);
            this.Name = "Form1";
            this.Text = "Service Bus";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox queueNameTxt;
        private System.Windows.Forms.Button createQ;
        private System.Windows.Forms.TextBox status;
        private System.Windows.Forms.Button sendQueue;
        private System.Windows.Forms.TextBox sendQueueTxt;
        private System.Windows.Forms.Button readQueue;
        private System.Windows.Forms.Button sndTopic;
        private System.Windows.Forms.TextBox topicTB;
    }
}

