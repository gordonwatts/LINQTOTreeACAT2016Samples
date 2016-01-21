using ROOTNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3HistogramFunctional
{
    class Program
    {
        static void Main(string[] args)
        {
            var h = new NTH1F("h1", "Hist", 100, 0.0, 10.0)
                .XaxisTitle("p_T [GeV]")
                .YaxisTitle("N/1 GeV");

            h.Fill(1.0);
        }
    }

    static class HistUtils
    {
        public static NTH1F XaxisTitle (this NTH1F h, string title)
        {
            h.Xaxis.SetTitle(title);
            return h;
        }
        public static NTH1F YaxisTitle(this NTH1F h, string title)
        {
            h.Yaxis.SetTitle(title);
            return h;
        }

        public static NTH1F XaxisTitleC(this NTH1F h, string title)
        {
            h = h.Clone() as NTH1F;
            h.Xaxis.SetTitle(title);
            return h;
        }
        public static NTH1F YaxisTitleC(this NTH1F h, string title)
        {
            h = h.Clone() as NTH1F;
            h.Yaxis.SetTitle(title);
            return h;
        }
    }

}