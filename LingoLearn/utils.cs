using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LingoLearn
{
    class utils
    {
        public static void loadForm(Form from, Form to)
        {
            to.Location = from.Location;
            to.StartPosition = FormStartPosition.Manual;
            to.Show();
            from.Hide();
        }

        public static Form getPageFromRole()
        {
            Form res;
            switch (login.role)
            {
                case 1:
                    res = new student_page();
                    break;
                case 2:
                    res = new teacher_page();
                    break;
            }
            return res;
        }
    }
}
