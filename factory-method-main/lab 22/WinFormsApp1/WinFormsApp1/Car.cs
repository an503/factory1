using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    abstract class Design//дизайн
    {
        public abstract void Chair();//стілець
        public abstract void Table();//стіл,люстра,шафи
        public abstract void Wardrobe();
        public abstract void Chandelier();
    }

    class Kitchen : Design//кухня.дизайн
    {
        public override void Chair()
        {
            MessageBox.Show("висота: 50см, колір:синій, виробник: Китай");
        }

        public override void Table()
        {
            MessageBox.Show("висота: 70см, колір:коричневий, виробник: Польща");
        }
        public override void Wardrobe()
        {
            MessageBox.Show("висота: 150см, колір:чорний, виробник: Україна");
        }
        public override void Chandelier()
        {
            MessageBox.Show("висота: 15см, колір:золотий, виробник: Україна");
        }

    }

    class Bathroom : Design//ванна дизайн
    {
        public override void Chair()
        {
            MessageBox.Show("висота: 50см, колір:синій, виробник: Китай");
        }

        public override void Table()
        {
            MessageBox.Show("висота: 70см, колір:коричневий, виробник: Польща");
        }
        public override void Wardrobe()
        {
            MessageBox.Show("висота: 150см, колір:чорний, виробник: Україна");
        }
        public override void Chandelier()
        {
            MessageBox.Show("висота: 15см, колір:золотий, виробник: Україна");
        }
    }
    //спальня
    class Bedroom : Design
    {
        public override void Chair()
        {
            MessageBox.Show("висота: 50см, колір:синій, виробник: Китай");
        }

        public override void Table()
        {
            MessageBox.Show("висота: 70см, колір:коричневий, виробник: Польща");
        }
        public override void Wardrobe()
        {
            MessageBox.Show("висота: 150см, колір:чорний, виробник: Україна");
        }
        public override void Chandelier()
        {
            MessageBox.Show("висота: 15см, колір:золотий, виробник: Україна");
        }
    }

    class DesignFactory//дизайнфакторі
    {
        public static Design CreateDesign(string type)//креатдиз
        {
            switch (type)
            {
                case "Kitchen":
                    return new Kitchen();//кухня,ванна,спальня
                case "Bathroom":
                    return new Bathroom();
                case "Bedroom":
                    return new Bedroom();
                default:
                    return null;
            }
        }
    }

    class DesignForm : Form//дизайнформ
    {
        private ComboBox DesignComboBox;//дизайнкомбобокс
        private Button createButton;

        public DesignForm()//дизайн
        {
            this.DesignComboBox = new ComboBox();//
            this.DesignComboBox.Items.AddRange(new object[] { "Kitchen", "Bathroom", "Bedroom", "Livingroom" });
            this.DesignComboBox.Location = new Point(10, 10);
            this.Controls.Add(this.DesignComboBox);

            this.createButton = new Button();
            this.createButton.Text = "ok";//
            this.createButton.Location = new Point(10, 40);
            this.createButton.Click += new EventHandler(this.CreateButton_Click);
            this.Controls.Add(this.createButton);
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (this.DesignComboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, оберіть рівень");
                return;
            }

            string DesignBrand = this.DesignComboBox.SelectedItem.ToString();
            Design Design = DesignFactory.CreateDesign(DesignBrand);
            if (Design == null)
            {
                MessageBox.Show("Не вірно вибранo рівень");
                return;
            }

            MessageBox.Show("Cтворення рівня");
            Design.Table();
            Design.Chair();
            Design.Wardrobe();
            Design.Chandelier();
        }
    }
}
