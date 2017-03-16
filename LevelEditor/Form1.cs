﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelEditor
{
    public partial class Form1 : Form
    {
        Dictionary dict;
        Content content;
        Bitmap plane, contentImg;

        Rectangle addPrevRect;
        Instance addition = null;
        bool drawCurr;

        public Form1()
        {
            InitializeComponent();

            dict = new Dictionary();
            content = new Content();
            plane = new Bitmap(pictureBoxEdit.Width, pictureBoxEdit.Height);
            contentImg = new Bitmap(pictureBoxEdit.Width, pictureBoxEdit.Height);

            RedrawPlane(true);
        }

        private void buttonAddDef_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Bitmap files(*.bmp,*.gif,*.jpg,*.jpeg,*.png,*.ico)|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.ico";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Definition def = new Definition("New Definition", this);

                    // This way the image file is unlocked after loading
                    using (Image temp = new Bitmap(dlg.FileName))
                    {
                        def.setImage(new Bitmap(temp), dlg.FileName);
                    }

                    dict.Add(def);
                    RenewDictionaryBox();
                }
            }
        }

        public void RedrawPlane(bool onAddMoved)
        {
            Graphics G = Graphics.FromImage(plane);

            if (onAddMoved)
            {
                Graphics C = Graphics.FromImage(contentImg);
                C.Clear(pictureBoxEdit.BackColor);
                content.Draw(C);

                G.DrawImage(contentImg, 0, 0);
            }
            else
            {
                if (addPrevRect != null)
                {
                    G.SetClip(addPrevRect);
                    G.DrawImage(contentImg, 0, 0);
                }
                else
                {
                    G.DrawImage(contentImg, 0, 0);
                }
            }

            if (addition != null && drawCurr) addition.Draw(G);

            if (checkShowGrid.Checked &&
                numericGridW.Value > 0 && numericGridH.Value > 0)
            {
                Pen pen = new Pen(Color.DarkGray);

                for (int i = 0; i < plane.Width; i += (int)numericGridW.Value)
                    G.DrawLine(pen, i, 0, i, plane.Height);

                for (int i = 0; i < plane.Height; i += (int)numericGridH.Value)
                    G.DrawLine(pen, 0, i, plane.Width, i);
            }

            pictureBoxEdit.Image = plane;
        }

        public void RenewDictionaryBox()
        {
            dictionaryBox.Items.Clear();

            for (int i = 0; i < dict.Count; ++i)
                dictionaryBox.Items.Add(dict[i].ToString());
        }

        public void RenewContentBox()
        {
            contentBox.Items.Clear();

            for (int i = 0; i < content.Count; ++i)
                contentBox.Items.Add(content[i].ToString());
        }

        public void RenewBoxes()
        {
            RenewDictionaryBox();
            RenewContentBox();
        }

        private void pictureBoxEdit_MouseMove(object sender, MouseEventArgs e)
        {
            Point loc = new Point(e.X, e.Y);

            if (checkSnapGrid.Checked)
            {
                int gridW = (int)numericGridW.Value;
                int gridH = (int)numericGridH.Value;

                loc.X = (loc.X / gridW) * gridW;
                loc.Y = (loc.Y / gridH) * gridH;
            }

            labelCoords.Text = loc.ToString();

            if (addition != null)
            {
                addPrevRect = new Rectangle(addition.Location, addition.GetDefinition().Image.Size);
                addition.setLocation(loc);

                drawCurr = true;
                RedrawPlane(false);
            }
        }

        private void pictureBoxEdit_MouseLeave(object sender, EventArgs e)
        {
            drawCurr = false;
            if (addition != null) RedrawPlane(false);
        }

        private void pictureBoxEdit_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (addition != null)
                {
                    content.Add(addition);
                    contentBox.Items.Add(addition.ToString());

                    Instance tmp = new Instance(addition.GetDefinition(), this);
                    tmp.setLocation(addition.Location);
                    addition = tmp;

                    RedrawPlane(true);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                addition = null;
                dictionaryBox.ClearSelected();
                RedrawPlane(false);
            }
        }

        private void dictionaryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = dictionaryBox.SelectedIndex;
            if (index >= 0)
            {
                addition = new Instance(dict[index], this);
                defProperties.SelectedObject = dict[index];
            }
        }

        private void contentBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = contentBox.SelectedIndex;
            if (index >= 0)
            {
                addition = null;
                instProperties.SelectedObject = content[index];
            }
        }

        private void numericGridW_ValueChanged(object sender, EventArgs e)
        {
            if (checkShowGrid.Checked) RedrawPlane(true);
        }

        private void numericGridH_ValueChanged(object sender, EventArgs e)
        {
            if (checkShowGrid.Checked) RedrawPlane(true);
        }

        private void checkShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            RedrawPlane(true);
        }

        private void contentBox_MouseLeave(object sender, EventArgs e)
        {
        }

        private void pictureBoxEdit_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }
    }
}
