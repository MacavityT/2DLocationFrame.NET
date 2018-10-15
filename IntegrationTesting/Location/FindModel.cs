using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;

namespace ApplyHalcon
{
    class FindModel
    {
        public static void CreateFeatureModel(HObject ho_Image, HTuple hv_Rows, HTuple hv_Columns,
                        HTuple hv_NumLevels, HTuple hv_AngleStart, HTuple hv_AngleExtent, HTuple hv_AngleStep,
                        HTuple hv_ScaleMin, HTuple hv_ScaleMax, HTuple hv_MinContrast, HTuple hv_MaxContrast,
                        HTuple hv_MinLength, out HTuple hv_ModelId, out HTuple hv_RowSource, out HTuple hv_ColumnSource,
                        out HTuple hv_AngleSource, out HTuple hv_XldRows, out HTuple hv_XldCols, out HTuple hv_XldPointCounts)
        {
            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 
            HObject ho_Region, ho_TemplateImage, ho_ModelContours;
            HObject ho_ObjectSelected = null;

            // Local control variables 
            HTuple hv_AngleExtentOut = null, hv_AngleStartOut = null;
            HTuple hv_AngleStepOut = null, hv_Scale = null, hv_Score = null;
            HTuple hv_HomMat2D = null, hv_Num = null, hv_Index = null;
            HTuple hv_Cols = new HTuple();
            HTuple hv_Rows_COPY_INP_TMP = hv_Rows.Clone();

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_TemplateImage);
            HOperatorSet.GenEmptyObj(out ho_ModelContours);
            HOperatorSet.GenEmptyObj(out ho_ObjectSelected);
            hv_AngleExtentOut = hv_AngleExtent.Clone();
            hv_AngleStartOut = hv_AngleStart.Clone();
            hv_AngleStepOut = hv_AngleStep.Clone();
            hv_AngleStartOut = hv_AngleStartOut.TupleRad();
            hv_AngleExtentOut = hv_AngleExtentOut.TupleRad();
            hv_AngleStepOut = hv_AngleStepOut.TupleRad();

            ho_Region.Dispose();
            HOperatorSet.GenRegionPolygonFilled(out ho_Region, hv_Rows_COPY_INP_TMP, hv_Columns);
            ho_TemplateImage.Dispose();
            HOperatorSet.ReduceDomain(ho_Image, ho_Region, out ho_TemplateImage);
            HOperatorSet.SetSystem("border_shape_models", "false");

            HOperatorSet.CreateScaledShapeModel(ho_TemplateImage, hv_NumLevels, hv_AngleStartOut,
                hv_AngleExtentOut, hv_AngleStepOut, hv_ScaleMin, hv_ScaleMax, 0.0121, (new HTuple("none")).TupleConcat(
                "no_pregeneration"), "use_polarity", ((hv_MinContrast.TupleConcat(hv_MaxContrast))).TupleConcat(
                hv_MinLength), 3, out hv_ModelId);
            HOperatorSet.FindScaledShapeModel(ho_TemplateImage, hv_ModelId, hv_AngleStartOut,
                hv_AngleExtentOut, hv_ScaleMin, hv_ScaleMax, 0.5, 1, 0.5, "least_squares",
                hv_NumLevels, 0.9, out hv_RowSource, out hv_ColumnSource, out hv_AngleSource,
                out hv_Scale, out hv_Score);

            ho_ModelContours.Dispose();
            HOperatorSet.GetShapeModelContours(out ho_ModelContours, hv_ModelId, 1);
            HOperatorSet.VectorAngleToRigid(0, 0, 0, hv_RowSource, hv_ColumnSource, hv_AngleSource,
                out hv_HomMat2D);
            {
                HObject ExpTmpOutVar_0;
                HOperatorSet.AffineTransContourXld(ho_ModelContours, out ExpTmpOutVar_0, hv_HomMat2D);
                ho_ModelContours.Dispose();
                ho_ModelContours = ExpTmpOutVar_0;
            }
            HOperatorSet.CountObj(ho_ModelContours, out hv_Num);

            hv_XldRows = new HTuple();
            hv_XldCols = new HTuple();
            hv_XldPointCounts = new HTuple();

            HTuple end_val23 = hv_Num;
            HTuple step_val23 = 1;
            for (hv_Index = 1; hv_Index.Continue(end_val23, step_val23); hv_Index = hv_Index.TupleAdd(step_val23))
            {
                ho_ObjectSelected.Dispose();
                HOperatorSet.SelectObj(ho_ModelContours, out ho_ObjectSelected, hv_Index);
                HOperatorSet.GetContourXld(ho_ObjectSelected, out hv_Rows_COPY_INP_TMP, out hv_Cols);
                hv_XldRows = hv_XldRows.TupleConcat(hv_Rows_COPY_INP_TMP);
                hv_XldCols = hv_XldCols.TupleConcat(hv_Cols);
                hv_XldPointCounts = hv_XldPointCounts.TupleConcat(new HTuple(hv_Rows_COPY_INP_TMP.TupleLength()));
            }


            ho_Region.Dispose();
            ho_TemplateImage.Dispose();
            ho_ModelContours.Dispose();
            ho_ObjectSelected.Dispose();

            return;
        }

        public static void FindFeatureModel(HObject ho_Image, HTuple hv_AngleStart, HTuple hv_AngleExtent,
            HTuple hv_AngleStep, HTuple hv_ScaleMin, HTuple hv_ScaleMax, HTuple hv_MinScore,
            HTuple hv_NumMatches, HTuple hv_ModelId, out HTuple hv_XldRowsM, out HTuple hv_XldColsM,
            out HTuple hv_XldPointCountsM, out HTuple hv_ModelRow, out HTuple hv_ModelColumn,
            out HTuple hv_ModelAngle, out HTuple hv_ModelScale, out HTuple hv_ModelScore)
        {
            // Local iconic variables 
            HObject ho_ModelContours, ho_TransContours = null;
            HObject ho_ObjectSelected = null;

            // Local control variables 

            HTuple hv_AngleExtentOut = null, hv_AngleStartOut = null;
            HTuple hv_AngleStepOut = null, hv_MatchingObjIdx = null;
            HTuple hv_HomMat = new HTuple(), hv_Num = new HTuple();
            HTuple hv_Index = new HTuple(), hv_Rows = new HTuple();
            HTuple hv_Cols = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ModelContours);
            HOperatorSet.GenEmptyObj(out ho_TransContours);
            HOperatorSet.GenEmptyObj(out ho_ObjectSelected);
            hv_AngleExtentOut = hv_AngleExtent.Clone();
            hv_AngleStartOut = hv_AngleStart.Clone();
            hv_AngleStepOut = hv_AngleStep.Clone();
            hv_AngleStartOut = hv_AngleStartOut.TupleRad();
            hv_AngleExtentOut = hv_AngleExtentOut.TupleRad();
            hv_AngleStepOut = hv_AngleStepOut.TupleRad();
            hv_XldRowsM = new HTuple();
            hv_XldColsM = new HTuple();
            hv_XldPointCountsM = new HTuple();
            HOperatorSet.FindScaledShapeModel(ho_Image, hv_ModelId, hv_AngleStartOut, hv_AngleExtentOut,
                                            hv_ScaleMin, hv_ScaleMax, hv_MinScore, hv_NumMatches, 0.5, "least_squares",
                                            (new HTuple(5)).TupleConcat(1), 0.75, out hv_ModelRow, out hv_ModelColumn,
                                            out hv_ModelAngle, out hv_ModelScale, out hv_ModelScore);//1120.632
            ho_ModelContours.Dispose();
            HOperatorSet.GetShapeModelContours(out ho_ModelContours, hv_ModelId, 1);
            for (hv_MatchingObjIdx = 0; (int)hv_MatchingObjIdx <= (int)((new HTuple(hv_ModelScore.TupleLength()
                )) - 1); hv_MatchingObjIdx = (int)hv_MatchingObjIdx + 1)
            {
                HOperatorSet.HomMat2dIdentity(out hv_HomMat);
                HOperatorSet.HomMat2dScale(hv_HomMat, hv_ModelScale.TupleSelect(hv_MatchingObjIdx),
                    hv_ModelScale.TupleSelect(hv_MatchingObjIdx), 0, 0, out hv_HomMat);
                HOperatorSet.HomMat2dRotate(hv_HomMat, hv_ModelAngle.TupleSelect(hv_MatchingObjIdx),
                    0, 0, out hv_HomMat);
                HOperatorSet.HomMat2dTranslate(hv_HomMat, hv_ModelRow.TupleSelect(hv_MatchingObjIdx),
                    hv_ModelColumn.TupleSelect(hv_MatchingObjIdx), out hv_HomMat);
                ho_TransContours.Dispose();
                HOperatorSet.AffineTransContourXld(ho_ModelContours, out ho_TransContours,
                    hv_HomMat);

                HOperatorSet.CountObj(ho_TransContours, out hv_Num);
                HTuple end_val19 = hv_Num;
                HTuple step_val19 = 1;
                for (hv_Index = 1; hv_Index.Continue(end_val19, step_val19); hv_Index = hv_Index.TupleAdd(step_val19))
                {
                    ho_ObjectSelected.Dispose();
                    HOperatorSet.SelectObj(ho_TransContours, out ho_ObjectSelected, hv_Index);
                    HOperatorSet.GetContourXld(ho_ObjectSelected, out hv_Rows, out hv_Cols);
                    hv_XldRowsM = hv_XldRowsM.TupleConcat(hv_Rows);
                    hv_XldColsM = hv_XldColsM.TupleConcat(hv_Cols);
                    hv_XldPointCountsM = hv_XldPointCountsM.TupleConcat(new HTuple(hv_Rows.TupleLength()
                        ));
                }

            }
            ho_ModelContours.Dispose();
            ho_TransContours.Dispose();
            ho_ObjectSelected.Dispose();//1120.224
            return;
        }
        public static void SaveModel(HTuple hv_ModelId, string modelName)
        {
            HOperatorSet.WriteShapeModel(hv_ModelId, modelName);
        }

        public static HTuple LoadModel(string modelName)
        {
            HTuple hv_ModelId;
            HOperatorSet.ReadShapeModel(modelName, out hv_ModelId);
            return hv_ModelId;
        }

        public static void detect_circle(HObject ho_Image, out HObject ho_PartCircleXLD, out HObject ho_Regions,
            out HObject ho_Cross, out HObject ho_Circle, HTuple hv_RowSource, HTuple hv_ColSource,
            HTuple hv_AngleSource, HTuple hv_RowImage, HTuple hv_ColImage, HTuple hv_AngleImage,
            HTuple hv_DrawRow, HTuple hv_DrawCol, HTuple hv_DrawRadius, HTuple hv_StartAngle,
            HTuple hv_EndAngle, HTuple hv_Elements, HTuple hv_DetectHeight, HTuple hv_DetectWidth,
            HTuple hv_Sigma, HTuple hv_Threshold, HTuple hv_Transition, HTuple hv_Select,
            HTuple hv_Direct, HTuple hv_crossSize, HTuple hv_RealArcType, out HTuple hv_RowCenter,
            out HTuple hv_ColCenter, out HTuple hv_Radius)
        {




            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local copy input parameter variables 
            HObject ho_Image_COPY_INP_TMP;
            ho_Image_COPY_INP_TMP = ho_Image.CopyObj(1, -1);



            // Local control variables 

            HTuple hv_RevertHomMat2D = new HTuple(), hv_HomMat2D = new HTuple();
            HTuple hv_SourceRow = new HTuple(), hv_SourceCol = new HTuple();
            HTuple hv_ResultRow = new HTuple(), hv_ResultColumn = new HTuple();
            HTuple hv_ArcType = new HTuple(), hv_Exception = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_PartCircleXLD);
            HOperatorSet.GenEmptyObj(out ho_Regions);
            HOperatorSet.GenEmptyObj(out ho_Cross);
            HOperatorSet.GenEmptyObj(out ho_Circle);
            hv_RowCenter = new HTuple();
            hv_ColCenter = new HTuple();
            hv_Radius = new HTuple();
            try
            {
                ho_PartCircleXLD.Dispose();
                HOperatorSet.GenEmptyObj(out ho_PartCircleXLD);
                ho_Cross.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Cross);
                ho_Circle.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Circle);
                ho_Regions.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Regions);

                try
                {
                    HOperatorSet.VectorAngleToRigid(hv_RowSource, hv_ColSource, hv_AngleSource,
                        hv_RowImage, hv_ColImage, hv_AngleImage, out hv_RevertHomMat2D);
                    HOperatorSet.VectorAngleToRigid(hv_RowImage, hv_ColImage, hv_AngleImage,
                        hv_RowSource, hv_ColSource, hv_AngleSource, out hv_HomMat2D);
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.AffineTransImage(ho_Image_COPY_INP_TMP, out ExpTmpOutVar_0,
                            hv_HomMat2D, "constant", "false");
                        ho_Image_COPY_INP_TMP.Dispose();
                        ho_Image_COPY_INP_TMP = ExpTmpOutVar_0;
                    }

                    ho_PartCircleXLD.Dispose();
                    HOperatorSet.GenCircleContourXld(out ho_PartCircleXLD, hv_DrawRow, hv_DrawCol,
                        hv_DrawRadius, hv_StartAngle.TupleRad(), hv_EndAngle.TupleRad(), "positive",
                        1);
                    HOperatorSet.GetContourXld(ho_PartCircleXLD, out hv_SourceRow, out hv_SourceCol);
                    ho_Regions.Dispose();
                    spoke(ho_Image_COPY_INP_TMP, out ho_Regions, hv_Elements, hv_DetectHeight,
                        hv_DetectWidth, hv_Sigma, hv_Threshold, hv_Transition, hv_Select, hv_SourceRow,
                        hv_SourceCol, hv_Direct, out hv_ResultRow, out hv_ResultColumn, out hv_ArcType);
                    ho_Cross.Dispose();
                    HOperatorSet.GenCrossContourXld(out ho_Cross, hv_ResultRow, hv_ResultColumn,
                        hv_crossSize, 0.785398);

                    //通过上面两段圆弧上的过渡点，根据点集合[ResultRow, ResultColumn]拟合出最合适的圆Circle
                    //该圆的信息为：RowCenter, ColCenter, Radius
                    ho_Circle.Dispose();
                    pts_to_best_circle(out ho_Circle, hv_ResultRow, hv_ResultColumn, (new HTuple((new HTuple(hv_ResultRow.TupleLength()
                        )) * 0.8)).TupleInt(), hv_RealArcType, out hv_RowCenter, out hv_ColCenter,
                        out hv_Radius);


                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.AffineTransContourXld(ho_PartCircleXLD, out ExpTmpOutVar_0,
                            hv_RevertHomMat2D);
                        ho_PartCircleXLD.Dispose();
                        ho_PartCircleXLD = ExpTmpOutVar_0;
                    }
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.AffineTransContourXld(ho_Cross, out ExpTmpOutVar_0, hv_RevertHomMat2D);
                        ho_Cross.Dispose();
                        ho_Cross = ExpTmpOutVar_0;
                    }
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.AffineTransContourXld(ho_Circle, out ExpTmpOutVar_0, hv_RevertHomMat2D);
                        ho_Circle.Dispose();
                        ho_Circle = ExpTmpOutVar_0;
                    }
                    //union1 (RegionVec, Regions)
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.AffineTransRegion(ho_Regions, out ExpTmpOutVar_0, hv_RevertHomMat2D,
                            "nearest_neighbor");
                        ho_Regions.Dispose();
                        ho_Regions = ExpTmpOutVar_0;
                    }
                    HOperatorSet.AffineTransPoint2d(hv_RevertHomMat2D, hv_RowCenter, hv_ColCenter,
                        out hv_RowCenter, out hv_ColCenter);
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    //*     log_exception (Exception)
                }
                ho_Image_COPY_INP_TMP.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_Image_COPY_INP_TMP.Dispose();

                throw HDevExpDefaultException;
            }
        }

        public static void spoke(HObject ho_Image, out HObject ho_Regions, HTuple hv_Elements,
            HTuple hv_DetectHeight, HTuple hv_DetectWidth, HTuple hv_Sigma, HTuple hv_Threshold,
            HTuple hv_Transition, HTuple hv_Select, HTuple hv_ROIRows, HTuple hv_ROICols,
            HTuple hv_Direct, out HTuple hv_ResultRow, out HTuple hv_ResultColumn, out HTuple hv_ArcType)
        {




            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 

            HObject ho_Contour, ho_ContCircle, ho_Rectangle1 = null;
            HObject ho_Arrow1 = null, ho_Arrow1Region = null;

            // Local control variables 

            HTuple hv_Width = null, hv_Height = null, hv_RowC = null;
            HTuple hv_ColumnC = null, hv_Radius = null, hv_StartPhi = null;
            HTuple hv_EndPhi = null, hv_PointOrder = null, hv_RowXLD = null;
            HTuple hv_ColXLD = null, hv_Length = null, hv_Length2 = null;
            HTuple hv_i = null, hv_j = new HTuple(), hv_RowE = new HTuple();
            HTuple hv_ColE = new HTuple(), hv_ATan = new HTuple();
            HTuple hv_RowL2 = new HTuple(), hv_RowL1 = new HTuple();
            HTuple hv_ColL2 = new HTuple(), hv_ColL1 = new HTuple();
            HTuple hv_MsrHandle_Measure = new HTuple(), hv_RowEdge = new HTuple();
            HTuple hv_ColEdge = new HTuple(), hv_Amplitude = new HTuple();
            HTuple hv_Distance = new HTuple(), hv_tRow = new HTuple();
            HTuple hv_tCol = new HTuple(), hv_t = new HTuple(), hv_Number = new HTuple();
            HTuple hv_k = new HTuple();
            HTuple hv_Select_COPY_INP_TMP = hv_Select.Clone();
            HTuple hv_Transition_COPY_INP_TMP = hv_Transition.Clone();

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Regions);
            HOperatorSet.GenEmptyObj(out ho_Contour);
            HOperatorSet.GenEmptyObj(out ho_ContCircle);
            HOperatorSet.GenEmptyObj(out ho_Rectangle1);
            HOperatorSet.GenEmptyObj(out ho_Arrow1);
            HOperatorSet.GenEmptyObj(out ho_Arrow1Region);
            hv_ArcType = new HTuple();
            try
            {
                HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);

                ho_Regions.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Regions);
                hv_ResultRow = new HTuple();
                hv_ResultColumn = new HTuple();


                ho_Contour.Dispose();
                HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_ROIRows, hv_ROICols);

                HOperatorSet.FitCircleContourXld(ho_Contour, "algebraic", -1, 0, 0, 3, 2, out hv_RowC,
                    out hv_ColumnC, out hv_Radius, out hv_StartPhi, out hv_EndPhi, out hv_PointOrder);
                ho_ContCircle.Dispose();
                HOperatorSet.GenCircleContourXld(out ho_ContCircle, hv_RowC, hv_ColumnC, hv_Radius,
                    hv_StartPhi, hv_EndPhi, hv_PointOrder, 3);
                HOperatorSet.GetContourXld(ho_ContCircle, out hv_RowXLD, out hv_ColXLD);

                HOperatorSet.LengthXld(ho_ContCircle, out hv_Length);
                HOperatorSet.TupleLength(hv_ColXLD, out hv_Length2);
                if ((int)(new HTuple(hv_Elements.TupleLess(1))) != 0)
                {

                    ho_Contour.Dispose();
                    ho_ContCircle.Dispose();
                    ho_Rectangle1.Dispose();
                    ho_Arrow1.Dispose();
                    ho_Arrow1Region.Dispose();

                    return;
                }
                HTuple end_val19 = hv_Elements - 1;
                HTuple step_val19 = 1;
                for (hv_i = 0; hv_i.Continue(end_val19, step_val19); hv_i = hv_i.TupleAdd(step_val19))
                {
                    if ((int)(new HTuple(((hv_RowXLD.TupleSelect(0))).TupleEqual(hv_RowXLD.TupleSelect(
                        hv_Length2 - 1)))) != 0)
                    {
                        HOperatorSet.TupleInt(((1.0 * hv_Length2) / (hv_Elements - 1)) * hv_i, out hv_j);
                        hv_ArcType = "circle";
                    }
                    else
                    {
                        HOperatorSet.TupleInt(((1.0 * hv_Length2) / (hv_Elements - 1)) * hv_i, out hv_j);
                        hv_ArcType = "arc";
                    }
                    if ((int)(new HTuple(hv_j.TupleGreaterEqual(hv_Length2))) != 0)
                    {
                        hv_j = hv_Length2 - 1;
                        //continue
                    }
                    hv_RowE = hv_RowXLD.TupleSelect(hv_j);
                    hv_ColE = hv_ColXLD.TupleSelect(hv_j);

                    //超出图像区域，不检测，否则容易报异常
                    if ((int)((new HTuple((new HTuple((new HTuple(hv_RowE.TupleGreater(hv_Height - 1))).TupleOr(
                        new HTuple(hv_RowE.TupleLess(0))))).TupleOr(new HTuple(hv_ColE.TupleGreater(
                        hv_Width - 1))))).TupleOr(new HTuple(hv_ColE.TupleLess(0)))) != 0)
                    {
                        continue;
                    }
                    if ((int)(new HTuple(hv_Direct.TupleEqual("inner"))) != 0)
                    {
                        HOperatorSet.TupleAtan2((-hv_RowE) + hv_RowC, hv_ColE - hv_ColumnC, out hv_ATan);
                        hv_ATan = ((new HTuple(180)).TupleRad()) + hv_ATan;

                    }
                    else
                    {
                        HOperatorSet.TupleAtan2((-hv_RowE) + hv_RowC, hv_ColE - hv_ColumnC, out hv_ATan);

                    }


                    ho_Rectangle1.Dispose();
                    HOperatorSet.GenRectangle2(out ho_Rectangle1, hv_RowE, hv_ColE, hv_ATan,
                        hv_DetectHeight / 2, hv_DetectWidth / 2);
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.ConcatObj(ho_Regions, ho_Rectangle1, out ExpTmpOutVar_0);
                        ho_Regions.Dispose();
                        ho_Regions = ExpTmpOutVar_0;
                    }
                    if ((int)(new HTuple(hv_i.TupleEqual(0))) != 0)
                    {
                        hv_RowL2 = hv_RowE + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_RowL1 = hv_RowE - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleSin()));
                        hv_ColL2 = hv_ColE + ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        hv_ColL1 = hv_ColE - ((hv_DetectHeight / 2) * (((-hv_ATan)).TupleCos()));
                        ho_Arrow1.Dispose();
                        gen_arrow_contour_xld(out ho_Arrow1, hv_RowL1, hv_ColL1, hv_RowL2, hv_ColL2,
                            25, 25);
                        ho_Arrow1Region.Dispose();
                        HOperatorSet.GenRegionContourXld(ho_Arrow1, out ho_Arrow1Region, "margin");
                        {
                            HObject ExpTmpOutVar_0;
                            HOperatorSet.ConcatObj(ho_Regions, ho_Arrow1Region, out ExpTmpOutVar_0);
                            ho_Regions.Dispose();
                            ho_Regions = ExpTmpOutVar_0;
                        }
                    }

                    HOperatorSet.GenMeasureRectangle2(hv_RowE, hv_ColE, hv_ATan, hv_DetectHeight / 2,
                        hv_DetectWidth / 2, hv_Width, hv_Height, "nearest_neighbor", out hv_MsrHandle_Measure);


                    if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("negative"))) != 0)
                    {
                        hv_Transition_COPY_INP_TMP = "negative";
                    }
                    else
                    {
                        if ((int)(new HTuple(hv_Transition_COPY_INP_TMP.TupleEqual("positive"))) != 0)
                        {

                            hv_Transition_COPY_INP_TMP = "positive";
                        }
                        else
                        {
                            hv_Transition_COPY_INP_TMP = "all";
                        }
                    }

                    if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("first"))) != 0)
                    {
                        hv_Select_COPY_INP_TMP = "first";
                    }
                    else
                    {
                        if ((int)(new HTuple(hv_Select_COPY_INP_TMP.TupleEqual("last"))) != 0)
                        {

                            hv_Select_COPY_INP_TMP = "last";
                        }
                        else
                        {
                            hv_Select_COPY_INP_TMP = "all";
                        }
                    }

                    HOperatorSet.MeasurePos(ho_Image, hv_MsrHandle_Measure, hv_Sigma, hv_Threshold,
                        hv_Transition_COPY_INP_TMP, hv_Select_COPY_INP_TMP, out hv_RowEdge, out hv_ColEdge,
                        out hv_Amplitude, out hv_Distance);
                    HOperatorSet.CloseMeasure(hv_MsrHandle_Measure);
                    hv_tRow = 0;
                    hv_tCol = 0;
                    hv_t = 0;
                    HOperatorSet.TupleLength(hv_RowEdge, out hv_Number);
                    if ((int)(new HTuple(hv_Number.TupleLess(1))) != 0)
                    {
                        continue;
                    }
                    HTuple end_val94 = hv_Number - 1;
                    HTuple step_val94 = 1;
                    for (hv_k = 0; hv_k.Continue(end_val94, step_val94); hv_k = hv_k.TupleAdd(step_val94))
                    {
                        if ((int)(new HTuple(((((hv_Amplitude.TupleSelect(hv_k))).TupleAbs())).TupleGreater(
                            hv_t))) != 0)
                        {

                            hv_tRow = hv_RowEdge.TupleSelect(hv_k);
                            hv_tCol = hv_ColEdge.TupleSelect(hv_k);
                            hv_t = ((hv_Amplitude.TupleSelect(hv_k))).TupleAbs();
                        }
                    }
                    if ((int)(new HTuple(hv_t.TupleGreater(0))) != 0)
                    {

                        hv_ResultRow = hv_ResultRow.TupleConcat(hv_tRow);
                        hv_ResultColumn = hv_ResultColumn.TupleConcat(hv_tCol);
                    }
                }


                ho_Contour.Dispose();
                ho_ContCircle.Dispose();
                ho_Rectangle1.Dispose();
                ho_Arrow1.Dispose();
                ho_Arrow1Region.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_Contour.Dispose();
                ho_ContCircle.Dispose();
                ho_Rectangle1.Dispose();
                ho_Arrow1.Dispose();
                ho_Arrow1Region.Dispose();

                throw HDevExpDefaultException;
            }
        }

        // Chapter: XLD / Creation
        // Short Description: Creates an arrow shaped XLD contour. 
        public static void gen_arrow_contour_xld(out HObject ho_Arrow, HTuple hv_Row1, HTuple hv_Column1,
            HTuple hv_Row2, HTuple hv_Column2, HTuple hv_HeadLength, HTuple hv_HeadWidth)
        {



            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 

            HObject ho_TempArrow = null;

            // Local control variables 

            HTuple hv_Length = null, hv_ZeroLengthIndices = null;
            HTuple hv_DR = null, hv_DC = null, hv_HalfHeadWidth = null;
            HTuple hv_RowP1 = null, hv_ColP1 = null, hv_RowP2 = null;
            HTuple hv_ColP2 = null, hv_Index = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Arrow);
            HOperatorSet.GenEmptyObj(out ho_TempArrow);
            try
            {
                //This procedure generates arrow shaped XLD contours,
                //pointing from (Row1, Column1) to (Row2, Column2).
                //If starting and end point are identical, a contour consisting
                //of a single point is returned.
                //
                //input parameteres:
                //Row1, Column1: Coordinates of the arrows' starting points
                //Row2, Column2: Coordinates of the arrows' end points
                //HeadLength, HeadWidth: Size of the arrow heads in pixels
                //
                //output parameter:
                //Arrow: The resulting XLD contour
                //
                //The input tuples Row1, Column1, Row2, and Column2 have to be of
                //the same length.
                //HeadLength and HeadWidth either have to be of the same length as
                //Row1, Column1, Row2, and Column2 or have to be a single element.
                //If one of the above restrictions is violated, an error will occur.
                //
                //
                //Init
                ho_Arrow.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Arrow);
                //
                //Calculate the arrow length
                HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Length);
                //
                //Mark arrows with identical start and end point
                //(set Length to -1 to avoid division-by-zero exception)
                hv_ZeroLengthIndices = hv_Length.TupleFind(0);
                if ((int)(new HTuple(hv_ZeroLengthIndices.TupleNotEqual(-1))) != 0)
                {
                    if (hv_Length == null)
                        hv_Length = new HTuple();
                    hv_Length[hv_ZeroLengthIndices] = -1;
                }
                //
                //Calculate auxiliary variables.
                hv_DR = (1.0 * (hv_Row2 - hv_Row1)) / hv_Length;
                hv_DC = (1.0 * (hv_Column2 - hv_Column1)) / hv_Length;
                hv_HalfHeadWidth = hv_HeadWidth / 2.0;
                //
                //Calculate end points of the arrow head.
                hv_RowP1 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) + (hv_HalfHeadWidth * hv_DC);
                hv_ColP1 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) - (hv_HalfHeadWidth * hv_DR);
                hv_RowP2 = (hv_Row1 + ((hv_Length - hv_HeadLength) * hv_DR)) - (hv_HalfHeadWidth * hv_DC);
                hv_ColP2 = (hv_Column1 + ((hv_Length - hv_HeadLength) * hv_DC)) + (hv_HalfHeadWidth * hv_DR);
                //
                //Finally create output XLD contour for each input point pair
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_Length.TupleLength())) - 1); hv_Index = (int)hv_Index + 1)
                {
                    if ((int)(new HTuple(((hv_Length.TupleSelect(hv_Index))).TupleEqual(-1))) != 0)
                    {
                        //Create_ single points for arrows with identical start and end point
                        ho_TempArrow.Dispose();
                        HOperatorSet.GenContourPolygonXld(out ho_TempArrow, hv_Row1.TupleSelect(
                            hv_Index), hv_Column1.TupleSelect(hv_Index));
                    }
                    else
                    {
                        //Create arrow contour
                        ho_TempArrow.Dispose();
                        HOperatorSet.GenContourPolygonXld(out ho_TempArrow, ((((((((((hv_Row1.TupleSelect(
                            hv_Index))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                            hv_RowP1.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)))).TupleConcat(
                            hv_RowP2.TupleSelect(hv_Index)))).TupleConcat(hv_Row2.TupleSelect(hv_Index)),
                            ((((((((((hv_Column1.TupleSelect(hv_Index))).TupleConcat(hv_Column2.TupleSelect(
                            hv_Index)))).TupleConcat(hv_ColP1.TupleSelect(hv_Index)))).TupleConcat(
                            hv_Column2.TupleSelect(hv_Index)))).TupleConcat(hv_ColP2.TupleSelect(
                            hv_Index)))).TupleConcat(hv_Column2.TupleSelect(hv_Index)));
                    }
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.ConcatObj(ho_Arrow, ho_TempArrow, out ExpTmpOutVar_0);
                        ho_Arrow.Dispose();
                        ho_Arrow = ExpTmpOutVar_0;
                    }
                }
                ho_TempArrow.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_TempArrow.Dispose();

                throw HDevExpDefaultException;
            }
        }

        public static void pts_to_best_circle(out HObject ho_Circle, HTuple hv_Rows, HTuple hv_Cols,
            HTuple hv_ActiveNum, HTuple hv_ArcType, out HTuple hv_RowCenter, out HTuple hv_ColCenter,
            out HTuple hv_Radius)
        {



            // Local iconic variables 

            HObject ho_Contour = null;

            // Local control variables 

            HTuple hv_Length = null, hv_StartPhi = new HTuple();
            HTuple hv_EndPhi = new HTuple(), hv_PointOrder = new HTuple();
            HTuple hv_Length1 = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Circle);
            HOperatorSet.GenEmptyObj(out ho_Contour);
            try
            {
                hv_RowCenter = 0;
                hv_ColCenter = 0;
                hv_Radius = 0;

                ho_Circle.Dispose();
                HOperatorSet.GenEmptyObj(out ho_Circle);
                HOperatorSet.TupleLength(hv_Cols, out hv_Length);

                if ((int)((new HTuple(hv_Length.TupleGreaterEqual(hv_ActiveNum))).TupleAnd(
                    new HTuple(hv_ActiveNum.TupleGreater(2)))) != 0)
                {

                    ho_Contour.Dispose();
                    HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_Rows, hv_Cols);
                    HOperatorSet.FitCircleContourXld(ho_Contour, "geotukey", -1, 0, 0, 3, 2,
                        out hv_RowCenter, out hv_ColCenter, out hv_Radius, out hv_StartPhi, out hv_EndPhi,
                        out hv_PointOrder);

                    HOperatorSet.TupleLength(hv_StartPhi, out hv_Length1);
                    if ((int)(new HTuple(hv_Length1.TupleLess(1))) != 0)
                    {
                        ho_Contour.Dispose();

                        return;
                    }
                    if ((int)(new HTuple(hv_ArcType.TupleEqual("arc"))) != 0)
                    {
                        ho_Circle.Dispose();
                        HOperatorSet.GenCircleContourXld(out ho_Circle, hv_RowCenter, hv_ColCenter,
                            hv_Radius, hv_StartPhi, hv_EndPhi, hv_PointOrder, 1);
                    }
                    else
                    {
                        ho_Circle.Dispose();
                        HOperatorSet.GenCircleContourXld(out ho_Circle, hv_RowCenter, hv_ColCenter,
                            hv_Radius, 0, (new HTuple(360)).TupleRad(), hv_PointOrder, 1);
                    }
                }

                ho_Contour.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_Contour.Dispose();

                throw HDevExpDefaultException;
            }
        }

        public static void detect_line(HObject ho_Image, HTuple hv_RowSource, HTuple hv_ColSource,
              HTuple hv_AngleSource, HTuple hv_RowImage, HTuple hv_ColImage, HTuple hv_AngleImage,
              HTuple hv_RectRow1, HTuple hv_RectCol1, HTuple hv_RectRow2, HTuple hv_RectCol2,
              HTuple hv_Step, HTuple hv_Direction, HTuple hv_Sigma, HTuple hv_Threshold, HTuple hv_Transition,
              HTuple hv_Selection, out HTuple hv_LineRow1, out HTuple hv_LineCol1, out HTuple hv_LineRow2,
              out HTuple hv_LineCol2)
        {

            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 

            HObject ho_Rectangle1 = null, ho_Rectangle = null;
            HObject ho_lineXLD = null;

            // Local copy input parameter variables 
            HObject ho_Image_COPY_INP_TMP;
            ho_Image_COPY_INP_TMP = ho_Image.CopyObj(1, -1);



            // Local control variables 

            HTuple hv_RevertHomMat2D = new HTuple(), hv_HomMat2D = new HTuple();
            HTuple hv_row0 = new HTuple(), hv_col0 = new HTuple();
            HTuple hv_radius0 = new HTuple(), hv_len01 = new HTuple();
            HTuple hv_len02 = new HTuple(), hv_phi0 = new HTuple();
            HTuple hv_phi1 = new HTuple(), hv_radius1 = new HTuple();
            HTuple hv_stepLen = new HTuple(), hv_RowsEdge = new HTuple();
            HTuple hv_ColsEdge = new HTuple(), hv_len1Meas = new HTuple();
            HTuple hv_len2Meas = new HTuple(), hv_radiusMeas = new HTuple();
            HTuple hv_WidthImg = new HTuple(), hv_HeightImg = new HTuple();
            HTuple hv_i = new HTuple(), hv_rowMeas = new HTuple();
            HTuple hv_colMeas = new HTuple(), hv_MeasureHandle = new HTuple();
            HTuple hv_RowEdgePoint = new HTuple(), hv_ColEdgePoint = new HTuple();
            HTuple hv_Amp = new HTuple(), hv_Dist = new HTuple(), hv_indices = new HTuple();
            HTuple hv_tempMax = new HTuple(), hv_Nr = new HTuple();
            HTuple hv_Nc = new HTuple(), hv_Dist1 = new HTuple(), hv_Exception = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Rectangle1);
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            HOperatorSet.GenEmptyObj(out ho_lineXLD);
            hv_LineRow1 = new HTuple();
            hv_LineCol1 = new HTuple();
            hv_LineRow2 = new HTuple();
            hv_LineCol2 = new HTuple();
            try
            {
                //**********************************************************
                if (HDevWindowStack.IsOpen())
                {
                    //dev_close_window ()
                }
                //dev_open_window (0, 0, 800, 800, 'black', WindowHandle)

                try
                {
                    //step1.
                    HOperatorSet.VectorAngleToRigid(hv_RowSource, hv_ColSource, hv_AngleSource,
                        hv_RowImage, hv_ColImage, hv_AngleImage, out hv_RevertHomMat2D);
                    HOperatorSet.VectorAngleToRigid(hv_RowImage, hv_ColImage, hv_AngleImage,
                        hv_RowSource, hv_ColSource, hv_AngleSource, out hv_HomMat2D);
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.AffineTransImage(ho_Image_COPY_INP_TMP, out ExpTmpOutVar_0,
                            hv_HomMat2D, "constant", "false");
                        ho_Image_COPY_INP_TMP.Dispose();
                        ho_Image_COPY_INP_TMP = ExpTmpOutVar_0;
                    }

                    ho_Rectangle1.Dispose();
                    HOperatorSet.GenRectangle1(out ho_Rectangle1, hv_RectRow1, hv_RectCol1, hv_RectRow2,
                        hv_RectCol2);
                    HOperatorSet.SmallestRectangle2(ho_Rectangle1, out hv_row0, out hv_col0,
                        out hv_radius0, out hv_len01, out hv_len02);
                    hv_phi0 = hv_radius0.TupleDeg();
                    if ((int)(new HTuple(hv_phi0.TupleLess(0))) != 0)
                    {
                        hv_phi0 = hv_phi0 + 180;
                    }
                    hv_radius0 = hv_phi0.TupleRad();
                    if ((int)(new HTuple((new HTuple("horizontal")).TupleEqual(hv_Direction))) != 0)
                    {
                        if ((int)(new HTuple(hv_phi0.TupleLess(90))) != 0)
                        {
                            hv_phi1 = hv_phi0 + 90;
                        }
                        else
                        {
                            hv_phi1 = hv_phi0 - 90;
                        }
                    }
                    else if ((int)(new HTuple((new HTuple("vertical")).TupleEqual(hv_Direction))) != 0)
                    {
                        hv_phi1 = hv_phi0 - 90;
                    }
                    hv_radius1 = hv_phi1.TupleRad();

                    //step2.
                    hv_stepLen = (hv_len01 * 1.0) / hv_Step;
                    hv_RowsEdge = new HTuple();
                    hv_ColsEdge = new HTuple();
                    hv_len1Meas = hv_len02.Clone();
                    hv_len2Meas = 0.6 * hv_stepLen;
                    hv_radiusMeas = hv_radius1.Clone();
                    HOperatorSet.GetImageSize(ho_Image_COPY_INP_TMP, out hv_WidthImg, out hv_HeightImg);
                    HTuple end_val36 = hv_Step;
                    HTuple step_val36 = 1;
                    for (hv_i = 0; hv_i.Continue(end_val36, step_val36); hv_i = hv_i.TupleAdd(step_val36))
                    {
                        hv_rowMeas = hv_row0 + (((hv_Step - (2 * hv_i)) * hv_stepLen) * (hv_radius0.TupleSin()
                            ));
                        hv_colMeas = hv_col0 - (((hv_Step - (2 * hv_i)) * hv_stepLen) * (hv_radius0.TupleCos()
                            ));
                        ho_Rectangle.Dispose();
                        HOperatorSet.GenRectangle2(out ho_Rectangle, hv_rowMeas, hv_colMeas, hv_radiusMeas,
                            hv_len1Meas, hv_len2Meas);
                        HOperatorSet.GenMeasureRectangle2(hv_rowMeas, hv_colMeas, hv_radiusMeas,
                            hv_len1Meas, hv_len2Meas, hv_WidthImg, hv_HeightImg, "nearest_neighbor",
                            out hv_MeasureHandle);
                        HOperatorSet.MeasurePos(ho_Image_COPY_INP_TMP, hv_MeasureHandle, hv_Sigma,
                            hv_Threshold, hv_Transition, hv_Selection, out hv_RowEdgePoint, out hv_ColEdgePoint,
                            out hv_Amp, out hv_Dist);
                        HOperatorSet.CloseMeasure(hv_MeasureHandle);
                        if ((int)(new HTuple((new HTuple(hv_Amp.TupleLength())).TupleGreater(0))) != 0)
                        {
                            hv_indices = 0;
                            HOperatorSet.TupleAbs(hv_Amp, out hv_Amp);
                            HOperatorSet.TupleMax(hv_Amp, out hv_tempMax);
                            HOperatorSet.TupleFind(hv_Amp, hv_tempMax, out hv_indices);
                            hv_RowsEdge = hv_RowsEdge.TupleConcat(hv_RowEdgePoint.TupleSelect(hv_indices.TupleSelect(
                                0)));
                            hv_ColsEdge = hv_ColsEdge.TupleConcat(hv_ColEdgePoint.TupleSelect(hv_indices.TupleSelect(
                                0)));
                        }
                    }

                    //step3.
                    if ((int)(new HTuple((new HTuple(hv_RowsEdge.TupleLength())).TupleGreater(
                        hv_Step * 0.5))) != 0)
                    {
                        ho_lineXLD.Dispose();
                        HOperatorSet.GenContourPolygonXld(out ho_lineXLD, hv_RowsEdge, hv_ColsEdge);
                        HOperatorSet.FitLineContourXld(ho_lineXLD, "tukey", -1, 0, 5, 2, out hv_LineRow1,
                            out hv_LineCol1, out hv_LineRow2, out hv_LineCol2, out hv_Nr, out hv_Nc,
                            out hv_Dist1);
                        HOperatorSet.AffineTransPoint2d(hv_RevertHomMat2D, hv_LineRow1, hv_LineCol1,
                            out hv_LineRow1, out hv_LineCol1);
                        HOperatorSet.AffineTransPoint2d(hv_RevertHomMat2D, hv_LineRow2, hv_LineCol2,
                            out hv_LineRow2, out hv_LineCol2);
                    }
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    //*     log_exception (Exception)
                }
                ho_Image_COPY_INP_TMP.Dispose();
                ho_Rectangle1.Dispose();
                ho_Rectangle.Dispose();
                ho_lineXLD.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_Image_COPY_INP_TMP.Dispose();
                ho_Rectangle1.Dispose();
                ho_Rectangle.Dispose();
                ho_lineXLD.Dispose();

                throw HDevExpDefaultException;
            }
        }

        public static void IntersetionPtAngle(HTuple hv_LineLeftRow1, HTuple hv_LineLeftCol1, HTuple hv_LineLeftRow2, HTuple hv_LineLeftCol2, 
            HTuple hv_LineUpRow1, HTuple hv_LineUpCol1, HTuple hv_LineUpRow2, HTuple hv_LineUpCol2,
            out HTuple hv_RowCross, out HTuple hv_ColCross, out HTuple hv_Phi, out HTuple hv_IsOverlapping)
        {
            HOperatorSet.IntersectionLines(hv_LineLeftRow1, hv_LineLeftCol1, hv_LineLeftRow2,
                        hv_LineLeftCol2, hv_LineUpRow1, hv_LineUpCol1, hv_LineUpRow2, hv_LineUpCol2,
                        out hv_RowCross, out hv_ColCross, out hv_IsOverlapping);
            HOperatorSet.TupleAtan2(hv_LineLeftRow2-hv_LineLeftRow1, hv_LineLeftCol2-hv_LineLeftCol1, out hv_Phi);

        }
    }
}
