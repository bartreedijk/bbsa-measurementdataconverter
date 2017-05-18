using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MeasurementDataConverter;

namespace BiobasedSoundAbsorption
{
    public class MeasurementDataImporter
    {
        private MeasurementData _measurementData;

        public MeasurementDataImporter()
        {
            _measurementData = new MeasurementData();
        }

        public MeasurementData ReadFile(string filePath)
        {
            bool octaveBandAvailable = false;
            bool thirdOctaveAvailable = false;
            _measurementData.File = filePath;
            string[] lines = File.ReadAllLines(filePath);
            foreach (var s in lines)
            {
                if (s == "One-third octave filtered data") thirdOctaveAvailable = true;
                if (s == "Octave filtered data") octaveBandAvailable = true;
            }
            if (octaveBandAvailable) ReadFileOctave(filePath, lines);
            if (thirdOctaveAvailable) ReadFileOneThirdOctave(filePath, lines);
            // ReSharper disable once StringLastIndexOfIsCultureSpecific.1
            _measurementData.Id = filePath.Substring(filePath.LastIndexOf(@"\"));
            Program.MeasurementDataList.Add(_measurementData);
            return _measurementData;
        }

        public void ReadFileOctaveBand(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            ReadFileOctave(filePath, lines);
        }

        private void ReadFileOctave(string filePath, string[] lines)
        {
            int[] FreqValues = new int[23];
            float[] RT30values = new float[8];
            float[] RT20values = new float[8];
            string[] valueBuffer = new string[13];
            int i = 0;
            while (lines[i] != "Octave filtered data") i++; // go to data
            i++; // fist line with data
            for (int j = 0; j < RT30values.Length; j++)
            {
                
                try
                {
                    valueBuffer = lines[i + j].Split(' ');
                    if (valueBuffer[0] != "")
                        FreqValues[j] = (int)double.Parse(valueBuffer[0].Replace('.', ','));
                    RT20values[j] = float.Parse(valueBuffer[4].Replace('.', ','));
                    RT30values[j] = float.Parse(valueBuffer[6].Replace('.', ','));
                }
                catch (IndexOutOfRangeException)
                {

                }
            }
            _measurementData.OctaveFrequencyValues = FreqValues;
            _measurementData.OctaveRt20Values = RT20values;
            _measurementData.OctaveRt30Values = RT30values;
        }

        public void ReadFileOneThirdOctave(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            ReadFileOneThirdOctave(filePath, lines);
        }

        private void ReadFileOneThirdOctave(string filePath, string[] lines)
        {
            int[] FreqValues = new int[23];
            float[] RT30values = new float[23];
            float[] RT20values = new float[23];
            string[] valueBuffer = new string[13];
            int i = 0;
            while (lines[i] != "One-third octave filtered data") i++; // go to data
            i++; // fist line with data
            for (int j = 0; j < RT30values.Length; j++)
            {
                try
                {
                    valueBuffer = lines[i + j].Split(' ');
                    if (valueBuffer[0] != "")
                        FreqValues[j] = (int)double.Parse(valueBuffer[0].Replace('.', ','));
                    RT20values[j] = float.Parse(valueBuffer[4].Replace('.', ','));
                    RT30values[j] = float.Parse(valueBuffer[6].Replace('.', ','));
                }
                catch (IndexOutOfRangeException)
                {

                }
                
            }
            _measurementData.OneThirdOctaveFrequencyValues = FreqValues;
            _measurementData.OneThirdOctaveRt20Values = RT20values;
            _measurementData.OneThirdOctaveRt30Values = RT30values;
        }
    }
}
