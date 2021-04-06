using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Rhino.DocObjects;

// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace _1Vector
{
    public class vectorSubtraction : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public vectorSubtraction()
          : base("Vector Subtraction", "Subtraction",
              "Subtraction",
              "NOC", "1_Vector")
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
            pManager.AddPointParameter("Cursor Point", "Cursor", "Cursor", GH_ParamAccess.item);
            pManager.AddLineParameter("Line", "Line", "Line between cursor and origin", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //declare variables
            var doc = Rhino.RhinoDoc.ActiveDoc;
            var view = doc.Views.ActiveView;
            var xform = view.ActiveViewport.GetTransform(Rhino.DocObjects.CoordinateSystem.Screen, Rhino.DocObjects.CoordinateSystem.World);
            Point3d cursor = new Rhino.Geometry.Point3d(Rhino.UI.MouseCursor.Location.X, Rhino.UI.MouseCursor.Location.Y, 0.0);
            cursor.Transform(xform);

            Line lineCursorOrigin = new Line(cursor, new Point3d(0, 0, 0));

            DA.SetData("Cursor Point", cursor);
            DA.SetData("Line", lineCursorOrigin);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("fcb6d00b-3d57-4155-a8f6-e91d8acd0b21"); }
        }
    }
}
