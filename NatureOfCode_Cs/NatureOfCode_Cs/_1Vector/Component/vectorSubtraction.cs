using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Rhino.DocObjects;
using Rhino.UI;
using Rhino.Display;


namespace NatureOfCode_Cs._1Vector
{
    public class vectorSubtraction : GH_Component
    {

        public vectorSubtraction()
          : base("Vector Subtraction", "Subtraction",
              "Subtraction",
              "NOC", "1_Vector")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {

        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Cursor Point", "Cursor", "Cursor", GH_ParamAccess.item);
            pManager.AddLineParameter("Line To Origin", "Line", "Line between cursor and origin", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //declare variables
            var doc = Rhino.RhinoDoc.ActiveDoc;
            var view = doc.Views.ActiveView.ActiveViewport;
            Point3d cursor = view.ClientToWorld(view.ScreenToClient(new System.Drawing.Point((int)MouseCursor.Location.X, (int)MouseCursor.Location.Y))).From;

            Line cursorToOrigin = new Line(cursor, new Point3d(0, 0, 0));

            DA.SetData("Cursor Point", cursor);
            DA.SetData("Line", cursorToOrigin);
        }

        protected override System.Drawing.Bitmap Icon
        {
            get
            {

                return null;
            }
        }

        public override Guid ComponentGuid
        {
            get { return new Guid("fcb6d00b-3d57-4155-a8f6-e91d8acd0b21"); }
        }
    }
}
