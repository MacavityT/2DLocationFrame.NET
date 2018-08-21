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
        // Server side handler of the SayHello RPC
        
        public override Task<SetFlag> triggerCamera(TriggerReq request, ServerCallContext context)
        {
            SetFlag resultFlag = new SetFlag();
            int flag = 0;
            if( triggerCamerHandler !=null )
            {
                flag = triggerCamerHandler(request.RobotPose.Position.X, request.RobotPose.Position.Y, request.RobotPose.Position.Z);
            }
            resultFlag.ErrorFlag = flag;
            return Task.FromResult(resultFlag);
        }

        public override Task<LocalizeRep> getLocalizeResult(LocalizeReq request, ServerCallContext context)
        {
//             request.VisionMode;
//             request.Flag;
//             request.TaskId;
            LocalizeRep localizeRespone = new LocalizeRep();
            double posX = 0;
            double posY = 0;
            double delta = 0;
            getLocalizeResultHandler(ref posX, ref posY, ref delta);

            Pose2D result_2D_pos = new Pose2D { X = posX, Y = posY, Theta = delta };
            localizeRespone.Pose2D = result_2D_pos;
            localizeRespone.VisionStatus = 0;
            localizeRespone.OffsetMethod = "P";

            return Task.FromResult(localizeRespone);
        }

        public override Task<SetFlag> doCalibrate(CalibReq request, ServerCallContext context)
        {
            Console.WriteLine("reve doCalibrate: OffsetMethod  " + request.OffsetMethod +
                " Position X " + request.Position.X.ToString() + " Y " + request.Position.Y.ToString() + " Z " + request.Position.Z.ToString() +
                " Terminate " + request.Terminate.ToString());
//             request.Position.X;
//             request.Position.Y;
//             request.Position.Z;
//             request.Terminate;
//             request.OffsetMethod;
            return Task.FromResult(new SetFlag { ErrorFlag = 5555 });
        }

        //收获X,Y,Z坐标不准确
        public override Task<SetFlag> configSystem(ConfigReq request, ServerCallContext context)
        {
            Console.WriteLine("reve configSystem: " + request.ToString());
            return Task.FromResult(new SetFlag { ErrorFlag = 6666 });
        }

        public override Task<WorkObjRep> getWorkObjInfo(WorkObjReq request, ServerCallContext context)
        {
            Console.WriteLine("reve getWorkObjInfo: " + request.ToString());
            return Task.FromResult(new WorkObjRep { CurrentObjNum = 77777 });
        }
    }
}