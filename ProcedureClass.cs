using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test1
{
    public class ProcedureClass
    {

        //этот класс создан только для того чтобы сюда загрузить большие процедурки и вызывать их из разных форм.кс, чтобы код там был поменьше лул
        public void CheckDeathUnit(Form_Main fm)
        {
            //проверка на убили ли гоба последним ударом
            if (Convert.ToInt32(Test1.Properties.Settings.Default.MONSTER_HP.Split('/')[0]) <= 0)
            {
                fm.pictureBox2.Image = Test1.Properties.Resources.череп;
                fm.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

                fm.button_agility.Visible = false;
                fm.button_intelligence.Visible = false;
                fm.button_strength.Visible = false;

                fm.rtb_monster_hp.Text = "";
                fm.rtb_name_monster.Text = "Мертвый гоблин";

                //очищаем логи событий после убийства гоблоты
                fm.Log_War.Clear();

                fm.AppendColorText(fm.Log_War, Color.Blue, "Гоблин повержен. Вы можете обыскать его труп.\r\n");
                fm.Log_War.SelectionStart = fm.Log_War.TextLength;
                fm.Log_War.ScrollToCaret();

                fm.button_gonext.Location = new System.Drawing.Point(418, 413);
                fm.button_gonext.Visible = true;
                fm.button_trade_buy.Visible = true;

                fm.button_trade_buy.Text = "Обыскать труп";

                fm.dead_goblin_level = Convert.ToInt32(Test1.Properties.Settings.Default.MONSTER_LVL);


                GiveExp(fm);
            }

            //проверка на умер ли главный герой последним ударом
            else if (Convert.ToInt32(Test1.Properties.Settings.Default.GG_HP.Split('/')[0]) <= 0)
            {
                fm.pictureBox1.Image = Test1.Properties.Resources.череп;
                fm.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                fm.AppendColorText(fm.Log_War, Color.Red, "Могрин погиб. Он так и не смог завершить свою миссию...\r\n");
                fm.Log_War.SelectionStart = fm.Log_War.TextLength;
                fm.Log_War.ScrollToCaret();

                fm.Enabled = false;

                fm.button_agility.Visible = false;
                fm.button_intelligence.Visible = false;
                fm.button_strength.Visible = false;

                fm.button_trade_buy.Visible = true;

                fm.button_trade_buy.Text = "Начать заново";
            }
        }




        public void RandomEvent(Form_Main fm)

        {
            if (Convert.ToInt32(Test1.Properties.Settings.Default.MONSTER_HP.Split('/')[0]) > 0)
            {
                int value = fm.rnd.Next(1, 101);

                if (value < 11)
                {
                    value = fm.rnd.Next(1, 4);

                    if (value == 1)
                    {
                        fm.AppendColorText(fm.Log_War, Color.Blue, "Вы замечаете как гоблин готовит удар мечом по вам (повышен шанс удара мечом от противника).\r\n");

                        fm.Log_War.SelectionStart = fm.Log_War.TextLength;
                        fm.Log_War.ScrollToCaret();

                        fm.goblin_choose = 1;
                    }
                    else if (value == 2)
                    {
                        fm.AppendColorText(fm.Log_War, Color.Blue, "Вы замечаете как гоблин готовит удар огненной стрелой по вам (повышен шанс удара магией от противника).\r\n");

                        fm.Log_War.SelectionStart = fm.Log_War.TextLength;
                        fm.Log_War.ScrollToCaret();

                        fm.goblin_choose = 2;
                    }
                    else if (value == 3)
                    {
                        fm.AppendColorText(fm.Log_War, Color.Blue, "Вы замечаете как гоблин готовит метательные ножи по вам (повышен шанс удара метательным оружием от противника).\r\n");

                        fm.Log_War.SelectionStart = fm.Log_War.TextLength;
                        fm.Log_War.ScrollToCaret();

                        fm.goblin_choose = 3;
                    }
                }
            }
        }




        public void GenerateNewMonster(string lvl_monster, Form_Main fm)
        {
            if (lvl_monster == "1")
            {
                Test1.Properties.Settings.Default.MONSTER_LVL = "1";
                Test1.Properties.Settings.Default.MONSTER_HP = "15/15";
            }
            else if (lvl_monster == "2")
            {
                Test1.Properties.Settings.Default.MONSTER_LVL = "2";
                Test1.Properties.Settings.Default.MONSTER_HP = "20/20";
            }
            else if (lvl_monster == "3")
            {
                Test1.Properties.Settings.Default.MONSTER_LVL = "3";
                Test1.Properties.Settings.Default.MONSTER_HP = "35/35";
            }
            else if (lvl_monster == "4")
            {
                Test1.Properties.Settings.Default.MONSTER_LVL = "4";
                Test1.Properties.Settings.Default.MONSTER_HP = "45/45";
            }
            else if (lvl_monster == "5")
            {
                Test1.Properties.Settings.Default.MONSTER_LVL = "5";
                Test1.Properties.Settings.Default.MONSTER_HP = "60/60";
            }

            fm.rtb_monster_hp.Clear();
            fm.rtb_monster_lvl.Clear();

            fm.AppendColorText(fm.rtb_monster_hp, Color.Black, "Здоровье: ");
            fm.AppendColorText(fm.rtb_monster_hp, Color.Red, Test1.Properties.Settings.Default.MONSTER_HP);

            fm.AppendColorText(fm.rtb_monster_lvl, Color.Black, "Уровень: ");
            fm.AppendColorText(fm.rtb_monster_lvl, Color.Blue, Test1.Properties.Settings.Default.MONSTER_LVL);

            fm.pictureBox2.Image = Test1.Properties.Resources.гоблин;
            fm.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            fm.button_agility.Visible = true;
            fm.button_intelligence.Visible = true;
            fm.button_strength.Visible = true;

            fm.button_gonext.Visible = false;
            fm.button_trade_buy.Visible = false;
            fm.button_trade_sell.Visible = false;

            fm.rtb_name_monster.Text = "Лесной гоблин";

            fm.AppendColorText(fm.Log_War, Color.Blue, "На пути вам встречается новый враг. Это - " + fm.rtb_name_monster.Text + ".\r\n");
            fm.Log_War.SelectionStart = fm.Log_War.TextLength;
            fm.Log_War.ScrollToCaret();
        }


 


        public void GiveExp(Form_Main fm)
        {
            if (Test1.Properties.Settings.Default.GG_EXP != "Максимальный уровень")
            {
                int exp = 0;
                if (fm.dead_goblin_level == 1)
                    exp = 25;
                else if (fm.dead_goblin_level == 2)
                    exp = 50;
                else if (fm.dead_goblin_level == 3)
                    exp = 75;
                else if (fm.dead_goblin_level == 4)
                    exp = 100;
                else if (fm.dead_goblin_level == 5)
                    exp = 125;

                int exp_with_nowexp = Convert.ToInt32(Test1.Properties.Settings.Default.GG_EXP.Split('/')[0]) + exp;

                if (exp_with_nowexp >= Convert.ToInt32(Test1.Properties.Settings.Default.GG_EXP.Split('/')[1]))
                {
                    fm.Sound(Test1.Properties.Resources.левел);

                    Test1.Properties.Settings.Default.GG_LVL = (Convert.ToInt32(Test1.Properties.Settings.Default.GG_LVL) + 1).ToString();
                    Test1.Properties.Settings.Default.Save();

                    if (Test1.Properties.Settings.Default.GG_LVL == "2")
                    {
                        Test1.Properties.Settings.Default.GG_EXP = (exp_with_nowexp - Convert.ToInt32(Test1.Properties.Settings.Default.GG_EXP.Split('/')[1])).ToString() + "/" + "500";
                        Test1.Properties.Settings.Default.GG_HP = "55/55";
                    }
                    else if (Test1.Properties.Settings.Default.GG_LVL == "3")
                    {
                        Test1.Properties.Settings.Default.GG_EXP = (exp_with_nowexp - Convert.ToInt32(Test1.Properties.Settings.Default.GG_EXP.Split('/')[1])).ToString() + "/" + "1000";
                        Test1.Properties.Settings.Default.GG_HP = "65/65";
                    }
                    else if (Test1.Properties.Settings.Default.GG_LVL == "4")
                    {
                        Test1.Properties.Settings.Default.GG_EXP = (exp_with_nowexp - Convert.ToInt32(Test1.Properties.Settings.Default.GG_EXP.Split('/')[1])).ToString() + "/" + "3000";
                        Test1.Properties.Settings.Default.GG_HP = "75/75";
                    }
                    else if (Test1.Properties.Settings.Default.GG_LVL == "5")
                    {
                        Test1.Properties.Settings.Default.GG_EXP = "Максимальный уровень";
                        Test1.Properties.Settings.Default.GG_HP = "90/90";
                    }

                    Test1.Properties.Settings.Default.Save();

                    fm.rtb_gg_lvl.Clear();
                    fm.rtb_exp.Clear();
                    fm.rtb_hp_gg.Clear();

                    fm.AppendColorText(fm.rtb_gg_lvl, Color.Black, "Уровень: ");
                    fm.AppendColorText(fm.rtb_gg_lvl, Color.Blue, Test1.Properties.Settings.Default.GG_LVL);

                    fm.AppendColorText(fm.rtb_exp, Color.Black, "Опыт: ");
                    fm.AppendColorText(fm.rtb_exp, Color.Blue, Test1.Properties.Settings.Default.GG_EXP);

                    fm.AppendColorText(fm.rtb_hp_gg, Color.Black, "Здоровье: ");
                    fm.AppendColorText(fm.rtb_hp_gg, Color.Red, Test1.Properties.Settings.Default.GG_HP);

                    //тут новый левел
                }
                else
                {
                    Test1.Properties.Settings.Default.GG_EXP = exp_with_nowexp + "/" + Test1.Properties.Settings.Default.GG_EXP.Split('/')[1];
                    Test1.Properties.Settings.Default.Save();

                    fm.rtb_exp.Clear();

                    fm.AppendColorText(fm.rtb_exp, Color.Black, "Опыт: ");
                    fm.AppendColorText(fm.rtb_exp, Color.Red, Test1.Properties.Settings.Default.GG_EXP);
                }
            }
        }





        public int CheckHighChance(Form_Main fm)
        {
            int value;

            //делаем проверку на повышенный шанс
            if (fm.goblin_choose == 0)
                value = fm.rnd.Next(1, 4);
            else
            {
                value = fm.rnd.Next(1, 5);
                if (value == 1 || value == 2)
                {
                    if (fm.goblin_choose == 1)
                    {
                        value = 1;
                        fm.goblin_choose = 0;
                    }
                    else if (fm.goblin_choose == 2)
                    {
                        value = 2;
                        fm.goblin_choose = 0;
                    }

                    else if (fm.goblin_choose == 3)
                    {
                        value = 3;
                        fm.goblin_choose = 0;
                    }
                }
            }

            return value;
        }





        public void LoadItemInDataGrid(string name, string count, string use, Form_Invent fi)
        {
            if (name == "Фласка")
            {
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[0].Value = Test1.Properties.Resources.фласка;
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[1].Value = "Фласка";
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[2].Value = "Целебное зелье, мгновенно прибавляющее 20 к здоровью.";
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[3].Value = count;
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[4].Value = use;
            }
            else if (name == "Отвар силы")
            {
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[0].Value = Test1.Properties.Resources.отвар_силы;
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[1].Value = "Отвар силы";
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[2].Value = "Отвар, увеличивающий урон до 2 на 10 ходов.";
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[3].Value = count;
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[4].Value = use;
            }
            else if (name == "Меч гоблина")
            {
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[0].Value = Test1.Properties.Resources.меч_гоблина;
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[1].Value = "Меч гоблина";
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[2].Value = "Меч одного из гоблинов, по виду довольно ржавый.";
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[3].Value = count;
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[4].Value = use;
            }
            else if (name == "Золото")
            {
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[0].Value = Test1.Properties.Resources.золото;
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[1].Value = "Золото";
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[2].Value = "Звеняющая, золотая монета.";
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[3].Value = count;
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[4].Value = use;
            }
            else if (name == "Донесение")
            {
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[0].Value = Test1.Properties.Resources.донесение;
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[1].Value = "Донесение";
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[2].Value = "Важное донесение вождю племени.";
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[3].Value = count;
                fi.DG_Invent.Rows[fi.DG_Invent.RowCount - 1].Cells[4].Value = use;
            }
        }






        //ниже метод по генерации случайных шмоток в трупах, передаем ему только вероятности, он генерит и возвращает что сгенерилось
        public List<string> GenerateRandomShmot(List<string> chance_shmot, List<string> name_shmot, Form_Invent fi)
        {
            List<string> listshmot = new List<string>();
            int value;
            string count_item;

            //делаем цикл для каждого вида шмотки, что передали
            for (int i = 0; i < chance_shmot.Count; i++)
            {
                value = fi.rnd.Next(1, 101);
                //делаем цикл на случай если у одной шмотки несколько веротностей выпадения ее по количеству
                for (int j = 0; j < chance_shmot[i].Split(' ').Length / 2; j++)
                {
                    //делаем проверку на случайно генерируемые значения количества предмета
                    if (chance_shmot[i].Split(' ')[Convert.ToInt32(chance_shmot[i].Split(' ').Length / 2 + j)].Contains("-"))
                    {
                        count_item = fi.rnd.Next(Convert.ToInt32(chance_shmot[i].Split(' ')[Convert.ToInt32(chance_shmot[i].Split(' ').Length / 2 + j)].Split('-')[0]), Convert.ToInt32(chance_shmot[i].Split(' ')[Convert.ToInt32(chance_shmot[i].Split(' ').Length / 2 + j)].Split('-')[1]) + 1).ToString();
                    }
                    else
                    {
                        count_item = chance_shmot[i].Split(' ')[Convert.ToInt32(chance_shmot[i].Split(' ').Length / 2 + j)];
                    }

                    if (value <= Convert.ToInt32(chance_shmot[i].Split(' ')[j]))
                    {
                        //вероятность считается по возрастанию (5% 10 50..) остальные цифры в передаваемом это количество этого что должно выпасть (5% 10% 2шт 1шт)
                        //так как добавлять надо штуки нужна еще одна логическая конструкция

                        listshmot.Add(count_item + " " + name_shmot[i]);
                        break;
                    }
                    //проверка на то, что вероятность вообще не прокнула и предмет не выпал
                    else if (value > Convert.ToInt32(chance_shmot[i].Split(' ')[j]) && j == (chance_shmot[i].Split(' ').Length / 2) - 1)
                    {
                        listshmot.Add("Не_выпало " + name_shmot[i]);
                    }
                }
            }
            return listshmot;
        }





        public void Animation(int count_animation_in_one_refresh, System.Drawing.Image[] images, PictureBox[] p, Form_Main fm)
        {
            if (fm.cb_animation.Checked)
            {
                for (int i = 0; i < images.Length; i = i + count_animation_in_one_refresh)
                {
                    for (int j = 0; j < count_animation_in_one_refresh; j++)
                    {
                        p[j].Image = images[i + j];
                    }
                    fm.Refresh();
                }
            }
        }
    }
}
