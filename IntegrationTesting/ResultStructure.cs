using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using AqVision.Shape;
using HalconDotNet;

namespace TypeC_Aidi
{
    class ResultStructure
    {
        //private List<Form1.RootObject> resultList;


        #region Json解析，生成方便抽取元素的objList,并且对objList按特征（面积、长宽、坐标）进行筛选
        public static List<RootObject> GetobjList(string jsonText,
            double minArea = 0, double minWidth = 0, double minHeight = 0,
            double cxStart = 0, double cxEnd = 9999999, double cyStart = 0, double cyEnd = 9999999)
        {
            List<RootObject> objList = new List<RootObject>();
            if (jsonText.Length > 20)
            {
                //Json数据解析
                string str = jsonText;
                var arrdata = Newtonsoft.Json.Linq.JArray.Parse(jsonText);
                objList = arrdata.ToObject<List<RootObject>>();
            }
            else  //数据长度<20的肯定是无效数据
            {
                objList = new List<RootObject>();
            }

            objList = GetNeededObjectList(objList, minArea, minWidth, minHeight, cxStart, cxEnd, cyStart, cyEnd);
            return objList;
        }

        /// <summary> 根据面积、宽、高、x&y坐标等筛选ObjectList
        /// 
        /// </summary>
        /// <param name="objList"></param>
        /// <param name="minArea"></param>
        /// <param name="minWidth"></param>
        /// <param name="minHeight"></param>
        /// <param name="cxStart"></param>
        /// <param name="cxEnd"></param>
        /// <param name="cyStart"></param>
        /// <param name="cyEnd"></param>
        /// <returns></returns>
        public static List<RootObject> GetNeededObjectList(List<RootObject> objList,
            double minArea = 0, double minWidth = 0, double minHeight = 0,
            double cxStart = 0, double cxEnd = 9999999, double cyStart = 0, double cyEnd = 9999999)
        {
            List<RootObject> NeededObjectList = new List<RootObject>();
            for (int i = 0; i < objList.Count(); i++)
            {
                if (Convert.ToDouble(objList[i].area) >= minArea &&
                    Convert.ToDouble(objList[i].width) >= minWidth &&
                    Convert.ToDouble(objList[i].height) >= minHeight &&
                    (Convert.ToDouble(objList[i].cx) >= cxStart && Convert.ToDouble(objList[i].cx) <= cxEnd) &&
                    (Convert.ToDouble(objList[i].cy) >= cyStart && Convert.ToDouble(objList[i].cy) <= cyEnd))
                {
                    NeededObjectList.Add(objList[i]);
                }
            }
            return NeededObjectList;
        }

        #endregion


        #region Aidi和halcon的轮廓绘制
        void DrawLine(float sx, float sy, float ex, float ey, AqVision.Controls.AqDisplay aqDisplay, AqVision.AqColorConstants color, int lineWidth)
        {
            AqLineSegment lineSegment = new AqLineSegment();
            lineSegment.StartX = sx;
            lineSegment.StartY = sy;
            lineSegment.EndX = ex;
            lineSegment.EndY = ey;

            lineSegment.Color = color;
            lineSegment.LineWidthInScreenPixels = lineWidth;
            aqDisplay.InteractiveGraphics.Add(lineSegment, "", true);
        }

       

        //绘制aidi轮廓
        public void DrawAqDisplayContours(AqVision.Controls.AqDisplay aqDisplay, List<RootObject> objList, 
            AqVision.AqColorConstants color = AqVision.AqColorConstants.Green, int lineWidth = 1)
        {
            for (int i = 0; i < objList.Count(); i++)
            {
                for (int j = 0; j < objList[i].contours.Count - 1; j++)
                {

                    string temp = objList[i].contours[j].x;

                    float sx = float.Parse(objList[i].contours[j].x);
                    float sy = float.Parse(objList[i].contours[j].y);
                    float ex = float.Parse(objList[i].contours[j + 1].x);
                    float ey = float.Parse(objList[i].contours[j + 1].y);

                    DrawLine(sx, sy, ex, ey, aqDisplay, color, lineWidth);
                }
                //再设计一个点，补全多边形
                int n = objList[i].contours.Count;
                float nx = float.Parse(objList[i].contours[n - 1].x);
                float ny = float.Parse(objList[i].contours[n - 1].y);
                float zero_x = float.Parse(objList[i].contours[0].x);
                float zero_y = float.Parse(objList[i].contours[0].y);
                DrawLine(nx, ny, zero_x, zero_y, aqDisplay, color, lineWidth);

            }

        }


        //绘制halcon轮廓
        public void DrawAqDisplayContours(AqVision.Controls.AqDisplay aqDisplay, HObject drawRegions, HTuple drawTolerance,
            AqVision.AqColorConstants color = AqVision.AqColorConstants.Green, int lineWidth = 1)
        {
            HTuple rows;
            HTuple cols;
            HTuple breakPoints;
            GetRegionPoints(drawRegions, drawTolerance, out rows, out cols, out breakPoints);

            int sum = 0;
            for (int i = 0; i < breakPoints.Length; i++)
            {
                int _count = breakPoints[i];


                for (int j = 0; j < _count - 1; j++)
                {
                    double sx = cols[j + sum];
                    double sy = rows[j + sum];
                    double ex = cols[j + sum + 1];
                    double ey = rows[j + sum + 1];
                    DrawLine((float)sx, (float)sy, (float)ex, (float)ey, aqDisplay, color, lineWidth);
                }
                sum += _count;
            }
        }

        public void GetRegionPoints(HObject ho_Regions, HTuple hv_Tolerance, out HTuple hv_Rows,
            out HTuple hv_Cols, out HTuple hv_BreakPoints)
        {




            // Local iconic variables 

            HObject ho_RegionUnion, ho_ConnectedRegions;
            HObject ho_ObjectSelected = null;

            // Local control variables 

            HTuple hv_Num = null, hv_Index = null, hv_Rows0 = new HTuple();
            HTuple hv_Columns0 = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_RegionUnion);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_ObjectSelected);
            try
            {
                ho_RegionUnion.Dispose();
                HOperatorSet.Union1(ho_Regions, out ho_RegionUnion);
                ho_ConnectedRegions.Dispose();
                HOperatorSet.Connection(ho_RegionUnion, out ho_ConnectedRegions);
                HOperatorSet.CountObj(ho_ConnectedRegions, out hv_Num);

                hv_Rows = new HTuple();
                hv_Cols = new HTuple();
                hv_BreakPoints = new HTuple();

                HTuple end_val8 = hv_Num;
                HTuple step_val8 = 1;
                for (hv_Index = 1; hv_Index.Continue(end_val8, step_val8); hv_Index = hv_Index.TupleAdd(step_val8))
                {
                    ho_ObjectSelected.Dispose();
                    HOperatorSet.SelectObj(ho_ConnectedRegions, out ho_ObjectSelected, hv_Index);
                    HOperatorSet.GetRegionPolygon(ho_ObjectSelected, hv_Tolerance, out hv_Rows0,
                        out hv_Columns0);
                    hv_Rows = hv_Rows.TupleConcat(hv_Rows0);
                    hv_Cols = hv_Cols.TupleConcat(hv_Columns0);
                    hv_BreakPoints = hv_BreakPoints.TupleConcat(new HTuple(hv_Rows0.TupleLength()
                        ));
                }
                ho_RegionUnion.Dispose();
                ho_ConnectedRegions.Dispose();
                ho_ObjectSelected.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_RegionUnion.Dispose();
                ho_ConnectedRegions.Dispose();
                ho_ObjectSelected.Dispose();

                throw HDevExpDefaultException;
            }
        }


        public void ShowBitmap(AqVision.Controls.AqDisplay aqDisplay, Bitmap bitmap)
        {
            if (aqDisplay.InvokeRequired)
            {
                aqDisplay.BeginInvoke(new Action(() =>
                {
                    aqDisplay.Image = bitmap;
                    aqDisplay.FitToScreen();
                }));
            }
            else
            {
                aqDisplay.Image = bitmap;
                aqDisplay.FitToScreen();
            }
        }

        public void UpdateWindow(AqVision.Controls.AqDisplay aqDisplay)
        {
            if (aqDisplay.InvokeRequired)
            {
                aqDisplay.BeginInvoke(new Action(() => { aqDisplay.Update(); }));
            }
            else
            {
                aqDisplay.Update();
            }
        }

        public void CleanWindow(AqVision.Controls.AqDisplay aqDisplay)
        {
            aqDisplay.InteractiveGraphics.Clear();
        }


        //halcon
        public void ShowAllGraph(AqVision.Controls.AqDisplay aqDisplay, Bitmap bitmap, HObject drawRegions, HTuple drawTolerance, 
            AqVision.AqColorConstants color = AqVision.AqColorConstants.Green, int lineWidth = 1)
        {
            CleanWindow(aqDisplay);
            ShowBitmap(aqDisplay, bitmap);
            DrawAqDisplayContours(aqDisplay, drawRegions, drawTolerance, color, lineWidth);
            UpdateWindow(aqDisplay);
        }

        //aidi
        public void ShowAllGraph(AqVision.Controls.AqDisplay aqDisplay, Bitmap bitmap, List<RootObject> objList,
            AqVision.AqColorConstants color = AqVision.AqColorConstants.Green, int lineWidth = 1)
        {
            CleanWindow(aqDisplay);
            ShowBitmap(aqDisplay, bitmap);
            DrawAqDisplayContours(aqDisplay, objList, color, lineWidth);
            UpdateWindow(aqDisplay);
        }

        #endregion

    }


    #region 用工具自动生成的Json解析C#类
    public class Contours
    {
        public string x { get; set; }
        public string y { get; set; }
    }

    public class RootObject
    {
        public string area { get; set; }
        public List<Contours> contours { get; set; }
        public string cx { get; set; }
        public string cy { get; set; }
        public string height { get; set; }
        public string score { get; set; }
        public string type { get; set; }
        public string type_name { get; set; }
        public string width { get; set; }
    }
    #endregion


}
