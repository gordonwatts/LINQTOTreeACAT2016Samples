using libDataAccess;
using LINQToTreeHelpers;
using LINQToTreeHelpers.FutureUtils;
using LINQToTTreeLib;
using MC;
using ROOTNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1SimpleJetPt
{
    class Program
    {
        /// <summary>
        /// Load up data and plot the jet pT for jets with
        /// eta less than 1.5.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var t = new NTStopwatch();
            t.Start();

            var dataset = "user.emmat.mc15_13TeV.361022.Pythia8EvtGen_A14NNPDF23LO_jetjet_JZ2W.merge.AOD.e3668_s2576_s2132_r6765_r6282__EXOT15_v3_EXT0";
            var jobFiles = GRIDJobs.FindJobFiles("DiVertAnalysis", 3, dataset);

            var events = QueryablerecoTree.CreateQueriable(jobFiles);
            //events.CleanupQuery = false; // Set to keep C++ around
            //events.IgnoreQueryCache = true; // Set to ignore query cache for speed

            using (var f = new FutureTFile("S1.root"))
            {
                var count = events.FutureCount();
                events
                    .SelectMany(e => e.Jet)
                    .Where(j => Math.Abs(j.eta) < 1.5)
                    .FuturePlot("pt", "Jet pT; pT [GeV]", 100, 0.0, 100.0, j => j.pT)
                    .Save(f);

                Console.WriteLine($"Saw {count.Value} events.");
            }

            // Print out usage
            Console.WriteLine("Time taken to run this query:");
            t.Stop();
            t.Print();
        }
    }
}
