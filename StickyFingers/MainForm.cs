﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StickyFingers.Variables;
using static StickyFingers.Methods;

namespace StickyFingers
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void EnableButtons()
        {
            if (xfbin1Open) exportNud1.Enabled = true;
            else exportNud1.Enabled = false;
            if (xfbin2Open)
            {
                exportNud2.Enabled = true;
                //if (xfbin1Open) replaceButton.Enabled = true;
                //else replaceButton.Enabled = false;
            }
            else exportNud2.Enabled = false;
        }
        private void Xfbin1Browse_Click(object sender, EventArgs e)
        {
            if (openXfbin1Dialog.ShowDialog() == DialogResult.OK)
            {
                if (XfbinOpen(1, openXfbin1Dialog.FileName))
                {
                    xfbin1Box.Text = xfbin1Path;
                    foreach (var nameInList in meshList1)
                    {
                        mesh1Box.Items.Add(nameInList.MeshName);
                    }
                    mesh1Box.SelectedIndex = 0;
                    mesh1Box.Focus(); 
                }
                EnableButtons();
            }
        }
        private void Xfbin2Browse_Click(object sender, EventArgs e)
        {
            if (openXfbin2Dialog.ShowDialog() == DialogResult.OK)
            {
                if (XfbinOpen(2, openXfbin2Dialog.FileName))
                {
                    xfbin2Box.Text = xfbin2Path;
                    foreach (var nameInList in meshList2)
                    {
                        mesh2Box.Items.Add(nameInList.MeshName);
                    }
                    mesh2Box.SelectedIndex = 0;
                    mesh2Box.Focus();
                }
                EnableButtons();
            }
        }
        private void Mesh1Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshProperties(1);
        }
        private void Mesh2Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshProperties(2);
        }
        public void RefreshProperties(int xfbinNo)
        {
            int x;
            if (xfbinNo == 1)
            {
                x = mesh1Box.SelectedIndex;
                mesh1IndexLabel.Text = meshList1[x].MeshIndex.ToString();
                group1Label.Text = meshList1[x].GroupCount.ToString();
                mat1Label.Text = meshList1[x].Material;
                if (meshList1[x].Mirror) mirrorState1Label.Text = "Yes";
                else mirrorState1Label.Text = "No";

            }
            else if (xfbinNo == 2)
            {
                x = mesh2Box.SelectedIndex;
                mesh2IndexLabel.Text = meshList2[x].MeshIndex.ToString();
                group2Label.Text = meshList2[x].GroupCount.ToString();
                mat2Label.Text = meshList2[x].Material;
                if (meshList2[x].Mirror) mirrorState2Label.Text = "Yes";
                else mirrorState2Label.Text = "No";
            }
        }
        public void XfbinClose(int xfbinNo)
        {
            if (xfbinNo == 1)
            {
                mesh1Box.Items.Clear();
                xfbin1Box.Text = "";
                mesh1IndexLabel.Text = "";
                group1Label.Text = "";
                mat1Label.Text = "";
                mirrorState1Label.Text = "";
                meshCount1 = 0;
                if (xfbin1Open)
                {
                    file1Bytes.Clear();
                    meshList1.Clear();
                }
                xfbin1Open = false;
            }
            else if (xfbinNo == 2)
            {
                mesh2Box.Items.Clear();
                xfbin2Box.Text = "";
                mesh2IndexLabel.Text = "";
                group2Label.Text = "";
                mat2Label.Text = "";
                mirrorState2Label.Text = "";
                meshCount2 = 0;
                if (xfbin2Open)
                {
                    file2Bytes.Clear();
                    meshList2.Clear();
                }
                xfbin2Open = false;
            }
        }
        private void ExportNud1_Click(object sender, EventArgs e)
        {
            ExportNud(file1Bytes, meshList1, mesh1Box.SelectedIndex);
        }
        private void ExportNud2_Click(object sender, EventArgs e)
        {
            ExportNud(file1Bytes, meshList2, mesh2Box.SelectedIndex);
        }
    }
}