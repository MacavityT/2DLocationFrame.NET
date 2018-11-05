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
        //static bool m_triggering = false;
        // Server side handler of the SayHello RPC
        
        public override Task<SetFlag> triggerCamera(TriggerReq request, ServerCallContext context)
        {
            //if(!m_triggering)
            {
               // m_triggering = true;
                SetFlag resultFlag = new SetFlag();
                int flag = 0;
                if (triggerCamerHandler != null)
                {
                    /*
                     * 原来代码可以编译flag = triggerCamerHandler(request.RobotPose.Position.X, request.RobotPose.Position.Y, request.RobotPose.Position.Z);
                     * 目前机器人端.pro文件如果为更新过则需要更新机器人端.pro协议,否则软件可能不能工作
                     */
                    flag = triggerCamerHandler(request.RobotPose.X, request.RobotPose.Y, request.RobotPose.Theta);
                }
                resultFlag.ErrorFlag = flag;
                //m_triggering = false;
                return Task.FromResult(resultFlag);
            }
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
            int posture = 0;
            getLocalizeResultHandler(ref posX, ref posY, ref delta, ref posture);

            delta = delta * 180 / Math.PI;
            while (delta > 180) 
            {
                delta -= 360;
            }
            while (delta < -180) 
            {
                delta += 360;
            }

            delta -= 180;  //修改数据
            Pose2D result_2D_pos = new Pose2D { X = posX, Y = posY, Theta = delta };
            localizeRespone.Pose2D = result_2D_pos;
            localizeRespone.VisionStatus = posture;     //1-工件平放状态 2-工件竖立状态
            localizeRespone.OffsetMethod = "P";

            return Task.FromResult(localizeRespone);
        }

        public override Task<SetFlag> doCalibrate(CalibReq request, ServerCallContext context)
        {
            /*
             * 原来代码可以编译 Position X " + request.Position.X.ToString() + " Y " + request.Position.Y.ToString() + " Z " + request.Position.Z.ToString() +
             * 目前机器人端.pro文件如果为更新过则需要更新机器人端.pro协议,否则软件可能不能工作
             */

            Console.WriteLine("reve doCalibrate: OffsetMethod  " + request.OffsetMethod +
                " Position X " + request.Position.X.ToString() + " Y " + request.Position.Y.ToString() + " Z " + request.Position.Theta.ToString() +
                " Terminate " + request.Terminate.ToString());
//             request.Position.X;      //double
//             request.Position.Y;      //double
//             request.Position.Z;      //double
//             request.Terminate;       //bool
//             request.OffsetMethod;    //string
            SetFlag resultFlag = new SetFlag();
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
    }
}