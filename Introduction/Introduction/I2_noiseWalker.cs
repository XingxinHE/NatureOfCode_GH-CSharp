using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Introduction
{
    public class I2_noiseWalker : GH_Component
    {
        public Walker walker = new Walker(0, 0);
        public I2_noiseWalker()
          : base("Perlin Noise Walker", "NoiseWalker",
              "The Perlin Noise walker in the intro section(Timer required)",
              "NOC", "Intro")
        {
        }


        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Reset", "Reset", "Reset the Noise walker", GH_ParamAccess.item, false);
            pManager.AddNumberParameter("Scale", "Scale", "The scale of the step from Noise walker", GH_ParamAccess.item, 1.0);
        }

        
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Walker", "Walker", "The Noise walker as a point", GH_ParamAccess.item);
        }

        public static float time = 0F; //mimic the time in processing
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //declare variables
            bool iReset = false;
            double iScale = 1.0;

            //retrieve data from GH
            DA.GetData("Reset", ref iReset);
            DA.GetData("Scale", ref iScale);

            time += 0.1F; //everytime GH timer refresh +0.1F; the incrementation should be lower than 1!!
            walker.StepNoise(time, (float)iScale);

            if (iReset)
            {
                walker.Reset();
                time = 0F;
            }

            DA.SetData("Walker", new Point3d(walker.x, walker.y, 0));
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("67bc6256-ca03-460f-9975-ed9a67bd35c6"); }
        }
    }
}