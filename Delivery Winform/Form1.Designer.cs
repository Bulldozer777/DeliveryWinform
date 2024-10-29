namespace Delivery_Winform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBoxWeight = new TextBox();
            textBoxCityDistrict = new TextBox();
            textBoxDeliveryDate = new TextBox();
            button4 = new Button();
            label1 = new Label();
            textBoxFiltCityDistrict = new TextBox();
            label5 = new Label();
            textBoxFiltDeliveryDate = new TextBox();
            label6 = new Label();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(352, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 80;
            dataGridView1.Size = new Size(669, 411);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            button1.Location = new Point(6, 177);
            button1.Name = "button1";
            button1.Size = new Size(342, 55);
            button1.TabIndex = 1;
            button1.Text = "Добавить заказ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic);
            button2.Location = new Point(12, 428);
            button2.Name = "button2";
            button2.Size = new Size(336, 55);
            button2.TabIndex = 2;
            button2.Text = "Выполнить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic);
            button3.Location = new Point(6, 238);
            button3.Name = "button3";
            button3.Size = new Size(342, 61);
            button3.TabIndex = 3;
            button3.Text = "Удалить заказ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(67, 13);
            label2.Name = "label2";
            label2.Size = new Size(104, 31);
            label2.TabIndex = 5;
            label2.Text = "Weight :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(24, 74);
            label3.Name = "label3";
            label3.Size = new Size(147, 31);
            label3.TabIndex = 6;
            label3.Text = "CityDistrict :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(6, 130);
            label4.Name = "label4";
            label4.Size = new Size(165, 31);
            label4.TabIndex = 7;
            label4.Text = "DeliveryDate :";
            // 
            // textBoxWeight
            // 
            textBoxWeight.Location = new Point(169, 15);
            textBoxWeight.Name = "textBoxWeight";
            textBoxWeight.Size = new Size(177, 27);
            textBoxWeight.TabIndex = 9;
            // 
            // textBoxCityDistrict
            // 
            textBoxCityDistrict.Location = new Point(169, 75);
            textBoxCityDistrict.Name = "textBoxCityDistrict";
            textBoxCityDistrict.Size = new Size(177, 27);
            textBoxCityDistrict.TabIndex = 10;
            // 
            // textBoxDeliveryDate
            // 
            textBoxDeliveryDate.Location = new Point(169, 132);
            textBoxDeliveryDate.Name = "textBoxDeliveryDate";
            textBoxDeliveryDate.Size = new Size(125, 27);
            textBoxDeliveryDate.TabIndex = 11;
            // 
            // button4
            // 
            button4.Location = new Point(294, 131);
            button4.Name = "button4";
            button4.Size = new Size(54, 29);
            button4.TabIndex = 12;
            button4.Text = "Now";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic);
            label1.Location = new Point(6, 316);
            label1.Name = "label1";
            label1.Size = new Size(156, 31);
            label1.TabIndex = 13;
            label1.Text = "Фильтрация";
            // 
            // textBoxFiltCityDistrict
            // 
            textBoxFiltCityDistrict.Location = new Point(216, 361);
            textBoxFiltCityDistrict.Name = "textBoxFiltCityDistrict";
            textBoxFiltCityDistrict.Size = new Size(130, 27);
            textBoxFiltCityDistrict.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(71, 361);
            label5.Name = "label5";
            label5.Size = new Size(147, 31);
            label5.TabIndex = 14;
            label5.Text = "CityDistrict :";
            // 
            // textBoxFiltDeliveryDate
            // 
            textBoxFiltDeliveryDate.Location = new Point(216, 394);
            textBoxFiltDeliveryDate.Name = "textBoxFiltDeliveryDate";
            textBoxFiltDeliveryDate.Size = new Size(130, 27);
            textBoxFiltDeliveryDate.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label6.Location = new Point(6, 392);
            label6.Name = "label6";
            label6.Size = new Size(212, 31);
            label6.TabIndex = 16;
            label6.Text = "FirstDeliveryDate :";
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold | FontStyle.Italic);
            button5.Location = new Point(352, 428);
            button5.Name = "button5";
            button5.Size = new Size(336, 55);
            button5.TabIndex = 18;
            button5.Text = "Вывести таблицу заказов";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 506);
            Controls.Add(button5);
            Controls.Add(textBoxFiltDeliveryDate);
            Controls.Add(label6);
            Controls.Add(textBoxFiltCityDistrict);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(textBoxDeliveryDate);
            Controls.Add(textBoxCityDistrict);
            Controls.Add(textBoxWeight);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Delivery";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBoxWeight;
        private TextBox textBoxCityDistrict;
        private TextBox textBoxDeliveryDate;
        private Button button4;
        private Label label1;
        private TextBox textBoxFiltCityDistrict;
        private Label label5;
        private TextBox textBoxFiltDeliveryDate;
        private Label label6;
        private Button button5;
    }
}
