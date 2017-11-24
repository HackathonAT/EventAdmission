using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FaceAPI_Services
{
    public class Trainer
    {
        private FaceServiceClient fsc;
        private string personGroupID = "6368468496874";

        public AzureHandler()
        {
            fsc = new FaceServiceClient(APIKeys.GetSubscriptionKey(), APIKeys.GetAPIURL());
        }

        public async void trainer()
        {
            await fsc.TrainPersonGroupAsync(personGroupID);

            TrainingStatus trainingStatus = null;
            while (true)
            {
                trainingStatus = await fsc.GetPersonGroupTrainingStatusAsync(personGroupID);

                if (trainingStatus.Status != Status.Running)
                {
                    break;
                }

                await Task.Delay(1000);
            }
        }
    }
}