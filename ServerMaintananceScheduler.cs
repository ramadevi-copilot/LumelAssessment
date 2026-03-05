using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Backend.Assessment.Models;

using Newtonsoft.Json.Linq;

namespace Backend.Assessment
{
    internal class ServerMaintananceScheduler
    {
        public int GetCompatibleSubsets(string RequestArrayJson)
        {
            var result = JsonConvert.DeserializeObject<MaintananceRequest>(RequestArrayJson);

            var CompatibleValue = 0;
            for (int i = 0; i < result.Timeinterval.Length; i++)
            {
                for (int j = 0; j < result.Timeinterval.Length; j++)
                {
                    var compare1 = result.Timeinterval[i].True(result.Timeinterval[j]!.Value.IsArray);
                    var compare2 = result.Timeinterval[i].Equal("a", result.Timeinterval[j]!.Value.Values[0]);

                    if (compare1 != compare2)
                        CompatibleValue++;
                }

            }

            return CompatibleValue;
        }

    }
}
