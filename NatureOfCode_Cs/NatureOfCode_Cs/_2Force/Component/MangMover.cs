using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace NatureOfCode_Cs._2Force.Component
{
    public class MangMover : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the MangMover class.
        /// </summary>
        public MangMover()
          : base("MangMover", "Nickname",
              "Description",
              "Category", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            var rand = new Random();

            List<Mover> movers = new List<Mover>();
            for (int i = 0; i < 10; i++)
            {
                Mover m = new Mover(rand.NextDouble() * (0.1 - 5) + 0.1, 0, 0);
                movers.Add(m);


            }

            //movers.Count
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
            get { return new Guid("5d058199-0dad-415b-a6e9-4b7864b42ca6"); }
        }
    }
}