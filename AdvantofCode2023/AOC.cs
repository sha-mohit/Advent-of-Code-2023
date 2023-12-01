using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Office.Interop.Excel;

namespace AdvantofCode2023
{
    public partial class AOC : Form
    {
        public AOC()
        {
            InitializeComponent();
        }
        List<string> readings = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                filePath = file.FileName; //get the path of the file  
                fileExt = Path.GetExtension(filePath); //get the file extension  
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        Microsoft.Office.Interop.Excel.Application xlsApp = new Microsoft.Office.Interop.Excel.Application();

                        if (xlsApp == null)
                        {
                            Console.WriteLine("EXCEL could not be started. Check that your office installation and project references are correct.");

                        }

                        //Displays Excel so you can see what is happening
                        //xlsApp.Visible = true;

                        Workbook wb = xlsApp.Workbooks.Open(filePath,
                            0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true);
                        Sheets sheets = wb.Worksheets;
                        Worksheet ws = (Worksheet)sheets.get_Item(1);

                        Range firstColumn = ws.UsedRange.Columns[1];
                        System.Array myvalues = (System.Array)firstColumn.Cells.Value;
                        if (readings.Count > 0)
                        {
                            readings.Clear();
                        }
                        readings = myvalues.OfType<object>().Select(o => o.ToString()).ToList();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }


                Puzzel_1 puzzel_1 = new Puzzel_1();
                label1.Text = puzzel_1.FirstSolution(readings);
                label2.Text = puzzel_1.SecondSolution(readings);

                //Puzzel_2 puzzel_2 = new Puzzel_2();
                //label1.Text = puzzel_2.FirstSolution(readings);
                //label2.Text = puzzel_2.SecondSolution(readings);

                //Puzzel_3 puzzel_3 = new Puzzel_3();
                //label1.Text = puzzel_3.FirstSolution(readings);
                //label2.Text = puzzel_3.SecondSolution(readings);

                //Puzzel_4 puzzel_4 = new Puzzel_4();
                //label1.Text = puzzel_4.FirstSolution(readings);
                //label2.Text = puzzel_4.SecondSolution(readings);

                //Puzzel_5 puzzel_5 = new Puzzel_5();
                //label1.Text = puzzel_5.FirstSolution(readings);
                //label2.Text = puzzel_5.SecondSolution(readings);

                //Puzzel_6 puzzel_6 = new Puzzel_6();
                //label1.Text = puzzel_6.FirstSolution(readings);
                //label2.Text = puzzel_6.SecondSolution(readings);

                // Puzzel_7 puzzel_7 = new Puzzel_7();
                //label1.Text = puzzel_7.FirstSolution(readings);
                //label2.Text = puzzel_7.SecondSolution(readings);

                //Puzzel_8 puzzel_8 = new Puzzel_8();
                //label1.Text = puzzel_8.FirstSolution(readings);
                //label2.Text = puzzel_8.SecondSolution(readings);

                //Puzzel_9 puzzel_9 = new Puzzel_9();
                //label1.Text = puzzel_9.FirstSolution(readings);
                //label2.Text = puzzel_9.SecondSolution(readings);

                //Puzzel_10 puzzel_10 = new Puzzel_10();
                //label1.Text = puzzel_10.FirstSolution(readings);
                //label2.Text = puzzel_10.SecondSolution(readings);

                //Puzzel_11 puzzel_11 = new Puzzel_11();
                //label1.Text = puzzel_11.FirstSolution(readings);
                //label2.Text = puzzel_11.SecondSolution(readings);

                //Puzzel_12 puzzel_12 = new Puzzel_12();
                //label1.Text = puzzel_12.FirstSolution(readings);
                //label2.Text = puzzel_12.SecondSolution(readings);

                //Puzzel_13 puzzel_13 = new Puzzel_13();
                //label1.Text = puzzel_13.FirstSolution(readings);
                //label2.Text = puzzel_13.SecondSolution(readings);

                //Puzzel_14 puzzel_14 = new Puzzel_14();
                //label1.Text = puzzel_14.FirstSolution(readings);
                //label2.Text = puzzel_14.SecondSolution(readings);

                //Puzzel_15 puzzel_15 = new Puzzel_15();
                //label1.Text = puzzel_15.FirstSolution(readings);
                //label2.Text = puzzel_15.SecondSolution(readings);

                //Puzzel_16 puzzel_16 = new Puzzel_16();
                //label1.Text = puzzel_16.FirstSolution(readings);
                //label2.Text = puzzel_16.SecondSolution(readings);

                //Puzzel_17 puzzel_17 = new Puzzel_17();
                //label1.Text = puzzel_17.FirstSolution(readings);
                //label2.Text = puzzel_17.SecondSolution(readings);

                // Puzzel_18 puzzel_18 = new Puzzel_18();
                //label1.Text = puzzel_18.FirstSolution(readings);
                //label2.Text = puzzel_18.SecondSolution(readings);

                //Puzzel_19 puzzel_19 = new Puzzel_19();
                //label1.Text = puzzel_19.FirstSolution(readings);
                //label2.Text = puzzel_19.SecondSolution(readings);

                //Puzzel_20 puzzel_20 = new Puzzel_20();
                //label1.Text = puzzel_20.FirstSolution(readings);
                //label2.Text = puzzel_20.SecondSolution(readings);

                //Puzzel_21 puzzel_21 = new Puzzel_21();
                //label1.Text = puzzel_21.FirstSolution(readings);
                //label2.Text = puzzel_21.SecondSolution(readings);

                //Puzzel_22 puzzel_22 = new Puzzel_22();
                //label1.Text = puzzel_22.FirstSolution(readings);
                //label2.Text = puzzel_22.SecondSolution(readings);

                //Puzzel_23 puzzel_23 = new Puzzel_23();
                //label1.Text = puzzel_23.FirstSolution(readings);
                //label2.Text = puzzel_23.SecondSolution(readings);

                //Puzzel_24 puzzel_24 = new Puzzel_24();
                //label1.Text = puzzel_24.FirstSolution(readings);
                //label2.Text = puzzel_24.SecondSolution(readings);

                //Puzzel_25 puzzel_25 = new Puzzel_25();
                //label1.Text = puzzel_25.FirstSolution(readings);
                //label2.Text = puzzel_25.SecondSolution(readings);

            }
        }    
      
    }
}
