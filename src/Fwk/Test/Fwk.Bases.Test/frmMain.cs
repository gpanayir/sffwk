using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.Bases.Test
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (frmEntitiesTest frm = new frmEntitiesTest ())
            { frm.ShowDialog(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (frmEntityFromXmlWhitAttributes frm = new frmEntityFromXmlWhitAttributes())
            { frm.ShowDialog(); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (frmUndoRedoEntitiesTest frm = new frmUndoRedoEntitiesTest())
            { frm.ShowDialog(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            using (frmHelperFunctions frm = new frmHelperFunctions())
            { frm.ShowDialog(); }

        }

        private void btnExeptions_Click(object sender, EventArgs e)
        {
            using (frmException frm = new frmException())
            { frm.ShowDialog(); }
        }


        
        public class Person
        {
            public Person(int id,string nombre) {
                this.Id = id;
                this.Nombre = nombre;
            }
            public Person() { }
            public int Id { get; set; }
            public string Nombre { get; set; }
        }

        private void button_SingletonFactoryArray_Click(object sender, EventArgs e)
        {
            SingletonFactoryArray<Person> personList = new SingletonFactoryArray<Person>();

            Person p1 = new Person();
            p1.Id = 1000;
            p1.Nombre = "Gaus";
            personList.Add(p1.Nombre, p1);

            Person p2 = new Person();
            p2.Id = 2000;
            p2.Nombre = "Hendryx";
            personList.Add(p2.Nombre, p2);



           Person p3 =  personList.Create("Maria");
           Person p4 = personList.Create("Robert", new Object[] { 3000, "Robert" });
        }



    }
}
