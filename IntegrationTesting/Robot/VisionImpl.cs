using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2D;
using Grpc.Core;

namespace IntegrationTesting.Robot
{  
    class VisionImpl : Robot2dApp.Robot2dAppBase
    {
        public TriggerCamerHandler triggerCamerHandler = null;
        public GetLocalizeResultHandler getLocalizeResultHandler = null;
        public GetWorkObjInfoHandler getWorkObjInfoHandler = null;
        public DoCalibrateHandler doCalibrateHandler = null;
        public TeachPickPoseHandler teachPickPoseHandler = null;
        // Server side handler of the SayHello RPC
        
        public override Task<SetFlag> triggerCamera(TriggerReq request, ServerCallContext context)
        {
            SetFlag resultFlag = new SetFlag();
            int flag = 0;
            if (triggerCamerHandler != null)
            {
                flag = triggerCamerHandler((double)(request.RobotPose.X * 1000), (double)(request.RobotPose.Y * 1000), (request.RobotPose.Theta));
            }
            resultFlag.ErrorFlag = flag;
            return Task.FromResult(resultFlag);
        }

        public override Task<LocalizeRep> getLocalizeResult(LocalizeReq request, ServerCallContext context)
        {
            LocalizeRep localizeRespone = new LocalizeRep();
            double posX = 0;
            double posY = 0;
            double delta = 0;
            int posture = 0;
            getLocalizeResultHandler(ref posX, ref posY, ref delta, ref posture);

            //delta = delta * 180 / Math.PI;
            while (delta > Math.PI*2) 
            {
                delta -= Math.PI*2;
            }

            Pose2D result_2D_pos = new Pose2D { X = (double)(posX/1000), Y = (double)(posY/1000), Theta = delta };
            localizeRespone.Pose2D = result_2D_pos;
            localizeRespone.VisionStatus = 0;
            localizeRespone.OffsetMethod = "P";

            return Task.FromResult(localizeRespone);
        }

        public override Task<SetFlag> doCalibrate(CalibReq request, ServerCallContext context)
        {
            int iRet = doCalibrateHandler(request.Position.X, request.Position.Y, request.Position.Theta, request.Terminate);
            SetFlag resultFlag = new SetFlag();
            resultFlag.ErrorFlag = iRet;
            return Task.FromResult(resultFlag);
        }
         
        //收获X,Y,Z坐标不准确
        public override Task<SetFlag> configSystem(ConfigReq request, ServerCallContext context)
        {
            Console.WriteLine("reve configSystem: " + request.ToString());
            return Task.FromResult(new SetFlag { ErrorFlag = 6666 });
        }

        public override Task<WorkObjRep> getWorkObjInfo(WorkObjReq request, ServerCallContext context)
        {
            int detectCount = 0;
            WorkObjRep objRep = new WorkObjRep();
            if (!getWorkObjInfoHandler(ref detectCount))
            {
                objRep.CurrentObjNum = 0;
            }
            else
            {
                objRep.CurrentObjNum = 1;
            }
            return Task.FromResult(objRep);
        }

        public override Task<SetFlag> teachPickPose(TriggerReq request, ServerCallContext context)
        {
            int iRet = teachPickPoseHandler(request.RobotPose.X, request.RobotPose.Y, request.RobotPose.Theta);
            SetFlag resultFlag = new SetFlag();
            resultFlag.ErrorFlag = iRet;
            return Task.FromResult(resultFlag);
        }
    }
}