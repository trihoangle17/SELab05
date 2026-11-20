using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace WinFormsStudentApp
{
    public class Form1 : Form
    {
        public Label lblStudentName;
        public TextBox txtStudentName;
        public Label lblCourseName;
        public TextBox txtCourseName;
        public Button btnSave;
        public Label lblCopyright;

        public Form1(int stage = 3)
        {
            this.Text = "WinFormsStudentApp - GitHub SCM Collaboration (SE Lab 5)";
            this.ClientSize = new Size(480, 250);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            Label lblHeader = new Label
            {
                Text = "Student Course Registration (GitHub SCM)",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(35, 22)
            };
            this.Controls.Add(lblHeader);

            if (stage >= 2)
            {
                // Added in Exercise 3c (Student B): Label "Student Name:" & TextBox txtStudentName
                lblStudentName = new Label
                {
                    Text = "Student Name:",
                    Font = new Font("Segoe UI", 10F),
                    AutoSize = true,
                    Location = new Point(35, 70)
                };
                txtStudentName = new TextBox
                {
                    Name = "txtStudentName",
                    Text = "Lê Hoàng Trí - 524H0199",
                    Font = new Font("Segoe UI", 10F),
                    Location = new Point(160, 67),
                    Size = new Size(260, 25)
                };
                this.Controls.Add(lblStudentName);
                this.Controls.Add(txtStudentName);
            }

            if (stage >= 3)
            {
                // Added in Exercise 3d (Student A): Label "Course Name:" & TextBox txtCourseName
                lblCourseName = new Label
                {
                    Text = "Course Name:",
                    Font = new Font("Segoe UI", 10F),
                    AutoSize = true,
                    Location = new Point(35, 115)
                };
                txtCourseName = new TextBox
                {
                    Name = "txtCourseName",
                    Text = "Software Engineering (Lab 5)",
                    Font = new Font("Segoe UI", 10F),
                    Location = new Point(160, 112),
                    Size = new Size(260, 25)
                };
                btnSave = new Button
                {
                    Name = "btnSave",
                    Text = "Submit Enrollment",
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    Location = new Point(160, 155),
                    Size = new Size(155, 34)
                };
                this.Controls.Add(lblCourseName);
                this.Controls.Add(txtCourseName);
                this.Controls.Add(btnSave);
            }

            lblCopyright = new Label
            {
                Text = "Developed by Lê Hoàng Trí - 524H0199 (GitHub SCM Lab 5)",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Italic),
                ForeColor = Color.DimGray,
                AutoSize = true,
                Location = new Point(35, 215)
            };
            this.Controls.Add(lblCopyright);
        }
    }

    static class Program
    {
        private static void SaveForm(Form f, string path)
        {
            f.Show();
            f.Refresh();
            Application.DoEvents();
            System.Threading.Thread.Sleep(150);
            Application.DoEvents();
            using (Bitmap bmp = new Bitmap(f.Width, f.Height))
            {
                f.DrawToBitmap(bmp, new Rectangle(0, 0, f.Width, f.Height));
                bmp.Save(path, ImageFormat.Png);
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length >= 2 && args[0] == "--capture")
            {
                string outDir = args[1];
                using (Form1 f1 = new Form1(1)) SaveForm(f1, Path.Combine(outDir, "lab5_ex1_initial.png"));
                using (Form1 f2 = new Form1(2)) SaveForm(f2, Path.Combine(outDir, "lab5_ex3c_student_name.png"));
                using (Form1 f3 = new Form1(3)) SaveForm(f3, Path.Combine(outDir, "lab5_ex3d_course_name.png"));
                return;
            }

            Application.Run(new Form1(3));
        }
    }
}
