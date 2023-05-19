using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace SolidWorksMacro
{
    public class Macro
    {
        public static void Main(string[] args)
        {
            // Создание экземпляра SolidWorks
            SldWorks swApp = new SldWorks();
            // Создание новой детали
            ModelDoc2 swModel = swApp.NewPart();
            // Добавление скетча
            swModel.InsertSketch2(true);
            // Создание прямоугольника в скетче
            SketchManager swSketchMgr = swModel.SketchManager;
            swSketchMgr.CreateCenterRectangle(0, 0, 0, 0.1, 0.1, 0);
            // Завершение скетча
            swModel.InsertSketch2(true);
            // Сохранение детали
            string filePath = "C:\\Path\\To\\Save\\File.sldprt";
            swModel.SaveAs3(filePath, (int)swSaveAsVersion_e.swSaveAsCurrentVersion, 
                (int)swSaveAsOptions_e.swSaveAsOptions_Silent);
            // Закрытие детали и SolidWorks
            swApp.CloseAllDocuments(true);
            swApp.ExitApp();
        }
    }
}