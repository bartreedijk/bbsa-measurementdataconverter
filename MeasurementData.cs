using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiobasedSoundAbsorption
{
    public struct MeasurementData
    {
        public string Id { get; set; }
        public string File { get; set; }
        public int[] OctaveFrequencyValues { get; set; }
        public float[] OctaveRt20Values { get; set; }
        public float[] OctaveRt30Values { get; set; }
        public int[] OneThirdOctaveFrequencyValues { get; set; }
        public float[] OneThirdOctaveRt20Values { get; set; }
        public float[] OneThirdOctaveRt30Values { get; set; }

        public void ExportToCsv(string path)
        {
            CsvExport export = new CsvExport();
            export.AddRow();
            if (OctaveFrequencyValues != null)
                for (int i = 0; i < OctaveFrequencyValues.Length; i++)
                {
                    export[i.ToString()] = OctaveFrequencyValues[i];
                }
            export.AddRow();
            if (OctaveRt20Values != null)
                for (int i = 0; i < OctaveRt20Values.Length; i++)
                {
                    export[i.ToString()] = OctaveRt20Values[i];
                }
            export.AddRow();
            if (OctaveRt30Values != null)
                for (int i = 0; i < OctaveRt30Values.Length; i++)
                {
                    export[i.ToString()] = OctaveRt30Values[i];
                }
            export.AddRow();
            if (OneThirdOctaveFrequencyValues != null)
                for (int i = 0; i < OneThirdOctaveFrequencyValues.Length; i++)
                {
                    export[i.ToString()] = OneThirdOctaveFrequencyValues[i];
                }
            export.AddRow();
            if (OneThirdOctaveRt20Values != null)
                for (int i = 0; i < OneThirdOctaveRt20Values.Length; i++)
                {
                    export[i.ToString()] = OneThirdOctaveRt20Values[i];
                }
            export.AddRow();
            if (OneThirdOctaveRt30Values != null)
                for (int i = 0; i < OneThirdOctaveRt30Values.Length; i++)
                {
                    export[i.ToString()] = OneThirdOctaveRt30Values[i];
                }
            export.ExportToFile(path);
        }
    }
}
