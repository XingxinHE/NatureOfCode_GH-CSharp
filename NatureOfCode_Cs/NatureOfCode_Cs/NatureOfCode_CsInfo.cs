using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace NatureOfCode_Cs
{
    public class NatureOfCode_CsInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "Introduction";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("4702a194-4b36-4c08-a80d-eb02f0c5286f");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
