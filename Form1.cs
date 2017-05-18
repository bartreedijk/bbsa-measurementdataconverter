using BiobasedSoundAbsorption;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeasurementDataConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            converteerTxtNaarCsvToolStripMenuItem_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            converteerTxtNaarCsvmapToolStripMenuItem_Click(sender, e);
        }

        private void converteerTxtNaarCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogTxtToCsv.ShowDialog();
            ConverteerTxtNaarCsv(openFileDialogTxtToCsv.FileName);
        }

        private void converteerTxtNaarCsvmapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folderBrowserDialogTxtToCsv.ShowDialog();
            var files = Directory.GetFiles(folderBrowserDialogTxtToCsv.SelectedPath);
            foreach (var file in files)
            {
                if (file.Substring(file.Length - 4) == ".txt") // check if it's a txt file
                    ConverteerTxtNaarCsv(file);
            }
        }

        private void ConverteerTxtNaarCsv(string path)
        {
            MeasurementDataImporter importer = new MeasurementDataImporter();
            var m = importer.ReadFile(path);
            m.ExportToCsv(path + ".csv");
        }
    }
}
