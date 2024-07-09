namespace Test1
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.button_strength = new System.Windows.Forms.Button();
            this.button_intelligence = new System.Windows.Forms.Button();
            this.button_agility = new System.Windows.Forms.Button();
            this.label_log = new System.Windows.Forms.Label();
            this.Log_War = new System.Windows.Forms.RichTextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_rules = new System.Windows.Forms.Button();
            this.rtb_hp_gg = new System.Windows.Forms.RichTextBox();
            this.rtb_gg_lvl = new System.Windows.Forms.RichTextBox();
            this.rtb_monster_hp = new System.Windows.Forms.RichTextBox();
            this.rtb_monster_lvl = new System.Windows.Forms.RichTextBox();
            this.rtb_gold = new System.Windows.Forms.RichTextBox();
            this.rtb_exp = new System.Windows.Forms.RichTextBox();
            this.button_invent = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.rtb_name_monster = new System.Windows.Forms.RichTextBox();
            this.button_trade_buy = new System.Windows.Forms.Button();
            this.button_gonext = new System.Windows.Forms.Button();
            this.cb_sound = new System.Windows.Forms.CheckBox();
            this.button_trade_sell = new System.Windows.Forms.Button();
            this.cb_animation = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // button_strength
            // 
            this.button_strength.BackColor = System.Drawing.Color.DarkOrange;
            this.button_strength.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_strength.Location = new System.Drawing.Point(418, 360);
            this.button_strength.Name = "button_strength";
            this.button_strength.Size = new System.Drawing.Size(238, 38);
            this.button_strength.TabIndex = 3;
            this.button_strength.Text = "Удар топором (Сил)";
            this.button_strength.UseVisualStyleBackColor = false;
            this.button_strength.Click += new System.EventHandler(this.button_strength_Click);
            // 
            // button_intelligence
            // 
            this.button_intelligence.BackColor = System.Drawing.Color.DarkOrange;
            this.button_intelligence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_intelligence.Location = new System.Drawing.Point(418, 413);
            this.button_intelligence.Name = "button_intelligence";
            this.button_intelligence.Size = new System.Drawing.Size(238, 38);
            this.button_intelligence.TabIndex = 4;
            this.button_intelligence.Text = "Ударить заклинанием (Инт)";
            this.button_intelligence.UseVisualStyleBackColor = false;
            this.button_intelligence.Click += new System.EventHandler(this.Button_intelligence_Click);
            // 
            // button_agility
            // 
            this.button_agility.BackColor = System.Drawing.Color.DarkOrange;
            this.button_agility.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_agility.Location = new System.Drawing.Point(418, 466);
            this.button_agility.Name = "button_agility";
            this.button_agility.Size = new System.Drawing.Size(238, 38);
            this.button_agility.TabIndex = 5;
            this.button_agility.Text = "Кинуть ножи (Лов)";
            this.button_agility.UseVisualStyleBackColor = false;
            this.button_agility.Click += new System.EventHandler(this.Button_agility_Click);
            // 
            // label_log
            // 
            this.label_log.AutoSize = true;
            this.label_log.Location = new System.Drawing.Point(486, 20);
            this.label_log.Name = "label_log";
            this.label_log.Size = new System.Drawing.Size(99, 18);
            this.label_log.TabIndex = 6;
            this.label_log.Text = "Лог событий";
            // 
            // Log_War
            // 
            this.Log_War.BackColor = System.Drawing.Color.Silver;
            this.Log_War.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Log_War.Location = new System.Drawing.Point(388, 53);
            this.Log_War.Name = "Log_War";
            this.Log_War.ReadOnly = true;
            this.Log_War.Size = new System.Drawing.Size(301, 279);
            this.Log_War.TabIndex = 7;
            this.Log_War.Text = "";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(168, 20);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(61, 18);
            this.label_name.TabIndex = 8;
            this.label_name.Text = "Могрин";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Test1.Properties.Resources.гоблин;
            this.pictureBox2.Location = new System.Drawing.Point(739, 165);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(290, 370);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Test1.Properties.Resources.могрин;
            this.pictureBox1.Location = new System.Drawing.Point(47, 165);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(290, 370);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_rules
            // 
            this.btn_rules.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_rules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rules.Location = new System.Drawing.Point(489, 520);
            this.btn_rules.Name = "btn_rules";
            this.btn_rules.Size = new System.Drawing.Size(99, 32);
            this.btn_rules.TabIndex = 10;
            this.btn_rules.Text = "Правила";
            this.btn_rules.UseVisualStyleBackColor = false;
            this.btn_rules.Click += new System.EventHandler(this.Btn_rules_Click);
            // 
            // rtb_hp_gg
            // 
            this.rtb_hp_gg.BackColor = System.Drawing.SystemColors.Control;
            this.rtb_hp_gg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_hp_gg.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtb_hp_gg.Location = new System.Drawing.Point(47, 62);
            this.rtb_hp_gg.Name = "rtb_hp_gg";
            this.rtb_hp_gg.ReadOnly = true;
            this.rtb_hp_gg.Size = new System.Drawing.Size(155, 18);
            this.rtb_hp_gg.TabIndex = 15;
            this.rtb_hp_gg.Text = "Здоровье:";
            // 
            // rtb_gg_lvl
            // 
            this.rtb_gg_lvl.BackColor = System.Drawing.SystemColors.Control;
            this.rtb_gg_lvl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_gg_lvl.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtb_gg_lvl.Location = new System.Drawing.Point(57, 92);
            this.rtb_gg_lvl.Name = "rtb_gg_lvl";
            this.rtb_gg_lvl.ReadOnly = true;
            this.rtb_gg_lvl.Size = new System.Drawing.Size(155, 18);
            this.rtb_gg_lvl.TabIndex = 16;
            this.rtb_gg_lvl.Text = "Уровень:";
            // 
            // rtb_monster_hp
            // 
            this.rtb_monster_hp.BackColor = System.Drawing.SystemColors.Control;
            this.rtb_monster_hp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_monster_hp.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtb_monster_hp.Location = new System.Drawing.Point(736, 62);
            this.rtb_monster_hp.Name = "rtb_monster_hp";
            this.rtb_monster_hp.ReadOnly = true;
            this.rtb_monster_hp.Size = new System.Drawing.Size(293, 18);
            this.rtb_monster_hp.TabIndex = 17;
            this.rtb_monster_hp.Text = "Здоровье:";
            // 
            // rtb_monster_lvl
            // 
            this.rtb_monster_lvl.BackColor = System.Drawing.SystemColors.Control;
            this.rtb_monster_lvl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_monster_lvl.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtb_monster_lvl.Location = new System.Drawing.Point(746, 92);
            this.rtb_monster_lvl.Name = "rtb_monster_lvl";
            this.rtb_monster_lvl.ReadOnly = true;
            this.rtb_monster_lvl.Size = new System.Drawing.Size(283, 50);
            this.rtb_monster_lvl.TabIndex = 18;
            this.rtb_monster_lvl.Text = "Уровень:";
            // 
            // rtb_gold
            // 
            this.rtb_gold.BackColor = System.Drawing.SystemColors.Control;
            this.rtb_gold.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_gold.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtb_gold.Location = new System.Drawing.Point(208, 62);
            this.rtb_gold.Name = "rtb_gold";
            this.rtb_gold.ReadOnly = true;
            this.rtb_gold.Size = new System.Drawing.Size(168, 18);
            this.rtb_gold.TabIndex = 19;
            this.rtb_gold.Text = "Золото:";
            // 
            // rtb_exp
            // 
            this.rtb_exp.BackColor = System.Drawing.SystemColors.Control;
            this.rtb_exp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_exp.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtb_exp.Location = new System.Drawing.Point(221, 92);
            this.rtb_exp.Name = "rtb_exp";
            this.rtb_exp.ReadOnly = true;
            this.rtb_exp.Size = new System.Drawing.Size(155, 18);
            this.rtb_exp.TabIndex = 20;
            this.rtb_exp.Text = "Опыт:";
            // 
            // button_invent
            // 
            this.button_invent.BackColor = System.Drawing.Color.PowderBlue;
            this.button_invent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_invent.Location = new System.Drawing.Point(47, 119);
            this.button_invent.Name = "button_invent";
            this.button_invent.Size = new System.Drawing.Size(99, 32);
            this.button_invent.TabIndex = 21;
            this.button_invent.Text = "Инвентарь";
            this.button_invent.UseVisualStyleBackColor = false;
            this.button_invent.Click += new System.EventHandler(this.ButtonInvent_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Test1.Properties.Resources.отвар_силы;
            this.pictureBox3.Location = new System.Drawing.Point(4, 165);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(39, 41);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // rtb_name_monster
            // 
            this.rtb_name_monster.BackColor = System.Drawing.SystemColors.Control;
            this.rtb_name_monster.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_name_monster.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtb_name_monster.Location = new System.Drawing.Point(837, 20);
            this.rtb_name_monster.Name = "rtb_name_monster";
            this.rtb_name_monster.ReadOnly = true;
            this.rtb_name_monster.Size = new System.Drawing.Size(155, 18);
            this.rtb_name_monster.TabIndex = 23;
            this.rtb_name_monster.Text = "Лесной гоблин";
            // 
            // button_trade_buy
            // 
            this.button_trade_buy.BackColor = System.Drawing.Color.DarkOrange;
            this.button_trade_buy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_trade_buy.Location = new System.Drawing.Point(418, 360);
            this.button_trade_buy.Name = "button_trade_buy";
            this.button_trade_buy.Size = new System.Drawing.Size(238, 38);
            this.button_trade_buy.TabIndex = 24;
            this.button_trade_buy.Text = "Обыскать труп";
            this.button_trade_buy.UseVisualStyleBackColor = false;
            this.button_trade_buy.Visible = false;
            this.button_trade_buy.Click += new System.EventHandler(this.Button_trade_buy_Click);
            // 
            // button_gonext
            // 
            this.button_gonext.BackColor = System.Drawing.Color.DarkOrange;
            this.button_gonext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_gonext.Location = new System.Drawing.Point(418, 413);
            this.button_gonext.Name = "button_gonext";
            this.button_gonext.Size = new System.Drawing.Size(238, 38);
            this.button_gonext.TabIndex = 25;
            this.button_gonext.Text = "Пойти дальше";
            this.button_gonext.UseVisualStyleBackColor = false;
            this.button_gonext.Visible = false;
            this.button_gonext.Click += new System.EventHandler(this.Button_gonext_Click);
            // 
            // cb_sound
            // 
            this.cb_sound.AutoSize = true;
            this.cb_sound.Checked = true;
            this.cb_sound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_sound.Location = new System.Drawing.Point(9, 553);
            this.cb_sound.Name = "cb_sound";
            this.cb_sound.Size = new System.Drawing.Size(60, 22);
            this.cb_sound.TabIndex = 26;
            this.cb_sound.Text = "Звук";
            this.cb_sound.UseVisualStyleBackColor = true;
            // 
            // button_trade_sell
            // 
            this.button_trade_sell.BackColor = System.Drawing.Color.DarkOrange;
            this.button_trade_sell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_trade_sell.Location = new System.Drawing.Point(418, 413);
            this.button_trade_sell.Name = "button_trade_sell";
            this.button_trade_sell.Size = new System.Drawing.Size(238, 38);
            this.button_trade_sell.TabIndex = 27;
            this.button_trade_sell.Text = "Продать";
            this.button_trade_sell.UseVisualStyleBackColor = false;
            this.button_trade_sell.Visible = false;
            this.button_trade_sell.Click += new System.EventHandler(this.Button_trade_sell_Click);
            // 
            // cb_animation
            // 
            this.cb_animation.AutoSize = true;
            this.cb_animation.Checked = true;
            this.cb_animation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_animation.Location = new System.Drawing.Point(75, 553);
            this.cb_animation.Name = "cb_animation";
            this.cb_animation.Size = new System.Drawing.Size(100, 22);
            this.cb_animation.TabIndex = 28;
            this.cb_animation.Text = "Анимация";
            this.cb_animation.UseVisualStyleBackColor = true;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 578);
            this.Controls.Add(this.cb_animation);
            this.Controls.Add(this.cb_sound);
            this.Controls.Add(this.rtb_name_monster);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.button_invent);
            this.Controls.Add(this.rtb_exp);
            this.Controls.Add(this.rtb_gold);
            this.Controls.Add(this.rtb_monster_lvl);
            this.Controls.Add(this.rtb_monster_hp);
            this.Controls.Add(this.rtb_gg_lvl);
            this.Controls.Add(this.rtb_hp_gg);
            this.Controls.Add(this.btn_rules);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.Log_War);
            this.Controls.Add(this.label_log);
            this.Controls.Add(this.button_agility);
            this.Controls.Add(this.button_intelligence);
            this.Controls.Add(this.button_strength);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_trade_buy);
            this.Controls.Add(this.button_gonext);
            this.Controls.Add(this.button_trade_sell);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ЗАГ ЗАГ";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_log;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Button button_invent;
        public System.Windows.Forms.RichTextBox rtb_hp_gg;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.RichTextBox rtb_gold;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Button button_strength;
        public System.Windows.Forms.Button button_intelligence;
        public System.Windows.Forms.Button button_agility;
        public System.Windows.Forms.Button btn_rules;
        public System.Windows.Forms.RichTextBox rtb_gg_lvl;
        public System.Windows.Forms.RichTextBox rtb_monster_hp;
        public System.Windows.Forms.RichTextBox rtb_monster_lvl;
        public System.Windows.Forms.RichTextBox rtb_name_monster;
        public System.Windows.Forms.RichTextBox Log_War;
        public System.Windows.Forms.Button button_trade_buy;
        public System.Windows.Forms.Button button_gonext;
        public System.Windows.Forms.RichTextBox rtb_exp;
        public System.Windows.Forms.Button button_trade_sell;
        public System.Windows.Forms.CheckBox cb_animation;
        public System.Windows.Forms.CheckBox cb_sound;
    }
}

