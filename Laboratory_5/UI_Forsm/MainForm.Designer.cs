namespace UI_Forsm
{
    partial class MainForm
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
            UserInfo = new Label();
            txtWeight = new TextBox();
            labelUserWeight = new Label();
            labelUserHeight = new Label();
            labelUserAge = new Label();
            txtHeight = new TextBox();
            txtAge = new TextBox();
            labelUserActivity = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            labelCat = new Label();
            comboCategories = new ComboBox();
            labelProducts = new Label();
            listProducts = new ListBox();
            txtSearch = new TextBox();
            btnSearch = new Button();
            labelRation = new Label();
            listMeals = new ListBox();
            btnAddToMeal = new Button();
            labelNewWeight = new Label();
            txtWeightUpdate = new TextBox();
            btnUpdateWeight = new Button();
            btnRemoveProduct = new Button();
            btnAddMeal = new Button();
            btnRemoveMeal = new Button();
            comboActivity = new ComboBox();
            btnCalc = new Button();
            lblCalories = new Label();
            btnSave = new Button();
            SuspendLayout();
            // 
            // UserInfo
            // 
            UserInfo.AutoSize = true;
            UserInfo.Location = new Point(12, 9);
            UserInfo.Name = "UserInfo";
            UserInfo.Size = new Size(164, 20);
            UserInfo.TabIndex = 0;
            UserInfo.Text = "Данные пользователя";
            // 
            // txtWeight
            // 
            txtWeight.Location = new Point(144, 45);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(125, 27);
            txtWeight.TabIndex = 1;
            txtWeight.TextChanged += txtWeight_TextChanged;
            // 
            // labelUserWeight
            // 
            labelUserWeight.AutoSize = true;
            labelUserWeight.Location = new Point(32, 45);
            labelUserWeight.Name = "labelUserWeight";
            labelUserWeight.Size = new Size(36, 20);
            labelUserWeight.TabIndex = 2;
            labelUserWeight.Text = "Вес:";
            // 
            // labelUserHeight
            // 
            labelUserHeight.AutoSize = true;
            labelUserHeight.Location = new Point(32, 85);
            labelUserHeight.Name = "labelUserHeight";
            labelUserHeight.Size = new Size(46, 20);
            labelUserHeight.TabIndex = 3;
            labelUserHeight.Text = "Рост: ";
            // 
            // labelUserAge
            // 
            labelUserAge.AutoSize = true;
            labelUserAge.Location = new Point(32, 124);
            labelUserAge.Name = "labelUserAge";
            labelUserAge.Size = new Size(64, 20);
            labelUserAge.TabIndex = 4;
            labelUserAge.Text = "Возраст";
            // 
            // txtHeight
            // 
            txtHeight.Location = new Point(144, 85);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(125, 27);
            txtHeight.TabIndex = 5;
            txtHeight.TextChanged += txtHeight_TextChanged;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(144, 124);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(125, 27);
            txtAge.TabIndex = 6;
            txtAge.TextChanged += txtAge_TextChanged;
            // 
            // labelUserActivity
            // 
            labelUserActivity.AutoSize = true;
            labelUserActivity.Location = new Point(32, 180);
            labelUserActivity.Name = "labelUserActivity";
            labelUserActivity.Size = new Size(88, 20);
            labelUserActivity.TabIndex = 7;
            labelUserActivity.Text = "Активность";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(275, 48);
            label6.Name = "label6";
            label6.Size = new Size(22, 20);
            label6.TabIndex = 17;
            label6.Text = "кг";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(275, 88);
            label7.Name = "label7";
            label7.Size = new Size(27, 20);
            label7.TabIndex = 18;
            label7.Text = "см";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(275, 127);
            label8.Name = "label8";
            label8.Size = new Size(31, 20);
            label8.TabIndex = 19;
            label8.Text = "лет";
            // 
            // labelCat
            // 
            labelCat.AutoSize = true;
            labelCat.Location = new Point(404, 9);
            labelCat.Name = "labelCat";
            labelCat.Size = new Size(82, 20);
            labelCat.TabIndex = 20;
            labelCat.Text = "Категории";
            // 
            // comboCategories
            // 
            comboCategories.FormattingEnabled = true;
            comboCategories.Location = new Point(427, 48);
            comboCategories.Name = "comboCategories";
            comboCategories.Size = new Size(314, 28);
            comboCategories.TabIndex = 21;
            comboCategories.SelectedIndexChanged += comboCategories_SelectedIndexChanged;
            // 
            // labelProducts
            // 
            labelProducts.AutoSize = true;
            labelProducts.Location = new Point(404, 124);
            labelProducts.Name = "labelProducts";
            labelProducts.Size = new Size(77, 20);
            labelProducts.TabIndex = 22;
            labelProducts.Text = "Продукты";
            // 
            // listProducts
            // 
            listProducts.FormattingEnabled = true;
            listProducts.Location = new Point(427, 177);
            listProducts.Name = "listProducts";
            listProducts.Size = new Size(475, 224);
            listProducts.TabIndex = 23;
            listProducts.SelectedIndexChanged += listProducts_SelectedIndexChanged;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(427, 428);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 27);
            txtSearch.TabIndex = 24;
            txtSearch.Text = "поиск";
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(427, 479);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 25;
            btnSearch.Text = "Найти";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // labelRation
            // 
            labelRation.AutoSize = true;
            labelRation.Location = new Point(974, 9);
            labelRation.Name = "labelRation";
            labelRation.Size = new Size(61, 20);
            labelRation.TabIndex = 26;
            labelRation.Text = "Рацион";
            // 
            // listMeals
            // 
            listMeals.FormattingEnabled = true;
            listMeals.Location = new Point(974, 48);
            listMeals.Name = "listMeals";
            listMeals.Size = new Size(468, 104);
            listMeals.TabIndex = 27;
            listMeals.SelectedIndexChanged += listMeals_SelectedIndexChanged;
            // 
            // btnAddToMeal
            // 
            btnAddToMeal.Location = new Point(974, 195);
            btnAddToMeal.Name = "btnAddToMeal";
            btnAddToMeal.Size = new Size(197, 33);
            btnAddToMeal.TabIndex = 28;
            btnAddToMeal.Text = "Добавить в рацион";
            btnAddToMeal.UseVisualStyleBackColor = true;
            btnAddToMeal.Click += btnAddToMeal_Click;
            // 
            // labelNewWeight
            // 
            labelNewWeight.AutoSize = true;
            labelNewWeight.Location = new Point(974, 261);
            labelNewWeight.Name = "labelNewWeight";
            labelNewWeight.Size = new Size(84, 20);
            labelNewWeight.TabIndex = 29;
            labelNewWeight.Text = "Новый вес";
            // 
            // txtWeightUpdate
            // 
            txtWeightUpdate.Location = new Point(974, 303);
            txtWeightUpdate.Name = "txtWeightUpdate";
            txtWeightUpdate.Size = new Size(163, 27);
            txtWeightUpdate.TabIndex = 30;
            txtWeightUpdate.TextChanged += txtWeightUpdate_TextChanged;
            // 
            // btnUpdateWeight
            // 
            btnUpdateWeight.Location = new Point(974, 373);
            btnUpdateWeight.Name = "btnUpdateWeight";
            btnUpdateWeight.Size = new Size(183, 29);
            btnUpdateWeight.TabIndex = 31;
            btnUpdateWeight.Text = "Изменить вес";
            btnUpdateWeight.UseVisualStyleBackColor = true;
            btnUpdateWeight.Click += btnUpdateWeight_Click;
            // 
            // btnRemoveProduct
            // 
            btnRemoveProduct.Location = new Point(974, 428);
            btnRemoveProduct.Name = "btnRemoveProduct";
            btnRemoveProduct.Size = new Size(182, 29);
            btnRemoveProduct.TabIndex = 32;
            btnRemoveProduct.Text = "Удалить продукт";
            btnRemoveProduct.UseVisualStyleBackColor = true;
            btnRemoveProduct.Click += btnRemoveProduct_Click;
            // 
            // btnAddMeal
            // 
            btnAddMeal.Location = new Point(974, 482);
            btnAddMeal.Name = "btnAddMeal";
            btnAddMeal.Size = new Size(216, 29);
            btnAddMeal.TabIndex = 33;
            btnAddMeal.Text = "Новый приём пищи";
            btnAddMeal.UseVisualStyleBackColor = true;
            btnAddMeal.Click += btnAddMeal_Click;
            // 
            // btnRemoveMeal
            // 
            btnRemoveMeal.Location = new Point(974, 533);
            btnRemoveMeal.Name = "btnRemoveMeal";
            btnRemoveMeal.Size = new Size(216, 29);
            btnRemoveMeal.TabIndex = 34;
            btnRemoveMeal.Text = "Удалить приём пищи";
            btnRemoveMeal.UseVisualStyleBackColor = true;
            btnRemoveMeal.Click += btnRemoveMeal_Click;
            // 
            // comboActivity
            // 
            comboActivity.FormattingEnabled = true;
            comboActivity.Location = new Point(144, 177);
            comboActivity.Name = "comboActivity";
            comboActivity.Size = new Size(151, 28);
            comboActivity.TabIndex = 35;
            comboActivity.SelectedIndexChanged += comboActivity_SelectedIndexChanged;
            // 
            // btnCalc
            // 
            btnCalc.Location = new Point(32, 233);
            btnCalc.Name = "btnCalc";
            btnCalc.Size = new Size(94, 29);
            btnCalc.TabIndex = 36;
            btnCalc.Text = "Рассчитать";
            btnCalc.UseVisualStyleBackColor = true;
            btnCalc.Click += btnCalc_Click;
            // 
            // lblCalories
            // 
            lblCalories.AutoSize = true;
            lblCalories.Location = new Point(211, 237);
            lblCalories.Name = "lblCalories";
            lblCalories.Size = new Size(0, 20);
            lblCalories.TabIndex = 37;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(427, 597);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 38;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1454, 770);
            Controls.Add(btnSave);
            Controls.Add(lblCalories);
            Controls.Add(btnCalc);
            Controls.Add(comboActivity);
            Controls.Add(btnRemoveMeal);
            Controls.Add(btnAddMeal);
            Controls.Add(btnRemoveProduct);
            Controls.Add(btnUpdateWeight);
            Controls.Add(txtWeightUpdate);
            Controls.Add(labelNewWeight);
            Controls.Add(btnAddToMeal);
            Controls.Add(listMeals);
            Controls.Add(labelRation);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(listProducts);
            Controls.Add(labelProducts);
            Controls.Add(comboCategories);
            Controls.Add(labelCat);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(labelUserActivity);
            Controls.Add(txtAge);
            Controls.Add(txtHeight);
            Controls.Add(labelUserAge);
            Controls.Add(labelUserHeight);
            Controls.Add(labelUserWeight);
            Controls.Add(txtWeight);
            Controls.Add(UserInfo);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UserInfo;
        private TextBox txtWeight;
        private Label labelUserWeight;
        private Label labelUserHeight;
        private Label labelUserAge;
        private TextBox txtHeight;
        private TextBox txtAge;
        private Label labelUserActivity;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label labelCat;
        private ComboBox comboCategories;
        private Label labelProducts;
        private ListBox listProducts;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label labelRation;
        private ListBox listMeals;
        private Button btnAddToMeal;
        private Label labelNewWeight;
        private TextBox txtWeightUpdate;
        private Button btnUpdateWeight;
        private Button btnRemoveProduct;
        private Button btnAddMeal;
        private Button btnRemoveMeal;
        private ComboBox comboActivity;
        private Button btnCalc;
        private Label lblCalories;
        private Button btnSave;
    }
}
