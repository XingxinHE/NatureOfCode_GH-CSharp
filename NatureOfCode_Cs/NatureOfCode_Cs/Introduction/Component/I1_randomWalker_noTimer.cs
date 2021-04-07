using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace NatureOfCode_Cs.Introduction
{
    public class I1_randomWalker_noTimer : GH_Component
    {
        public I1_randomWalker_noTimer()
          : base("Random Walker Static", "RndWalker static",
              "The random walker in the intro section(no Timer required)",
              "NOC", "Intro")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("Seed", "Seed", "The seed to randomize", GH_ParamAccess.item, 0);
            pManager.AddIntegerParameter("Time", "Time", "Timer to mimic frame in Processing", GH_ParamAccess.item, 0);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Walkers", "Walkers", "The random walker as a list of points", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //declare variables
            int seed = 0;
            int time = 0;

            //retrieve data from GH
            DA.GetData("Seed", ref seed);
            DA.GetData("Time", ref time);

            //main
            List<Point3d> wPoints = new List<Point3d>();
            Walker w = new Walker(0, 0, seed);
            for (int i = 0; i < time; i++)
            {
                w.Step();
                wPoints.Add(new Point3d(w.x, w.y, 0));
            }

            //Export to GH
            DA.SetDataList("Walkers", wPoints);
        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.RandomWalker_noTimer;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("0950da76-92b6-4043-8651-940f6723bfd0"); }
        }
    }
}