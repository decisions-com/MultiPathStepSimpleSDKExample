using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using DecisionsFramework.Design.Flow;
using DecisionsFramework.Design.Flow.CoreSteps;
using DecisionsFramework.Design.Flow.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multipath
{
    [AutoRegisterStep("Do Numbers Divide Evenly", "Math")]
    [Writable]
    public class MyClass : BaseFlowAwareStep, ISyncStep, IDataConsumer, IDataProducer
    {
        private const string OUTCOME_EVEN = "EVEN";
        private const string OUTCOME_ODD = "ODD";

        private const string OUTPUT_VALUE = "value";

        private const string INPUT_VALUE = "InputValue";

        public override OutcomeScenarioData[] OutcomeScenarios
        {
            get
            {
                return new[] {
                    new OutcomeScenarioData(OUTCOME_EVEN, new DataDescription(typeof(string), OUTPUT_VALUE)),
                    new OutcomeScenarioData(OUTCOME_ODD, new DataDescription(typeof(string), OUTPUT_VALUE))
                };
            }
        }

        public ResultData Run(StepStartData data)
        {
            Dictionary<string, object> resultData = new Dictionary<string, object>();

            var value = (int)data.Data[INPUT_VALUE];

            if (value % 2 == 0)
            {
                //even
                resultData.Add(OUTPUT_VALUE, value);
                return new ResultData(OUTCOME_EVEN, resultData);
            }
            else
            {
                //Number is odd")

                resultData.Add(OUTPUT_VALUE, value);
                return new ResultData(OUTCOME_ODD, resultData);
           }
            throw new NotImplementedException();
        }

        public DataDescription[] InputData
        {
            get
            {
                return new DataDescription[]
                {
                    new DataDescription(typeof (int), INPUT_VALUE, false)
                    
                };
            }
        }
    }
}
