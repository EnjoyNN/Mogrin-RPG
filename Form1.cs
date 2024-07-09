using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test1
{
    public partial class Form_Main : Form
    {

        public Random rnd = new Random();

        ProcedureClass cs = new ProcedureClass();

        public int goblin_choose = 0; //повышенный шанс гоблина выкинуть что-то
        public int strength_flaska = 0; //действие отвара силы
        public int dead_goblin_level; //передаем левел мертвого гоблина при обыске и дропе предметов и получении экспы

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {

            setBeginSettings();
            
            this.ActiveControl = label_log;

            if (Test1.Properties.Settings.Default.GG_HP == "" &&
                Test1.Properties.Settings.Default.GG_LVL == "" &&
                Test1.Properties.Settings.Default.MONSTER_LVL == "" &&
                Test1.Properties.Settings.Default.MONSTER_HP == "" &&
                Test1.Properties.Settings.Default.GG_EXP == "" &&
                Test1.Properties.Settings.Default.GG_GOLD == "")
            {
                setBeginSettings();
            }

            rtb_hp_gg.Clear();
            rtb_gg_lvl.Clear();
            rtb_monster_hp.Clear();
            rtb_monster_lvl.Clear();
            rtb_gold.Clear();
            rtb_exp.Clear();

            AppendColorText(rtb_hp_gg, Color.Black, "Здоровье: ");
            AppendColorText(rtb_hp_gg, Color.Red, Test1.Properties.Settings.Default.GG_HP);

            AppendColorText(rtb_monster_hp, Color.Black, "Здоровье: ");
            AppendColorText(rtb_monster_hp, Color.Red, Test1.Properties.Settings.Default.MONSTER_HP);

            AppendColorText(rtb_monster_lvl, Color.Black, "Уровень: ");
            AppendColorText(rtb_monster_lvl, Color.Blue, Test1.Properties.Settings.Default.MONSTER_LVL);

            AppendColorText(rtb_gg_lvl, Color.Black, "Уровень: ");
            AppendColorText(rtb_gg_lvl, Color.Blue, Test1.Properties.Settings.Default.GG_LVL);

            AppendColorText(rtb_gold, Color.Black, "Золото: ");
            AppendColorText(rtb_gold, Color.DarkGoldenrod, Test1.Properties.Settings.Default.GG_GOLD);

            AppendColorText(rtb_exp, Color.Black, "Опыт: ");
            AppendColorText(rtb_exp, Color.Blue, Test1.Properties.Settings.Default.GG_EXP);

        }

        private void Btn_rules_Click(object sender, EventArgs e)
        {
            Form_Rules FRules = new Form_Rules();
            DialogResult dr1 = FRules.ShowDialog();
        }

        private void button_strength_Click(object sender, EventArgs e)
        {
            int value = cs.CheckHighChance(this);

            if (value == 1)
            {
                //1 - это его оружие

                AppendColorText(Log_War, Color.White, "Ваш удар топором встретил гоблинский меч. Удар блокирован.\r\n");

                if (strength_flaska != 0)
                    strength_flaska += -1;

                Log_War.SelectionStart = Log_War.TextLength;
                Log_War.ScrollToCaret();

                cs.RandomEvent(this);

                Sound(Test1.Properties.Resources.промах);

                cs.Animation(2, new Image[] {
                   Test1.Properties.Resources.щитмога1, Test1.Properties.Resources.щит1,
                   Test1.Properties.Resources.щитмога2, Test1.Properties.Resources.щит2,
                   Test1.Properties.Resources.щитмога3, Test1.Properties.Resources.щит3,
                   Test1.Properties.Resources.щитмога4, Test1.Properties.Resources.щит4,
                   Test1.Properties.Resources.щитмога5, Test1.Properties.Resources.щит5,
                   Test1.Properties.Resources.щитмога6, Test1.Properties.Resources.щит6,
                   Test1.Properties.Resources.щитмога6, Test1.Properties.Resources.щит6,
                   Test1.Properties.Resources.щитмога6, Test1.Properties.Resources.щит6,
                   Test1.Properties.Resources.щитмога6, Test1.Properties.Resources.щит6,
                   Test1.Properties.Resources.могрин, Test1.Properties.Resources.гоблин}, new PictureBox[] { pictureBox1, pictureBox2 }, this);

            }
            else if (value == 2)
            {
                //2 - это его спелл

                int health = Convert.ToInt32(Test1.Properties.Settings.Default.GG_HP.Split('/')[0]) - 1;
                Test1.Properties.Settings.Default.GG_HP = health.ToString() + "/" + Test1.Properties.Settings.Default.GG_HP.Split('/')[1];
                Test1.Properties.Settings.Default.Save();

                if (strength_flaska != 0)
                    strength_flaska += -1;

                rtb_hp_gg.Clear();
                AppendColorText(rtb_hp_gg, Color.Black, "Здоровье: ");
                AppendColorText(rtb_hp_gg, Color.Red, Test1.Properties.Settings.Default.GG_HP);

                AppendColorText(Log_War, Color.Red, "Вы не успеваете ударить, как гоблин кастует заклинание огненной стрелы в вас.\r\n");

                Log_War.SelectionStart = Log_War.TextLength;
                Log_War.ScrollToCaret();

                cs.RandomEvent(this);

                Sound(Test1.Properties.Resources.огненный_шар);

                cs.Animation(1, new Image[] {
                   Test1.Properties.Resources.шар1, Test1.Properties.Resources.шар2,
                   Test1.Properties.Resources.шар3, Test1.Properties.Resources.шар4,
                   Test1.Properties.Resources.шар5, Test1.Properties.Resources.шар4,
                   Test1.Properties.Resources.шар3, Test1.Properties.Resources.шар2,
                   Test1.Properties.Resources.шар1, Test1.Properties.Resources.могрин}, new PictureBox[] { pictureBox1 }, this);

            }
            else if (value == 3)
            {
                //3 - это его метательное

                int health;
                if (strength_flaska != 0)
                {
                    strength_flaska += -1;
                    health = Convert.ToInt32(Test1.Properties.Settings.Default.MONSTER_HP.Split('/')[0]) - 2;
                }
                else
                {
                    health = Convert.ToInt32(Test1.Properties.Settings.Default.MONSTER_HP.Split('/')[0]) - 1;
                }
                Test1.Properties.Settings.Default.MONSTER_HP = health.ToString() + "/" + Test1.Properties.Settings.Default.MONSTER_HP.Split('/')[1];
                Test1.Properties.Settings.Default.Save();

                rtb_monster_hp.Clear();
                AppendColorText(rtb_monster_hp, Color.Black, "Здоровье: ");
                AppendColorText(rtb_monster_hp, Color.Red, Test1.Properties.Settings.Default.MONSTER_HP);

                AppendColorText(Log_War, Color.ForestGreen, "Гоблин попытался бросить ножи, но вы успеваете ударить его своим топором.\r\n");

                Log_War.SelectionStart = Log_War.TextLength;
                Log_War.ScrollToCaret();

                cs.RandomEvent(this);

                Sound(Test1.Properties.Resources.удар_топором);

                cs.Animation(1, new Image[] {
                   Test1.Properties.Resources.топор1, Test1.Properties.Resources.топор2,
                   Test1.Properties.Resources.топор3, Test1.Properties.Resources.топор4,
                   Test1.Properties.Resources.топор5, Test1.Properties.Resources.топор4,
                   Test1.Properties.Resources.топор3, Test1.Properties.Resources.топор2,
                   Test1.Properties.Resources.топор1, Test1.Properties.Resources.гоблин}, new PictureBox[] { pictureBox2 }, this);

            }

            //проверка на убили ли гоба или героя последним ударом
            cs.CheckDeathUnit(this);

            //заодно проверяем, работает ли фласка на силу
            CheckStrengthFlaska();
        }

        private void Button_intelligence_Click(object sender, EventArgs e)
        {
            int value = cs.CheckHighChance(this);

            if (value == 1)
            {
                //1 - это его оружие

                int health;
                if (strength_flaska != 0)
                {
                    strength_flaska += -1;
                    health = Convert.ToInt32(Test1.Properties.Settings.Default.MONSTER_HP.Split('/')[0]) - 2;
                }
                else
                {
                    health = Convert.ToInt32(Test1.Properties.Settings.Default.MONSTER_HP.Split('/')[0]) - 1;
                }
                Test1.Properties.Settings.Default.MONSTER_HP = health.ToString() + "/" + Test1.Properties.Settings.Default.MONSTER_HP.Split('/')[1];
                Test1.Properties.Settings.Default.Save();

                rtb_monster_hp.Clear();
                AppendColorText(rtb_monster_hp, Color.Black, "Здоровье: ");
                AppendColorText(rtb_monster_hp, Color.Red, Test1.Properties.Settings.Default.MONSTER_HP);

                AppendColorText(Log_War, Color.ForestGreen, "Вы используете удар молнии в противника, который пытался замахнуться на вас мечом.\r\n");

                Log_War.SelectionStart = Log_War.TextLength;
                Log_War.ScrollToCaret();

                cs.RandomEvent(this);

                Sound(Test1.Properties.Resources.молния);

                //попытка сделать анимацию по картинкам. всех картинки потом нужно будет оптимизировать на вес
                cs.Animation(1, new Image[] {
                   Test1.Properties.Resources.молния1, Test1.Properties.Resources.молния2,
                   Test1.Properties.Resources.молния3, Test1.Properties.Resources.молния4,
                   Test1.Properties.Resources.молния5, Test1.Properties.Resources.молния4,
                   Test1.Properties.Resources.молния3, Test1.Properties.Resources.молния2,
                   Test1.Properties.Resources.молния1, Test1.Properties.Resources.гоблин}, new PictureBox[] { pictureBox2 }, this);

            }
            else if (value == 2)
            {
                //2 - это его спелл

                AppendColorText(Log_War, Color.White, "Вы кастуете заклинание, пытаясь нанести урон, но оно лишь поглощается ответным заклинанием противника.\r\n");

                Log_War.SelectionStart = Log_War.TextLength;
                Log_War.ScrollToCaret();

                cs.RandomEvent(this);

                if (strength_flaska != 0)
                    strength_flaska += -1;

                Sound(Test1.Properties.Resources.промах);

                cs.Animation(2, new Image[] {
                   Test1.Properties.Resources.щитмога1, Test1.Properties.Resources.щит1,
                   Test1.Properties.Resources.щитмога2, Test1.Properties.Resources.щит2,
                   Test1.Properties.Resources.щитмога3, Test1.Properties.Resources.щит3,
                   Test1.Properties.Resources.щитмога4, Test1.Properties.Resources.щит4,
                   Test1.Properties.Resources.щитмога5, Test1.Properties.Resources.щит5,
                   Test1.Properties.Resources.щитмога6, Test1.Properties.Resources.щит6,
                   Test1.Properties.Resources.щитмога6, Test1.Properties.Resources.щит6,
                   Test1.Properties.Resources.щитмога6, Test1.Properties.Resources.щит6,
                   Test1.Properties.Resources.щитмога6, Test1.Properties.Resources.щит6,
                   Test1.Properties.Resources.могрин, Test1.Properties.Resources.гоблин}, new PictureBox[] { pictureBox1, pictureBox2 }, this);

            }
            else if (value == 3)
            {
                //3 - это его метательное

                int health = Convert.ToInt32(Test1.Properties.Settings.Default.GG_HP.Split('/')[0]) - 1;
                Test1.Properties.Settings.Default.GG_HP = health.ToString() + "/" + Test1.Properties.Settings.Default.GG_HP.Split('/')[1];
                Test1.Properties.Settings.Default.Save();

                rtb_hp_gg.Clear();
                AppendColorText(rtb_hp_gg, Color.Black, "Здоровье: ");
                AppendColorText(rtb_hp_gg, Color.Red, Test1.Properties.Settings.Default.GG_HP);

                AppendColorText(Log_War, Color.Red, "Гоблин броском ножей успевает сбить ваш каст заклинания и наносит вам урон.\r\n");

                if (strength_flaska != 0)
                    strength_flaska += -1;

                Log_War.SelectionStart = Log_War.TextLength;
                Log_War.ScrollToCaret();

                cs.RandomEvent(this);

                Sound(Test1.Properties.Resources.мет_ножи_гоба);

                cs.Animation(1, new Image[] {
                   Test1.Properties.Resources.ножигоба1, Test1.Properties.Resources.ножигоба2,
                   Test1.Properties.Resources.ножигоба3, Test1.Properties.Resources.ножигоба4,
                   Test1.Properties.Resources.ножигоба5, Test1.Properties.Resources.ножигоба4,
                   Test1.Properties.Resources.ножигоба3, Test1.Properties.Resources.ножигоба2,
                   Test1.Properties.Resources.ножигоба1, Test1.Properties.Resources.могрин}, new PictureBox[] { pictureBox1 }, this);

            }

            cs.CheckDeathUnit(this);

            //заодно проверяем, работает ли фласка на силу
            CheckStrengthFlaska();

        }

        private void Button_agility_Click(object sender, EventArgs e)
        {
            int value = cs.CheckHighChance(this);

            if (value == 1)
            {
                //1 - это его оружие

                int health = Convert.ToInt32(Test1.Properties.Settings.Default.GG_HP.Split('/')[0]) - 1;
                Test1.Properties.Settings.Default.GG_HP = health.ToString() + "/" + Test1.Properties.Settings.Default.GG_HP.Split('/')[1];
                Test1.Properties.Settings.Default.Save();

                rtb_hp_gg.Clear();
                AppendColorText(rtb_hp_gg, Color.Black, "Здоровье: ");
                AppendColorText(rtb_hp_gg, Color.Red, Test1.Properties.Settings.Default.GG_HP);

                AppendColorText(Log_War, Color.Red, "Вы решаете кинуть ножи в гоблина, но получаете неприятный удар мечом.\r\n");

                if (strength_flaska != 0)
                    strength_flaska += -1;

                Log_War.SelectionStart = Log_War.TextLength;
                Log_War.ScrollToCaret();

                cs.RandomEvent(this);

                Sound(Test1.Properties.Resources.меч);

                cs.Animation(1, new Image[] {
                   Test1.Properties.Resources.мечгоба1, Test1.Properties.Resources.мечгоба2,
                   Test1.Properties.Resources.мечгоба3, Test1.Properties.Resources.мечгоба4,
                   Test1.Properties.Resources.мечгоба5, Test1.Properties.Resources.мечгоба4,
                   Test1.Properties.Resources.мечгоба3, Test1.Properties.Resources.мечгоба2,
                   Test1.Properties.Resources.мечгоба1, Test1.Properties.Resources.могрин}, new PictureBox[] { pictureBox1 }, this);

            }
            else if (value == 2)
            {
                //2 - это его спелл

                int health;
                if (strength_flaska != 0)
                {
                    strength_flaska += -1;
                    health = Convert.ToInt32(Test1.Properties.Settings.Default.MONSTER_HP.Split('/')[0]) - 2;
                }
                else
                {
                    health = Convert.ToInt32(Test1.Properties.Settings.Default.MONSTER_HP.Split('/')[0]) - 1;
                }

                Test1.Properties.Settings.Default.MONSTER_HP = health.ToString() + "/" + Test1.Properties.Settings.Default.MONSTER_HP.Split('/')[1];
                Test1.Properties.Settings.Default.Save();

                rtb_monster_hp.Clear();
                AppendColorText(rtb_monster_hp, Color.Black, "Здоровье: ");
                AppendColorText(rtb_monster_hp, Color.Red, Test1.Properties.Settings.Default.MONSTER_HP);

                AppendColorText(Log_War, Color.ForestGreen, "Быстрым броском ножа вы сбиваете попытку кинуть в вас огненную стрелу и наносите урон.\r\n");

                Log_War.SelectionStart = Log_War.TextLength;
                Log_War.ScrollToCaret();

                cs.RandomEvent(this);

                Sound(Test1.Properties.Resources.ножи_орка);

                cs.Animation(1, new Image[] {
                   Test1.Properties.Resources.ножи1, Test1.Properties.Resources.ножи2,
                   Test1.Properties.Resources.ножи3, Test1.Properties.Resources.ножи4,
                   Test1.Properties.Resources.ножи5, Test1.Properties.Resources.ножи4,
                   Test1.Properties.Resources.ножи3, Test1.Properties.Resources.ножи2,
                   Test1.Properties.Resources.ножи1, Test1.Properties.Resources.гоблин}, new PictureBox[] { pictureBox2 }, this);

            }
            else if (value == 3)
            {
                //3 - это его метательное


                AppendColorText(Log_War, Color.White, "Вы ловко бросаете ножи, и ваш противник отвечает тем же. Вы оба уворачиваетесь от летящих лезвий.\r\n");

                if (strength_flaska != 0)
                    strength_flaska += -1;

                Log_War.SelectionStart = Log_War.TextLength;
                Log_War.ScrollToCaret();

                cs.RandomEvent(this);

                Sound(Test1.Properties.Resources.промах);

                cs.Animation(2, new Image[] {
                   Test1.Properties.Resources.щитмога1, Test1.Properties.Resources.щит1,
                   Test1.Properties.Resources.щитмога2, Test1.Properties.Resources.щит2,
                   Test1.Properties.Resources.щитмога3, Test1.Properties.Resources.щит3,
                   Test1.Properties.Resources.щитмога4, Test1.Properties.Resources.щит4,
                   Test1.Properties.Resources.щитмога5, Test1.Properties.Resources.щит5,
                   Test1.Properties.Resources.щитмога6, Test1.Properties.Resources.щит6,
                   Test1.Properties.Resources.щитмога6, Test1.Properties.Resources.щит6,
                   Test1.Properties.Resources.щитмога6, Test1.Properties.Resources.щит6,
                   Test1.Properties.Resources.щитмога6, Test1.Properties.Resources.щит6,
                   Test1.Properties.Resources.могрин, Test1.Properties.Resources.гоблин}, new PictureBox[] { pictureBox1, pictureBox2 }, this);

            }


            cs.CheckDeathUnit(this);

            //заодно проверяем, работает ли фласка на силу
            CheckStrengthFlaska();

        }


        private void Button_gonext_Click(object sender, EventArgs e)
        {
            if (Test1.Properties.Settings.Default.GG_LVL == "1")
            {
                int value = 1;
                cs.GenerateNewMonster(value.ToString(), this);
            }
            else if (Test1.Properties.Settings.Default.GG_LVL == "2")
            {
                int value = rnd.Next(1, 3);
                cs.GenerateNewMonster(value.ToString(), this);
            }
            else if (Test1.Properties.Settings.Default.GG_LVL == "3")
            {
                int value = rnd.Next(1, 5);
                cs.GenerateNewMonster(value.ToString(), this);
            }
            else if (Test1.Properties.Settings.Default.GG_LVL == "4")
            {
                int value = rnd.Next(1, 6);
                cs.GenerateNewMonster(value.ToString(), this);
            }
            else if (Test1.Properties.Settings.Default.GG_LVL == "5")
            {
                int value = rnd.Next(1, 6);
                cs.GenerateNewMonster(value.ToString(), this);
            }
        }


        private void ButtonInvent_Click(object sender, EventArgs e)
        {
            Form_Invent FInvent = new Form_Invent(this, "Могрин"); //передали ссылку на эту форму в форму инвента
            DialogResult dr1 = FInvent.ShowDialog();
        }



        private void Button_trade_buy_Click(object sender, EventArgs e)
        {
            if (button_trade_buy.Text == "Обыскать труп")
            {
                Form_Invent FInvent = new Form_Invent(this, "Гоблин" + " " + dead_goblin_level);
                DialogResult dr1 = FInvent.ShowDialog();
                button_trade_buy.Text = "Пойти к торговцу";

            }
            else if (button_trade_buy.Text == "Пойти к торговцу")
            {
                pictureBox2.Image = Test1.Properties.Resources.торговец;
                rtb_name_monster.Text = "Торговец Ахмед";
                rtb_monster_lvl.Text = "Странствующий торговец предлагает вам свои товары";
                AppendColorText(Log_War, Color.Blue, "Торговец Ахмед жестом приветствует вас. Здесь вы можете продать ненужный хлам и прикупить на что-то ценное.\r\n");

                button_gonext.Location =  new System.Drawing.Point(418,466);

                button_trade_buy.Text = "Купить";
                button_trade_sell.Text = "Продать";
                button_trade_sell.Visible = true;
            }
            else if (button_trade_buy.Text == "Купить")
            {
                Form_Invent FInvent = new Form_Invent(this, "Купить Торговец");
                DialogResult dr1 = FInvent.ShowDialog();
            }
            else if (button_trade_buy.Text == "Начать заново")
            {
                Application.Restart();
            }
        }


        public void setPictureAfterStrengthFlaska()
        {
            pictureBox3.Image = Test1.Properties.Resources.отвар_силы;
            pictureBox3.Visible = true;
            Refresh();
        }

        public void setHealthAfterFlaska() 
        {
            rtb_hp_gg.Clear();

            AppendColorText(rtb_hp_gg, Color.Black, "Здоровье: ");
            AppendColorText(rtb_hp_gg, Color.Red, Test1.Properties.Settings.Default.GG_HP);
        }

        public void AppendColorText(RichTextBox rich, Color color, string s)
        {
            string appendtext = s;
            int length = rich.TextLength;
            rich.AppendText(appendtext);
            rich.SelectionStart = length;
            rich.SelectionLength = appendtext.Length;
            rich.SelectionColor = color;
        }

        public void CheckStrengthFlaska()
        {
            if (strength_flaska == 0)
            {
                pictureBox3.Visible = false;
                Refresh();
            }
        }



        public void setBeginSettings()
        {
            Test1.Properties.Settings.Default.GG_HP = "50/50";
            Test1.Properties.Settings.Default.GG_LVL = "1";
            Test1.Properties.Settings.Default.GG_EXP = "0/100";
            Test1.Properties.Settings.Default.GG_GOLD = "0";
            Test1.Properties.Settings.Default.MONSTER_LVL = "1";
            Test1.Properties.Settings.Default.MONSTER_HP = "15/15";

            Test1.Properties.Settings.Default.GG_MESSAGEQUEST = "1";
            Test1.Properties.Settings.Default.GG_GOBLINSWORD = "0";
            Test1.Properties.Settings.Default.GG_FLASKA = "1";
            Test1.Properties.Settings.Default.GG_ATTACK_FLASKA = "0";

            Test1.Properties.Settings.Default.Save();
        }

        public void Sound(System.IO.UnmanagedMemoryStream sound_resources)
        {
            if (cb_sound.Checked)
            {
                SoundPlayer Sound = new SoundPlayer(sound_resources);
                Sound.Play();
            }
        }

        private void Button_trade_sell_Click(object sender, EventArgs e)
        {
            if (button_trade_sell.Text == "Продать")
            {
                Form_Invent FInvent = new Form_Invent(this, "Продать Торговец");
                DialogResult dr1 = FInvent.ShowDialog();
            }
        }

        //повышенный шанс на удар это 50% вместо 33.
    }
}
