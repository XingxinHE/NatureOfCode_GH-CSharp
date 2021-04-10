using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Rhino.DocObjects;
using Rhino.UI;
using Rhino.Display;

namespace NatureOfCode_Cs._1Vector.Component
{
    public class vectorMagnitude : GH_Component
    {
        public vectorMagnitude()
          : base("Vector Magnitude", "Magnitude",
              "Vector Magnitude",
              "NOC", "1_Vector")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Band Height", "Height", "The height of the band", GH_ParamAccess.item, 20.0);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddRectangleParameter("Band", "Band", "Band", GH_ParamAccess.item);
            pManager.AddPointParameter("Cursor Point", "Cursor", "Cursor", GH_ParamAccess.item);
            pManager.AddLineParameter("Line To Origin", "Line", "Line between cursor and origin", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //declare
            double bandHeight = 0.0;
            var doc = Rhino.RhinoDoc.ActiveDoc;
            var view = doc.Views.ActiveView.ActiveViewport;
            double bandWidth = 0.0;

            //retrieve
            DA.GetData("Band Height", ref bandHeight);

            //MAIN
            Point3d cursor = view.ClientToWorld(view.ScreenToClient(new System.Drawing.Point((int)MouseCursor.Location.X, (int)MouseCursor.Location.Y))).From;
            Line cursorToOrigin = new Line(cursor, new Point3d(0, 0, 0));
            //  PVector, subtraction and magnitude
            PVector mouse = new PVector(cursor.X, cursor.Y);
            PVector center = new PVector(0, 0);
            mouse.Sub(center);
            bandWidth = mouse.Mag();
            //  create band
            Rectangle3d band = new Rectangle3d(Plane.WorldXY, bandWidth, bandHeight);

            //output
            DA.SetData("Band", band);
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
            get { return new Guid("452a3aaf-deac-452c-be81-818402579e06"); }
        }
    }
}