using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Rhino.DocObjects;
using Rhino.UI;
using Rhino.Display;

namespace NatureOfCode_Cs._1Vector.Component
{
    public class vectorNormalization : GH_Component
    {
        public vectorNormalization()
          : base("Vector Normalization", "Normalization",
              "Normalization",
              "NOC", "1_Vector")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Scale of the line", "Scale", "Scale", GH_ParamAccess.item, 50);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Cursor Point", "Cursor", "Cursor", GH_ParamAccess.item);
            pManager.AddLineParameter("Line To Origin", "Line", "Line between cursor and origin", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //declare variables
            double scale = 0.0;
            var doc = Rhino.RhinoDoc.ActiveDoc;
            var view = doc.Views.ActiveView.ActiveViewport;
            Point3d cursor = view.ClientToWorld(view.ScreenToClient(new System.Drawing.Point((int)MouseCursor.Location.X, (int)MouseCursor.Location.Y))).From;

            //retrieve data
            DA.GetData("Scale of the line", ref scale);

            //main
            PVector mouse = new PVector(cursor.X, cursor.Y);
            PVector center = new PVector(0, 0);
            mouse.Sub(center);
            mouse.Normalize();
            mouse.Mul(scale);

            Line cursorToOriginNormalized = new Line(new Point3d(0, 0, 0), new Point3d(mouse.x, mouse.y, 0));

            DA.SetData("Cursor Point", cursor);
            DA.SetData("Line", cursorToOriginNormalized);

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
            get { return new Guid("656241cf-ccae-45ef-8b2d-370f85afd59a"); }
        }
    }
}