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

namespace Rawa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. التأكد أولاً أن الحقول ليست فارغة قبل الحفظ
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
    {
                    MessageBox.Show("تنبيه: لا يمكن حفظ بيانات فارغة! يرجى تعبئة كافة الخانات.", "خطأ في الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
    else
                {
                    // 2. إذا كانت الحقول ممتلئة، يتم الحفظ
                    string filePath = "data.txt";
                    string info = "Name: " + txtName.Text + " | Email: " + txtEmail.Text + " | Password: " + txtPass.Text + Environment.NewLine;

                    File.AppendAllText(filePath, info);

                    MessageBox.Show("تم حفظ البيانات بنجاح في الملف!", "نجاح الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ غير متوقع: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 1. التحقق من أن الخانات ليست فارغة
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
    {
                MessageBox.Show("عذراً، يجب تعبئة كافة الخانات!", "تنبيه");
            }
    // 2. التحقق من صحة الإيميل (يجب أن يحتوي على @ و نقطة معاً)
    // لاحظي استخدمنا && التي تعني "و" مع علامة ! لضمان وجود الرمزين
            else if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("صيغة الإيميل غير صحيحة! تأكدي من وجود @ ونقطة .", "خطأ في الإدخال");
            }
            // 3. التحقق من طول كلمة المرور
            else if (txtPass.Text.Length < 6)
            {
                MessageBox.Show("كلمة المرور يجب أن تكون 6 خانات أو أكثر", "تنبيه");
            }
            else
            {
                MessageBox.Show("تم التحقق والإرسال بنجاح!", "نجاح");
                // اختياري: مسح الخانات بعد النجاح
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPass.Clear();
            txtName.Focus(); // يضع الماوس على أول خانة تلقائياً
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists("data.txt"))
            {
                // قراءة كل الأسطر من الملف
                string[] lines = File.ReadAllLines("data.txt");

                // إذا كان الملف غير فارغ، اعرض آخر سطر تم حفظه
                if (lines.Length > 0)
                {
                    string lastLine = lines[lines.Length - 1];
                    MessageBox.Show("آخر بيانات محفوظة هي: \n" + lastLine);
                }
            }
            else
            {
                MessageBox.Show("لا يوجد ملف بيانات بعد!");
            }
        }
    }
}
