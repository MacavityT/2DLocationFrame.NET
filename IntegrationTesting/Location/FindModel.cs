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
                                            out hv_ModelAngle, out hv_ModelScale, out hv_ModelScore);
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
            ho_ObjectSelected.Dispose();

            return;
        }
        public void SaveModel(HTuple hv_ModelId, string modelName)
        {
            HOperatorSet.WriteShapeModel(hv_ModelId, modelName);
        }

        public HTuple LoadModel(string modelName)
        {
            HTuple hv_ModelId;
            HOperatorSet.ReadShapeModel(modelName, out hv_ModelId);
            return hv_ModelId;
        }
    }
}
