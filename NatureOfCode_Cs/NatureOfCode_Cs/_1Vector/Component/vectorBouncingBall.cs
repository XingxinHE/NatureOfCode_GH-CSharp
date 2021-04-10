using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace NatureOfCode_Cs._1Vector.Component
{
    public class vectorBouncingBall : GH_Component
    {

        public vectorBouncingBall()
          : base("Vector Bouncing Ball", "Bouncing Ball",
              "Create bouncing ball using vectors",
              "NOC", "1_Vector")
        {
        }


        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Reset", "Reset", "Reset", GH_ParamAccess.item, false);
            pManager.AddRectangleParameter("Bouncing Region", "Region", "The region of bouncing ball", GH_ParamAccess.item, new Rectangle3d(Plane.WorldXY, 200.0, 100.0));
            pManager.AddPointParameter("Initial Position", "Initial Pos", "Bouncing Ball Initial Position", GH_ParamAccess.item, new Point3d(10.0, 10.0, 0));
            pManager.AddVectorParameter("Velocity", "Velocity", "Velocity", GH_ParamAccess.item, new Vector3d(0.1, 0.5, 0));
        }


        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddPointParameter("Bouncing Ball", "Bouncing Ball", "Bouncing Ball", GH_ParamAccess.item);
        }

        public static PVector location = new PVector(10.0, 10.0);
        public static PVector velocity = new PVector(0.1, 0.5);

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            //declare variables
            bool reset = false;
            Rectangle3d bouncingRegion = new Rectangle3d(Plane.WorldXY, 200.0, 100.0);
            Point3d initialPos = new Point3d(0, 0, 0);
            Vector3d vel = new Vector3d(0, 0, 0);

            //retrieve data
            DA.GetData("Reset", ref reset);
            DA.GetData("Bouncing Region", ref bouncingRegion);
            DA.GetData("Initial Position", ref initialPos);
            DA.GetData("Velocity", ref vel);


            //main
            if (reset)
            {
                location.x = initialPos.X;
                location.y = initialPos.Y;
                velocity.x = vel.X;
                velocity.y = vel.Y;
            }

            location.Add(velocity);
            if ((location.x > bouncingRegion.Width) || (location.x < 0))
            {
                velocity.x = velocity.x * -1;
            }
            if ((location.y > bouncingRegion.Height) || (location.y < 0))
            {
                velocity.y = velocity.y * -1;
            }

            //output
            Point3d bouncingBall = new Point3d(location.x, location.y, 0);
            DA.SetData("Bouncing Ball", bouncingBall);
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
            get { return new Guid("c2e9d787-a77e-4455-8a94-673d4596ed20"); }
        }
    }
}