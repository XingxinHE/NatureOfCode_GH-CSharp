using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace Introduction
{
    public class I2_noiseWalker_noTimer : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the I2_noiseWalker_noTimer class.
        /// </summary>
        public I2_noiseWalker_noTimer()
          : base("Perlin Noise Walker Static", "NoiseWalker Static",
              "The Perlin Noise walker in the intro section(no Timer required)",
              "NOC", "Intro")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("Time", "Time", "Timer to mimic frame in Processing", GH_ParamAccess.item, 0);
            pManager.AddNumberParameter("Scale", "Scale", "The scale of the step from Noise walker", GH_ParamAccess.item, 1.0);
            pManager.AddIntegerParameter("Seed", "Seed", "The seed to randomize", GH_ParamAccess.item, 0);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Walkers", "Walkers", "The random walker as a list of points", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //declare variables in GH
            int time = 0;
            double scale = 1.0;
            int seed = 0;

            //retrieve data
            DA.GetData("Time", ref time);
            DA.GetData("Scale", ref scale);
            DA.GetData("Seed", ref seed);

            //main
            List<Point3d> wPoints = new List<Point3d>();
            Walker w = new Walker(0, 0);
            float noiseTime = 0 + seed * 1000F; //the time in Noise function
            for (int i = 0; i < time; i++) //the pseudo time set by GH
            {
                w.StepNoise(noiseTime, (float)scale);
                wPoints.Add(new Point3d(w.x, w.y, 0));
                noiseTime += 0.1F;  //increment Noise time
            }

            //Export to GH
            DA.SetDataList("Walkers", wPoints);
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
            get { return new Guid("1ec1aae7-408a-4899-b6eb-5c37cbb6233d"); }
        }
    }
}