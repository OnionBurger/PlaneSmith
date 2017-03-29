﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace LevelEditor
{
    public partial class Form1 : Form
    {
        Foundation foundation;

        public Form1()
        {
            InitializeComponent();

            foundation = new Foundation(this);

            foundation.Plane.RedrawWhole();
            pictureBoxEdit.Image = foundation.Plane.Image;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        internal Color PlaneBackColor
        {
            get { return pictureBoxEdit.BackColor; }
        }

        internal Size PlaneSize
        {
            get { return pictureBoxEdit.Size; }
        }

        internal Size GridCellSize
        {
            get
            {
                return new Size((int)numericGridW.Value, (int)numericGridH.Value);
            }
        }

        internal bool ShouldShowGrid
        {
            get { return checkShowGrid.Checked; }
        }

        internal bool ShouldSnapGrid
        {
            get { return checkSnapGrid.Checked; }
        }

        private void renewDictionaryBox()
        {
            dictionaryBox.Items.Clear();

            for (int i = 0; i < foundation.Dictionary.Count; ++i)
                dictionaryBox.Items.Add(foundation.Dictionary[i].ToString());
        }

        private void renewLevelBox()
        {
            levelBox.Items.Clear();

            for (int i = 0; i < foundation.Level.Count; ++i)
                levelBox.Items.Add(foundation.Level[i].ToString());
        }

        private void renewBoxes()
        {
            renewDictionaryBox();
            renewLevelBox();
        }

        internal void onDictionaryChanged(int SelectedIndex)
        {
            if (SelectedIndex < 0) SelectedIndex = dictionaryBox.SelectedIndex;

            renewDictionaryBox();

            if (SelectedIndex >= 0 && SelectedIndex < dictionaryBox.Items.Count)
            {
                dictionaryBox.SelectedIndex = SelectedIndex;
                defProperties.SelectedObject = foundation.Dictionary[SelectedIndex];
            }
            else
            {
                defProperties.SelectedObject = null;
            }
        }

        internal void onLevelChanged(int SelectedIndex)
        {
            if (SelectedIndex < 0) SelectedIndex = levelBox.SelectedIndex;

            renewLevelBox();
            
            if (SelectedIndex >= 0 && SelectedIndex < levelBox.Items.Count)
            {
                levelBox.SelectedIndex = SelectedIndex;
                instProperties.SelectedObject = foundation.Level[SelectedIndex];
            }
            else
            {
                instProperties.SelectedObject = null;
            }

            onPlaneChanged(true);
        }

        internal void onDictAndLevelChanged()
        {
            onDictionaryChanged(-1);
            onLevelChanged(-1);
        }

        internal void onDefinitionChanged()
        {
            renewDictionaryBox();
            onPlaneChanged(true);
        }

        internal void onPlaneChanged(bool RedrawWhole)
        {
            if (RedrawWhole) foundation.Plane.RedrawWhole();
            else foundation.Plane.RedrawIncrm();

            pictureBoxEdit.Image = foundation.Plane.Image;
            numericGridW.Value = foundation.Plane.GridCellSize.Width;
            numericGridH.Value = foundation.Plane.GridCellSize.Height;
            checkShowGrid.Checked = foundation.Plane.IsDrawGrid;
            checkSnapGrid.Checked = foundation.Plane.IsSnapGrid;
        }

        internal void onInstanceLocationChanged(Instance I)
        {
            if (I == foundation.Plane.InstAtCursor)
            {
                foundation.Plane.RedrawIncrm();
                pictureBoxEdit.Image = foundation.Plane.Image;
            }
            else
            {
                renewLevelBox();
                foundation.Plane.RedrawWhole();
                pictureBoxEdit.Image = foundation.Plane.Image;
            }
        }

        private void buttonAddDef_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox(
                "Definition name", "Name", "New Definition", 
                this.Left + 100, this.Top + 100
                );

            if (name != null && name.Length > 0)
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.Title = "Open Image";
                    dialog.Filter = "Bitmap files(*.bmp,*.gif,*.jpg,*.jpeg,*.png,*.ico)|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.ico";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        foundation.AddDefinition(name, dialog.FileName);
                    }
                }
            }
        }

        private void buttonMoveUpDef_Click(object sender, EventArgs e)
        {
            int index = dictionaryBox.SelectedIndex;

            if (index >= 0) foundation.MoveDefUp(index);
        }

        private void buttonMoveDownDef_Click(object sender, EventArgs e)
        {
            int index = dictionaryBox.SelectedIndex;

            if (index >= 0) foundation.MoveDefDown(index);
        }

        private void buttonDeleteDef_Click(object sender, EventArgs e)
        {
            int index = dictionaryBox.SelectedIndex;

            selectedDefValid = false;

            if (index >= 0) foundation.DeleteDefinition(index);
        }

        private void buttonMoveUpInst_Click(object sender, EventArgs e)
        {
            int index = levelBox.SelectedIndex;

            if (index >= 0) foundation.MoveInstUp(index);
        }

        private void buttonMoveDownInst_Click(object sender, EventArgs e)
        {
            int index = levelBox.SelectedIndex;

            if (index >= 0) foundation.MoveInstDown(index);
        }

        private void buttonDeleteInst_Click(object sender, EventArgs e)
        {
            int index = levelBox.SelectedIndex;

            selectedInstValid = false;

            if (index >= 0) foundation.DeleteInstance(index);
        }

        private void pictureBoxEdit_MouseEnter(object sender, EventArgs e)
        {
            foundation.Plane.ShowInstAtCursor();
        }

        private void pictureBoxEdit_MouseMove(object sender, MouseEventArgs e)
        {
            if (foundation.Plane.InstAtCursor == null) return;

            Point prev = foundation.Plane.InstAtCursor.Location;

            foundation.Plane.MoveInstAtCursor(e.X, e.Y);

            if (foundation.Plane.IsSnapGrid &&
                (Control.MouseButtons & MouseButtons.Left) == MouseButtons.Left &&
                (Control.ModifierKeys & Keys.Shift) != 0)
            {
                Point curr = foundation.Plane.InstAtCursor.Location;
                curr = foundation.Plane.SnapToGrid(curr.X, curr.Y);

                if (prev.X != curr.X || prev.Y != curr.Y)
                    foundation.AddInstAtCursorToLevel();
            }
        }

        private void pictureBoxEdit_MouseLeave(object sender, EventArgs e)
        {
            foundation.Plane.HideInstAtCursor();
        }

        private void pictureBoxEdit_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foundation.AddInstAtCursorToLevel();
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (foundation.Plane.InstAtCursor != null)
                {
                    dictionaryBox.ClearSelected();
                    foundation.Plane.ForgetInstAtCursor();
                }
                else
                {
                    foundation.DeleteInstanceAt(e.Location);
                }
            }
        }

        private void putBaseCode()
        {
            foundation.Level.CopyAsCode(richTextCodeBase.Lines);
        }

        private void takeBaseCode()
        {
            string[] code = foundation.Level.GetCode();
            if (code != null)
            {
                richTextCodeBase.Clear();

                foreach (string line in code)
                    richTextCodeBase.AppendText(line);
            }
            else
            {
                richTextCodeBase.Lines = null;
            }
        }

        int selectedDefIndex;
        bool selectedDefValid = false;

        private void putSelectedDefCode()
        {
            if (selectedDefValid && selectedDefIndex >= 0)
            {
                foundation.Dictionary[selectedDefIndex].CopyAsCode(richTextCodeDef.Lines);
            }
        }

        private void takeSelectedDefCode()
        {
            if (!selectedDefValid)
            {
                richTextCodeDef.Lines = null;
                return;
            }

            string[] code = foundation.Dictionary[selectedDefIndex].GetCode();
            if (code != null)
            {
                richTextCodeDef.Clear();

                foreach (string line in code)
                    richTextCodeDef.AppendText(line);
            }
            else
            {
                richTextCodeDef.Lines = null;
            }
        }

        private void dictionaryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            putSelectedDefCode();

            selectedDefIndex = dictionaryBox.SelectedIndex;
            if (selectedDefIndex >= 0)
            {
                selectedDefValid = true;

                foundation.Plane.MakeInstAtCursor(foundation.Dictionary[selectedDefIndex]);
                defProperties.SelectedObject = foundation.Dictionary[selectedDefIndex];

                buttonMoveUpDef.Enabled = true;
                buttonMoveDownDef.Enabled = true;
                buttonDeleteDef.Enabled = true;

                richTextCodeDef.Enabled = true;

                takeSelectedDefCode();
            }
            else
            {
                selectedDefValid = false;

                buttonMoveUpDef.Enabled = false;
                buttonMoveDownDef.Enabled = false;
                buttonDeleteDef.Enabled = false;

                richTextCodeDef.Enabled = false;
                richTextCodeDef.Lines = null;
            }
        }

        int selectedInstIndex = -1;
        bool selectedInstValid = false;

        private void putSelectedInstCode()
        {
            if (selectedInstValid && selectedInstIndex >= 0)
            {
                foundation.Level[selectedInstIndex].CopyAsCode(richTextCodeInst.Lines);
            }
        }

        private void takeSelectedInstCode()
        {
            if (!selectedInstValid)
            {
                richTextCodeDef.Lines = null;
                return;
            }

            string[] code = foundation.Level[selectedInstIndex].GetCode();
            if (code != null)
            {
                richTextCodeInst.Clear();

                foreach (string line in code)
                    richTextCodeInst.AppendText(line);
            }
            else
            {
                richTextCodeInst.Lines = null;
            }
        }

        private void levelBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            putSelectedInstCode();

            selectedInstIndex = levelBox.SelectedIndex;
            if (selectedInstIndex >= 0)
            {
                selectedInstValid = true;

                foundation.Plane.ForgetInstAtCursor();
                instProperties.SelectedObject = foundation.Level[selectedInstIndex];

                buttonMoveUpInst.Enabled = true;
                buttonMoveDownInst.Enabled = true;
                buttonDeleteInst.Enabled = true;

                richTextCodeInst.Enabled = true;

                takeSelectedInstCode();
            }
            else
            {
                selectedInstValid = false;

                buttonMoveUpInst.Enabled = false;
                buttonMoveDownInst.Enabled = false;
                buttonDeleteInst.Enabled = false;

                richTextCodeInst.Enabled = false;
                richTextCodeInst.Lines = null;
            }
        }

        private void numericGridW_ValueChanged(object sender, EventArgs e)
        {
            Size size = new Size();
            size.Width = (int)numericGridW.Value;
            size.Height = foundation.Plane.GridCellSize.Height;
            foundation.Plane.GridCellSize = size;
        }

        private void numericGridH_ValueChanged(object sender, EventArgs e)
        {
            Size size = new Size();
            size.Width = foundation.Plane.GridCellSize.Width;
            size.Height = (int)numericGridH.Value;
            foundation.Plane.GridCellSize = size;
        }

        private void checkShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            foundation.Plane.IsDrawGrid = checkShowGrid.Checked;
        }

        private void checkSnapGrid_CheckedChanged(object sender, EventArgs e)
        {
            foundation.Plane.IsSnapGrid = checkShowGrid.Checked;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // @TODO@ ask about saving

            foundation.Reset();

            takeBaseCode();
            takeSelectedDefCode();
            takeSelectedInstCode();
        }

        private void newLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // @TODO@ ask about saving

            foundation.ResetLevel();

            takeBaseCode();
            takeSelectedDefCode();
            takeSelectedInstCode();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // @TODO@ will user lose all unsaved data?

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PSM Files|*.psm;*.txt";
            openFileDialog.Title = "Load From File(s)";

            if (openFileDialog.ShowDialog() != DialogResult.OK ||
                openFileDialog.FileName == null ||
                openFileDialog.FileName.Length == 0)
                return;

            string dictFilePath = foundation.ExtractDictionaryPathFromLevelFile(openFileDialog.FileName);

            if (dictFilePath != null)
            {
                if (foundation.Dictionary.Load(dictFilePath))
                {
                    if (foundation.Level.Load(openFileDialog.FileName))
                        takeBaseCode();
                }
            }
            else
            {
                foundation.Dictionary.Load(openFileDialog.FileName);
            }

            onDictAndLevelChanged();
        }

        private bool saveDictionaryAskPath()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PSM Dictionary File|*.psm;*.txt";
            saveFileDialog.Title = "Save Dictionary";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != null && 
                saveFileDialog.FileName.Length != 0)
            {
                return foundation.Dictionary.Save(saveFileDialog.FileName);
            }
            else
            {
                return false;
            }
        }

        private bool saveLevelAskPath()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PSM Level File|*.psm;*.txt";
            saveFileDialog.Title = "Save Level";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != null &&
                saveFileDialog.FileName.Length != 0)
            {
                return foundation.Level.Save(saveFileDialog.FileName);
            }
            else
            {
                return false;
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            putBaseCode();
            putSelectedDefCode();
            putSelectedInstCode();

            if (foundation.Dictionary.GetFilePath() != null && 
                foundation.Dictionary.GetFilePath().Length != 0)
            {
                if (!foundation.Dictionary.Save()) return;
            }
            else
            {
                MessageBox.Show("You will now save the dictionary.", "Save Dictionary");
                if (!saveDictionaryAskPath()) return;
            }

            if (foundation.Level.GetFilePath() != null &&
                foundation.Level.GetFilePath().Length != 0)
            {
                foundation.Level.Save();
            }
            else
            {
                MessageBox.Show("You will now save the level.", "Save Level");
                saveLevelAskPath();
            }
        }

        private void saveDictionaryAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            putSelectedDefCode();

            saveDictionaryAskPath();
        }

        private void saveLevelAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // @TODO@ track for changes

            putBaseCode();
            putSelectedInstCode();

            saveToolStripMenuItem1_Click(null, null);
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            putBaseCode();
            putSelectedDefCode();
            putSelectedInstCode();

            // @TODO@
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // @TODO@ ask about saving

            Application.Exit();
        }

        private void levelBox_MouseLeave(object sender, EventArgs e)
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

        private void pictureBoxEdit_Click(object sender, EventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void textCodeInst_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
