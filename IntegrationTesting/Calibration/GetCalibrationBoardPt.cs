using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTesting.Calibration
{
    class GetCalibrationBoardPt
    {
        // Local procedures 
        public static void Get_11_Point_Coordinates(HObject ho_Image, HTuple hv_Diameter, HTuple hv_Threshold,
            out HTuple hv_isFind, out HTuple hv_Rows_cc, out HTuple hv_Cols_cc)
        {
            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 

            HObject ho_ImageOut = null, ho_Region, ho_RegionOpening;
            HObject ho_ConnectedRegions, ho_Regions_11_Circles, ho_RegionClosing;
            HObject ho_Regions_9_Circles, ho_Regions_2_Circles;

            // Local control variables 

            HTuple hv_Channels = null, hv_Areas11 = null;
            HTuple hv_Rows11 = null, hv_Columns11 = null, hv_Indices0 = null;
            HTuple hv_x1 = null, hv_y1 = null, hv_x3 = null, hv_y3 = null;
            HTuple hv_Dist1_3 = null, hv_Areas = null, hv_Rows = null;
            HTuple hv_Columns = null, hv_Distances = null, hv_i = null;
            HTuple hv_Dist = new HTuple(), hv_Indices = null, hv_x9 = null;
            HTuple hv_y9 = null, hv_x7 = null, hv_y7 = null, hv_x5_ = null;
            HTuple hv_y5_ = null, hv_x5 = null, hv_y5 = null, hv_x2_ = null;
            HTuple hv_y2_ = null, hv_x2 = null, hv_y2 = null, hv_x6_ = null;
            HTuple hv_y6_ = null, hv_x6 = null, hv_y6 = null, hv_x8_ = null;
            HTuple hv_y8_ = null, hv_x8 = null, hv_y8 = null, hv_x4_ = null;
            HTuple hv_y4_ = null, hv_x4 = null, hv_y4 = null, hv_Areas2 = null;
            HTuple hv_Rows2 = null, hv_Columns2 = null, hv_x11 = null;
            HTuple hv_y11 = null, hv_x10 = null, hv_y10 = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ImageOut);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_RegionOpening);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_Regions_11_Circles);
            HOperatorSet.GenEmptyObj(out ho_RegionClosing);
            HOperatorSet.GenEmptyObj(out ho_Regions_9_Circles);
            HOperatorSet.GenEmptyObj(out ho_Regions_2_Circles);
            hv_Rows_cc = new HTuple();
            hv_Cols_cc = new HTuple();
            try
            {
                //说明：
                //1、Diameter指的是常规的9个圆的直径大小（以像素计量），如果懒得设置，可以令Diameter := 0。isFind ==1 表示成功找到11个圆。
                //2、每个黑圆中央必须有一个小白点清晰可见,并且黑圆的个数必须为11个,否则函数将计算失败。
                //3、当标定板摆正时，圆的排序“先从左到右，再从上到下”，最小的圆是圆1,最大的圆是圆3
                //4、标定板可以任意角度摆放，不一定需要摆正。标定板表面不得有其他脏污，否则可能计算失败。标定板图像需黑白分明。
                //5、halcon的x、y（Rows_cc和Cols_cc）和其他编程语言中的图像中x、y值刚好是相反的。具体使用时，要把x、y的值调换顺序。
                //6、圆10和圆11必须离圆1-9比较远
                //7、如程序执行异常需要优化，可联系hui.xia@aqrose.com


                ho_ImageOut.Dispose();
                ho_ImageOut = ho_Image.CopyObj(1, -1);
                hv_isFind = 0;
                HOperatorSet.CountChannels(ho_ImageOut, out hv_Channels);
                if ((int)(new HTuple(hv_Channels.TupleGreaterEqual(3))) != 0)
                {
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.Rgb1ToGray(ho_ImageOut, out ExpTmpOutVar_0);
                        ho_ImageOut.Dispose();
                        ho_ImageOut = ExpTmpOutVar_0;
                    }
                }

                ho_Region.Dispose();
                HOperatorSet.Threshold(ho_ImageOut, out ho_Region, 0, hv_Threshold);
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.FillUp(ho_Region, out ExpTmpOutVar_0);
                    ho_Region.Dispose();
                    ho_Region = ExpTmpOutVar_0;
                }
                ho_RegionOpening.Dispose();
                HOperatorSet.OpeningCircle(ho_Region, out ho_RegionOpening, 4.0);
                ho_ConnectedRegions.Dispose();
                HOperatorSet.Connection(ho_RegionOpening, out ho_ConnectedRegions);
                ho_Regions_11_Circles.Dispose();
                HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_Regions_11_Circles, (new HTuple("circularity")).TupleConcat(
                    "area"), "and", (new HTuple(0.9)).TupleConcat(10000), (new HTuple(1.0)).TupleConcat(
                    9999999999));
                if ((int)(new HTuple(hv_Diameter.TupleNotEqual(0))) != 0)
                {
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.SelectShape(ho_Regions_11_Circles, out ExpTmpOutVar_0, "width",
                            "and", hv_Diameter * 0.3, hv_Diameter * 3);
                        ho_Regions_11_Circles.Dispose();
                        ho_Regions_11_Circles = ExpTmpOutVar_0;
                    }
                }


                HOperatorSet.AreaCenter(ho_Regions_11_Circles, out hv_Areas11, out hv_Rows11,
                    out hv_Columns11);

                if ((int)(new HTuple((new HTuple(hv_Areas11.TupleLength())).TupleNotEqual(11))) != 0)
                {
                    hv_isFind = 0;
                    ho_ImageOut.Dispose();
                    ho_Region.Dispose();
                    ho_RegionOpening.Dispose();
                    ho_ConnectedRegions.Dispose();
                    ho_Regions_11_Circles.Dispose();
                    ho_RegionClosing.Dispose();
                    ho_Regions_9_Circles.Dispose();
                    ho_Regions_2_Circles.Dispose();

                    return;
                }

                HOperatorSet.TupleSortIndex(hv_Areas11, out hv_Indices0);
                //直径最小的是圆1
                hv_x1 = hv_Rows11.TupleSelect(hv_Indices0.TupleSelect(0));
                hv_y1 = hv_Columns11.TupleSelect(hv_Indices0.TupleSelect(0));

                //直径最大的是圆3
                hv_x3 = hv_Rows11.TupleSelect(hv_Indices0.TupleSelect((new HTuple(hv_Areas11.TupleLength()
                    )) - 1));
                hv_y3 = hv_Columns11.TupleSelect(hv_Indices0.TupleSelect((new HTuple(hv_Areas11.TupleLength()
                    )) - 1));

                HOperatorSet.DistancePp(hv_x1, hv_y1, hv_x3, hv_y3, out hv_Dist1_3);
                ho_RegionClosing.Dispose();
                HOperatorSet.ClosingCircle(ho_RegionOpening, out ho_RegionClosing, 5 + (hv_Dist1_3 / 4));
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.FillUp(ho_RegionClosing, out ExpTmpOutVar_0);
                    ho_RegionClosing.Dispose();
                    ho_RegionClosing = ExpTmpOutVar_0;
                }
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.Connection(ho_RegionClosing, out ExpTmpOutVar_0);
                    ho_RegionClosing.Dispose();
                    ho_RegionClosing = ExpTmpOutVar_0;
                }
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.SelectShapeStd(ho_RegionClosing, out ExpTmpOutVar_0, "max_area",
                        70);
                    ho_RegionClosing.Dispose();
                    ho_RegionClosing = ExpTmpOutVar_0;
                }

                ho_Regions_9_Circles.Dispose();
                HOperatorSet.SelectShapeProto(ho_Regions_11_Circles, ho_RegionClosing, out ho_Regions_9_Circles,
                    "overlaps_rel", 80, 100);
                HOperatorSet.AreaCenter(ho_Regions_9_Circles, out hv_Areas, out hv_Rows, out hv_Columns);

                if ((int)(new HTuple((new HTuple(hv_Areas.TupleLength())).TupleNotEqual(9))) != 0)
                {
                    hv_isFind = 0;
                    ho_ImageOut.Dispose();
                    ho_Region.Dispose();
                    ho_RegionOpening.Dispose();
                    ho_ConnectedRegions.Dispose();
                    ho_Regions_11_Circles.Dispose();
                    ho_RegionClosing.Dispose();
                    ho_Regions_9_Circles.Dispose();
                    ho_Regions_2_Circles.Dispose();

                    return;
                }

                //离圆1最远的是圆9
                hv_Distances = new HTuple();
                for (hv_i = 0; (int)hv_i <= (int)((new HTuple(hv_Areas.TupleLength())) - 1); hv_i = (int)hv_i + 1)
                {
                    HOperatorSet.DistancePp(hv_x1, hv_y1, hv_Rows.TupleSelect(hv_i), hv_Columns.TupleSelect(
                        hv_i), out hv_Dist);
                    hv_Distances = hv_Distances.TupleConcat(hv_Dist);
                }
                HOperatorSet.TupleSortIndex(hv_Distances, out hv_Indices);
                hv_x9 = hv_Rows.TupleSelect(hv_Indices.TupleSelect(8));
                hv_y9 = hv_Columns.TupleSelect(hv_Indices.TupleSelect(8));

                //离圆3最远的是圆7
                hv_Distances = new HTuple();
                for (hv_i = 0; (int)hv_i <= (int)((new HTuple(hv_Areas.TupleLength())) - 1); hv_i = (int)hv_i + 1)
                {
                    HOperatorSet.DistancePp(hv_x3, hv_y3, hv_Rows.TupleSelect(hv_i), hv_Columns.TupleSelect(
                        hv_i), out hv_Dist);
                    hv_Distances = hv_Distances.TupleConcat(hv_Dist);
                }
                HOperatorSet.TupleSortIndex(hv_Distances, out hv_Indices);
                hv_x7 = hv_Rows.TupleSelect(hv_Indices.TupleSelect(8));
                hv_y7 = hv_Columns.TupleSelect(hv_Indices.TupleSelect(8));

                //圆1、9中间的是圆5
                hv_x5_ = (hv_x1 + hv_x9) / 2;
                hv_y5_ = (hv_y1 + hv_y9) / 2;
                hv_Distances = new HTuple();
                for (hv_i = 0; (int)hv_i <= (int)((new HTuple(hv_Areas.TupleLength())) - 1); hv_i = (int)hv_i + 1)
                {
                    HOperatorSet.DistancePp(hv_x5_, hv_y5_, hv_Rows.TupleSelect(hv_i), hv_Columns.TupleSelect(
                        hv_i), out hv_Dist);
                    hv_Distances = hv_Distances.TupleConcat(hv_Dist);
                }
                HOperatorSet.TupleSortIndex(hv_Distances, out hv_Indices);
                hv_x5 = hv_Rows.TupleSelect(hv_Indices.TupleSelect(0));
                hv_y5 = hv_Columns.TupleSelect(hv_Indices.TupleSelect(0));

                //圆1、3中间的是圆2
                hv_x2_ = (hv_x1 + hv_x3) / 2;
                hv_y2_ = (hv_y1 + hv_y3) / 2;
                hv_Distances = new HTuple();
                for (hv_i = 0; (int)hv_i <= (int)((new HTuple(hv_Areas.TupleLength())) - 1); hv_i = (int)hv_i + 1)
                {
                    HOperatorSet.DistancePp(hv_x2_, hv_y2_, hv_Rows.TupleSelect(hv_i), hv_Columns.TupleSelect(
                        hv_i), out hv_Dist);
                    hv_Distances = hv_Distances.TupleConcat(hv_Dist);
                }
                HOperatorSet.TupleSortIndex(hv_Distances, out hv_Indices);
                hv_x2 = hv_Rows.TupleSelect(hv_Indices.TupleSelect(0));
                hv_y2 = hv_Columns.TupleSelect(hv_Indices.TupleSelect(0));


                //圆3、9中间的是圆6
                hv_x6_ = (hv_x3 + hv_x9) / 2;
                hv_y6_ = (hv_y3 + hv_y9) / 2;
                hv_Distances = new HTuple();
                for (hv_i = 0; (int)hv_i <= (int)((new HTuple(hv_Areas.TupleLength())) - 1); hv_i = (int)hv_i + 1)
                {
                    HOperatorSet.DistancePp(hv_x6_, hv_y6_, hv_Rows.TupleSelect(hv_i), hv_Columns.TupleSelect(
                        hv_i), out hv_Dist);
                    hv_Distances = hv_Distances.TupleConcat(hv_Dist);
                }
                HOperatorSet.TupleSortIndex(hv_Distances, out hv_Indices);
                hv_x6 = hv_Rows.TupleSelect(hv_Indices.TupleSelect(0));
                hv_y6 = hv_Columns.TupleSelect(hv_Indices.TupleSelect(0));

                //圆7、9中间的是圆8
                hv_x8_ = (hv_x7 + hv_x9) / 2;
                hv_y8_ = (hv_y7 + hv_y9) / 2;
                hv_Distances = new HTuple();
                for (hv_i = 0; (int)hv_i <= (int)((new HTuple(hv_Areas.TupleLength())) - 1); hv_i = (int)hv_i + 1)
                {
                    HOperatorSet.DistancePp(hv_x8_, hv_y8_, hv_Rows.TupleSelect(hv_i), hv_Columns.TupleSelect(
                        hv_i), out hv_Dist);
                    hv_Distances = hv_Distances.TupleConcat(hv_Dist);
                }
                HOperatorSet.TupleSortIndex(hv_Distances, out hv_Indices);
                hv_x8 = hv_Rows.TupleSelect(hv_Indices.TupleSelect(0));
                hv_y8 = hv_Columns.TupleSelect(hv_Indices.TupleSelect(0));

                //圆1、7中间的是圆4
                hv_x4_ = (hv_x1 + hv_x7) / 2;
                hv_y4_ = (hv_y1 + hv_y7) / 2;
                hv_Distances = new HTuple();
                for (hv_i = 0; (int)hv_i <= (int)((new HTuple(hv_Areas.TupleLength())) - 1); hv_i = (int)hv_i + 1)
                {
                    HOperatorSet.DistancePp(hv_x4_, hv_y4_, hv_Rows.TupleSelect(hv_i), hv_Columns.TupleSelect(
                        hv_i), out hv_Dist);
                    hv_Distances = hv_Distances.TupleConcat(hv_Dist);
                }
                HOperatorSet.TupleSortIndex(hv_Distances, out hv_Indices);
                hv_x4 = hv_Rows.TupleSelect(hv_Indices.TupleSelect(0));
                hv_y4 = hv_Columns.TupleSelect(hv_Indices.TupleSelect(0));

                hv_Rows_cc = new HTuple();
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x1);
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x2);
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x3);
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x4);
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x5);
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x6);
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x7);
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x8);
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x9);
                hv_Cols_cc = new HTuple();
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y1);
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y2);
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y3);
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y4);
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y5);
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y6);
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y7);
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y8);
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y9);


                //找最后两个点
                ho_Regions_2_Circles.Dispose();
                HOperatorSet.SelectShapeProto(ho_Regions_11_Circles, ho_RegionClosing, out ho_Regions_2_Circles,
                    "overlaps_rel", 0, 30);
                HOperatorSet.AreaCenter(ho_Regions_2_Circles, out hv_Areas2, out hv_Rows2,
                    out hv_Columns2);

                if ((int)(new HTuple((new HTuple(hv_Areas2.TupleLength())).TupleNotEqual(2))) != 0)
                {
                    hv_isFind = 0;
                    ho_ImageOut.Dispose();
                    ho_Region.Dispose();
                    ho_RegionOpening.Dispose();
                    ho_ConnectedRegions.Dispose();
                    ho_Regions_11_Circles.Dispose();
                    ho_RegionClosing.Dispose();
                    ho_Regions_9_Circles.Dispose();
                    ho_Regions_2_Circles.Dispose();

                    return;
                }


                //离圆1最远的是圆11
                hv_Distances = new HTuple();
                for (hv_i = 0; (int)hv_i <= (int)((new HTuple(hv_Areas2.TupleLength())) - 1); hv_i = (int)hv_i + 1)
                {
                    HOperatorSet.DistancePp(hv_x1, hv_y1, hv_Rows2.TupleSelect(hv_i), hv_Columns2.TupleSelect(
                        hv_i), out hv_Dist);
                    hv_Distances = hv_Distances.TupleConcat(hv_Dist);
                }
                HOperatorSet.TupleSortIndex(hv_Distances, out hv_Indices);
                hv_x11 = hv_Rows2.TupleSelect(hv_Indices.TupleSelect(1));
                hv_y11 = hv_Columns2.TupleSelect(hv_Indices.TupleSelect(1));

                //另一个点就是最近的
                hv_x10 = hv_Rows2.TupleSelect(hv_Indices.TupleSelect(0));
                hv_y10 = hv_Columns2.TupleSelect(hv_Indices.TupleSelect(0));

                hv_Rows_cc = new HTuple();
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x1);
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x2);
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x3);
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x4);
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x5);
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x6);
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x7);
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x8);
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x9);
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x10);
                hv_Rows_cc = hv_Rows_cc.TupleConcat(hv_x11);
                hv_Cols_cc = new HTuple();
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y1);
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y2);
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y3);
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y4);
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y5);
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y6);
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y7);
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y8);
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y9);
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y10);
                hv_Cols_cc = hv_Cols_cc.TupleConcat(hv_y11);

                hv_isFind = 1;
                ho_ImageOut.Dispose();
                ho_Region.Dispose();
                ho_RegionOpening.Dispose();
                ho_ConnectedRegions.Dispose();
                ho_Regions_11_Circles.Dispose();
                ho_RegionClosing.Dispose();
                ho_Regions_9_Circles.Dispose();
                ho_Regions_2_Circles.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_ImageOut.Dispose();
                ho_Region.Dispose();
                ho_RegionOpening.Dispose();
                ho_ConnectedRegions.Dispose();
                ho_Regions_11_Circles.Dispose();
                ho_RegionClosing.Dispose();
                ho_Regions_9_Circles.Dispose();
                ho_Regions_2_Circles.Dispose();

                throw HDevExpDefaultException;
            }
        }
    }
}
