namespace Task4
{
    partial class GraphicsEditor
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.DrawArea = new System.Windows.Forms.Panel();
            this.UndoButton = new System.Windows.Forms.Button();
            this.RedoButton = new System.Windows.Forms.Button();
            this.DrawLinesButton = new System.Windows.Forms.Button();
            this.SelectLinesButton = new System.Windows.Forms.Button();
            this.DeleteLineButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DrawArea
            // 
            this.DrawArea.BackColor = System.Drawing.SystemColors.Window;
            this.DrawArea.Location = new System.Drawing.Point(93, 12);
            this.DrawArea.Name = "DrawArea";
            this.DrawArea.Size = new System.Drawing.Size(679, 537);
            this.DrawArea.TabIndex = 0;
            this.DrawArea.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawArea_Paint);
            this.DrawArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseDown);
            this.DrawArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseMove);
            this.DrawArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawArea_MouseUp);
            // 
            // UndoButton
            // 
            this.UndoButton.Location = new System.Drawing.Point(12, 15);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(75, 23);
            this.UndoButton.TabIndex = 1;
            this.UndoButton.Text = "Undo";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // RedoButton
            // 
            this.RedoButton.Location = new System.Drawing.Point(12, 44);
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(75, 23);
            this.RedoButton.TabIndex = 2;
            this.RedoButton.Text = "Redo";
            this.RedoButton.UseVisualStyleBackColor = true;
            this.RedoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // DrawLinesButton
            // 
            this.DrawLinesButton.Location = new System.Drawing.Point(12, 189);
            this.DrawLinesButton.Name = "DrawLinesButton";
            this.DrawLinesButton.Size = new System.Drawing.Size(75, 23);
            this.DrawLinesButton.TabIndex = 3;
            this.DrawLinesButton.Text = "Draw lines";
            this.DrawLinesButton.UseVisualStyleBackColor = true;
            this.DrawLinesButton.Click += new System.EventHandler(this.DrawLinesButton_Click);
            // 
            // SelectLinesButton
            // 
            this.SelectLinesButton.Location = new System.Drawing.Point(12, 218);
            this.SelectLinesButton.Name = "SelectLinesButton";
            this.SelectLinesButton.Size = new System.Drawing.Size(75, 23);
            this.SelectLinesButton.TabIndex = 4;
            this.SelectLinesButton.Text = "Select lines";
            this.SelectLinesButton.UseVisualStyleBackColor = true;
            this.SelectLinesButton.Click += new System.EventHandler(this.SelectLinesButton_Click);
            // 
            // DeleteLineButton
            // 
            this.DeleteLineButton.Location = new System.Drawing.Point(12, 117);
            this.DeleteLineButton.Name = "DeleteLineButton";
            this.DeleteLineButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteLineButton.TabIndex = 5;
            this.DeleteLineButton.Text = "DeleteLine";
            this.DeleteLineButton.UseVisualStyleBackColor = true;
            this.DeleteLineButton.Click += new System.EventHandler(this.DeleteLineButton_Click);
            // 
            // GraphicsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.DeleteLineButton);
            this.Controls.Add(this.SelectLinesButton);
            this.Controls.Add(this.DrawLinesButton);
            this.Controls.Add(this.RedoButton);
            this.Controls.Add(this.UndoButton);
            this.Controls.Add(this.DrawArea);
            this.Name = "GraphicsEditor";
            this.Text = "Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DrawArea;
        private System.Windows.Forms.Button UndoButton;
        private System.Windows.Forms.Button RedoButton;
        private System.Windows.Forms.Button DrawLinesButton;
        private System.Windows.Forms.Button SelectLinesButton;
        private System.Windows.Forms.Button DeleteLineButton;
    }
}

