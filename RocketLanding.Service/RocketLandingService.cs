using RocketLanding.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace RocketLanding.Service
{
    public class RocketLandingService : IRocketLandingService
    {
        private readonly Area area;
        private static List<Target> AllocatedTargets = new List<Target>();

        public RocketLandingService(int platformXLength, int platformYLength)
        {
            //Platform top left coordinates are fixed according to the definition
            int x = 5, y = 5;

            area = new Area()
            {
                Platform = new Platform(platformXLength, platformYLength, position: new Position(x, y))
            };
        }

        public string GetResponse(int x, int y)
        {
            var target = new Target(x, y);

            if (IsOutOfPlatform(target, area))
                return "out of platform";

            if (IsTargetNotAvailable(target))
                return "clash";

            MarkLanding(target);

            return "ok for landing";
        }

        private void MarkLanding(Target target)
        {
            var extendedTarget = GetExtendedTarget(target);
            foreach (var item in extendedTarget)
            {
                AllocatedTargets.Add(item);
            }
        }

        /// <summary>
        /// adds surrounding points so that they can be marked as allocated as well
        /// inorder to obtain one unit seperation between the landings
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private List<Target> GetExtendedTarget(Target target)
        {
            var extendedList = new List<Target>();

            var targetXStart = target.X - 1;
            var targetXEnd = target.X + 1;
            var targetYStart = target.Y - 1;
            var targetYEnd = target.Y + 1;

            for (int x = targetXStart; x <= targetXEnd; x++)
            {
                for (int y = targetYStart; y <= targetYEnd; y++)
                {
                    extendedList.Add(new Target(x, y));
                }
            }

            return extendedList;
        }

        private bool IsTargetNotAvailable(Target target)
        {
            return AllocatedTargets.Any(t => t.X == target.X && t.Y == target.Y);
        }

        private bool IsOutOfPlatform(Target target, Area area)
        {
            return
                    target.X < area.Platform.X0
                 || target.X > area.Platform.X1
                 || target.Y < area.Platform.Y0
                 || target.Y > area.Platform.Y1;
        }
    }
}