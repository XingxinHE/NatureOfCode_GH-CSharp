using System;
using System.Collections.Generic;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace NatureOfCode_Cs.Introduction
{
    public class randomWalker : GH_Component
    {

        public Walker walker = new Walker(0,0);

        public randomWalker()
          : base("Random Walker", "RndWalker",
              "The random walker in the intro section(Timer Required)",
              "NOC", "Intro")
        {
        }


        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Reset", "Reset", "Reset the walker", GH_ParamAccess.item, false);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Walker", "Walker", "The random walker as a point", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //retrieve input from gh
            bool iReset = false;

            DA.GetData("Reset", ref iReset);

            walker.Step();

            if (iReset)
            {
                walker.Reset();
            }

            DA.SetData("Walker", new Point3d(walker.x, walker.y, 0));

        }


        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Properties.Resources.RandomWalker;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("1bd923c2-ff50-4a6a-9021-67800732e591"); }
        }
    }
}
