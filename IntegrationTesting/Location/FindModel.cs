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
