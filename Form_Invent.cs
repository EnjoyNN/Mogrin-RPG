using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test1
{
    public partial class Form_Invent : Form
    {
        Form_Main fm;
        string who;
        public Random rnd = new Random();

        ProcedureClass cs = new ProcedureClass();

        public Form_Invent(Form_Main fm, string who)
        {
            this.who = who;
            this.fm = fm; //получили ссылку и передали ее в экземпеляр созданный выше, теперь управляем главной формой отсюда
            InitializeComponent();
        }

        public void LoadInventary()
        {
            while (DG_Invent.Rows.Count != 0)
                DG_Invent.Rows.Remove(DG_Invent.Rows[DG_Invent.Rows.Count - 1]);

            DG_Invent.ClearSelection();
            DG_Invent.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            if (who == "Могрин")
            {
                this.Text = "Инвентарь";

                if (Test1.Properties.Settings.Default.GG_MESSAGEQUEST != "0")
                {
                    DataGridViewRow Row = new DataGridViewRow();
                    Row.Height = 50;
                    DG_Invent.Rows.Add(Row);

                    cs.LoadItemInDataGrid("Донесение", Test1.Properties.Settings.Default.GG_MESSAGEQUEST, "...", this);
                }
                if (Test1.Properties.Settings.Default.GG_FLASKA != "0")
                {
                    DataGridViewRow Row = new DataGridViewRow();
                    Row.Height = 50;
                    DG_Invent.Rows.Add(Row);

                    cs.LoadItemInDataGrid("Фласка", Test1.Properties.Settings.Default.GG_FLASKA, "Выпить", this);
                }
                if (Test1.Properties.Settings.Default.GG_ATTACK_FLASKA != "0")
                {
                    DataGridViewRow Row = new DataGridViewRow();
                    Row.Height = 50;
                    DG_Invent.Rows.Add(Row);

                    cs.LoadItemInDataGrid("Отвар силы", Test1.Properties.Settings.Default.GG_ATTACK_FLASKA, "Выпить", this);
                }
                if (Test1.Properties.Settings.Default.GG_GOBLINSWORD != "0")
                {
                    DataGridViewRow Row = new DataGridViewRow();
                    Row.Height = 50;
                    DG_Invent.Rows.Add(Row);

                    cs.LoadItemInDataGrid("Меч гоблина", Test1.Properties.Settings.Default.GG_GOBLINSWORD, "...", this);
                }
            }
            else if (who.Contains("Гоблин"))
            {
                this.Text = "Труп гоблина";

                List<string> chanceshmot = new List<string>();
                List<string> nameshmot = new List<string>();

                //для первого левела гоблоты
                if (who.Contains("1"))
                {
                    //передаем выероятности выпадения и после вероятностей передаем количество сколько по этим вероятностям может выпасть
                    chanceshmot.AddRange(new string[] {"30 1", "30 1", "50 1", "5 30 100 7-10 3-6 1-2"});
                    nameshmot.AddRange(new string[] { "Отвар силы", "Фласка", "Меч гоблина", "Золото" });
                }
                else if (who.Contains("2"))
                {
                    chanceshmot.AddRange(new string[] { "15 55 2 1", "15 45 2 1", "50 1", "20 100 6-10 1-5" });
                    nameshmot.AddRange(new string[] { "Отвар силы", "Фласка", "Меч гоблина", "Золото" });
                }
                else if (who.Contains("3"))
                {
                    chanceshmot.AddRange(new string[] { "10 70 95 3 2 1", "15 60 90 3 2 1", "50 1", "10 45 100 11-18 8-10 3-7" });
                    nameshmot.AddRange(new string[] { "Отвар силы", "Фласка", "Меч гоблина", "Золото" });
                }
                else if (who.Contains("4"))
                {
                    chanceshmot.AddRange(new string[] { "30 70 100 3 2 1", "20 75 100 3 2 1", "50 1", "10 65 100 17-23 11-16 5-10" });
                    nameshmot.AddRange(new string[] { "Отвар силы", "Фласка", "Меч гоблина", "Золото" });
                }
                else if (who.Contains("5"))
                {
                    chanceshmot.AddRange(new string[] { "50 90 100 3 2 1", "40 95 100 3 2 1", "50 1", "10 50 100 21-30 13-20 8-12" });
                    nameshmot.AddRange(new string[] { "Отвар силы", "Фласка", "Меч гоблина", "Золото" });
                }
                chanceshmot = cs.GenerateRandomShmot(chanceshmot, nameshmot, this);

                for (int i = 0; i < chanceshmot.Count; i++)
                {
                    if (!chanceshmot[i].Contains("Не_выпало"))
                    {
                        DataGridViewRow Row = new DataGridViewRow();
                        Row.Height = 50;
                        DG_Invent.Rows.Add(Row);

                        cs.LoadItemInDataGrid(nameshmot[i], chanceshmot[i].Split(' ')[0], "Забрать", this);

                    }
                }
            }
            else if (who == "Купить Торговец")
            {
                this.Text = "Торговец Ахмед";

                DG_Invent.Columns[3].HeaderText = "Цена";

                DataGridViewRow Row = new DataGridViewRow();
                Row.Height = 50;
                DG_Invent.Rows.Add(Row);
                cs.LoadItemInDataGrid("Фласка", "17", "Купить", this);

                DataGridViewRow Row2 = new DataGridViewRow();
                Row2.Height = 50;
                DG_Invent.Rows.Add(Row2);
                cs.LoadItemInDataGrid("Отвар силы", "15", "Купить", this);
            }
            else if (who == "Продать Торговец")
            {
                this.Text = "Инвентарь";
                DG_Invent.Columns[3].HeaderText = "Цена";

                if (Test1.Properties.Settings.Default.GG_FLASKA != "0")
                {
                    DataGridViewRow Row = new DataGridViewRow();
                    Row.Height = 50;
                    DG_Invent.Rows.Add(Row);

                    cs.LoadItemInDataGrid("Фласка", "8(" + Test1.Properties.Settings.Default.GG_FLASKA + "шт)", "Продать", this);
                }
                if (Test1.Properties.Settings.Default.GG_ATTACK_FLASKA != "0")
                {
                    DataGridViewRow Row = new DataGridViewRow();
                    Row.Height = 50;
                    DG_Invent.Rows.Add(Row);

                    cs.LoadItemInDataGrid("Отвар силы", "7(" + Test1.Properties.Settings.Default.GG_ATTACK_FLASKA + "шт)", "Продать", this);
                }
                if (Test1.Properties.Settings.Default.GG_GOBLINSWORD != "0")
                {
                    DataGridViewRow Row = new DataGridViewRow();
                    Row.Height = 50;
                    DG_Invent.Rows.Add(Row);

                    cs.LoadItemInDataGrid("Меч гоблина", "5(" + Test1.Properties.Settings.Default.GG_GOBLINSWORD + "шт)", "Продать", this);
                }
            }
        }




        private void Form_Invent_Load(object sender, EventArgs e)
        {
            LoadInventary();
        }


        private void DG_Invent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (who == "Могрин")
            {
                if (e.ColumnIndex == 4)
                {
                    if (DG_Invent.RowCount > 0)
                    {
                        DG_Invent.Enabled = false;
                        if (DG_Invent.Rows[e.RowIndex].Cells[1].Value.ToString() == "Фласка" && Convert.ToInt32(Test1.Properties.Settings.Default.GG_FLASKA) != 0)
                        {
                            int health_now = Convert.ToInt32(Test1.Properties.Settings.Default.GG_HP.Split('/')[0]);
                            int health_max = Convert.ToInt32(Test1.Properties.Settings.Default.GG_HP.Split('/')[1]);

                            if ((health_now + 20) > health_max)
                                health_now = health_max;
                            else
                                health_now = health_now + 20;

                            Test1.Properties.Settings.Default.GG_HP = health_now.ToString() + "/" + health_max.ToString();

                            int count_flaska = Convert.ToInt32(Test1.Properties.Settings.Default.GG_FLASKA) - 1;
                            Test1.Properties.Settings.Default.GG_FLASKA = count_flaska.ToString();

                            Test1.Properties.Settings.Default.Save();

                            fm.setHealthAfterFlaska();

                            fm.Sound(Test1.Properties.Resources.выпито_зелье);

                            LoadInventary();
                        }
                        else if (DG_Invent.Rows[e.RowIndex].Cells[1].Value.ToString() == "Отвар силы" && Convert.ToInt32(Test1.Properties.Settings.Default.GG_ATTACK_FLASKA) != 0)
                        {
                            fm.strength_flaska = 10;

                            int count_flaska = Convert.ToInt32(Test1.Properties.Settings.Default.GG_ATTACK_FLASKA) - 1;
                            Test1.Properties.Settings.Default.GG_ATTACK_FLASKA = count_flaska.ToString();

                            Test1.Properties.Settings.Default.Save();

                            fm.Sound(Test1.Properties.Resources.выпито_зелье);

                            fm.setPictureAfterStrengthFlaska();

                            LoadInventary();
                        }

                        DG_Invent.Enabled = true;
                    }
                }
            }

            else if (who.Contains("Гоблин"))
            {
                if (e.ColumnIndex == 4)
                {
                    if (DG_Invent.RowCount > 0)
                    {
                        DG_Invent.Enabled = false;

                        if (DG_Invent.Rows[e.RowIndex].Cells[1].Value.ToString() == "Фласка")
                        {
                            Test1.Properties.Settings.Default.GG_FLASKA = (Convert.ToInt32(Test1.Properties.Settings.Default.GG_FLASKA) + Convert.ToInt32(DG_Invent.Rows[e.RowIndex].Cells[3].Value.ToString())).ToString();
                        }
                        else if (DG_Invent.Rows[e.RowIndex].Cells[1].Value.ToString() == "Отвар силы")
                        {
                            Test1.Properties.Settings.Default.GG_ATTACK_FLASKA = (Convert.ToInt32(Test1.Properties.Settings.Default.GG_ATTACK_FLASKA) + Convert.ToInt32(DG_Invent.Rows[e.RowIndex].Cells[3].Value.ToString())).ToString();
                        }
                        else if (DG_Invent.Rows[e.RowIndex].Cells[1].Value.ToString() == "Золото")
                        {
                            Test1.Properties.Settings.Default.GG_GOLD = (Convert.ToInt32(Test1.Properties.Settings.Default.GG_GOLD) + Convert.ToInt32(DG_Invent.Rows[e.RowIndex].Cells[3].Value.ToString())).ToString();
                            fm.rtb_gold.Clear();
                            fm.AppendColorText(fm.rtb_gold, Color.Black, "Золото: ");
                            fm.AppendColorText(fm.rtb_gold, Color.DarkGoldenrod, Test1.Properties.Settings.Default.GG_GOLD);
                        }
                        else if (DG_Invent.Rows[e.RowIndex].Cells[1].Value.ToString() == "Меч гоблина")
                        {
                            Test1.Properties.Settings.Default.GG_GOBLINSWORD = (Convert.ToInt32(Test1.Properties.Settings.Default.GG_GOBLINSWORD) + Convert.ToInt32(DG_Invent.Rows[e.RowIndex].Cells[3].Value.ToString())).ToString();
                        }
                        Test1.Properties.Settings.Default.Save();

                        DG_Invent.Rows.Remove(DG_Invent.Rows[e.RowIndex]);

                        DG_Invent.Enabled = true;
                    }
                }
            }
            else if (who == "Купить Торговец")
            {
                if (e.ColumnIndex == 4)
                {
                    if (DG_Invent.RowCount > 0)
                    {
                        DG_Invent.Enabled = false;

                        if (DG_Invent.Rows[e.RowIndex].Cells[1].Value.ToString() == "Фласка")
                        {
                            if (Convert.ToInt32(Test1.Properties.Settings.Default.GG_GOLD) >= 17)
                            {
                                fm.Sound(Test1.Properties.Resources.купля_продажа);
                                Test1.Properties.Settings.Default.GG_GOLD = (Convert.ToInt32(Test1.Properties.Settings.Default.GG_GOLD) - 17).ToString();
                                Test1.Properties.Settings.Default.GG_FLASKA = (Convert.ToInt32(Test1.Properties.Settings.Default.GG_FLASKA) + 1).ToString();

                                fm.rtb_gold.Clear();
                                fm.AppendColorText(fm.rtb_gold, Color.Black, "Золото: ");
                                fm.AppendColorText(fm.rtb_gold, Color.DarkGoldenrod, Test1.Properties.Settings.Default.GG_GOLD);
                            }
                        }
                        else if (DG_Invent.Rows[e.RowIndex].Cells[1].Value.ToString() == "Отвар силы")
                        {
                            if (Convert.ToInt32(Test1.Properties.Settings.Default.GG_GOLD) >= 15)
                            {
                                fm.Sound(Test1.Properties.Resources.купля_продажа);
                                Test1.Properties.Settings.Default.GG_GOLD = (Convert.ToInt32(Test1.Properties.Settings.Default.GG_GOLD) - 15).ToString();
                                Test1.Properties.Settings.Default.GG_ATTACK_FLASKA = (Convert.ToInt32(Test1.Properties.Settings.Default.GG_ATTACK_FLASKA) + 1).ToString();

                                fm.rtb_gold.Clear();
                                fm.AppendColorText(fm.rtb_gold, Color.Black, "Золото: ");
                                fm.AppendColorText(fm.rtb_gold, Color.DarkGoldenrod, Test1.Properties.Settings.Default.GG_GOLD);
                            }
                        }

                        Test1.Properties.Settings.Default.Save();

                        LoadInventary();

                        DG_Invent.Enabled = true;
                    }
                }
            }


            else if (who == "Продать Торговец")
            {
                if (e.ColumnIndex == 4)
                {
                    if (DG_Invent.RowCount > 0)
                    {
                        DG_Invent.Enabled = false;

                        if (DG_Invent.Rows[e.RowIndex].Cells[1].Value.ToString() == "Фласка")
                        {
                            fm.Sound(Test1.Properties.Resources.купля_продажа);
                            Test1.Properties.Settings.Default.GG_GOLD = (Convert.ToInt32(Test1.Properties.Settings.Default.GG_GOLD) + 8).ToString();
                            Test1.Properties.Settings.Default.GG_FLASKA = (Convert.ToInt32(Test1.Properties.Settings.Default.GG_FLASKA) - 1).ToString();

                            fm.rtb_gold.Clear();
                            fm.AppendColorText(fm.rtb_gold, Color.Black, "Золото: ");
                            fm.AppendColorText(fm.rtb_gold, Color.DarkGoldenrod, Test1.Properties.Settings.Default.GG_GOLD);
                        }
                        else if (DG_Invent.Rows[e.RowIndex].Cells[1].Value.ToString() == "Отвар силы")
                        {
                            fm.Sound(Test1.Properties.Resources.купля_продажа);
                            Test1.Properties.Settings.Default.GG_GOLD = (Convert.ToInt32(Test1.Properties.Settings.Default.GG_GOLD) + 7).ToString();
                            Test1.Properties.Settings.Default.GG_ATTACK_FLASKA = (Convert.ToInt32(Test1.Properties.Settings.Default.GG_ATTACK_FLASKA) - 1).ToString();

                            fm.rtb_gold.Clear();
                            fm.AppendColorText(fm.rtb_gold, Color.Black, "Золото: ");
                            fm.AppendColorText(fm.rtb_gold, Color.DarkGoldenrod, Test1.Properties.Settings.Default.GG_GOLD);
                        }
                        else if (DG_Invent.Rows[e.RowIndex].Cells[1].Value.ToString() == "Меч гоблина")
                        {
                            fm.Sound(Test1.Properties.Resources.купля_продажа);
                            Test1.Properties.Settings.Default.GG_GOLD = (Convert.ToInt32(Test1.Properties.Settings.Default.GG_GOLD) + 5).ToString();
                            Test1.Properties.Settings.Default.GG_GOBLINSWORD = (Convert.ToInt32(Test1.Properties.Settings.Default.GG_GOBLINSWORD) - 1).ToString();

                            fm.rtb_gold.Clear();
                            fm.AppendColorText(fm.rtb_gold, Color.Black, "Золото: ");
                            fm.AppendColorText(fm.rtb_gold, Color.DarkGoldenrod, Test1.Properties.Settings.Default.GG_GOLD);
                        }

                        Test1.Properties.Settings.Default.Save();

                        LoadInventary();

                        DG_Invent.Enabled = true;
                    }
                }
            }
        }
    }
}
