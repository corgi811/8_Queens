using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ExcelSheetSave
{
    public partial class Form1 : Form
    {
        int[] arr;
        int counts = 0;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            //呼叫waiting畫面
            ThreadStart myRun = new ThreadStart(FormRun);
            Thread t = new Thread(myRun);
            t.IsBackground = true;
            t.Start();
            run();
            t.Abort();
        }
        private void run(){
            int queens = 8;
            arr= new int[queens];
            Count(0, queens);
            //顯示總數到listbox裡面
            listBox1.Items.Add("總共"+counts+"種解法!");
        }
        private void Count(int num,int queens)
        {
            if (num==queens)
            {
                //顯示解法
                List_add();
                return;
            }
            for(int i = 0; i < queens; i++)
            {
                arr[num] = i;
                //判斷num在第i列,是否衝突
                if (Save(num))
                {
                    //如不衝突 開始判斷下個皇后在下一列的位置
                    Count(num + 1, queens);
                }
            }
        }
        //判斷是否會和其他皇后衝突
        private Boolean Save(int num)
        {
            for (int i = 0; i < num; i++)
            {
                //判斷是否和前面幾個皇后同一列或同一斜線
                if (arr[i] == arr[num] || Math.Abs(num - i) == Math.Abs(arr[num] - arr[i]))
                {
                    return false;
                }
            }
            return true;
        }
        private void List_add()
        {
            //總數加1
            counts++;
            string str="";
            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i] + " ";
            }
            //顯示解法到listbox裡面
            listBox1.Items.Add(str);
        }

        private void FormRun()
        {
            Application.Run(new Form2());
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
