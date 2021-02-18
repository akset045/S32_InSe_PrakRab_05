using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace PrakRab_05
{
    public partial class Form1 : Form
    {
        char[] characters = new char[]
        { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',  'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ', 'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        public int N;

        public Form1()
        { InitializeComponent();
          N = characters.Length;
        }

        private string Encode(string input, string keyword)
        {
            input = input.ToUpper();
            keyword = keyword.ToUpper();
            string result = "";
            int keyword_index = 0;
            foreach (char symbol in input)
            {
                int c = (Array.IndexOf(characters, symbol) + Array.IndexOf(characters, keyword[keyword_index])) % N;
                result += characters[c];
                keyword_index++;
                if ((keyword_index + 1) == keyword.Length) keyword_index = 0;
            }
            return result;
        }

        private string Decode(string input, string keyword)
        {
            input = input.ToUpper();
            keyword = keyword.ToUpper();
            string result = "";
            int keyword_index = 0;
            foreach (char symbol in input)
            {
                int p = (Array.IndexOf(characters, symbol) + N - Array.IndexOf(characters, keyword[keyword_index])) % N;
                result += characters[p];
                keyword_index++; if ((keyword_index + 1) == keyword.Length) keyword_index = 0;
            }
            return result;
        }

        private string Generate_Pseudorandom_KeyWord(int length, int startSeed)
        {
            Random rand = new Random(startSeed);
            string result = "";
            for (int i = 0;
            i < length; i++) result += characters[rand.Next(0, characters.Length)];
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string s;
                StreamReader sr = new StreamReader(@"C:\Users\Student\source\repos\akset045\S32_InSe_PrakRab_05\PrakRab_05\Resources\file1.txt");
                StreamWriter sw = new StreamWriter(@"C:\Users\Student\source\repos\akset045\S32_InSe_PrakRab_05\PrakRab_05\Resources\file2.txt");
                while (!sr.EndOfStream)
                {
                    s = sr.ReadLine();
                    sw.WriteLine(Encode(s, Generate_Pseudorandom_KeyWord(s.Length, 100)));
                }
                sr.Close();
                sw.Close();
            }
            else
            {
                if (textBox1.Text.Length > 0)
                {
                    string s;
                    StreamReader sr = new StreamReader(@"C:\Users\Student\source\repos\akset045\S32_InSe_PrakRab_05\PrakRab_05\Resources\file1.txt");
                    StreamWriter sw = new StreamWriter(@"C:\Users\Student\source\repos\akset045\S32_InSe_PrakRab_05\PrakRab_05\Resources\file2.txt");
                    while (!sr.EndOfStream)
                    {
                        s = sr.ReadLine();
                        sw.WriteLine(Encode(s, textBox1.Text));
                    }
                    sr.Close();
                    sw.Close();
                }
                else MessageBox.Show("Введите ключевое слово!");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string s;
                StreamReader sr = new StreamReader(@"C:\Users\Student\source\repos\akset045\S32_InSe_PrakRab_05\PrakRab_05\Resources\file1.txt");
                StreamWriter sw = new StreamWriter(@"C:\Users\Student\source\repos\akset045\S32_InSe_PrakRab_05\PrakRab_05\Resources\file2.txt");
                while (!sr.EndOfStream)
                {
                    s = sr.ReadLine();
                    sw.WriteLine(Decode(s, Generate_Pseudorandom_KeyWord(s.Length, 100)));
                }
                sr.Close();
                sw.Close();
            }
            else
            {
                if (textBox1.Text.Length > 0)
                {
                    string s;  //
                    StreamReader sr = new StreamReader(@"C:\Users\Student\source\repos\akset045\S32_InSe_PrakRab_05\PrakRab_05\Resources\file1.txt");
                    StreamWriter sw = new StreamWriter(@"C:\Users\Student\source\repos\akset045\S32_InSe_PrakRab_05\PrakRab_05\Resources\file2.txt");
                    while (!sr.EndOfStream)
                    {
                        s = sr.ReadLine();
                        sw.WriteLine(Decode(s, textBox1.Text));
                    }
                    sr.Close();
                    sw.Close();
                }
                else MessageBox.Show("Введите ключевое слово!");
            }
        }
    }    
}




    


  
