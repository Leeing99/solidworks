using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;


namespace SwAPIdiploma
{
    public class PartModel
    {
        public string PartName { get; set; }

        public double Dim_A { get; set; }
        public double Dim_B { get; set; }
        public double Dim_H1 { get; set; }
        public double Dim_H2 { get; set; }
        public double Dim_D1 { get; set; }
        public double Dim_D2 { get; set; }
        public double Dim_D3 { get; set; }


        SldWorks swApp;
        ModelDoc2 swModel;
        Feature swFeature;
        bool status;
        string defaultPartTemplate;

        public void CreatePart()
        {
            string guid = Guid.NewGuid().ToString();
            string root = @"C:\\" + guid;
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            else
            {
                MessageBox.Show("A file with the same name exists...");
            }

            swApp = GetSolidworks.GetApplication();

            defaultPartTemplate = swApp.GetUserPreferenceStringValue((int)
                swUserPreferenceStringValue_e.swDefaultTemplatePart);
            swApp.NewDocument(defaultPartTemplate, 0, 0, 0);

            swModel = (ModelDoc2)swApp.ActiveDoc;
            swFeature = swModel.FeatureByPositionReverse(2);
            swFeature.Name = "Refplane";

            status = swModel.Extension.SelectByID2("Refplane", "PLANE", 0, 0, 0, false, 0, null, 0);

            swModel.InsertSketch2(true);

            swModel.CreateCircleByRadius2(Dim_A / 2, Dim_A / 2, 0, Dim_D1 / 2);

            swModel.CreateLine2(0, 0, 0, Dim_A, 0, 0);
            swModel.CreateLine2(Dim_A, 0, 0, Dim_A, Dim_A, 0);
            swModel.CreateLine2(Dim_A, Dim_A, 0, 0, Dim_A, 0);
            swModel.CreateLine2(0, 0, 0, 0, Dim_A, 0);

            swModel.CreateCircleByRadius2(Dim_B, Dim_B, 0, Dim_D3 / 2);
            swModel.CreateCircleByRadius2(Dim_A - Dim_B, Dim_B, 0, Dim_D3 / 2);
            swModel.CreateCircleByRadius2(Dim_A - Dim_B, Dim_A - Dim_B, 0, Dim_D3 / 2);
            swModel.CreateCircleByRadius2(Dim_B, Dim_A - Dim_B, 0, Dim_D3 / 2);

            swModel.InsertSketch2(true);

            swFeature = swModel.FeatureByPositionReverse(0);
            swFeature.Name = "Sketch1";

            status = swModel.Extension.SelectByID2("Sketch1", "SKETCH", 0, 0, 0, false, 0, null, 0);

            swModel.FeatureManager.FeatureExtrusion3
                (true, false, false, 0, 0, Dim_H1, 0, false, false, false, false, 0, 0, false, false, false, false, false, false, false, 0, 0, false);

            status = swModel.Extension.SelectByID2("", "FACE", Dim_B / 2, Dim_H1, -Dim_B / 2, false, 0, null, 0);

            swModel.InsertSketch2(true);

            swModel.CreateCircleByRadius2(Dim_A / 2, Dim_A / 2, 0, Dim_D1 / 2);
            swModel.CreateCircleByRadius2(Dim_A / 2, Dim_A / 2, 0, Dim_D2 / 2);

            swModel.InsertSketch2(true);

            swFeature = swModel.FeatureByPositionReverse(0);
            swFeature.Name = "Sketch2";

            status = swModel.Extension.SelectByID2("Sketch2", "SKETCH", 0, 0, 0, false, 0, null, 0);

            swModel.FeatureManager.FeatureExtrusion3
               (true, false, false, 0, 0, Dim_H2, 0, false, false, false, false, 0, 0, false, false, false, false, true, false, false, 0, 0, false);

            swModel.ViewZoomtofit2();
            swModel.ForceRebuild3(true);

            swModel.SaveAs3(root.ToString() + "\\" + PartName + ".sldprt", (int)
                swSaveAsVersion_e.swSaveAsCurrentVersion, (int)swSaveAsOptions_e.swSaveAsOptions_CopyAndOpen);




        }



    }
}
