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
      
        // Server side handler of the SayHello RPC
        Pose2D result_2D_pos = new Pose2D { X = 1, Y = 2, Theta = 3 };
        public override Task<SetFlag> triggerCamera(TriggerReq request, ServerCallContext context)
        {
            Console.WriteLine("reve triggerCamera: " + request.ToString());
            return Task.FromResult(new SetFlag { ErrorFlag = 1111 });
        }

        public override Task<LocalizeRep> getLocalizeResult(LocalizeReq request, ServerCallContext context)
        {
            Console.WriteLine("reve getLocalizeResult: VisionMode " + request.VisionMode.ToString() + " TaskId " + request.TaskId.ToString() + " Flag " + request.Flag.ToString());
            return Task.FromResult(new LocalizeRep { VisionStatus = 0, OffsetMethod = "P", Pose2D = result_2D_pos });// OffsetMethod, P/F
        }

        public override Task<SetFlag> doCalibrate(CalibReq request, ServerCallContext context)
        {
            Console.WriteLine("reve doCalibrate: OffsetMethod  " + request.OffsetMethod +
                " Position X " + request.Position.X.ToString() + " Y " + request.Position.Y.ToString() + " Z " + request.Position.Z.ToString() +
                " Terminate " + request.Terminate.ToString());

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
